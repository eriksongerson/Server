namespace Server
{
    public class Subject
    {
        int id;
        string name;

        public int Id
        {
            set { id = value; }
            get { return id; }
        }

        public string Name
        {
            set { name = value; }
            get { return name; }
        }

        public Subject() { }
        public Subject(string name)
        {
            this.name = name;
        }
        public Subject(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
    }
}
