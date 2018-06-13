using System;
using System.Windows.Forms;

using Server.Helpers;
using Server.Models;

namespace Server.Forms {
    // Форма, позволяющая добавлять, редктировать или удалять группы
    public partial class GroupsForm : Form {
        // Конструктор:
        public GroupsForm(){
            InitializeComponent();
        }
        // Событие при загрузке формы
        private void GroupsForm_Load(object sender, EventArgs e){
            updateData();
        }
        // Функция, обновляющая данные на форме
        private void updateData(){
            // Делает запрос к базе данных о выборке всех групп
            dataGridView1.DataSource = DatabaseHelper.SelectGroupsAdapter();
            
            dataGridView1.Columns[0].Visible = false; // Первая колонка пользователю не нужна. Скрываем
            dataGridView1.Columns[1].Name = "Группа"; // Заголовок для необходимого столбца

            editButton.Enabled = deleteButton.Enabled = dataGridView1.Rows.Count == 0 ? false : true; // кнопки активируются или деактивируются в зависимости от наличия групп
        }

        private void backButton_Click(object sender, EventArgs e){
            this.Close(); // Закрытие формы
        }
        // Кнопка добавления
        private void addButton_Click(object sender, EventArgs e){
            // При необходимости добавления группы, создаётся модальная форма groupModal
            // И к ней передаётся функция, которая должна выполниться при закрытии модальной формы.
            new groupModal(groupModal.type.create, null, ()=>
            {
                updateData(); // Сама функция
            }).ShowDialog();
        }
        // Кнопка редактирования 
        private void editButton_Click(object sender, EventArgs e){
            // при необходимости редактирования группы создаётся элемент группы из выбранного элемента на форме
            Group group = new Group()
            {
                Id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value),
                Name = dataGridView1.SelectedRows[0].Cells[1].Value.ToString(),
            };
            // И создаётся модальная форма groupModal.
            // По закрытии модальной формы выполнится обновление данных на этой форме
            new groupModal(groupModal.type.edit, group, () =>
            {
                updateData();
            }).ShowDialog();
        }
        // Кнопка удаления
        private void deleteButton_Click(object sender, EventArgs e){
            // Если пользователь действительно хочет удалить группу
            if(MessageBox.Show("Вы действительно хотите удалить эту группу?", "Подтверждение удаления", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // Создаётся элемент группы из выбранного элемента на форме
                Group group = new Group()
                {
                    Id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value),
                    Name = dataGridView1.SelectedRows[0].Cells[1].Value.ToString(),
                };
                // удаляет её
                DatabaseHelper.DeleteGroup(group);
                updateData(); // И обнровляет форму
            }
        }
    }
}
