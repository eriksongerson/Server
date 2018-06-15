namespace Server.Models {
    // Класс ответа
    public class Response {
        public string response; // Ответ. Дублируется с запроса
        public string body; // Тело ответа. Содержит запрашиваемую информацию
    }
}
