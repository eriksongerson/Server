using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Models
{
    public class Testing
    {

        private Client client;
        private List<Answer> answers;
        private Subject subject;
        private Theme theme;
        private int countOfQuestions;

        public Client Client
        {
            set => client = value;
            get => client;
        }
        public List<Answer> Answers
        {
            set => answers = value;
            get => answers; 
        }
        public Subject Subject
        {
            set => subject = value;
            get => subject;
        }
        public Theme Theme
        {
            set => theme = value;
            get => theme;
        }
        public int CountOfQuestions
        {
            set => countOfQuestions = value;
            get => countOfQuestions;
        }

    }
}
