using System;
using System.Collections.Generic;

namespace Server.Models
{
    // Мне потребовалось реализовать класс листа с дополнительным событием.
    // Он будет использоваться во время тестирования.
    // Каждый раз, когда на сервер будет приходить запрос, объект клиента из запроса будет обработан и помещён в этот класс.
    // Событие нужно для постоянной отрисовки на форме новых элементов или удаления старых
    public class ClientList : List<Client>
    {
        public event EventHandler onLengthChanged; // Это новое событие. Оно будет срабатывать каждый раз, когда размер списка изменится.

        public ClientList(): base() { } // Это конструктор класса.

        public new void Add(Client client)
        {
            base.Add(client);
            onLengthChanged?.Invoke(this, null); // А это встраивание события для его работы.
        }

        public new void Remove(Client client)
        {
            base.Remove(client);
            onLengthChanged?.Invoke(this, null); // И это тоже.
        }
        // Зачем вопросительный знак после onLengthChanged? Это проверка события на null. Если он не null, он выполнится, нет - нет.
    }
}
