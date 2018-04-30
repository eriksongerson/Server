using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Server.Helpers;

namespace Server.Models
{
    public enum Method
    {
        GET,
        POST,
        PUT,
    }

    class discipline
    {
        public Subject subject;
        public Theme theme;
    }

    class disciplineWithMark
    {
        public Subject subject;
        public Theme theme;
        public int mark;
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
                            body = JsonConvert.SerializeObject(subjects),
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
                            body = JsonConvert.SerializeObject(themes),
                        };

                        return JsonConvert.SerializeObject(response, Formatting.Indented);
                    }
                case "getQuestions":
                    {
                        discipline discipline = JsonConvert.DeserializeObject<discipline>(body);
                        List<Question> questions = DatabaseHelper.GetQuestionsByTestAndSubjectId(discipline.subject.Id, discipline.theme.Id);

                        Response response = new Response()
                        {
                            response = request,
                            body = JsonConvert.SerializeObject(questions),
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
                            body = JsonConvert.SerializeObject("OK"),
                        };

                        return JsonConvert.SerializeObject(response, Formatting.Indented);
                    }
                case "done":
                    {
                        disciplineWithMark disciplineWithMark = JsonConvert.DeserializeObject<disciplineWithMark>(body);
                        
                        Journal journal = new Journal()
                        {
                            client = client,
                            subject = disciplineWithMark.subject,
                            theme = disciplineWithMark.theme,
                            mark = disciplineWithMark.mark,
                        };

                        DatabaseHelper.InsertJournal(journal);

                        Response response = new Response()
                        {
                            response = request,
                            body = JsonConvert.SerializeObject("OK"),
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
