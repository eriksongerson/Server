namespace Server
{
    public class Theme
    {
        int id;
        int id_subject;
        string name;

        public int Id
        {
            set { this.id = value; }
            get { return this.id; }
        }

        public int SubjectId
        {
            set { this.id_subject = value; }
            get { return this.id_subject; }
        }
        public string Name
        {
            set { this.name = value; }
            get { return this.name; }
        }

        public Theme() { }
        public Theme(int id, int id_subject, string name)
        {
            this.id = id;
            this.id_subject = id_subject;
            this.name = name;
        }

    }
}
