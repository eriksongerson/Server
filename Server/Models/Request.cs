using System.Collections.Generic;
using Newtonsoft.Json;
using Server.Helpers;
namespace Server.Models {
    // Вспомогательный класс, содержащий предмет и тему.
    // Необходим, потому что проще передавать информацию в одном объекте, а не в нескольких
    class Discipline {
        private Subject _subject;
        private Theme _theme;
        public Subject Subject { get => _subject; set => _subject = value; }
        public Theme Theme { get => _theme; set => _theme = value; }
    }
    // Аналогичный вспомогательный класс, содержащий помимо предмета и темы ещё и оценку
    class DisciplineWithMark {
        private Subject _subject;
        private Theme _theme;
        private int _mark;
        public Subject Subject { get => _subject; set => _subject = value; }
        public Theme Theme { get => _theme; set => _theme = value; }
        public int Mark { get => _mark; set => _mark = value; }
    }
    // Класс запроса
    public class Request {
        public string request; // Запрос
        public Client client; // Клиент
        public string body; // Тело запроса
        // Функция обработки запроса
        public string Handle() {
            switch (request) {
                case "connect": {
                        // Запрос на соединение
                        ClientHandler.addClient(client); // Добавление клиента
                        // Создание ответа
                        Response response = new Response() {
                            response = request,
                            body = JsonConvert.SerializeObject("OK", Formatting.Indented),
                        };
                        // Конвертация объекта ответа в строку и её возврат
                        return JsonConvert.SerializeObject(response, Formatting.Indented);
                    }
                case "disconnect": {
                        // Запрос на отсоединение
                        ClientHandler.removeClient(client); // удаление клиента
                        // Создание ответа
                        Response response = new Response() {
                            response = request,
                            body = JsonConvert.SerializeObject("OK", Formatting.Indented),
                        };
                        // Конвертация объекта ответа в строку и её возврат
                        return JsonConvert.SerializeObject(response, Formatting.Indented);;
                    }
                case "getSubjects": {
                        // Запрос на получение списка предметов
                        List<Subject> subjects = DatabaseHelper.GetSubjects(); // Получение списка предметов
                        ClientHandler.updateClient(client); // Обновление клиента
                        // создание ответа
                        Response response = new Response() {
                            response = request,
                            body = JsonConvert.SerializeObject(subjects, Formatting.Indented), // конвертация списка предметов в строку и помещение её в тело ответа
                        };
                        // Конвертация объекта ответа в строку и её возврат
                        return JsonConvert.SerializeObject(response, Formatting.Indented);
                    }
                case "getThemes": {
                        // Запрос на получение тем, связанных с предметом
                        Subject subject = JsonConvert.DeserializeObject<Subject>(body); // Получение выбранного предмета из запроса
                        List<Theme> themes = DatabaseHelper.GetThemes(subject.Id); // Получение списка тем
                        ClientHandler.updateClient(client); // Обновление клиента
                        // Создание ответа
                        Response response = new Response() {
                            response = request,
                            body = JsonConvert.SerializeObject(themes, Formatting.Indented), // конвертация списка тем в строку и помещение её в тело ответа
                        };
                        // Конвертация объекта ответа в строку и её возврат
                        return JsonConvert.SerializeObject(response, Formatting.Indented);
                    }
                case "getQuestions": {
                        // Запрос на получение списка вопросов
                        Discipline discipline = JsonConvert.DeserializeObject<Discipline>(body); // Получение объекта дисциплины из запроса
                        List<Question> questions = DatabaseHelper.GetQuestionsByTestAndSubjectId(discipline.Subject.Id, discipline.Theme.Id); // Получение списка вопросов
                        ClientHandler.updateClient(client); // Обновление клиента
                        ClientHandler.setSubjectAndTheme(client, discipline.Subject, discipline.Theme); // Указание, что клиент выбрал предмет и тему
                        ClientHandler.setCountOfQuestion(client, questions.Count); // Указание, что клиент получил определённое количество вопросов
                        // Создание ответа
                        Response response = new Response() {
                            response = request,
                            body = JsonConvert.SerializeObject(questions, Formatting.Indented), // конвертация списка вопросов в строку и помещение её в тело ответа
                        };
                        // Конвертация объекта ответа в строку и её возврат
                        return JsonConvert.SerializeObject(response, Formatting.Indented);
                    }
                case "getGroups": {
                        // Запрос на получение списка учебных групп
                        List<Group> groups = DatabaseHelper.GetGroups(); // Получение списка групп
                        ClientHandler.updateClient(client); // Обновление клиента
                        // Создание ответа
                        Response response = new Response() {
                            response = request,
                            body = JsonConvert.SerializeObject(groups, Formatting.Indented), // конвертация списка групп в строку и помещение её в тело ответа
                        };
                        // Конвертация объекта ответа в строку и её возврат
                        return JsonConvert.SerializeObject(response, Formatting.Indented);
                    }
                case "answer": {
                        // Запрос на сохранение ответа
                        Answer answer = JsonConvert.DeserializeObject<Answer>(body); // Получение объекта ответа из тела запроса
                        ClientHandler.addAnswer(client, answer); // Добавление ответа в список уже отвеченных вопросов
                        // Создание ответа
                        Response response = new Response() {
                            response = request,
                            body = JsonConvert.SerializeObject("OK", Formatting.Indented),
                        };
                        // Конвертация объекта ответа в строку и её возврат
                        return JsonConvert.SerializeObject(response, Formatting.Indented);
                    }
                case "done": {
                        // Запрос на окончание тестирования
                        DisciplineWithMark disciplineWithMark = JsonConvert.DeserializeObject<DisciplineWithMark>(body); // Получение дисциплины с оценкой из тела запроса
                        // Создание нового журнала
                        Journal journal = new Journal() {
                            client = client,
                            subject = disciplineWithMark.Subject,
                            theme = disciplineWithMark.Theme,
                            mark = disciplineWithMark.Mark,
                        };
                        // Сохранение журнала
                        DatabaseHelper.InsertJournal(journal);
                        // Создание ответа
                        Response response = new Response() {
                            response = request,
                            body = JsonConvert.SerializeObject("OK", Formatting.Indented),
                        };
                        // Конвертация объекта ответа в строку и её возврат
                        return JsonConvert.SerializeObject(response, Formatting.Indented);
                    }
                default: { return null; }
            }
        }
    }    
}
