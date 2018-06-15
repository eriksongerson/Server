using System.Collections.Generic;
using Server.Models;
namespace Server.Helpers {
    // Класс ClientHelper отвечает за содержание клиентов и их синхронное отображение
    public static class ClientHandler {
        public static List<Testing> testings = new List<Testing>();
        // Функция добавления нового клиента
        public static void addClient(Client client) {
            // Если клиент с таким именем ПК и адресом уже существует, следует пропустить его
            foreach (var item in testings) {
                if (item.Client.ip.Equals(client.ip) && item.Client.pc.Equals(client.pc)) return;
            }
            // Иначе - добавить
            Testing testing = new Testing() {
                Client = client,
                Answers = new List<Answer>(),
                Subject = null,
                Theme = null,
                CountOfQuestions = 0,
            };
            testings.Add(testing);
        }
        // функция обновления клиента. Обновляет имя, фамилию и группу
        public static void updateClient(Client client) {
            foreach (var item in testings) {
                if(item.Client.ip.Equals(client.ip) && item.Client.pc.Equals(client.pc)) {
                    item.Client.name = client.name;
                    item.Client.surname = client.surname;
                    item.Client.group = client.group;
                    return;
                }
            }
        }
        // Функция добавления ответа для конкретного клиента
        public static void addAnswer(Client client, Answer answer) {
            if(testings.Count != 0) { 
                foreach (var item in testings) {
                    if(item.Client.ip.Equals(client.ip) && item.Client.pc.Equals(client.pc)) {
                        item.Answers.Add(answer);
                    }
                }
            }
        }
        // Функция установки предмета и темы для клиента
        public static void setSubjectAndTheme(Client client, Subject subject, Theme theme) {
            foreach (var item in testings) {
                if (item.Client.ip.Equals(client.ip) && item.Client.pc.Equals(client.pc)){
                    item.Subject = subject;
                    item.Theme = theme;
                }
            }
        }
        // Функция установки количества вопросов. Оно нужно для отрисовки
        public static void setCountOfQuestion(Client client, int count) {
            foreach (var item in testings) {
                if (item.Client.ip.Equals(client.ip) && item.Client.pc.Equals(client.pc)){
                    item.CountOfQuestions = count;
                }
            }
        }
        // Функция удаления клиента
        public static void removeClient(Client client) {
            foreach (var item in testings) {
                if (item.Client.ip.Equals(client.ip) && item.Client.pc.Equals(client.pc)) {
                    testings.Remove(item);
                    return;
                }
            }
        }
    }
}
