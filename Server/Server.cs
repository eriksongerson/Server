using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace Server
{

    class Server
    {

        public static List<string> Clients = new List<string>();//В данном массиве хранятся имена ПК клиентов
        public static List<string> ClientInfo = new List<string>();

        private static bool isDebug;
        private static bool isEnabled;
        private static string IP = "127.0.0.1";

        public static bool get_isEnabled()
        {
            return isEnabled;
        }
        public static void set_isEnabled(bool value)
        {
            isEnabled = value;
        }

        public static bool get_isDebug()
        {
            return isDebug;
        }
        public static void set_isDebug(bool value)
        {
            isDebug = value;
            IP = GetLocalIP();
        }

        public static string get_IP()
        {
            return IP;
        }

        public Server()
        {

        }

        public static string SocketHandler(/*string Function,*/ StringBuilder Message)
        {

            string message = Message.ToString();
            string[] Line = message.Split(':');

            string PCname = Line[1];
            string Query = Line[2];

            string mes = "";

            //Нужно установить обработку сообщений
            switch (Query)
            {
                case "Connect":
                    {
                        Clients.Add(PCname);

                        mes = PCname + ":Connected";
                        break;
                    }
                case "Disconnect":
                    {
                        Clients.Remove(PCname);

                        mes = PCname + ":Disconnected";
                        break;
                    }
                case "Subjects":
                    {
                        mes = DataBaseController.SelectQuery("Subject", "Subject");
                        break;
                    }
                case "Themes":
                    {
                        string Subject = Line[3];
                        string Id_s = DataBaseController.SelectQuery("Id_s", "Subject", "Subject='" + Subject + "'");

                        mes = DataBaseController.SelectQuery("Theme", "Theme", "Id_s = " + Id_s);
                        break;
                    }
                case "Questions":
                    {
                        string Subject = Line[1];
                        string Theme = Line[2];
                        string Id_s = DataBaseController.SelectQuery("Id_s", "Subject", "Subject='" + Subject + "'");
                        string Id_t = DataBaseController.SelectQuery("Id_t", "Theme", "Theme='" + Theme + "'");
                        /**
                         *IDвопроса:Вопрос: ПервыйВариантОтвета: ВторойВариантОтвета: ТретийВариантОтвета: ЧетвёртыйВариантОтвета: НомерВерногоОтвета
                        **/
                        mes = DataBaseController.SelectQuery("Id + ':' + Question + ':' + FirstOption + ':' + SecondOption + ':' + ThirdOption + ':' + FourthOption + ':' + CONVERT(nvarchar, RightOption)", "Question", "Id_s=" + Id_s + " AND Id_t=" + Id_t);
                        break;
                    }
                case "Answer":
                    {
                        string QuestionNumber = Line[6];
                        string TotalQuestions = Line[7];
                        string Answer = Line[8];

                        ClientInfo.Add(PCname + ":" + QuestionNumber + ":" + TotalQuestions + ":" + Answer);

                        mes = PCname + ":Updated";
                        break;
                    }
            }
            mes = Query + ";" + mes;

            return mes;

            /*switch (Function)
            {
                case "Listen": return ListenSocketHandler(Message);
                case "STQ": return QuestionSocketHandler(Message); 
                case "Answer": return AnswerSocketHandler(Message);
                default: return "";
            }*/
        }

        public static string AddClient(string PCname)
        {
            Clients.Add(PCname);

            return PCname + ":Connected";
        }

        public static string RemoveClient(string PCname)
        {
            Clients.Remove(PCname);

            return PCname + ":Disconnected";
        }

        public static string UpdateClient(string PCname, string QuestionNumber, string TotalQuestions, string Answer)
        {
            ClientInfo.Add(PCname + ":" + QuestionNumber + ":" + TotalQuestions + ":" + Answer);

            return PCname + ":Updated";
        }

        public static string GetLocalIP()
        {
            if (isDebug == true)
            {
                return "127.0.0.1";
            }

            string Ip = "";
            var host = Dns.GetHostEntry(Dns.GetHostName());

            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    Ip = ip.ToString();
                }
            }

            return Ip;


            /**
             * Синтаксис сообщения:
             * IP:ИмяПК:Tryconnect
             * IP:ИмяПК:Disconnect:ОтвеченныхВопросов:ВсегоВопросов:Оценка
             **/
            /*private string ListenSocketHandler(StringBuilder Message)
            {

                string[] Line = Message.ToString().Split(':');

                string Query = Line[2];
                string PCname = Line[1];

                string mes = "";

                switch (Query)
                {
                    case "TryConnect": mes = ifController.AddClient(PCname); break;
                    case "Disconnect":
                        {

                            mes = ifController.RemoveClient(PCname); break;
                        }
                }

                return mes;
            }*/

            /**
             * Синтаксис сообщения для предметов:
             * Subjects
             * Синтаксис сообщения для тем:
             * Themes:Предмет
             * Синтаксис сообщения для вопросов:
             * Question:Предмет:Тема
             **/
            /*private string QuestionSocketHandler(StringBuilder Message)
            {
                string[] Line = Message.ToString().Split(':');

                string Query = Line[0];

                string mes = "";

                if (Query == "Subjects")
                {
                    mes = DBController.SelectQuery("Subject", "Subject");
                }
                if (Query == "Themes")
                {
                    string Subject = Line[1];
                    string Id_s = DBController.SelectQuery("Id_s", "Subject", "Subject='" + Subject + "'");

                    mes = DBController.SelectQuery("Theme", "Theme", "Id_s = ");
                }
                if (Query == "Question")
                {
                    string Subject = Line[1];
                    string Theme = Line[2];
                    string Id_s = DBController.SelectQuery("Id_s", "Subject", "Subject='" + Subject + "'");
                    string Id_t = DBController.SelectQuery("Id_t", "Theme", "Theme='" + Theme + "'");
                    **
                     * IDвопроса:Вопрос:ПервыйВариантОтвета:ВторойВариантОтвета:ТретийВариантОтвета:ЧетвёртыйВариантОтвета:НомерВерногоОтвета
                     **
                    mes = DBController.SelectQuery("Id + ':' + Question + ':' + FirstOption + ':' + SecondOption + ':' + ThirdOption + ':' + FourthOption + ':' + CONVERT(nvarchar, RightOption)", "Question", "Id_s=" + Id_s + " AND Id_t=" + Id_t);
                }

                return mes;
            }*/

            /**
             * Синтаксис сообщения:
             * IP:ИмяПК:Answer:Предмет:Тема:IDотвеченногоВопроса:ПорядковыйНомерВопроса:ВсегоВопросов:Ответ
             **/
            /*private string AnswerSocketHandler(StringBuilder Message)
            {
                string[] Line = Message.ToString().Split(':');

                string Query = Line[2];
                string PCname = Line[1];
                string QuestionNumber = Line[6];
                string TotalQuestions = Line[7];
                string Answer = Line[8];

                string mes = "";

                if (Query == "Answer")
                {
                    mes = ifController.UpdateClient(PCname, QuestionNumber,TotalQuestions,Answer);
                }

                return "";
            }*/

        }

    }
}