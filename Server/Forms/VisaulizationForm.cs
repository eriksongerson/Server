using System;
using System.Windows.Forms;
using System.Threading;
using System.Collections.Generic;
using Server.Models;
using Server.Helpers;
using Server.Forms.Fragments;
namespace Server.Forms {
    // Форма отображения состояния тестирования
    public partial class VisaulizationForm : Form {
        // Объекты тестирования. Содержат всю необходимую информацию о студенте
        private List<Testing> testings;
        private List<Testing> Testings {
            set { // Если задано новое значение
                testings = value; // Сохраняем его
                try { 
                    flowLayoutPanel1.BeginInvoke((MethodInvoker)(() => {
                        flowLayoutPanel1.Controls.Clear(); // Очищаем форму
                    }));
                    // Заполняем форму в соответствии с новыми значениями
                    foreach (var item in testings) {
                        ClientFragment clientFragment = new ClientFragment(item);
                        flowLayoutPanel1.BeginInvoke((MethodInvoker)(() => {
                            flowLayoutPanel1.Controls.Add(clientFragment);
                        }));
                    }
                    // Меняем надпись о количестве подключенных клиентов
                    label1.BeginInvoke((MethodInvoker)(() => {
                        label1.Text = $"Подключенные ПК ({testings.Count} шт.):";
                    }));
                }
                catch (InvalidOperationException){}
            }
            get => testings;
        }
        // Конструктор
        public VisaulizationForm() => InitializeComponent();
        // событие при загрузке
        private void VisaulizationForm_Load(object sender, EventArgs e) {
            // Запускаем новый поток, который измененяет переменную тестирования
            new Thread(() => {
                Thread.CurrentThread.IsBackground = true;
                while (true) {
                    Testings = ClientHandler.testings;
                    Thread.Sleep(1000); // И делает это раз в секунду
                }
            }).Start();
        }
    }
}
