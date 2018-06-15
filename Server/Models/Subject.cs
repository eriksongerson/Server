namespace Server.Models {
    // Класс предмета
    public class Subject {
        int id; // id предмета
        string name; // название предмета
        // Свойства для полей предмета:
        public int Id {
            set { id = value; }
            get { return id; }
        }
        public string Name {
            set { name = value; }
            get { return name; }
        }
        //Конструктор:
        public Subject() { }
    }
}
