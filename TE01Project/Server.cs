using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;



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
            Thread newThread;

            while (true){

                Console.WriteLine("Esperando conexiones...");

                socketClient = socketServer.Accept();
                newThread = new Thread(clientConnection);
                newThread.Start(socketClient);
                Console.WriteLine("Se ha conectado  un nuevo cliente");

            }
            

        }

        public void clientConnection (object receivedObject){
            Socket socketClient =(Socket)receivedObject;
            byte[] buffer;
            string message;
            int endPoint;
            

            while(true){
                buffer =  new byte[1024];
               socketClient.Receive(buffer);
               
                message = byteToString(buffer);
                
                Console.WriteLine("Se recibio el mensaje: " + message); 
                Console.Out.Flush();
            }

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
