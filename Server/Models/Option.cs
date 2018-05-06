using System;

namespace Server.Models
{
    public class Option
    {
        public int id;
        public int id_question;
        public string option;
        public bool isRight;

        public Option(){ }

        public Option(string option, bool isRight)
        {
            this.option = option;
            this.isRight = isRight;
        }

        public static implicit operator string(Option v)
        {
            return v.option;
        }
    }
}
