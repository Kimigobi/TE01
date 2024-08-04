using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;


namespace TE01Project {
    class Server {
        IPHostEntry host;
        IPAddress ipAddress;
        IPEndPoint endPoint;

        Socket socketServer;
        Socket socketClient;
        public Server(string ip, int port){
            host = Dns.GetHostEntry(ip);
            ipAddress = host.AddressList[0];
            endPoint = new IPEndPoint(ipAddress,port);

            socketServer = new Socket (ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            socketServer.Bind(endPoint);
            socketServer.Listen(10);
        }

        public void Start(){

            byte[] buffer = new byte[1024];
            string message;
            socketClient = socketServer.Accept();

            while(true){
               socketClient.Receive(buffer);
                message = Encoding.ASCII.GetString(buffer); 
                Console.WriteLine("Se recibio el mensaje: " + message);     
            }
            
            

        }

    }
}
