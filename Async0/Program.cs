using System.Threading.Channels;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Text.Json;

var echoChannel = Channel.CreateUnbounded<String>();
await echoChannel.Writer.WriteAsync("bread");
echoChannel.Writer.Complete();

await foreach (var item in echoChannel.Reader.ReadAllAsync())
    Console.WriteLine(item);

Int32 port;
if(args.Length == 0) {
  port = 8080;
} else {
  port = Int32.Parse(args[0]);
}

var server = new TcpListener(port);
server.Start();

bool isPrime(Int128 number) {

  return false;
}

while (true)
{
  using TcpClient client = server.AcceptTcpClient();

  NetworkStream stream = client.GetStream();
  var recvBuffer = new Byte[4096];
  var sendBuffer = new Byte[4096];
  var malformed = "{}";
  var data = "";
  int i;
  
  while ((i = stream.Read(recvBuffer, 0, recvBuffer.Length)) != 0)
  {
    var recvString = System.Text.Encoding.ASCII.GetString(recvBuffer, 0, i);
    var recvData = Json.Decode(recvString);
    try {
       
    } catch {
      sendBuffer = System.Text.Encoding.ASCII.GetBytes(malformed);
    }
    bool myIsPrime = isPrime(recvData.number);
    if((recvData.method != "isPrime") || myIsPrime) {
      var json = Json.Encode(new { method = "isPrime", prime = myIsPrime });
      sendBuffer = System.Text.Encoding.ASCII.GetBytes(json);
    } else {
      sendBuffer = System.Text.Encoding.ASCII.GetBytes(malformed);
    }
    sendBuffer = System.Text.Encoding.ASCII.GetBytes(recvData);
    stream.Write(sendBuffer, 0, sendBuffer.Length);
  }
}
