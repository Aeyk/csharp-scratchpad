using System.Net;
using System.Net.Sockets;
using System.Text.Json;
using Microsoft.Extensions.Logging;

class Program
{
    private static IPAddress localhost = IPAddress.Parse("127.0.0.1");
    private static Int32 port = 1045;
    private static ILogger logger;
    static void Main(string[] args)
    {
        if (args is null)
        {
            throw new ArgumentNullException(nameof(args));
        }

        Int32 solution = 1;
        TcpListener server = new TcpListener(localhost, port);
        using ILoggerFactory loggingFactory = LoggerFactory.Create(builder => builder.AddConsole());
        logger = loggingFactory.CreateLogger("ProtoHackers/Solve1");
        string index = solution.ToString();
        _ = typeof(Program).GetMethod(name: "Solve" + index)
                           .Invoke(null, [server, 1045]);
    }

    async public static Task Solve0(TcpListener server, Int32 port = 1025)
    {
        logger.LogInformation("Connected. ");
        try
        {
            server.Start();
            logger.LogInformation($"Created Tcp Server on {localhost.ToString()}:{port}");
            while (true)
            {
                logger.LogInformation("Waiting for connection. ");
                using TcpClient client = await server.AcceptTcpClientAsync();
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
            server.Stop();
        }
    }
    public static bool isPrime(Decimal number)
    {
        return false;
    }

    public static void Solve1(TcpListener server, Int32 port)
    {
        logger.LogInformation("Solve1");
        try
        {
            server = new TcpListener(localhost, port);
            server.Start();
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
                    var datas = data.Split("\n");
                    datas.ToList().ForEach(data =>
                    {
                        var json = JsonDocument.Parse(data).RootElement;
                        bool isPrime = json.GetProperty("isPrime").GetBoolean();
                        decimal number = json.GetProperty("number").GetDecimal();
                        if (isPrime
                            && Program.isPrime(number))
                        {
                            // TODO send back message
                        }
                        else
                        {
                            // TODO send back message
                        }
                        stream.Write(System.Text.Encoding.ASCII.GetBytes(data), 0, System.Text.Encoding.ASCII.GetBytes(data).Length);
                    });
                }
            }
        }
        catch (SocketException e)
        {
            logger.LogCritical("SocketException: {0}", e);
        }
        finally
        {
            server.Stop();
        }
    }
}

