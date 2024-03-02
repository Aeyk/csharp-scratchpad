﻿using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Text.Json;
using Microsoft.Extensions.Logging;

namespace ProtoHacker
{
  public static class StringExt
  {
    public static string Truncate(this string s, int maxLength)
    {
      return s != null && s.Length > maxLength ? s.Substring(0, maxLength) : s;
    }
  }
  interface IProtoHackersService
  {
    public void Process(Stream stream);
  }
  public abstract class ProtoHackersService : IProtoHackersService
  {
    protected TcpClient client;
    public TcpListener server;
    protected ILogger logger;

    public bool HasBinaryContent(string content)
    {
      return content.Any(ch => char.IsControl(ch) && ch != '\r' && ch != '\n');
    }
    public ProtoHackersService(
       ILogger _logger, TcpListener _server)
    {
      this.logger = _logger;
      this.server = _server;
    }
    public void Process(Stream stream)
    {
      throw new NotImplementedException();
    }
  }
  public class SmokeTestService : ProtoHackersService
  {
    private ILogger logger;
    private Stream stream;
    private TcpClient client;
    public SmokeTestService(
      ILogger _logger, TcpListener _server) :
        base(_logger, _server)
    {
      logger = _logger;
      this.server = _server;
    }
    public void Process()
    {
      int i = 0;
      string data;
      Byte[] buffer = new Byte[65535];
      server.Start();
      using(client = server.AcceptTcpClient())
      using(stream = client.GetStream()) {
        logger.LogInformation("Solve0");
        while ((i = stream.Read(buffer, 0, buffer.Length)) != 0)
        {
          data = System.Text.Encoding.ASCII.GetString(buffer, 0, i);
          logger.LogInformation($"Recv # of bytes: {data.Length}");
          if (!HasBinaryContent(data))
          {
            logger.LogInformation($"Recv: {data.Truncate(30)}... ");
          }
          else
          {
            logger.LogInformation($"Recv: [ BinaryData omitted ]");
          }

          byte[] returnMessage = System.Text.Encoding.ASCII.GetBytes(data);
          stream.Write(buffer, 0, data.Length);

          if (!HasBinaryContent(data))
          {
            logger.LogInformation($"Send: {data.Truncate(30)}... ");
          }
          else
          {
            logger.LogInformation($"Send: [ BinaryData omitted ]");
          }
        }
      }
      stream.Close();
      client.Close();
    }
  }
  public class PrimeTimeService : ProtoHackersService, IDisposable
  {
    private ILogger logger;
    private Stream stream;
    private TcpClient client;
    public PrimeTimeService(
      ILogger _logger, TcpListener _server) :
        base(_logger, _server)
    {
      this.logger = _logger;
      this.server = _server;
      server.Start();
    }
    private static bool IsPrime(Decimal n)
    {
      if (n <= 1) return false;
      for (int i = 2; i * i <= n; i++)
        if (n % i == 0) return false;
      return true;
    }
    public static string CreateIsPrimeMessage(Decimal number)
    {
      var message = """{"method": "isPrime", "prime": """ + (IsPrime(number) ? "true" : "false") + "}\n";
      return message;
    }
    public void Dispose()
    {
      client.Close();
      server.Stop();
    }
    public static string ParseIsPrimeMessage(string message)
    {
      string result;
      JsonElement json = JsonDocument.Parse(message).RootElement;
      bool methodIsPrime = "isPrime" == json.GetProperty("method").GetString();
      decimal number = json.GetProperty("number").GetDecimal();
      if (methodIsPrime)
        return CreateIsPrimeMessage(number);
      else
        return "{}";
    }

