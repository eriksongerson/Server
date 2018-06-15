namespace Server.Models {
    // Класс темы
    public class Theme {
        int id; // id темы
        int id_subject; // id предмета, к которому привязана тема
        string name; // Название темы
        // Свойства полей:
        public int Id {
            set => this.id = value;
            get => this.id;  
        }
        public int SubjectId {
            set => this.id_subject = value;
            get => this.id_subject;
        }
        public string Name {
            set => this.name = value; 
            get => this.name; 
        }
        // Конструктор:
        public Theme() { }
    }
}
