using System.Collections.Generic;

namespace Server.Models
{
    // Класс вопроса
    public class Question
    {
        int id; // id вопроса
        int id_subject; // id предмета
        int id_theme; // id темы
        string name; // Сам вопрос
        List<Option> options; // Список вариантов ответа
        Type type = Type.single; // Тип вопроса
        // свойства для полей объекта
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
        // Конструктор
        public Question() { }
    }
}
