using System.Collections.Generic;

using Newtonsoft.Json;
using Server.Helpers;

namespace Server.Models
{
    class Discipline
    {
        private Subject _subject;
        private Theme _theme;

        public Subject Subject { get => _subject; set => _subject = value; }
        public Theme Theme { get => _theme; set => _theme = value; }
    }

    class DisciplineWithMark
    {
        private Subject _subject;
        private Theme _theme;
        private int _mark;

        public Subject Subject { get => _subject; set => _subject = value; }
        public Theme Theme { get => _theme; set => _theme = value; }
        public int Mark { get => _mark; set => _mark = value; }
    }

    public class Request
    {
        public string request;
        public Client client;
        public string body;

        public string Handle()
        {
            switch (request)
            {
                case "connect":
                    {
                        ClientHandler.addClient(client);
                        Response response = new Response()
                        {
                            response = request,
                            body = JsonConvert.SerializeObject("OK", Formatting.Indented),
                        };
                        return JsonConvert.SerializeObject(response, Formatting.Indented);
                    }
                case "disconnect": 
                    {
                        ClientHandler.removeClient(client);
                        Response response = new Response()
                        {
                            response = request,
                            body = JsonConvert.SerializeObject("OK", Formatting.Indented),
                        };
                        return JsonConvert.SerializeObject(response, Formatting.Indented);;
                    }
                case "getSubjects": 
                    {
                        List<Subject> subjects = DatabaseHelper.GetSubjects();
                        ClientHandler.updateClient(client);

                        Response response = new Response()
                        {
                            response = request,
                            body = JsonConvert.SerializeObject(subjects, Formatting.Indented),
                        };

                        return JsonConvert.SerializeObject(response, Formatting.Indented);
                    }
                case "getThemes": 
                    {
                        Subject subject = JsonConvert.DeserializeObject<Subject>(body);
                        List<Theme> themes = DatabaseHelper.GetThemes(subject.Id);
                        ClientHandler.updateClient(client);

                        Response response = new Response()
                        {
                            response = request,
                            body = JsonConvert.SerializeObject(themes, Formatting.Indented),
                        };

                        return JsonConvert.SerializeObject(response, Formatting.Indented);
                    }
                case "getQuestions":
                    {
                        Discipline discipline = JsonConvert.DeserializeObject<Discipline>(body);
                        List<Question> questions = DatabaseHelper.GetQuestionsByTestAndSubjectId(discipline.Subject.Id, discipline.Theme.Id);
                        ClientHandler.updateClient(client);
                        ClientHandler.setSubjectAndTheme(client, discipline.Subject, discipline.Theme);
                        ClientHandler.setCountOfQuestion(client, questions.Count);

                        Response response = new Response()
                        {
                            response = request,
                            body = JsonConvert.SerializeObject(questions, Formatting.Indented),
                        };

                        /*
                        [
                            {
                            "Id": 1,
                            "Id_subject": 1,
                            "Id_theme": 1,
                            "Name": "Какая версия Visual Studio последняя?",
                            "Options": [
                                {
                                    "id": 1,
                                    "id_question": 1,
                                    "option": "2008",
                                    "isRight": false
                                },
                                {
                                    "id": 2,
                                    "id_question": 1,
                                    "option": "2003",
                                    "isRight": false
                                },
                                {
                                    "id": 3,
                                    "id_question": 1,
                                    "option": "2012",
                                    "isRight": false
                                },
                                {
                                    "id": 4,
                                    "id_question": 1,
                                    "option": "2017",
                                    "isRight": true
                                }
                            ],
                            "Type": 1
                            }
                        ]"
                         */

                        return JsonConvert.SerializeObject(response, Formatting.Indented);
                    }
                case "getGroups":
                    {
                        List<Group> groups = DatabaseHelper.GetGroups();
                        ClientHandler.updateClient(client);

                        Response response = new Response()
                        {
                            response = request,
                            body = JsonConvert.SerializeObject(groups, Formatting.Indented),
                        };

                        return JsonConvert.SerializeObject(response, Formatting.Indented);
                    }
                case "answer":
                    {
                        Answer answer = JsonConvert.DeserializeObject<Answer>(body);
                        ClientHandler.addAnswer(client, answer);

                        Response response = new Response()
                        {
                            response = request,
                            body = JsonConvert.SerializeObject("OK", Formatting.Indented),
                        };

                        return JsonConvert.SerializeObject(response, Formatting.Indented);
                    }
                case "done":
                    {
                        DisciplineWithMark disciplineWithMark = JsonConvert.DeserializeObject<DisciplineWithMark>(body);
                        //ClientHandler.removeClient(client);

                        Journal journal = new Journal()
                        {
                            client = client,
                            subject = disciplineWithMark.Subject,
                            theme = disciplineWithMark.Theme,
                            mark = disciplineWithMark.Mark,
                        };

                        DatabaseHelper.InsertJournal(journal);

                        Response response = new Response()
                        {
                            response = request,
                            body = JsonConvert.SerializeObject("OK", Formatting.Indented),
                        };

                        return JsonConvert.SerializeObject(response, Formatting.Indented);
                    }
                default:
                    {
                        return null;
                    }
            }
        }

    }

    
}
