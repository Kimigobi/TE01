

namespace TE01Project{
    class Program{
        static void Main(string[] args){
            Server newServer = new("localhost",4445);
            newServer.Start();
            
        }
    }
}