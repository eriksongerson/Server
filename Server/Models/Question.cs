using System.Collections.Generic;

namespace Server.Models
{
    public class Question
    {
        int id;
        int id_subject;
        int id_theme;
        string name;
        List<Option> options;
        Type type = Type.single;

        public int Id
        {
            set { this.id = value; }
            get { return this.id; }
        }
        public int Id_subject
        {
            set { this.id_subject = value; }
            get { return this.id_subject; }
        }
        public int Id_theme
        {
            set { this.id_theme = value; }
            get { return this.id_theme; }
        }
        public string Name
        {
            set { this.name = value; }
            get { return this.name; }
        }
        public List<Option> Options
        {
            set { this.options = value; }
            get { return this.options; }
        }
        public Type Type
        {
            set { this.type = value; }
            get { return this.type; }
        }

        public Question() { }
        public Question(int id, int id_subject, int id_theme, string name, List<Option> options, Type type)
        {
            this.id = id;
            this.id_subject = id_subject;
            this.id_theme = id_theme;
            this.name = name;
            this.options = options;
            this.type = type;
        }

    }
}
