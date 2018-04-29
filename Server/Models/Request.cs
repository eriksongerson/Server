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

    public class Request
    {

        //public Method method;
        public string request;
        public Client client;
        public string body;

        class discipline
        {
            public Subject subject;
            public Theme theme;
        }

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
                        return "";
                    }
                case "done":
                    {
                        return "";
                    }
                default:
                    {
                        return null;
                    }
            }
        }

    }

    
}
