namespace Server.Models
{
    // Объект группы
    public class Group
    {
        private int id; // id группы
        private string name; // название группы
        // сеттеры и геттеры для полей
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
