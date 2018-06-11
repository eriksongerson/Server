namespace Server.Models
{
    // Класс варианта ответа
    public class Option
    {
        public int id; // id варианта ответа 
        public int id_question; // id вопроса, к которому прикреплен вариант ответа
        public string option; // Текст варианта ответа
        public bool isRight; // Правильный ли вариант ответа
        // Конструкторы:
        public Option(){ }
        public Option(string option, bool isRight)
        {
            this.option = option;
            this.isRight = isRight;
        }
        // для отображения поля option в перечислениях
        public static implicit operator string(Option v) => v.option;
    }
}
