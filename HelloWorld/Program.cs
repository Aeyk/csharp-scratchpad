using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;

class Program
{
    private static void Main(string[] args)
    {
        // See https://aka.ms/new-console-template for more information
        Console.WriteLine("Hello, World!");
        Console.Clear();
        var localhost = IPAddress.Parse("127.0.0.1");
        var port = (new Random()).Next(49152, 65535);
        var server = new TcpListener(localhost, port);
        Byte[] buffer = new Byte[1024 * 8];
				String data = null;
        server.Start();
        Console.WriteLine($"Listening on localhost:{port}. ");
        while (true)
        {
            Console.WriteLine("Waiting for connection.");
            using TcpClient client = server.AcceptTcpClient();
            Console.WriteLine("Connected!");
						data = null;
            var i = 0;
            NetworkStream stream = client.GetStream();
            while ((i = stream.Read(buffer, 0, buffer.Length)) != 0) {
                data = System.Text.Encoding.ASCII.GetString(buffer, 0, i);
								String response = data switch {
										"ping" => "pong",
                    _      => ""
								};
                Byte[] responseBuffer = System.Text.Encoding.ASCII.GetBytes(response);
                if(response.Equals("exit")) { // TODO (Malik): why not matching on exit
                    server.Stop();
                    Environment.Exit(0);
                }
							  if(response != null) {
										stream.Write(responseBuffer, 0, responseBuffer.Length);
								}
						}
        }
    }
}
