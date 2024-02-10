using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Logging;

class Program {
    private static IPAddress localhost = IPAddress.Parse("127.0.0.1"); 

    static void Main(string[] args)
    private static ILogger logger;
    {
        // Display the number of command line arguments.
        Int32 port = Int32.Parse(args[1]) ?? 443;
        using ILoggerFactory loggingFactory = LoggerFactory.Create(builder => builder.AddConsole());
        logger = loggingFactory.CreateLogger("ProtoHackers/Solve1");
        logger.LogInformation(args[0]);
        _ = typeof(Program).GetMethod("Solve" + args[0]).Invoke(null, []);
    }

    async public static Task Solve0(Int32 port = 1025)
    {
        TcpListener server = null;
        logger.LogInformation("Connected. ");
        try
        {
            server.Start();
            Byte[] bytes = new Byte[4096];
            String? data = null;
            while(true) {
                using TcpClient client = server.AcceptTcpClient();
                data = null;
                NetworkStream stream = client.GetStream();
                int i ;
                while((i = stream.Read(bytes, 0, bytes.Length))!=0)
            logger.LogInformation($"Created Tcp Server on {localhost.ToString()}:{port}");
            while (true)
            {
                logger.LogInformation("Waiting for connection. ");
                using TcpClient client = await server.AcceptTcpClientAsync();
                {
                    data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);
                    stream.Write(msg, 0, msg.Length);
                }
                        logger.LogInformation($"Recv: {data}");
                        logger.LogInformation($"Send: {data}");
            }
        }
        catch(SocketException e)
        {
            logger.LogCritical($"{e}");
        }
        finally
        {
            server.Stop();
        }
    }
    public static void Solve1(Int32 port)
    {
        logger.LogInformation("Solve1");
        TcpListener server = null;
        try {
            server = new TcpListener(port);
            server.Start();
            Byte[] bytes = new Byte[4096];
            String? data = null;
            while(true) {
                using TcpClient client = server.AcceptTcpClient();
                data = null;
                NetworkStream stream = client.GetStream();
                int i ;
                while((i = stream.Read(bytes, 0, bytes.Length))!=0)
                {
                    data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);
                    var datas = data.Split ("\n");
                    datas.ToList().ForEach (data => {
                        try {
                            json = JsonDocument.Parse(data);
                            bool isPrime = json.isPrime;
                            Numeric number = Numeric.Parse(json.number);
                            return isPrime && isPrime(number));
                        } catch {}
                        
                    });
                    stream.Write(msg, 0, msg.Length);
                            logger.LogCritical("SocketException: {0}", e);
                }
            }
        }
        catch(SocketException e)
        {
        }
        finally
        {
            server.Stop();
        }
    }
}
