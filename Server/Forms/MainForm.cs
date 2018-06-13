using System;
using System.Threading;
using System.Windows.Forms;

using Server.Helpers;

namespace Server.Forms { 
    // Главная форма. Управляет состоянием сервера и взаимодействует со всеми остальными формами
    public partial class MainForm : Form {
        // Конструктор формы
        public MainForm(){ InitializeComponent(); }
        // Кнопка изменения статуса системы
        private void button1_Click(object sender, EventArgs e){
            ChangeStatus();
        }
        // Функция изменения состояния сервера
        private void ChangeStatus() {
            SocketHelper.ChangeStatus(); // Изменяет состояние
            if (SocketHelper.Status) { // Узнаёт, запущен ли сервер
                // Если запущен, меняет форму
                statusLabel.Text = "Сервер запущен";
                button1.Text = "Остановить сервер";
                button2.Visible = true;
                // И запускает новый поток
                new Thread(() => {
                    Thread.CurrentThread.IsBackground = true;
                    while (SocketHelper.Status) {
                        // Который отображает количество подключенных клиентов
                        connectedLabel.BeginInvoke((MethodInvoker)(() => {
                            connectedLabel.Text = $"Подключено {ClientHandler.testings.Count} студентов";
                        }));
                        // И делает это раз в секунду
                        Thread.Sleep(1000);
                    }
                }).Start();
            } else{
                // Если сервер не запущен, меняет форму
                statusLabel.Text = "Сервер отключен";
                button1.Text = "Запустить сервер";
                connectedLabel.Text = "";
                button2.Visible = false;
            }
        }
        // Функция перехода на форму работы с тестами
        private void databaseButton_Click(object sender, EventArgs e) {
            DataBase dataBaseForm = new DataBase();
            dataBaseForm.Show();
        }
        // Событие выхода с формы
        private void Main_Leave(object sender, EventArgs e) {
            SocketHelper.StopListener(); // Останавливает сервер
            Application.Exit(); 
        }
        // Событие загрузки формы
        private void Main_Load(object sender, EventArgs e){
            label4.Text = SocketHelper.GetListenerIP(); // Показываем IP-адрес сервера
        }    
        // Кнопка перехода на форму журналов
        private void button3_Click(object sender, EventArgs e) {
            Journal journal = new Journal();
            journal.Show();
        }
        // Событие перехода на форму отображения состояния тестирования
        private void button2_Click(object sender, EventArgs e) {
            if (SocketHelper.Status)
                new VisaulizationForm().ShowDialog();
        }
        // Кнопка перехода на форму работы с группами
        private void groupsButton_Click(object sender, EventArgs e) {
            new GroupsForm().ShowDialog();
        }   
    }
}
