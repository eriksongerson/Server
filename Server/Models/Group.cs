namespace Server.Models
{
    public class Group
    {

        private int id;
        private string name;

        public int Id
        {
            set => id = value;
            get => id;
        }

        public string Name
        {
            set => name = value;
            get => name;
        }

    }
}