    public void Process()
    {
      logger.LogInformation("Solve1");
      Byte[] buffer = new Byte[65535];
      String sendMessage = "";
      var malformedResponse = "{}";
      try
      {
        server.Start();
        using(TcpClient client = server.AcceptTcpClient())
        using(NetworkStream stream = client.GetStream())
        using(StreamReader reader = new(stream))
        using(StreamWriter writer = new(stream))
        {
          while (client.Connected)
          {
            var data = reader.ReadLine();
            logger.LogInformation($"Recv: {data}");
            try
            {
              if (null == data)
                break;

              logger.LogDebug($"Processing: {data}\nSize: {data.Length}");
              logger.LogDebug($"Send: {sendMessage}");
              sendMessage = ParseIsPrimeMessage(data);

              writer.Write(sendMessage);
              writer.Flush();
            }
            catch (System.Collections.Generic.KeyNotFoundException e)
            {
              logger.LogError(e.Message);
              logger.LogInformation($"Send: {malformedResponse}");
              writer.Write(malformedResponse);
              client.Close();
              break;
            }
            catch (System.Text.Json.JsonException e)
            {
              logger.LogError($"{e.GetType()}: {e.Message}");
              logger.LogInformation($"Send: {malformedResponse}");
              writer.Write(malformedResponse);
              client.Close();
              break;
            }
          }
        }
      }
      catch (SocketException e)
      {
        logger.LogCritical($"SocketException: {e.Message}");
      }
      finally
      {
        stream.Close();
        client.Close();
        if (server != null)
        {
          server.Stop();
        }
      }
    }
  }
  class Program
  {
    private static IPAddress localhost = IPAddress.Parse("0.0.0.0");
    private static Int32 port = 1045;
    private static ILogger? logger;
    async static Task<int> Main(string[] args)
    {
      using ILoggerFactory loggingFactory = LoggerFactory.Create(builder => builder.AddSimpleConsole(options =>{
        options.SingleLine = true;
      }));
      logger = loggingFactory.CreateLogger("ProtoHackers");
      if (args is null)
      {
        throw new ArgumentNullException(nameof(args));
      }
      String index = "1";
      if (args.Length >= 1 && null != args[0])
      {
        index = Int32.Parse(args[0]).ToString();
        logger.LogDebug($"Number of arguments: {args.Length}, solution index: {index}, args[0]: {args[0]}, port: {port}");
      }
      TcpListener server = new TcpListener(localhost, port);
      try
      {
        await (Task)typeof(Program)?.GetMethod($"Solve{index}")
                                   ?.Invoke(null, [logger, server, port]);
      }
      catch (Exception e)
      {
        logger.LogCritical(e.GetBaseException().Message);
      }

      return 0;
    }
    public static bool HasBinaryContent(string content)
    {
      return content.Any(ch => char.IsControl(ch) && ch != '\r' && ch != '\n');
    }
    async public static Task Solve0(ILogger logger, TcpListener server, Int32 port = 1045)
    {
      var es = new SmokeTestService(logger, server);
      while (true)
      {
        es.Process();
      }
    }

    public static void Solve1(ILogger logger, TcpListener server, Int32 port)
    {
      var es = new PrimeTimeService(logger, server);
      while(true) {
        es.Process();
      }
    }

    public record InsertBankMessage(
      Int32 Timestamp,
      Int32 Price
    );
    public record QueryBankMessage(
      Int32 MinTime,
      Int32 MaxTime
    );

    public static void Solve2(ILogger logger, TcpListener server, Int32 port)
    {
      var bankRecords = new ArrayList();
      bool listen = true;
      logger.LogInformation("Solve2");
      try
      {
        server.Start();
        while (listen)
        {
          using TcpClient client = server.AcceptTcpClient();
          var stream = client.GetStream();
          int i;
          int count = 9;
          Byte[] buffer = new Byte[count]; // TODO handle incorrectly sized messagesd
          while (count != 0 && listen && (i = stream.Read(buffer, 0, buffer.Length)) != 0)
          {
            count--;
            if (count == 0)
            {
              count = 9;

              logger.LogInformation($"buffer[0]'s type: {buffer[0].GetType()}, buffer[0]'s value: {(char)buffer[0]}.");
              if (0 == buffer[0].CompareTo((Byte)'I'))
              {
                InsertBankMessage message = new(BitConverter.ToInt32(buffer, 1), BitConverter.ToInt32(buffer, 5));
                bankRecords.Add(message);
              }
              else if (0 == buffer[0].CompareTo((Byte)'Q'))
              {
                QueryBankMessage message = new(BitConverter.ToInt32(buffer, 1), BitConverter.ToInt32(buffer, 5));
                var query = from InsertBankMessage m in bankRecords
                            where m.Timestamp >= message.MinTime && m.Timestamp <= message.MaxTime
                            select m;
                var average = BitConverter.GetBytes(query.Average(q => q.Price));
              }
              else
              {
                // TODO handle invalid message type
              }
            }
          }
        }
      }
      catch (SocketException e)
      {
        logger.LogCritical("SocketException: {0}", e);
      }
      finally
      {
        if (server != null)
        {
          server.Stop();
        }
      }
    }
  }

  public interface IStream : IDisposable
  {
    void Write(byte[] buffer, int offset, int count);
    int Read(byte[] buffer, int offset, int count);
  }

  public interface IClient : IDisposable
  {
    IStream Stream { get; }
  }

  public interface IListener : IDisposable
  {
    public IClient AcceptClient();
    public void Start();
    public void Stop();
  }

}

namespace ProtoHackerTests
{
  using ProtoHacker;
  using NUnit.Framework;

  class MockStream : IStream, IDisposable
  {
    private bool disposedValue;
    private byte[]? _buffer;

    public MockStream()
    {
      this._buffer = new byte[4096];
    }

    public int Read(byte[] buffer, int offset, int count)
    {
      Array.Copy(this._buffer, offset, buffer, offset, count);
      return 0;
    }

    public void Write(byte[] buffer, int offset, int count)
    {
      Array.Copy(buffer, offset, this._buffer, offset, count);
    }

    protected virtual void Dispose(bool disposing)
    {
      if (!disposedValue)
      {
        if (disposing)
        {
          _buffer = null;
        }
        disposedValue = true;
      }
    }

    public void Dispose()
    {
      Dispose(disposing: true);
      GC.SuppressFinalize(this);
    }
  }

