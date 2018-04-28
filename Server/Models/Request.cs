using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void handle()
        {
            switch (request)
            {
                case "connection":
                    {
                        Server.AddClient(this.client);
                        break;
                    }
                case "": {
                        break;
                    }
            }
        }

    }

    
}
