using System.Collections.Generic;

namespace Server.Models
{
    //Объект ответа
    public class Answer
    {   
        public Question question; // содержит сам вопрос
        public List<Option> choosen; // и выбранные варианты ответа студентом
    }
}
