using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using Server.Models;
using System;
namespace Server.Forms.Fragments {
    // Элемент управления AnswerFragment призван отобразить правильность/неправильность ответа, который выбрал студент
    class AnswerFragment : Panel {
        // Перечисление для лучшего восприятия кода
        private enum AnswerStatus {
            right,
            wrong,
            wait,
        }
        private AnswerStatus status; // элемент перечисления
        // Поле
        AnswerStatus Status {
            // Которое выполняет метод set когда поле получает новое значение 
            set {  
                status = value; // устанавливает элемент перечисления
                // И проверяет его
                switch (status) {
                    case AnswerStatus.right: // Если ответ правильный 
                        this.statusLabel.BackColor = Color.Green; // Закрашивает элемент зеленым
                        break;
                    case AnswerStatus.wrong: // Если ответ неправильный
                        this.statusLabel.BackColor = Color.Red; // Закрашивает элемент красным
                        break;
                    case AnswerStatus.wait: // Если элемент не получил ответа студента, значит, студент ещё не решил данный вопрос
                        this.statusLabel.BackColor = SystemColors.ControlDark; // И закрашивает элемнт в серый
                        break;
                }
            }
            get { return status; }
        }
        // Ответ студента, привязанный к элементу 
        Answer answer;
        // Номер вопроса
        int number = 0;
        Label statusLabel;
        // Два конструктора элемента:
        public AnswerFragment(int number): base() {
            this.number = number;
            this.answer = null;
            Init();
        }
        public AnswerFragment(Answer answer, int number): base() {
            this.number = number;
            this.answer = answer;
            Init();
        }
        // Функция конфигурации элемента управления
        private void Init() {
            // Конфигурация фрагмента:
            statusLabel = new Label();
            this.Controls.Add(statusLabel);
            this.statusLabel.Size = new Size(28, 28); // Размер надписи
            this.statusLabel.Location = new Point(4, 11); // Место надписи на родительском элементе
            this.statusLabel.TextAlign = ContentAlignment.MiddleCenter; // Выравнивание текста
            this.statusLabel.Text = $"{number}"; // Надпись (номер вопроса)
            this.Size = new Size(40, 50); // Размер самого элемента
            this.Margin = new Padding(0); // поля
            // Если во фрагменте нет элемента ответа, он должен быть серым
            if (answer == null) {
                Status = AnswerStatus.wait; // Устанавливается состояние
                return;
            }
            // Проверка правильности отвеченного вопроса
            switch (answer.question.Type) {
                // Если вопрос с одиночным или множественным выбором
                case Models.Type.single:
                case Models.Type.multiple:
                    // Фильтруются варианты ответа на вопрос
                    var rightOptions = GetRightOptions(answer.question.Options);
                    // И проверяются с теми, которые ответил студент
                    bool equal = answer.choosen.SequenceEqual(rightOptions, new OptionComparer());
                    // Если они равны - закрашивается зеленым, иначе - красным
                    Status = equal ? AnswerStatus.right : AnswerStatus.wrong;
                    break;
                // Если вопрос на заполнение
                case Models.Type.filling:
                    // Правильный вариант ответа и ответ студента приводятся к одному виду.
                    // Если они не равны
                    if(answer.choosen[0].option.TrimEnd().TrimStart().ToLower() == answer.question.Options[0].option.TrimEnd().TrimStart().ToLower()) {
                        Status = AnswerStatus.right; // Закрашивается зеленым
                    } else {
                        Status = AnswerStatus.wrong; // или красным
                    }
                    break;
            }
        }
        // Метод возвращает все верные варианты ответа на вопрос
        private List<Option> GetRightOptions(List<Option> options) {
            List<Option> rightOptions = new List<Option>();
            // Перебираются все варианты ответа
            foreach (var item in options) {
                // Если вариант ответа верный
                if (item.isRight) {
                    rightOptions.Add(item); // Сохраняется в список
                }
            }
            return rightOptions; // и затем возвращается
        }
    }
    // Этот класс необходим для проверки идентичности двух списков List<Option>
    class OptionComparer : IEqualityComparer<Option> {
        // Метод Equals перегружен и теперь проверяет все поля объекта Option на идентичность
        public bool Equals(Option x, Option y) {
            // Возвращает true, если два сравниваемых элемента идентичны по типу
            if (Object.ReferenceEquals(x, y)) return true;
            // Возвращает false, если хоть один из сравниваемых элементов не существует
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                return false;
            // Сравнивает все поля двух объектов и возвращает true, если поля идентичны
            return x.id == y.id && x.id_question == y.id_question && x.isRight == y.isRight && x.option == y.option;
        }
        // Метод возвращает цифровой хэш объекта
        public int GetHashCode(Option option) {
            // Если объект не существует, его хэш будет равен нулю
            if (Object.ReferenceEquals(option, null)) return 0;
            // Создаётся хэш поля id объекта Option
            int hashOptionId = option.id.GetHashCode();
            // Создаётся хэш поля id_question объекта Option
            int hashOptionIdQuestion = option.id_question.GetHashCode();
            // Создаётся хэш поля isRight объекта Option
            int hashOptionIsRight = option.isRight.GetHashCode();
            // Создаётся хэш поля option объекта Option
            int hashOptionOption = option.option.GetHashCode();
            // Складываются все хэши.
            return hashOptionId ^ hashOptionIdQuestion ^ hashOptionIsRight ^ hashOptionOption;
        }
    }
}
