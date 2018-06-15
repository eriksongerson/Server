using System;
using System.Windows.Forms;
using Server.Models;
using Server.Helpers;
namespace Server.Forms {
    // Модальное окно, позволяющее создать или отредактировать группу
    public partial class groupModal : Form {
        // Перечисление двух типов работы формы
        public enum type {
            create, // Режим создания группы
            edit    // Режим редактирования группы
        }
        type Type; // Переменная, содержащая этот режим
        Group group; // Группа
        Execute execute; // Функция, выполняемая после главного действия формы
        public delegate void Execute();
        // Конструктор:
        public groupModal(type type, Group group, Execute execute) {
            InitializeComponent();
            this.Type = type;
            this.group = group;
            this.execute = execute;
        }
        // При загрузке формы, конфигурируются основные элементы управления
        private void groupModal_Load(object sender, EventArgs e) {
            // В зависимости от режима работы формы, форма меняет свой вид и функционал
            switch (Type) {
                case type.create: 
                    // Если установлен режим создания
                    // То меняются надписи на элементах управления
                    this.Text = "Добавление группы";
                    doThingButton.Text = "Добавить";
                    // И также меняется обработчик события нажатия кнопки
                    doThingButton.Click += new EventHandler((senderObject, eventArgs) => {
                        // Если название группы заполнено
                        if(thingTextBox.Text != "") {
                            // создаётся новый объект группы
                            group = new Group() {
                                Name = thingTextBox.Text,
                            };
                            // Сохраняется в базу данных
                            DatabaseHelper.InsertGroup(group);
                            // Выполняется внешняя функция
                            execute();
                            // Форма закрывается
                            this.Close();
                        }else{
                            // иначе всплывает сообщение
                            MessageBox.Show("Заполните название группы");
                            thingTextBox.Select();
                        }
                    });
                    break;
                case type.edit:
                    // Если установлен режим редактирования
                    // То меняются надписи на элементах управления
                    this.Text = "Изменение группы";
                    thingTextBox.Text = group.Name;
                    doThingButton.Text = "Изменить";
                    // И также меняется обработчик события нажатия кнопки
                    doThingButton.Click += new EventHandler((senderObject, eventArgs) => {
                        // Если название группы заполнено
                        if (thingTextBox.Text != "") {
                            // В объекте группы меняется название
                            group.Name = thingTextBox.Text;
                            // сохраняется в базу данных
                            DatabaseHelper.UpdateGroup(group);
                            // Выполняется внешняя функция
                            execute();
                            // Форма закрывается
                            this.Close();
                        } else {
                            // иначе всплывает сообщение
                            MessageBox.Show("Заполните название группы");
                            thingTextBox.Select();
                        }
                    });
                    break;
            }
            thingTextBox.Select();
        }
        private void thingTextBox_KeyDown(object sender, KeyEventArgs e) {
            // Нажатие на Enter обрабатывается как нажатие на кнопку
            if (e.KeyCode == Keys.Enter) {
                doThingButton.PerformClick();
            }
        }
    }
}
