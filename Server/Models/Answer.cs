using System.Collections.Generic;

namespace Server.Models
{
    class Answer
    {
        
        public Question question;
        public List<Option> choosen;

        public void Handle(Client client)
        {

        }

    }
}
