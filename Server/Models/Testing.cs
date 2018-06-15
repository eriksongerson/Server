using System.Collections.Generic;
namespace Server.Models {
    // класс Testing содержит текущую информацию о тестирующемся
    public class Testing {
        private Client client; // Информация о клиенте
        private List<Answer> answers; // Все ответы на вопросы, которые прошёл студент
        private Subject subject; // Предмет тестирования
        private Theme theme; // Тема тестирования
        private int countOfQuestions; // Количество вопросов в тесте
        // Свойства полей:
        public Client Client {
            set => client = value;
            get => client;
        }
        public List<Answer> Answers {
            set => answers = value;
            get => answers; 
        }
        public Subject Subject {
            set => subject = value;
            get => subject;
        }
        public Theme Theme {
            set => theme = value;
            get => theme;
        }
        public int CountOfQuestions {
            set => countOfQuestions = value;
            get => countOfQuestions;
        }
    }
}
