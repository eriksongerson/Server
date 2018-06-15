namespace Server.Models {
    // перечисление типа вопроса
    public enum Type : int {
        single = 1,     // с одиночным выбором
        multiple = 2,   // со множественным выбором
        filling = 3,    // на заполнение
    }
}
