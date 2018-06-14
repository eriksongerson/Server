using System;
using System.Windows.Forms;

using Server.Helpers;

namespace Server.Forms
{
    // Форма Журналов. Позволяет просматривать результаты прошлых тестирований и удалять их
    public partial class Journal : Form {
        // Конструктор
        public Journal(){ InitializeComponent(); }
        // Функция обновления данных на форме
        private void updateData() {
            dataGridView1.DataSource = DatabaseHelper.SelectJournalsAdapter();
            dataGridView1.Columns[0].Visible = false; // скрытие ненужного столбца
            // настройка ширины столбцов
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[2].Width = 100;
            dataGridView1.Columns[3].Width = 150;
            dataGridView1.Columns[5].Width = 100;
            dataGridView1.Columns[6].Width = 100;
            deleteButton.Enabled = dataGridView1.SelectedRows.Count != 0;
            //dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font(FontFamily.GenericSansSerif, 14, FontStyle.Regular);
        }
        // Событие при загрузке формы
        private void Journal_Load(object sender, EventArgs e) => updateData();
        // Кнопка назад
        private void backButton_Click(object sender, EventArgs e) => this.Hide();
        // Кнопка удаления записи
        private void deleteButton_Click(object sender, EventArgs e) {
            if(dataGridView1.SelectedCells.Count != 0)
            {
                int id = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
                DatabaseHelper.DeleteJournalByID(id);
                updateData();
            }
        }
        // кнопка перехода на форму формирования отчётов
        private void createReportButton_Click(object sender, EventArgs e) => new ReportForm().ShowDialog();
        // если выделена новая ячейка
        private void dataGridView1_SelectionChanged(object sender, EventArgs e) {
            // Проверяем, есть ли строки в таблице
            deleteButton.Enabled = dataGridView1.SelectedRows.Count != 0;
        }
    }
}
