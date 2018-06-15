using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Server.Helpers;
using Server.Models;
namespace Server {
    // Форма предоставляет интерфейс для работы с базой данных
    public partial class DataBase : Form {  
        string Line = "";
        Question CurrentQuestion;
        public DataBase() => InitializeComponent();
        // Событие загрузки формы
        private void DataBase_Load(object sender, EventArgs e) => UpdateViews();
        // Событие переключения владок
        private void tabControl1_Selected(object sender, TabControlEventArgs e) {
            UpdateViews();
            if(TabControl.SelectedTab.Name == "deleteTab") {
                // Если вкладка удаления - нужно уменьшить размер формы
                this.Height = 455;
                TabControl.Height = 397;
            } else {
                this.Height = 730;
                TabControl.Height = 675;
            }
        }
        // Функция обновления формы
        private void UpdateViews() {
            ClearAddTab();
            ClearEditTab();
            ClearDeleteTab();
            ClearEditQuestion();
            UpdateSubjects();
        }
        // Функция обновления всех выпадающих списков предметов
        private void UpdateSubjects() {
            // Очистка
            addThemeSubjectComboBox.Items.Clear();
            addQuestionSubjectComboBox.Items.Clear();
            editSubjectComboBox.Items.Clear();
            editThemeSubjectComboBox.Items.Clear();
            editQuestionSubjectComboBox.Items.Clear();
            deleteSubjectComboBox.Items.Clear();
            deleteThemeSubjectComboBox.Items.Clear();
            deleteQuestionSubjectComboBox.Items.Clear();
            // Заполнение
            List<Subject> subjects = DatabaseHelper.GetSubjects();
            if(subjects.Count != 0) {
                foreach (Subject subject in subjects) {
                    addThemeSubjectComboBox.Items.Add(subject);
                    addQuestionSubjectComboBox.Items.Add(subject);
                    editSubjectComboBox.Items.Add(subject);
                    editThemeSubjectComboBox.Items.Add(subject);
                    editQuestionSubjectComboBox.Items.Add(subject);
                    deleteSubjectComboBox.Items.Add(subject);
                    deleteThemeSubjectComboBox.Items.Add(subject);
                    deleteQuestionSubjectComboBox.Items.Add(subject);
                }
            } else {
                addThemeSubjectComboBox.Text = "В базе данных нет ни одного предмета";
                addThemeSubjectComboBox.Enabled = false;
                addQuestionSubjectComboBox.Text = "В базе данных нет ни одного предмета";
                addQuestionSubjectComboBox.Enabled = false;
                editSubjectComboBox.Text = "В базе данных нет ни одного предмета";
                editSubjectComboBox.Enabled = false;
                editThemeSubjectComboBox.Text = "В базе данных нет ни одного предмета";
                editThemeSubjectComboBox.Enabled = false;
                editQuestionSubjectComboBox.Text = "В базе данных нет ни одного предмета";
                editQuestionSubjectComboBox.Enabled = false;
                deleteSubjectComboBox.Text = "В базе данных нет ни одного предмета";
                deleteSubjectComboBox.Enabled = false;
                deleteThemeSubjectComboBox.Text = "В базе данных нет ни одного предмета";
                deleteThemeSubjectComboBox.Enabled = false;
                deleteQuestionSubjectComboBox.Text = "В базе данных нет ни одного предмета";
                deleteQuestionSubjectComboBox.Enabled = false;
            }
        }
        // Функцяи загрузки тем в определенный выпадающий список
        private void UpdateThemes(Subject subject, ComboBox comboBox) {
            List<Theme> themes = DatabaseHelper.GetThemes(subject.Id);
            comboBox.Items.Clear();
            if (themes.Count != 0) {
                foreach (var theme in themes) {
                    comboBox.Items.Add(theme);
                }
                comboBox.Enabled = true;
            } else {
                comboBox.Text = "Нет тем, связанных с выбранным предметом";
                comboBox.Enabled = false;
            }
        }
        // Функция загрузки вопросов в определенный выпадающий список
        private void UpdateQuestions(Theme theme, ComboBox comboBox) {
            List<Question> questions = DatabaseHelper.GetQuestionsByTestAndSubjectId(theme.SubjectId, theme.Id);
            comboBox.Text = "";
            comboBox.Items.Clear();
            if (questions.Count != 0) {
                foreach (var question in questions) {
                    comboBox.Items.Add(question);
                }
                comboBox.Enabled = true;
            } else {
                comboBox.Text = "Нет вопросов, связанных с выбранной темой";
                comboBox.Enabled = false;
            }
        }
        // Функция очистки вкладки добавления
        private void ClearAddTab() {
            ClearAddSubject();
            ClearAddTheme();
            ClearAddQuestion();
            addQuestionThemeComboBox.SelectedIndex = -1;
            addQuestionThemeComboBox.Enabled = false;
        }
        // Функция чистки блока добавления предмета
        private void ClearAddSubject() {
            addSubjectTextBox.Text = "";
            UpdateSubjects();
        }
        // Чистка блока добавления вопроса
        private void ClearAddTheme() {
            addThemeTextBox.Text = "";
            addThemeTextBox.Enabled = false;
            addThemeButton.Enabled = false;
            // Обновляем вопросы
            UpdateSubjects();
        }
        // Очистка блока добавления вопроса
        private void ClearAddQuestion(){
            // Чистим поля ввода
            addQuestionTextBox.Text = "";
            addFillingTextBox.Text = "";
            addSingleChoiceFirstOptionTextBox.Text = "";
            addSingleChoiceSecondOptionTextBox.Text = "";
            addSingleChoiceThirdOptionTextBox.Text = "";
            addSingleChoiceFourthOptionTextBox.Text = "";
            addMultipleChoiceFirstOptionTextBox.Text = "";
            addMultipleChoiceSecondOptionTextBox.Text = "";
            addMultipleChoiceThirdOptionTextBox.Text = "";
            addMultipleChoiceFourthOptionTextBox.Text = "";
            // Делаем их неактивными
            addSingleChoiceFirstOptionRadioButton.Checked = false;
            addSingleChoiceSecondOptionRadioButton.Checked = false;
            addSingleChoiceThirdOptionRadioButton.Checked = false;
            addSingleChoiceFourthOptionRadioButton.Checked = false;
            addMultipleChioceFirstOptionCheckBox.Checked = false;
            addMultipleChioceSecondOptionCheckBox.Checked = false;
            addMultipleChioceThirdOptionCheckBox.Checked = false;
            addMultipleChioceFourthOptionCheckBox.Checked = false;
            addTypeComboBox.SelectedIndex = 0;
        }
        // Функция очистки вкладки редактирования
        private void ClearEditTab() {
            editThemeComboBox.Items.Clear();
            editThemeComboBox.Enabled = false;
            editQuestionThemeComboBox.Items.Clear();
            editQuestionThemeComboBox.Enabled = false;
            editQuestionComboBox.SelectedIndex = -1;
            editQuestionComboBox.Items.Clear();
            editQuestionComboBox.Enabled = false;
            editThemeTextBox.Text = "";
            editQuestionTextBox.Text = "";
            editThemeButton.Enabled = false;
            editQuestionThemeComboBox.Enabled = false;
            editFillingTextBox.Text = "";            
            editSingleChoiceFirstOptionTextBox.Text = "";
            editSingleChoiceSecondOptionTextBox.Text = "";
            editSingleChoiceThirdOptionTextBox.Text = "";
            editSingleChoiceFourthOptionTextBox.Text = "";
            editMultipleChoiceFirstOptionTextBox.Text = "";
            editMultipleChoiceSecondOptionTextBox.Text = "";
            editMultipleChoiceThirdOptionTextBox.Text = "";
            editMultipleChoiceFourthOptionTextBox.Text = "";
            editSingleChoiceFirstOptionRadioButton.Checked = false;
            editSingleChoiceSecondOptionRadioButton.Checked = false;
            editSingleChoiceThirdOptionRadioButton.Checked = false;
            editSingleChoiceFourthOptionRadioButton.Checked = false;
            editMultipleChoiceFirstOptionCheckBox.Checked = false;
            editMultipleChoiceSecondOptionCheckBox.Checked = false;
            editMultipleChoiceThirdOptionCheckBox.Checked = false;
            editMultipleChoiceFourthOptionCheckBox.Checked = false;
            editTypeComboBox.SelectedIndex = -1;
            UpdateSubjects();
        }
        // Функция очистки вкладки удаления
        private void ClearDeleteTab() {
            deleteThemeComboBox.Items.Clear();
            deleteThemeComboBox.Enabled = false;
            deleteQuestionThemeComboBox.Items.Clear();
            deleteQuestionThemeComboBox.Enabled = false;
            deleteQuestionComboBox.Items.Clear();
            deleteQuestionComboBox.Enabled = false;
            deleteThemeSubjectComboBox.SelectedIndex = -1;
            deleteThemeComboBox.SelectedIndex = -1;
            deleteThemeComboBox.Enabled = false;
            deleteQuestionSubjectComboBox.SelectedIndex = -1;
            deleteQuestionThemeComboBox.SelectedIndex = -1;
            deleteQuestionThemeComboBox.Enabled = false;
            deleteQuestionComboBox.SelectedIndex = -1;
            deleteQuestionComboBox.Enabled = false;
            UpdateSubjects();
        }
        // Функция очистки блока изменения предмета 
        private void ClearEditSubject() {
            editSubjectTextBox.Text = "";
            UpdateSubjects();
        }
        // Функция очистки полей ввода при редактировании вопроса
        // Нужно не только очистить все поля, но и сделать их неактивными
        private void ClearEditQuestion() {
            editTypeComboBox.SelectedIndex = 0;
            editTypeComboBox.Enabled = false;
            editFillingTextBox.Text = "";
            editFillingTextBox.Enabled = false;
            editSingleChoiceFirstOptionTextBox.Text = "";
            editSingleChoiceFirstOptionTextBox.Enabled = false;
            editSingleChoiceSecondOptionTextBox.Text = "";
            editSingleChoiceSecondOptionTextBox.Enabled = false;
            editSingleChoiceThirdOptionTextBox.Text = "";
            editSingleChoiceThirdOptionTextBox.Enabled = false;
            editSingleChoiceFourthOptionTextBox.Text = "";
            editSingleChoiceFourthOptionTextBox.Enabled = false;
            editMultipleChoiceFirstOptionTextBox.Text = "";
            editMultipleChoiceFirstOptionTextBox.Enabled = false;
            editMultipleChoiceSecondOptionTextBox.Text = "";
            editMultipleChoiceSecondOptionTextBox.Enabled = false;
            editMultipleChoiceThirdOptionTextBox.Text = "";
            editMultipleChoiceThirdOptionTextBox.Enabled = false;
            editMultipleChoiceFourthOptionTextBox.Text = "";
            editMultipleChoiceFourthOptionTextBox.Enabled = false;
            editSingleChoiceFirstOptionRadioButton.Checked = false;
            editSingleChoiceFirstOptionRadioButton.Enabled = false;
            editSingleChoiceSecondOptionRadioButton.Checked = false;
            editSingleChoiceSecondOptionRadioButton.Enabled = false;
            editSingleChoiceThirdOptionRadioButton.Checked = false;
            editSingleChoiceThirdOptionRadioButton.Enabled = false;
            editSingleChoiceFourthOptionRadioButton.Checked = false;
            editSingleChoiceFourthOptionRadioButton.Enabled = false;
            editMultipleChoiceFirstOptionCheckBox.Checked = false;
            editMultipleChoiceFirstOptionCheckBox.Enabled = false;
            editMultipleChoiceSecondOptionCheckBox.Checked = false;
            editMultipleChoiceSecondOptionCheckBox.Enabled = false;
            editMultipleChoiceThirdOptionCheckBox.Checked = false;
            editMultipleChoiceThirdOptionCheckBox.Enabled = false;
            editMultipleChoiceFourthOptionCheckBox.Checked = false;
            editMultipleChoiceFourthOptionCheckBox.Enabled = false;
        }
        // В блоке добавления темы при выборе предмета делаем доступным поле ввода новой темы
        private void addThemeSubjectComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            addThemeTextBox.Enabled = true;
            addThemeTextBox.Text = "";
            addThemeButton.Enabled = true;
        }
        // В блоке добавления вопроса при выборе предмета нужно хаполнить темы
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) {
            UpdateThemes(addQuestionSubjectComboBox.SelectedItem as Subject, addQuestionThemeComboBox);
        }
        // При выборе темы в блоке добавления нужно активировать поля ввода
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e) {
            addQuestionThemeComboBox.Enabled = addQuestionTextBox.Enabled = 
                addSingleChoiceFirstOptionTextBox.Enabled = addSingleChoiceSecondOptionTextBox.Enabled = 
                addSingleChoiceThirdOptionTextBox.Enabled = addSingleChoiceFourthOptionTextBox.Enabled = 
                addSingleChoiceFirstOptionRadioButton.Enabled = addSingleChoiceSecondOptionRadioButton.Enabled = 
                addSingleChoiceThirdOptionRadioButton.Enabled = addSingleChoiceFourthOptionRadioButton.Enabled = 
                addMultipleChioceFirstOptionCheckBox.Enabled = addMultipleChioceSecondOptionCheckBox.Enabled = 
                addMultipleChioceThirdOptionCheckBox.Enabled = addMultipleChioceFourthOptionCheckBox.Enabled = 
                addMultipleChoiceFirstOptionTextBox.Enabled = addMultipleChoiceSecondOptionTextBox.Enabled = 
                addMultipleChoiceThirdOptionTextBox.Enabled = addMultipleChoiceFourthOptionTextBox.Enabled = 
                addFillingTextBox.Enabled = addQuestionButton.Enabled = 
                addTypeComboBox.Enabled = addQuestionThemeComboBox.SelectedIndex != -1;
            addTypeComboBox.SelectedIndex = 0;
        }
        // Кнопка добавления предмета
        private void addSubjectButton_Click(object sender, EventArgs e) {
            if (addSubjectTextBox.Text != "") {
                Subject subject = new Subject() {
                    Name = addSubjectTextBox.Text,
                };
                // Добавляем предмет
                DatabaseHelper.InsertSubject(subject);
                // Чистим блок добавления предмета
                ClearAddSubject();
            } else { MessageBox.Show("Заполните поле!");
            }
        }
        // Кнопка создания новой темы
        private void button2_Click(object sender, EventArgs e) {
            if (addThemeTextBox.Text != "") {
                Subject subject = addThemeSubjectComboBox.SelectedItem as Subject;
                // Конфигурируем тему
                Theme theme = new Theme()
                {
                    SubjectId = subject.Id,
                    Name = addThemeTextBox.Text,
                };
                // Добавляем тему
                DatabaseHelper.InsertTheme(theme);
                // Чистим блок добавления темы
                ClearAddTheme();
            } else {
                MessageBox.Show("Заполните поле!");
            }
        }
        // Поле ввода названия нового предмета
        private void textBox1_TextChanged(object sender, EventArgs e) {
            addQuestionThemeComboBox.Enabled = false;
            addSubjectButton.Enabled = true;
        }
        // поле изменения темы при добавлении
        private void textBox2_TextChanged(object sender, EventArgs e) => addThemeButton.Enabled = true;
        // Функция заполнения списка вариантов ответа для вопроса
        private List<Option> ConfigureAddOptions() {
            List<Option> options = new List<Option>();
            Models.Type type = (Models.Type)addTypeComboBox.SelectedIndex + 1;
            switch (type) {
                // Вопрос на одиночный ответ
                case Models.Type.single: {      
                        // Первый вариант ответа
                        Option option = new Option() {
                            option = addSingleChoiceFirstOptionTextBox.Text,
                            isRight = addSingleChoiceFirstOptionRadioButton.Checked,
                        };
                        options.Add(option);
                        // Второй вариант ответа
                        option = new Option() {
                            option = addSingleChoiceSecondOptionTextBox.Text,
                            isRight = addSingleChoiceSecondOptionRadioButton.Checked,
                        };
                        options.Add(option);
                        // Третий вариант ответа
                        option = new Option() {
                            option = addSingleChoiceThirdOptionTextBox.Text,
                            isRight = addSingleChoiceThirdOptionRadioButton.Checked,
                        };
                        options.Add(option);
                        // Четвертый вариант ответа
                        option = new Option() {
                            option = addSingleChoiceFourthOptionTextBox.Text,
                            isRight = addSingleChoiceFourthOptionRadioButton.Checked,
                        };
                        options.Add(option);
                        break;
                    }
                //Вопрос на множественный ответ
                case Models.Type.multiple: {  
                        // Первый вариант ответа
                        Option option = new Option() {
                            option = addMultipleChoiceFirstOptionTextBox.Text,
                            isRight = addMultipleChioceFirstOptionCheckBox.Checked,
                        };
                        options.Add(option);
                        // Второй вариант ответа
                        option = new Option() {
                            option = addMultipleChoiceSecondOptionTextBox.Text,
                            isRight = addMultipleChioceSecondOptionCheckBox.Checked,
                        };
                        options.Add(option);
                        // Третий вариант ответа
                        option = new Option() {
                            option = addMultipleChoiceThirdOptionTextBox.Text,
                            isRight = addMultipleChioceThirdOptionCheckBox.Checked,
                        };
                        options.Add(option);
                        // Четвертый вариант ответа
                        option = new Option() {
                            option = addMultipleChoiceFourthOptionTextBox.Text,
                            isRight = addMultipleChioceFourthOptionCheckBox.Checked,
                        };
                        options.Add(option);
                        break;
                    }
                // Вопрос на заполнение
                case Models.Type.filling: {     
                        // Единственный варивнт ответа
                        Option option = new Option() {
                            option = addFillingTextBox.Text,
                            isRight = true,
                        };
                        options.Add(option);
                        break;
                    }
            }
            return options;
        }
        // Функция проверки заполненности полей
        private bool CheckFilledOptions() {
            Models.Type type = (Models.Type)addTypeComboBox.SelectedIndex + 1;
            // В зависимости от типа вопроса проверяем разные поля
            switch (type) {
                case Models.Type.single:{
                        if ((addSingleChoiceFirstOptionRadioButton.Checked || addSingleChoiceSecondOptionRadioButton.Checked || addSingleChoiceThirdOptionRadioButton.Checked || addSingleChoiceFourthOptionRadioButton.Checked) 
                            && (addSingleChoiceFirstOptionTextBox.Text != "" && addSingleChoiceSecondOptionTextBox.Text != "" && addSingleChoiceThirdOptionTextBox.Text != "" && addSingleChoiceFourthOptionTextBox.Text != "")) {
                            return true;
                        }
                        return false;
                    }
                case Models.Type.multiple:{
                        if ((addMultipleChioceFirstOptionCheckBox.Checked || addMultipleChioceSecondOptionCheckBox.Checked || addMultipleChioceThirdOptionCheckBox.Checked || addMultipleChioceFourthOptionCheckBox.Checked) 
                            && (addMultipleChoiceFirstOptionTextBox.Text != "" && addMultipleChoiceSecondOptionTextBox.Text != "" && addMultipleChoiceThirdOptionTextBox.Text != "" && addMultipleChoiceFourthOptionTextBox.Text != "")) {
                            return true;
                        }
                        return false;
                    }
                case Models.Type.filling: {
                        if(addFillingTextBox.Text != "") {
                            return true;
                        }
                        return false;
                    }
            }
            return false;
        }
        // Кнопка добваления вопроса
        private void button3_Click(object sender, EventArgs e) {
            if (addQuestionTextBox.Text != "" && CheckFilledOptions()) {
                string questionName = addQuestionTextBox.Text;
                // Конфигурируем вопрос
                List<Option> options = ConfigureAddOptions();
                Theme theme = addQuestionThemeComboBox.SelectedItem as Theme;
                Models.Type type = (Models.Type)addTypeComboBox.SelectedIndex + 1; // Тип вопроса
                Question question = new Question() {
                    Id_subject = theme.SubjectId,
                    Id_theme = theme.Id,
                    Name = questionName,
                    Options = options,
                    Type = type,
                };
                // Добавляем в базу данных вопрос
                DatabaseHelper.InsertQuestion(question);
                // Очищаем блок добавления вопроса
                ClearAddQuestion();
            } else { 
                MessageBox.Show("Заполните все поля!");
            }
        }
        // кнопка удаления предмета
        private void deleteSubjectButton_Click(object sender, EventArgs e) {
            if (MessageBox.Show("Вы действительно хотите удалить этот предмет?", 
                                "Подтверждение удаления", 
                                MessageBoxButtons.YesNo) == DialogResult.Yes) {
                // Удаляем предмет
                Subject subject = deleteSubjectComboBox.SelectedItem as Subject;
                DatabaseHelper.DeleteSubjectById(subject.Id);
                deleteSubjectComboBox.Text = "";
                // Обновляем форму
                UpdateViews();
                deleteSubjectButton.Enabled = false;
            }
        }
        // Выбор предмета в блоке удаления темы
        private void deleteThemeSubjectComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            UpdateThemes(deleteThemeSubjectComboBox.SelectedItem as Subject, deleteThemeComboBox);
            deleteThemeComboBox.Enabled = deleteThemeSubjectComboBox.SelectedIndex != -1;
        }
        // Кнопка удаления темы
        private void deleteThemeButton_Click(object sender, EventArgs e) {
            if (MessageBox.Show("Вы действительно хотите удалить эту тему?", 
                                "Подтверждение удаления", 
                                MessageBoxButtons.YesNo) == DialogResult.Yes) {
                // Удаляем тему
                Theme theme = deleteThemeComboBox.SelectedItem as Theme;
                DatabaseHelper.DeleteThemeById(theme.Id);
                UpdateThemes(deleteThemeSubjectComboBox.SelectedItem as Subject, deleteThemeComboBox);
                deleteThemeComboBox.Text = "";
                // Обновляем форму
                UpdateViews();
                deleteThemeButton.Enabled = false;
            }
        }
        // Событие выбора предмета в блоке удаления вопроса
        private void deleteQuestionSubjectComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            deleteQuestionComboBox.Items.Clear();
            deleteQuestionComboBox.Enabled = false;
            // заполняем темами выпадающий список
            UpdateThemes(deleteQuestionSubjectComboBox.SelectedItem as Subject, deleteQuestionThemeComboBox);
        }
        // Событие выбора темы в блоке удаления вопроса
        private void deleteQuestionThemeComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            // Заполняем вопросы
            if(deleteQuestionThemeComboBox.SelectedItem != null)
                UpdateQuestions(deleteQuestionThemeComboBox.SelectedItem as Theme, deleteQuestionComboBox);
        }
        // Кнопка удаления вопроса
        private void deleteQuestionButton_Click(object sender, EventArgs e) {
            // Если пользователь действительно хочет удалить вопрос
            if (MessageBox.Show("Вы действительно хотите удалить этот вопрос?", 
                                "Подтверждение удаления", 
                                MessageBoxButtons.YesNo) == DialogResult.Yes) {
                // Удаляем вопрос
                Question question = deleteQuestionComboBox.SelectedItem as Question;
                DatabaseHelper.DeleteQuestionById(question.Id);
                // Обновляем форму
                UpdateViews();
                deleteQuestionButton.Enabled = false;
            }
        }
        // Выпадающий список предметов в блоке изменения предметов
        private void editSubjectComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            Line = editSubjectComboBox.Text;
            editSubjectComboBox.Visible = false;
            groupBox4.Controls.Add(editSubjectTextBox);
            editSubjectTextBox.Text = Line;
            editSubjectTextBox.Visible = true;
            editSubjectTextBox.Location = editSubjectComboBox.Location;
            editSubjectButton.Enabled = true;
            editSubjectClearButton.Enabled = true;
        }
        // Кнопка изменения предмета
        private void editSubjectButton_Click(object sender, EventArgs e) {
            if(editSubjectTextBox.Text != "") {
                // Изменяем предмет
                Subject subject = editSubjectComboBox.SelectedItem as Subject;
                subject.Name = editSubjectTextBox.Text;
                DatabaseHelper.UpdateSubject(subject);
                // чистим поля
                editSubjectTextBox.Text = "";
                editSubjectComboBox.Visible = true;
                editSubjectComboBox.Text = "";
                editSubjectComboBox.SelectedText = "";
                groupBox4.Controls.Remove(editSubjectTextBox);
                editSubjectTextBox.Visible = false;
                editSubjectButton.Enabled = false;
                editSubjectClearButton.Enabled = false;
                ClearEditSubject();
            } else {
                MessageBox.Show("Заполните поле!");
            }
        }
        // Кнопка очистки блока изменения предмета
        private void editSubjectClearButton_Click(object sender, EventArgs e) {
            editSubjectTextBox.Text = "";
            editSubjectComboBox.Visible = true;
            groupBox4.Controls.Remove(editSubjectTextBox);
            editSubjectTextBox.Visible = false;
            editSubjectButton.Enabled = false;
            editSubjectClearButton.Enabled = false;
            UpdateViews();
        }
        // Событие выбора предмета в блоке изменения темы
        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e) {
            UpdateThemes(editThemeSubjectComboBox.SelectedItem as Subject, editThemeComboBox);
        }
        // При выборе в блоке изменения темы изменяем форму
        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e) {
            // Скрываем выпадающее меню 
            // и отображаем текстовое поле для изменения
            editThemeComboBox.Visible = false;
            groupBox5.Controls.Add(editThemeTextBox);
            editThemeTextBox.Visible = true;
            editThemeTextBox.Text = (editThemeComboBox.SelectedItem as Theme)?.Name;
            editThemeTextBox.Location = editThemeComboBox.Location;
            editThemeButton.Enabled = true;
            editThemeClearButton.Enabled = true;
        }
        // Кнопка изменения темы
        private void button10_Click(object sender, EventArgs e) {
            if(editThemeTextBox.Text != "") {
                // Изменяем тему
                Theme theme = editThemeComboBox.SelectedItem as Theme;
                theme.Name = editThemeTextBox.Text;
                DatabaseHelper.UpdateTheme(theme);
                UpdateThemes(editThemeSubjectComboBox.SelectedItem as Subject, editThemeComboBox);
                // И очищаем поля
                editThemeTextBox.Text = "";
                editThemeComboBox.Visible = true;
                editThemeComboBox.SelectedText = "";
                groupBox5.Controls.Remove(editThemeTextBox);
                editThemeTextBox.Visible = false;
                editThemeButton.Enabled = false;
                editThemeClearButton.Enabled = false;
            } else {
                // Если в поле названия ничего нет - выдаём предупреждение
                MessageBox.Show("Заполните поле!");
            }
        }
        // Кнопка очистки темы при редактировании
        private void button11_Click(object sender, EventArgs e) {
            UpdateThemes(editThemeSubjectComboBox.SelectedItem as Subject, editThemeComboBox);
            editThemeTextBox.Text = "";
            editThemeComboBox.Visible = true;
            editThemeComboBox.SelectedText = "";
            groupBox5.Controls.Remove(editThemeTextBox);
            editThemeTextBox.Visible = false;
            editThemeButton.Enabled = false;
            editThemeClearButton.Enabled = false;
        }
        // При выборе предмета во время редактирования вопроса меняем форму редактирвоания вопроса
        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e) {
            editQuestionComboBox.SelectedIndex = -1;
            editQuestionComboBox.Enabled = false;
            UpdateThemes(editQuestionSubjectComboBox.SelectedItem as Subject, editQuestionThemeComboBox);
        }
        // При выборе темы во время редактирования изменяем выпадающий список вопроса
        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e) {
            editQuestionComboBox.SelectedIndex = -1;
            UpdateQuestions(editQuestionThemeComboBox.SelectedItem as Theme, editQuestionComboBox);
        }
        // Конфигурируем варианты ответов при редактировании
        private void ConfigureEditOptions(Models.Type type, List<Option> options) {
            editSingleGroupBox.Visible = false;
            editMultipleGroupBox.Visible = false;
            editFillingGroupBox.Visible = false;
            DisableAllEditFields();
            switch (type) {
                case Models.Type.single: {
                        editSingleGroupBox.Visible = true;
                        editSingleChoiceFirstOptionTextBox.Text = options[0];
                        editSingleChoiceFirstOptionRadioButton.Checked = options[0].isRight;
                        editSingleChoiceSecondOptionTextBox.Text = options[1];
                        editSingleChoiceSecondOptionRadioButton.Checked = options[1].isRight;
                        editSingleChoiceThirdOptionTextBox.Text = options[2];
                        editSingleChoiceThirdOptionRadioButton.Checked = options[2].isRight;
                        editSingleChoiceFourthOptionTextBox.Text = options[3];
                        editSingleChoiceFourthOptionRadioButton.Checked = options[3].isRight;
                        editSingleChoiceFirstOptionTextBox.Enabled =
                        editSingleChoiceFirstOptionRadioButton.Enabled =
                        editSingleChoiceSecondOptionTextBox.Enabled =
                        editSingleChoiceSecondOptionRadioButton.Enabled =
                        editSingleChoiceThirdOptionTextBox.Enabled =
                        editSingleChoiceThirdOptionRadioButton.Enabled =
                        editSingleChoiceFourthOptionTextBox.Enabled =
                        editSingleChoiceFourthOptionRadioButton.Enabled = true;
                        return;
                    }
                case Models.Type.multiple: {
                        editMultipleGroupBox.Visible = true;
                        editMultipleChoiceFirstOptionTextBox.Text = options[0];
                        editMultipleChoiceFirstOptionCheckBox.Checked = options[0].isRight;
                        editMultipleChoiceSecondOptionTextBox.Text = options[1];
                        editMultipleChoiceSecondOptionCheckBox.Checked = options[1].isRight;
                        editMultipleChoiceThirdOptionTextBox.Text = options[2];
                        editMultipleChoiceThirdOptionCheckBox.Checked = options[2].isRight;
                        editMultipleChoiceFourthOptionTextBox.Text = options[3];
                        editMultipleChoiceFourthOptionCheckBox.Checked = options[3].isRight;
                        editMultipleChoiceFirstOptionTextBox.Enabled =
                        editMultipleChoiceFirstOptionCheckBox.Enabled =
                        editMultipleChoiceSecondOptionTextBox.Enabled =
                        editMultipleChoiceSecondOptionCheckBox.Enabled =
                        editMultipleChoiceThirdOptionTextBox.Enabled =
                        editMultipleChoiceThirdOptionCheckBox.Enabled =
                        editMultipleChoiceFourthOptionTextBox.Enabled =
                        editMultipleChoiceFourthOptionCheckBox.Enabled = true;
                        return;
                    }
                case Models.Type.filling: {
                        editFillingGroupBox.Visible = true;
                        editFillingTextBox.Text = options[0];
                        editFillingTextBox.Enabled = true;
                        return;
                    }
                default:
                    break;
            }
        }
        // Событие изменения выбора вопроса в выпадающем списке
        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e) {
            if(editQuestionComboBox.SelectedIndex != -1) {
                editQuestionComboBox.Visible = false;
                groupBox6.Controls.Add(editQuestionTextBox);
                editQuestionTextBox.Visible = true;
                editQuestionTextBox.Text = (editQuestionComboBox.SelectedItem as Question).Name;
                editQuestionTextBox.Location = editQuestionComboBox.Location;
                editQuestionButton.Enabled = true;
                editQuestionClearButton.Enabled = true;
                editTypeComboBox.Enabled = true;
                // Сохраняем выбранный вопрос
                CurrentQuestion = editQuestionComboBox.SelectedItem as Question;
                // Изменяем текст
                editQuestionTextBox.Text = CurrentQuestion.Name;
                // В зависимости от типа вопроса выбираем тип в выпадащем списке
                switch (CurrentQuestion.Type) {
                    case Models.Type.single:
                        editTypeComboBox.SelectedIndex = 0;
                        break;
                    case Models.Type.multiple:
                        editTypeComboBox.SelectedIndex = 1;
                        break;
                    case Models.Type.filling:
                        editTypeComboBox.SelectedIndex = 2;
                        break;
                    default:
                        break;
                }
                ConfigureEditOptions(CurrentQuestion.Type, CurrentQuestion.Options);
            } else {
                editQuestionTextBox.Text = "";
                editQuestionComboBox.Visible = true;
                editQuestionComboBox.Text = "";
                editQuestionComboBox.SelectedText = "";
                groupBox6.Controls.Remove(editQuestionTextBox);
                editQuestionTextBox.Visible = false;
                editQuestionButton.Enabled = false;
                editQuestionClearButton.Enabled = false;
                CurrentQuestion = null;
                ClearEditQuestion();
                editTypeComboBox.SelectedIndex = 0;
            }
        }
        // Функция изменения вариантов ответа для вопроса
        private List<Option> GettingEditOptions(Models.Type type, List<Option> LastOptions)
        {
            List<Option> options = LastOptions;
            switch (type) {
                case Models.Type.single: {
                        options[0].option = editSingleChoiceFirstOptionTextBox.Text;
                        options[0].isRight = editSingleChoiceFirstOptionRadioButton.Checked;
                        options[1].option = editSingleChoiceSecondOptionTextBox.Text;
                        options[1].isRight = editSingleChoiceSecondOptionRadioButton.Checked;
                        options[2].option = editSingleChoiceThirdOptionTextBox.Text;
                        options[2].isRight = editSingleChoiceThirdOptionRadioButton.Checked;
                        options[3].option = editSingleChoiceFourthOptionTextBox.Text;
                        options[3].isRight = editSingleChoiceFourthOptionRadioButton.Checked;
                        break;
                    }
                case Models.Type.multiple: {
                        options[0].option = editMultipleChoiceFirstOptionTextBox.Text;
                        options[0].isRight = editMultipleChoiceFirstOptionCheckBox.Checked;
                        options[1].option = editMultipleChoiceSecondOptionTextBox.Text;
                        options[1].isRight = editMultipleChoiceSecondOptionCheckBox.Checked;
                        options[2].option = editMultipleChoiceThirdOptionTextBox.Text;
                        options[2].isRight = editMultipleChoiceThirdOptionCheckBox.Checked;
                        options[3].option = editMultipleChoiceFourthOptionTextBox.Text;
                        options[3].isRight = editMultipleChoiceFourthOptionCheckBox.Checked;
                        break;
                    }
                case Models.Type.filling: {
                        options[0].option = editFillingTextBox.Text;
                        options[1].isRight = true;
                        break;
                    }
            }
            return options;
        }
        // Кнопка изменения вопроса
        private void button12_Click(object sender, EventArgs e)
        {
            // проверяем заполнены ли поля
            if(editQuestionTextBox.Text != "" && CheckEditFieldsFill(CurrentQuestion.Type))
            {
                // Изменяем вопрос. Задаём новый вопрос
                CurrentQuestion.Name = editQuestionTextBox.Text;
                // Выбираем новые варианты вопроса
                CurrentQuestion.Options = GettingEditOptions(CurrentQuestion.Type, CurrentQuestion.Options);
                // и тип
                CurrentQuestion.Type = (Models.Type) editTypeComboBox.SelectedIndex + 1;
                DatabaseHelper.UpdateQuestion(CurrentQuestion);
                CurrentQuestion = null;
                editQuestionComboBox.SelectedIndex = -1;
                UpdateQuestions(editQuestionThemeComboBox.SelectedItem as Theme, editQuestionComboBox);
            } else {
                // Если хоть одно поле не заполнено, выдать предупреждение
                MessageBox.Show("Заполните все поля!");
            }   
        }
        // Функция проверки заполненности полей вопроса при редактировании
        private bool CheckEditFieldsFill(Models.Type type)
        {
            switch (type)
            {
                case Models.Type.single:
                    return (editSingleChoiceFirstOptionTextBox.Text != "" && editSingleChoiceSecondOptionTextBox.Text != "" 
                        && editSingleChoiceThirdOptionTextBox.Text != "" && editSingleChoiceFourthOptionTextBox.Text != "" &&
                        (editSingleChoiceFirstOptionRadioButton.Checked || editSingleChoiceSecondOptionRadioButton.Checked || 
                        editSingleChoiceThirdOptionRadioButton.Checked || editSingleChoiceFourthOptionRadioButton.Checked));
                case Models.Type.multiple:
                    return (editMultipleChoiceFirstOptionTextBox.Text != "" && editMultipleChoiceSecondOptionTextBox.Text != ""
                        && editMultipleChoiceThirdOptionTextBox.Text != "" && editMultipleChoiceFourthOptionTextBox.Text != "" &&
                        (editMultipleChoiceFirstOptionCheckBox.Checked || editMultipleChoiceSecondOptionCheckBox.Checked ||
                        editMultipleChoiceThirdOptionCheckBox.Checked || editMultipleChoiceFourthOptionCheckBox.Checked));
                case Models.Type.filling:
                    return editFillingTextBox.Text != "";
            }
            return false;
        }
        // Кнопка очистки полей вопроса при редактировании
        private void button4_Click(object sender, EventArgs e) {
            editQuestionComboBox.SelectedIndex = -1;
            CurrentQuestion = null;
        }
        // выпадающий список типа вопроса при добавлении
        private void comboBox16_SelectedIndexChanged(object sender, EventArgs e){
            addSingleChoiceGroupBox.Visible = addTypeComboBox.SelectedIndex == 0;   // Одиночный выбор
            addMultipleChoiceGroupBox.Visible = addTypeComboBox.SelectedIndex == 1; // Множественный выбор
            fillingGroupBox.Visible = addTypeComboBox.SelectedIndex == 2;        // Заполнение
        }

        // Деактивация всех полей на вкладке редактирования в блоке вопроса
        private void DisableAllEditFields() {
            editSingleChoiceFirstOptionTextBox.Enabled = 
            editSingleChoiceFirstOptionRadioButton.Enabled = 
            editSingleChoiceSecondOptionTextBox.Enabled = 
            editSingleChoiceSecondOptionRadioButton.Enabled = 
            editSingleChoiceThirdOptionTextBox.Enabled = 
            editSingleChoiceThirdOptionRadioButton.Enabled = 
            editSingleChoiceFourthOptionTextBox.Enabled = 
            editSingleChoiceFourthOptionRadioButton.Enabled = false;
            editMultipleChoiceFirstOptionTextBox.Enabled = 
            editMultipleChoiceFirstOptionCheckBox.Enabled = 
            editMultipleChoiceSecondOptionTextBox.Enabled = 
            editMultipleChoiceSecondOptionCheckBox.Enabled = 
            editMultipleChoiceThirdOptionTextBox.Enabled = 
            editMultipleChoiceThirdOptionCheckBox.Enabled = 
            editMultipleChoiceFourthOptionTextBox.Enabled = 
            editMultipleChoiceFourthOptionCheckBox.Enabled = false;
            editFillingTextBox.Enabled = false;
        }
        // Когда сменился тип изменяемого вопроса нужно перерисовать форму
        private void editTypeComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            // Скрываем все поля
            editSingleGroupBox.Visible = false; 
            editMultipleGroupBox.Visible = false;
            editFillingGroupBox.Visible = false;
            if(CurrentQuestion != null) {
                Models.Type type = (Models.Type)editTypeComboBox.SelectedIndex + 1;
                CurrentQuestion.Type = type;
                var options = CurrentQuestion.Options;
                DisableAllEditFields();
                switch (type) {
                    // если одиночный тип вопроса
                    case Models.Type.single: {
                            // Делаем видимыми элементы управления для одиночного типа вопроса
                            editSingleGroupBox.Visible = true;
                            try {
                                editSingleChoiceFirstOptionTextBox.Text = options[0];
                                editSingleChoiceFirstOptionRadioButton.Checked = options[0].isRight;
                                editSingleChoiceSecondOptionTextBox.Text = options[1];
                                editSingleChoiceSecondOptionRadioButton.Checked = options[1].isRight;
                                editSingleChoiceThirdOptionTextBox.Text = options[2];
                                editSingleChoiceThirdOptionRadioButton.Checked = options[2].isRight;
                                editSingleChoiceFourthOptionTextBox.Text = options[3];
                                editSingleChoiceFourthOptionRadioButton.Checked = options[3].isRight;
                            }
                            catch (IndexOutOfRangeException) { }
                            // Элементы активируем
                            editSingleChoiceFirstOptionTextBox.Enabled =
                            editSingleChoiceFirstOptionRadioButton.Enabled =
                            editSingleChoiceSecondOptionTextBox.Enabled =
                            editSingleChoiceSecondOptionRadioButton.Enabled =
                            editSingleChoiceThirdOptionTextBox.Enabled =
                            editSingleChoiceThirdOptionRadioButton.Enabled =
                            editSingleChoiceFourthOptionTextBox.Enabled =
                            editSingleChoiceFourthOptionRadioButton.Enabled = true;
                            return;
                        }
                        // Если множественный тип вопроса
                    case Models.Type.multiple: {
                            // Делаем видимыми элементы управления для множественного типа вопроса 
                            editMultipleGroupBox.Visible = true;
                            try {
                                editMultipleChoiceFirstOptionTextBox.Text = options[0];
                                editMultipleChoiceFirstOptionCheckBox.Checked = options[0].isRight;
                                editMultipleChoiceSecondOptionTextBox.Text = options[1];
                                editMultipleChoiceSecondOptionCheckBox.Checked = options[1].isRight;
                                editMultipleChoiceThirdOptionTextBox.Text = options[2];
                                editMultipleChoiceThirdOptionCheckBox.Checked = options[2].isRight;
                                editMultipleChoiceFourthOptionTextBox.Text = options[3];
                                editMultipleChoiceFourthOptionCheckBox.Checked = options[3].isRight;
                            }
                            catch (IndexOutOfRangeException) { }
                            // Элементы активируем
                            editMultipleChoiceFirstOptionTextBox.Enabled =
                            editMultipleChoiceFirstOptionCheckBox.Enabled =
                            editMultipleChoiceSecondOptionTextBox.Enabled =
                            editMultipleChoiceSecondOptionCheckBox.Enabled =
                            editMultipleChoiceThirdOptionTextBox.Enabled =
                            editMultipleChoiceThirdOptionCheckBox.Enabled =
                            editMultipleChoiceFourthOptionTextBox.Enabled =
                            editMultipleChoiceFourthOptionCheckBox.Enabled = true;
                            return;
                        }
                        // если на заполнение
                    case Models.Type.filling: {
                            // Делаем видимыми элементы управления для типа вопроса "Заполнение"
                            editFillingGroupBox.Visible = true;
                            editFillingTextBox.Text = options[0];
                            editFillingTextBox.Enabled = true;
                            return;
                        }
                }
            } else {
                editSingleGroupBox.Visible = true;
            }
        }
        // После выбора удаляемого предмета делаем кнопку удаления предмета активной
        private void deleteSubjectComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            deleteSubjectButton.Enabled = deleteSubjectComboBox.SelectedItem != null;
        }
        // Кнопка очистки
        private void clearAddQuestionButton_Click(object sender, EventArgs e) {
            ClearAddQuestion();
        }
        // проверка заполненности всех полей
        private void isAddClearButtonVisible() {
            switch (addTypeComboBox.SelectedIndex) {
                case 0:
                    bool singleChoiceFill = addSingleChoiceFirstOptionTextBox.Text != "" ||
                                                    addSingleChoiceSecondOptionTextBox.Text != "" ||
                                                    addSingleChoiceThirdOptionTextBox.Text != "" ||
                                                    addSingleChoiceFourthOptionTextBox.Text != "";
                    clearAddQuestionButton.Enabled = singleChoiceFill;
                    break;
                case 1:
                    bool multipleChoiceFill = addMultipleChoiceFirstOptionTextBox.Text != "" ||
                                            addMultipleChoiceSecondOptionTextBox.Text != "" ||
                                            addMultipleChoiceThirdOptionTextBox.Text != "" ||
                                            addMultipleChoiceFourthOptionTextBox.Text != "";
                    clearAddQuestionButton.Enabled = multipleChoiceFill;
                    break;
                case 2:
                    bool fillingChoiceFill = addFillingTextBox.Text != "";
                    clearAddQuestionButton.Enabled = fillingChoiceFill;
                    break;
            }
            clearAddQuestionButton.Enabled = clearAddQuestionButton.Enabled || addQuestionTextBox.Text != "";
        }
        // Проверка элементов на заполненность
        private void CheckFilling(object sender, EventArgs e) {
            isAddClearButtonVisible();
        }
        // После выбора удаляемой темы делаем кнопку удаления темы активной 
        private void deleteThemeComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            deleteThemeButton.Enabled = deleteThemeComboBox.SelectedIndex != -1;
        }
        // После выбора удаляемого вопроса делаем кнопку удаления вопроса активной
        private void deleteQuestionComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            deleteQuestionButton.Enabled = deleteQuestionComboBox.SelectedIndex != -1;
        }
    }
}
