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
                        return "";
                    }
                case "getQuestions":
                    {
                        return "";
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
