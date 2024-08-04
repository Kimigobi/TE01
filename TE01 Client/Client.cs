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

        public void sendMessage(string message){
            byte[] byteMessage =Encoding.ASCII.GetBytes(message);

            socketClient.Send(byteMessage);
            Console.WriteLine("Mensaje Enviado");
        }


        public string receiveMessage(){

            byte[] buffer = new byte[1024];
            socketClient.Receive(buffer);

             return byteToString(buffer);

        }

        
        public string byteToString(byte[] bufferReceived){
            string message;
            int endIndex;

            message = Encoding.ASCII.GetString(bufferReceived);
            endIndex = message.IndexOf('\0');
            if (endIndex > 0){
                message = message.Substring(0,endIndex);
            }
            return message;
        }

    }
}