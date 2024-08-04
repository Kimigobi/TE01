


namespace TE01_Client{
    class Program {
        
        static void Main (string[] args){
            Client client1 = new Client("localhost", 4445);
            string message = "";
            client1.Start();
            while (true){

                message = Console.ReadLine();
                client1.sendMessage(message);
            }
            
            
        }
    }


}
