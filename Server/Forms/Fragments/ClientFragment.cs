using System.Drawing;
using System.Windows.Forms;
using Server.Models;
namespace Server.Forms.Fragments {
    // Фрагмент отображения текущего состояния тестирования студента
    public class ClientFragment : Panel {
        Testing testing; // Объект тестирование для конкретного студента
        // Элементы управления:
        Label surnameLabel;
        Label nameLabel;
        FlowLayoutPanel thingsFlowLayoutPanel;
        // Конструктор элемента
        public ClientFragment(Testing testing) {
            // сохраняется объект тестирования
            this.testing = testing;
            // И проводится конфигурирование элемента
            InitializeComponent();
        }
        // Функция конфигурирования элемента
        private void InitializeComponent() {
            // Внутренние элементы управления
            surnameLabel = new Label();
            nameLabel = new Label();
            thingsFlowLayoutPanel = new FlowLayoutPanel();
            // Добавление внутренних элементов на элемент:
            this.Controls.Add(this.thingsFlowLayoutPanel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.surnameLabel);
            this.Margin = new Padding(0); // Поля элемента управления
            this.Size = new Size(882, 50); // Размер
            this.TabIndex = 0;
            // Конфигурация Надписи для фамилии/имени ПК
            this.surnameLabel.Location = new Point(0, 0); // Позиция
            this.surnameLabel.Margin = new Padding(0); // Поля
            this.surnameLabel.Size = new Size(215, 30); // Размер
            this.surnameLabel.TabIndex = 0;
            this.surnameLabel.TextAlign = ContentAlignment.MiddleCenter; // Выравнивание текста
            // Конфигурирование надписи для имени
            this.nameLabel.Location = new Point(0, 30); // Позиция
            this.nameLabel.Margin = new Padding(0); // Поля
            this.nameLabel.Size = new Size(215, 20); // Размер
            this.nameLabel.TabIndex = 1; 
            this.nameLabel.TextAlign = ContentAlignment.MiddleCenter; // Выравнивание текста
            // Конфигурирование панели отображения ответов на вопросы
            this.thingsFlowLayoutPanel.AutoScroll = true; // Элемент может создавать scrollBar
            this.thingsFlowLayoutPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink; // Размер не может изменяться
            this.thingsFlowLayoutPanel.Location = new Point(215, 0); // Позиция
            this.thingsFlowLayoutPanel.Margin = new Padding(0); // Поля
            this.thingsFlowLayoutPanel.Size = new Size(666, 50); // Размер
            this.thingsFlowLayoutPanel.TabIndex = 2;
            double additionHeight = (double)this.testing.CountOfQuestions / 14; // Переменная, добавляющая высоту к элементу управления
            // Если вопросов больше чем 14, нужно увеличить высоту элемента
            for (int i = 0; i < additionHeight; i++) {
                // на 50
                this.Height += 50; 
                this.thingsFlowLayoutPanel.Height += 50;
            }
            if(additionHeight % 10 != 0) {
                this.Height += 50;
                this.thingsFlowLayoutPanel.Height += 50;
            }
            // Если тестирование не пустое, нужно сконфигурировать элемент
            if (testing != null) {
                // Если имя и фамилия указаны
                if (this.testing.Client.name != null && this.testing.Client.surname != null) {
                    // Пишем их в элемент управления
                    surnameLabel.Text = this.testing.Client.surname;
                    nameLabel.Text = this.testing.Client.name;
                } else { 
                    // иначе указываем имя ПК
                    surnameLabel.Text = this.testing.Client.pc;
                    nameLabel.Text = "";
                }
                int currentQuestionNumber = 1; // переменная для нумерации ответов на вопрос
                thingsFlowLayoutPanel.Controls.Clear(); // Очистка панели ответов на вопрос
                foreach (var item in testing.Answers) {
                    // Создание элементов ответа на вопрос и их отображение
                    AnswerFragment answerFragment = new AnswerFragment(item, currentQuestionNumber);
                    thingsFlowLayoutPanel.Controls.Add(answerFragment);
                    currentQuestionNumber++;
                }
                // Также рисуем вопросы, которые студенту только придётся решить
                for (int i = 0; i < testing.CountOfQuestions - testing.Answers.Count; i++) {
                    AnswerFragment answerFragment = new AnswerFragment(currentQuestionNumber);
                    thingsFlowLayoutPanel.Controls.Add(answerFragment);
                    currentQuestionNumber++;
                }
            }
            this.ResumeLayout(false);
        }
    }
}