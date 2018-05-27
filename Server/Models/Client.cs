namespace Server.Models
{
    public class Client
    {
        public string ip;
        public string pc;
        public string surname;
        public string name;
        public Group group;

        public void Disconnect()
        {
            // TODO: клиент должен как-то узнать, что он отключен
        }
    }
}
