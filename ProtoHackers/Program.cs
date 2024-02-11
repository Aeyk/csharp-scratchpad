using System.Net;
using System.Net.Sockets;
using System.Text.Json;
using Microsoft.Extensions.Logging;

namespace ProtoHacker
{
    class Program
    {
        private static IPAddress localhost = IPAddress.Parse("0.0.0.0");
        private static Int32 port = 1045;
        private static ILogger logger;
        async static Task Main(string[] args)
        {
            using ILoggerFactory loggingFactory = LoggerFactory.Create(builder => builder.AddConsole());
            logger = loggingFactory.CreateLogger("ProtoHackers");
            if (args is null)
            {
                throw new ArgumentNullException(nameof(args));
            }
            logger.LogInformation(args.ToString());
            String index = "1";
            if (args.Length >= 1 && null != args[0])
            {
                index = Int32.Parse(args[0]).ToString();
            }
            TcpListener server = new TcpListener(localhost, port);
            // server.Start();
            await (Task)typeof(Program).GetMethod($"Solve{index}")
                                       .Invoke(null, [logger, server, port]);
        }

        async public static Task Solve0(ILogger logger, TcpListener server, Int32 port = 1025)
        {
            logger.LogInformation("Connected. ");
            try
            {
                logger.LogInformation($"Created Tcp Server on {localhost.ToString()}:{port}");
                while (true)
                {
                    logger.LogInformation("Waiting for connection. ");
                    using TcpClient client = server.AcceptTcpClient();
                    await Task.Run(() =>
                    {
                        Byte[] buffer = new Byte[4096];
                        String data = null;
                        data = null;
                        NetworkStream stream = client.GetStream();
                        int i;
                        while ((i = stream.Read(buffer, 0, buffer.Length)) != 0)
                        {
                            data = System.Text.Encoding.ASCII.GetString(buffer, 0, i);
                            logger.LogInformation($"Recv: {data}");
                            byte[] returnMessage = System.Text.Encoding.ASCII.GetBytes(data);
                            stream.Write(returnMessage, 0, returnMessage.Length);
                            logger.LogInformation($"Send: {data}");
                        }
                    });
                }
            }
            catch (SocketException e)
            {
                logger.LogCritical($"{e}");
            }
            finally
            {
                if (server != null)
                {
                    server.Stop();
                }
            }
        }
        public static bool isPrime(Decimal number)
        {
            return false;
        }

        public static void Solve1(ILogger logger, TcpListener server, Int32 port)
        {
            logger.LogInformation("Solve1");
            try
            {
                server = new TcpListener(localhost, port);
                server.Start();
                var malformedResponse = System.Text.Encoding.ASCII.GetBytes("{}");
                while (true)
                {
                    using TcpClient client = server.AcceptTcpClient();
                    String? data = null;
                    NetworkStream stream = client.GetStream();
                    int i;
                    Byte[] bytes = new Byte[4096];
                    while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                        logger.LogInformation(data);
                        JsonElement json;
                        try
                        {
                            json = JsonDocument.Parse(data).RootElement;
                            bool isPrime = "isPrime" == json.GetProperty("method").GetString();
                            decimal number = json.GetProperty("number").GetDecimal();
                            String sendMessage;
                            if (isPrime
                                && Program.isPrime(number))
                            {
                                sendMessage = """
                            {"method": "isPrime",
                                "prime": "true"}
                            """;
                                stream.Write(System.Text.Encoding.ASCII.GetBytes(sendMessage), 0, System.Text.Encoding.ASCII.GetBytes(sendMessage).Length);
                            }
                            else
                            {
                                sendMessage = """
                            {"method": "isPrime",
                                "prime": "false"}
                            """;
                                stream.Write(System.Text.Encoding.ASCII.GetBytes(sendMessage), 0, System.Text.Encoding.ASCII.GetBytes(sendMessage).Length);
                            }
                            logger.LogDebug(sendMessage);
                        }
                        catch (System.Collections.Generic.KeyNotFoundException e)
                        {
                            logger.LogError(e.Message);
                            stream.Write(malformedResponse, 0, malformedResponse.Length);
                            server.Stop();
                        }
                        catch (System.Text.Json.JsonException e)
                        {
                            logger.LogError($"{e.GetType()}{e.Message}");
                            stream.Write(malformedResponse, 0, malformedResponse.Length);
                            server.Stop();
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
        IStream GetStream();
    }

    public interface IListener : IDisposable
    {
        IStream GetStream(byte[] buffer, int offset, int count);
        public IClient AcceptClient();
        public void Start();
        public void Stop();
    }

}

namespace ProtoHackerTests
{
    using ProtoHacker;
    using NUnit.Framework;
    using FakeItEasy;

    class MockStream : IStream, IDisposable
    {
        private bool disposedValue;
        private byte[] _buffer;

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
              if(disposing) {
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
        private IPAddress localhost;
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

        public IStream GetStream(byte[] buffer, int offset, int count)
        {
            return this.stream;
        }

        public void Start() {}
        public void Stop() {}

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
        private MockStream stream;

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
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~MockTcpClient()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        IStream IClient.GetStream()
        {
            return (IStream)this.stream;
        }
        public MockStream GetStream() {
          return this.stream;
        }
    }

    [TestFixture]
    public class ProtoHackerTests
    {
        private MockTcpListener server;
        private MockTcpClient client;
        private Int32 port;
        private Byte[] buffer;
        private MockStream stream;
        private ILogger logger;
        private IPAddress localhost;

        [SetUp]
        async public Task Setup()
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
    }
}
