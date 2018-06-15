using System.Collections.Generic;
namespace Server.Models {
    //Объект ответа
    public class Answer {
        // содержит сам вопрос
        public Question question;
        // и выбранные варианты ответа студентом
        public List<Option> choosen; 
    }
}
