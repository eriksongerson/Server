namespace Server.Models
{
    public class Question
    {
        int id;
        int id_subject;
        int id_theme;
        string name;
        string firstOption;
        string secondOption;
        string thirdOption;
        string fourthOption;
        int rightOption;

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
        public string FirstOption
        {
            set { this.firstOption = value; }
            get { return this.firstOption; }
        }
        public string SecondOption
        {
            set { this.secondOption = value; }
            get { return this.secondOption; }
        }
        public string ThirdOption
        {
            set { this.thirdOption = value; }
            get { return this.thirdOption; }
        }
        public string FourthOption
        {
            set { this.fourthOption = value; }
            get { return this.fourthOption; }
        }
        public int RightOption
        {
            set { this.rightOption = value; }
            get { return this.rightOption; }
        }

        public Question() { }
        public Question(int id, int id_subject, int id_theme, string name, string firstOption, string secondOption, string thirdOption, string fourthOption, int rightOption)
        {
            this.id = id;
            this.id_subject = id_subject;
            this.id_theme = id_theme;
            this.name = name;
            this.firstOption = firstOption;
            this.secondOption = secondOption;
            this.thirdOption = thirdOption;
            this.fourthOption = fourthOption;
            this.rightOption = rightOption;
        }

    }
}
