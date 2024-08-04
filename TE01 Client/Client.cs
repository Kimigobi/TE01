using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TE01_Client{


    class Client{   
        IPHostEntry host;
        IPAddress ipAddress;
        IPEndPoint endPoint;
        Socket socketClient;
        public Client(string ip, int port){
            host = Dns.GetHostEntry(ip);
            ipAddress = host.AddressList[0];
            endPoint = new IPEndPoint(ipAddress,port);

            socketClient = new Socket (ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            
        }

        public void Start() {
            socketClient.Connect(endPoint);
        }

        public void Send(string message){
            byte[] byteMessage =Encoding.ASCII.GetBytes(message);

            socketClient.Send(byteMessage);
            Console.WriteLine("Mensaje Enviado");
        }

    }
}