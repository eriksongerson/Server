using System.Collections.Generic;

using Server.Models;

namespace Server.Helpers
{
    public static class ClientHandler
    {

        public static CustomList<Testing> testings = new CustomList<Testing>();

        public static void addClient(Client client)
        {
            Testing testing = new Testing()
            {
                Client = client,
                Answers = new List<Answer>(),
                Subject = null,
                Theme = null,
                CountOfQuestions = 0,
            };
            testings.Add(testing);
        }

        public static void updateClient(Client client)
        {
            foreach (var item in testings)
            {
                if(item.Client.ip.Equals(client.ip) && item.Client.pc.Equals(client.pc))
                {

                    item.Client.name = client.name;
                    item.Client.surname = client.surname;
                    item.Client.group = client.group;
                    return;

                }
            }
            addClient(client);
        }
    
        public static void addAnswer(Client client, Answer answer)
        {
            if(testings.Count != 0) { 
                foreach (var item in testings)
                {
                    if(item.Client.ip.Equals(client.ip) && item.Client.pc.Equals(client.pc))
                    {
                        item.Answers.Add(answer);
                    }
                }
            }
        }

        public static void setSubjectAndTheme(Client client, Subject subject, Theme theme)
        {
            foreach (var item in testings)
            {
                if (item.Client.ip.Equals(client.ip) && item.Client.pc.Equals(client.pc))
                {
                    item.Subject = subject;
                    item.Theme = theme;
                }
            }
        }

        public static void setCountOfQuestion(Client client, int count)
        {
            foreach (var item in testings)
            {
                if (item.Client.ip.Equals(client.ip) && item.Client.pc.Equals(client.pc))
                {
                    item.CountOfQuestions = count;
                }
            }
        }

        public static void removeClient(Client client)
        {
            foreach (var item in testings)
            {
                if (item.Client.ip.Equals(client.ip) && item.Client.pc.Equals(client.pc))
                {
                    testings.Remove(item);
                    return;
                }
            }
        }
    }
}