  class MockTcpListener : IListener, IDisposable
  {
    private bool disposedValue;
    private IPAddress? localhost;
    private int port;
    private IStream stream;

    public MockTcpListener(IPAddress localhost, int port)
    {
      this.localhost = localhost;
      this.port = port;
      this.stream = new MockStream();
    }

    public IClient AcceptClient()
    {
      return new MockTcpClient();
    }

    public void Start() { }
    public void Stop() { }

    protected virtual void Dispose(bool disposing)
    {
      if (!disposedValue)
      {
        if (disposing)
        {
          localhost = null;
        }
        disposedValue = true;
      }
    }

    public void Dispose()
    {
      Dispose(disposing: true);
      GC.SuppressFinalize(this);
    }
  }

  class MockTcpClient : IClient, IDisposable
  {
    private bool disposedValue;
    private MockStream? stream;

    public MockTcpClient()
    {
      this.stream = new MockStream();
    }

    protected virtual void Dispose(bool disposing)
    {
      if (!disposedValue)
      {
        if (disposing)
        {
          this.stream = null;
        }
        disposedValue = true;
      }
    }

    public void Dispose()
    {
      Dispose(disposing: true);
      GC.SuppressFinalize(this);
    }

    IStream? IClient.Stream => this.stream
                               as IStream;

    public MockStream GetStream() => this.stream;

  }

  [TestFixture]
  public class ProtoHackerTests
  {
    private MockTcpListener? server; // TODO processing instead of just echoing
    private MockTcpClient? client;
    private Int32 port;
    private Byte[]? buffer;
    private MockStream? stream;
    private ILogger? logger;
    private IPAddress? localhost;

    [SetUp]
    public void Setup()
    {
      using ILoggerFactory loggingFactory = LoggerFactory.Create(builder => builder.AddConsole());
      logger = loggingFactory.CreateLogger($"ProtoHackers/TestSetupSolve");
      localhost = IPAddress.Parse("127.0.0.1");
      port = 1045;
      server = new MockTcpListener(localhost, port);
      server.Start();
      client = (MockTcpClient)server.AcceptClient();
      stream = client.GetStream();
    }

    [TearDown]
    public void Cleanup()
    {
      stream.Dispose();
      client.Dispose();
      server.Dispose();
    }

    [Test]
    public void TestSolution0()
    {
      var expected = System.Text.Encoding.ASCII.GetBytes("Hello World");
      byte[] actual = new byte[expected.Length];
      stream.Write(expected, 0, expected.Length);
      int i;
      while ((i = stream.Read(actual, 0, actual.Length)) != 0)
      {
        stream.Read(actual, 0, actual.Length);
      }
      Assert.That(expected, Is.EqualTo(actual));
    }

    [Test]
    public void TestSolution1()
    {
      // TODO test sending multiple newline delimited messages at once, conforming (dotProduct) malformed
      string[] primeCases = [
         //"""{"method": "isPrime", "number": 1}""",
        """{"method": "isPrime", "number": 11621}""",
        """{"method": "isPrime", "number": 33721}""",
        """{"method": "isPrime", "number": 55511}""",
        """{"method": "isPrime", "number": 63281}""",
        """{"method": "isPrime", "number": 18517}""",
        """{"method": "isPrime", "number": 3583}""",
        """{"method": "isPrime", "number": 16703}""",
        """{"method": "isPrime", "number": 46687}""",
        """{"method": "isPrime", "number": 24971}"""
      ];
      string[] compositeCases = [
        """{"method": "isPrime", "number": 6}""",
        """{"method": "isPrime", "number": 10}""",
        """{"method": "isPrime", "number": 14}""",
        """{"method": "isPrime", "number": 15}""",
        """{"method": "isPrime", "number": 21}""",
        """{"method": "isPrime", "number": 22}""",
        """{"method": "isPrime", "number": 26}""",
        """{"method": "isPrime", "number": 33}"""
      ];

      var encodedPrimeCases = primeCases.Select(c => System.Text.Encoding.ASCII.GetBytes(c + "\n")).ToArray();
      var encodedCompositeCases = compositeCases.Select(c => System.Text.Encoding.ASCII.GetBytes(c + "\n")).ToArray();

      var isPrimeExpected = """{"method": "isPrime", "prime": true}"""; // System.Text.Encoding.ASCII.GetBytes();
      var isCompositeExpected = """{"method": "isPrime", "prime": false}"""; // System.Text.Encoding.ASCII.GetBytes();
      var malformedExpected = """{}"""; // System.Text.Encoding.ASCII.GetBytes();

      Array.ForEach(primeCases, expected =>
      {
        Assert.That(PrimeTimeService.ParseIsPrimeMessage(expected), Is.EqualTo(isPrimeExpected +"\n"));
      });

      Array.ForEach(compositeCases, expected =>
      {
        Assert.That(PrimeTimeService.ParseIsPrimeMessage(expected), Is.EqualTo(isCompositeExpected+"\n"));
      });
    }
  }
}
