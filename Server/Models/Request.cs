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

        //public Method method;
        public string request;
        public Client client;
        public string body;

        public string Handle()
        {

            switch (request)
            {
                case "connect":
                    {
                        //Server.AddClient(this.client);
                        return "";
                    }
                case "disconnect": 
                    {
                        return "";
                    }
                case "getSubjects": 
                    {
                        List<Subject> subjects = DatabaseHelper.GetSubjects();

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

                        Response response = new Response()
                        {
                            response = request,
                            body = JsonConvert.SerializeObject(questions, Formatting.Indented),
                        };

                        return JsonConvert.SerializeObject(response, Formatting.Indented);
                    }
                case "answer":
                    {
                        Answer answer = JsonConvert.DeserializeObject<Answer>(body);
                        answer.Handle(client);

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
