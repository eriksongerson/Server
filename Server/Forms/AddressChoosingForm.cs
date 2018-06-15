using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Windows.Forms;
namespace Server.Forms {
    // Форма позволяет выбрать ip-адрес системы, который будет использоваться во время тестирования
    public partial class AddressChoosingForm : Form {
        List<IPAddress> addresses; // Список адресов
        Execute execute; // Функция, которая передаётся при создании формы
        public delegate void Execute(IPAddress address);
        // Конструктор:
        public AddressChoosingForm(List<IPAddress> addresses, Execute execute) {
            InitializeComponent();
            this.addresses = addresses;
            this.execute = execute;
        }
        // Событие при загрузке формы
        private void AddressChoosingForm_Load(object sender, EventArgs e) {
            // Создаётся новая таблица
            DataTable dataTable = new DataTable();
            // С одним столбцом
            dataTable.Columns.Add(new DataColumn("IP", Type.GetType("System.String")));
            // Заполняется списком IP-адресов
            foreach (IPAddress address in addresses) {
                DataRow dataRow = dataTable.NewRow();
                dataRow["IP"] = address.ToString();
                dataTable.Rows.Add(dataRow);
            }
            // И выводится на форму
            thingsDataGridView.DataSource = dataTable;
        }
        // При двойном нажатии по IP-адресу на форме вызывается функция обработки выбора
        private void thingsDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            chooseButton_Click(sender, null);
        }
        private void chooseButton_Click(object sender, EventArgs e) {
            // Выполняется поиск выбранного объекта IPAddress
            string choosen = thingsDataGridView.SelectedRows[0].Cells[0].Value.ToString();
            foreach (IPAddress address in addresses) {
                if (address.ToString() == choosen) {
                    // и выполняется функция, которую передали при создании формы
                    execute(address);
                }
            }
            // Форма закрывается
            this.Close();
        }
    }
}
