using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Server.Helpers;
using Server.Models;

namespace Server
{
    public partial class DataBase : Form
    {  
        string Line = "";
        Question CurrentQuestion;

        public DataBase()
        {
            InitializeComponent();
        }

        private void DataBase_Load(object sender, EventArgs e)
        {
            UpdateViews();
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            UpdateViews();
            if(TabControl.SelectedTab.Name == "deleteTab")
            {
                this.Height = 455;
                TabControl.Height = 397;
            }
            else
            {
                this.Height = 730;
                TabControl.Height = 675;
            }
        }

        private void UpdateViews()
        {
            ClearAddTab();
            ClearEditTab();
            ClearDeleteTab();

            UpdateSubjects();
        }

        private void UpdateSubjects()
        {
            addThemeSubjectComboBox.Items.Clear();
            addQuestionSubjectComboBox.Items.Clear();
            editSubjectComboBox.Items.Clear();
            editThemeSubjectComboBox.Items.Clear();
            editQuestionSubjectComboBox.Items.Clear();
            deleteSubjectComboBox.Items.Clear();
            deleteThemeSubjectComboBox.Items.Clear();
            deleteQuestionSubjectComboBox.Items.Clear();

            List<Subject> subjects = DatabaseHelper.GetSubjects();
            if(subjects.Count != 0)
            {
                foreach (Subject subject in subjects)
                {
                    addThemeSubjectComboBox.Items.Add(subject);
                    addQuestionSubjectComboBox.Items.Add(subject);
                    editSubjectComboBox.Items.Add(subject);
                    editThemeSubjectComboBox.Items.Add(subject);
                    editQuestionSubjectComboBox.Items.Add(subject);
                    deleteSubjectComboBox.Items.Add(subject);
                    deleteThemeSubjectComboBox.Items.Add(subject);
                    deleteQuestionSubjectComboBox.Items.Add(subject);
                }
            }
            else
            {
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

        private void UpdateThemes(Subject subject, ComboBox comboBox)
        {
            List<Theme> themes = DatabaseHelper.GetThemes(subject.Id);

            comboBox.SelectedIndex = -1;
            comboBox.Items.Clear();

            if (themes.Count != 0)
            {
                foreach (var theme in themes)
                {
                    comboBox.Items.Add(theme);
                }
                comboBox.Enabled = true;
            }
            else
            {
                comboBox.Text = "Нет тем, связанных с выбранным предметом";
                comboBox.Enabled = false;
            }
        }

        private void UpdateQuestions(Theme theme, ComboBox comboBox)
        {
            List<Question> questions = DatabaseHelper.GetQuestionsByTestAndSubjectId(theme.SubjectId, theme.Id);

            comboBox.Text = "";
            comboBox.Items.Clear();

            if (questions.Count != 0)
            {
                foreach (var question in questions)
                {
                    comboBox.Items.Add(question);
                }
                comboBox.Enabled = true;
            }
            else
            {
                comboBox.Text = "Нет вопросов, связанных с выбранной темой";
                comboBox.Enabled = false;
            }
        }

        private void ClearAddTab()
        {
            ClearAddSubject();
            ClearAddTheme();
            ClearAddQuestion();

            addQuestionThemeComboBox.SelectedIndex = -1;
            addQuestionThemeComboBox.Enabled = false;
        }

        private void ClearAddSubject()
        {
            addSubjectTextBox.Text = "";
            UpdateSubjects();
        }

        private void ClearAddTheme()
        {
            addThemeTextBox.Text = "";
            addThemeTextBox.Enabled = false;
            addThemeButton.Enabled = false;

            UpdateSubjects();
        }

        private void ClearAddQuestion()
        {
            addQuestionTextBox.Text = "";
            //addQuestionTextBox.Enabled = false;
            addFillingTextBox.Text = "";
            //addFillingTextBox.Enabled = false;

            addSingleChoiceFirstOptionTextBox.Text = "";
            //addSingleChoiceFirstOptionTextBox.Enabled = false;
            addSingleChoiceSecondOptionTextBox.Text = "";
            //addSingleChoiceSecondOptionTextBox.Enabled = false;
            addSingleChoiceThirdOptionTextBox.Text = "";
            //addSingleChoiceThirdOptionTextBox.Enabled = false;
            addSingleChoiceFourthOptionTextBox.Text = "";
            //addSingleChoiceFourthOptionTextBox.Enabled = false;

            addMultipleChoiceFirstOptionTextBox.Text = "";
            //addMultipleChoiceFirstOptionTextBox.Enabled = false;
            addMultipleChoiceSecondOptionTextBox.Text = "";
            //addMultipleChoiceSecondOptionTextBox.Enabled = false;
            addMultipleChoiceThirdOptionTextBox.Text = "";
            //addMultipleChoiceThirdOptionTextBox.Enabled = false;
            addMultipleChoiceFourthOptionTextBox.Text = "";
            //addMultipleChoiceFourthOptionTextBox.Enabled = false;

            addSingleChoiceFirstOptionRadioButton.Checked = false;
            //addSingleChoiceFirstOptionRadioButton.Enabled = false;
            addSingleChoiceSecondOptionRadioButton.Checked = false;
            //addSingleChoiceSecondOptionRadioButton.Enabled = false;
            addSingleChoiceThirdOptionRadioButton.Checked = false;
            //addSingleChoiceThirdOptionRadioButton.Enabled = false;
            addSingleChoiceFourthOptionRadioButton.Checked = false;
            //addSingleChoiceFourthOptionRadioButton.Enabled = false;

            addMultipleChioceFirstOptionCheckBox.Checked = false;
            //addMultipleChioceFirstOptionCheckBox.Enabled = false;
            addMultipleChioceSecondOptionCheckBox.Checked = false;
            //addMultipleChioceSecondOptionCheckBox.Enabled = false;
            addMultipleChioceThirdOptionCheckBox.Checked = false;
            //addMultipleChioceThirdOptionCheckBox.Enabled = false;
            addMultipleChioceFourthOptionCheckBox.Checked = false;
            //addMultipleChioceFourthOptionCheckBox.Enabled = false;

            addTypeComboBox.SelectedIndex = 0;
            //addTypeComboBox.Enabled = false;
        }

        private void ClearEditTab()
        {
            editThemeComboBox.Items.Clear();
            editThemeComboBox.Enabled = false;
            editQuestionThemeComboBox.Items.Clear();
            editQuestionThemeComboBox.Enabled = false;
            editQuestionComboBox.Items.Clear();
            editQuestionComboBox.Enabled = false;

            
            
            editThemeTextBox.Text = "";
            editQuestionTextBox.Text = "";
            editThemeButton.Enabled = false;
            editQuestionThemeComboBox.Enabled = false;
            
            editFillingTextBox.Text = "";
            //editFillingTextBox.Enabled = false;
            
            editSingleChoiceFirstOptionTextBox.Text = "";
            //editSingleChoiceFirstOptionTextBox.Enabled = false;
            editSingleChoiceSecondOptionTextBox.Text = "";
            //editSingleChoiceSecondOptionTextBox.Enabled = false;
            editSingleChoiceThirdOptionTextBox.Text = "";
            //editSingleChoiceThirdOptionTextBox.Enabled = false;
            editSingleChoiceFourthOptionTextBox.Text = "";
            //editSingleChoiceFourthOptionTextBox.Enabled = false;
            
            editMultipleChoiceFirstOptionTextBox.Text = "";
            //editMultipleChoiceFirstOptionTextBox.Enabled = false;
            editMultipleChoiceSecondOptionTextBox.Text = "";
            //editMultipleChoiceSecondOptionTextBox.Enabled = false;
            editMultipleChoiceThirdOptionTextBox.Text = "";
            //editMultipleChoiceThirdOptionTextBox.Enabled = false;
            editMultipleChoiceFourthOptionTextBox.Text = "";
            //editMultipleChoiceFourthOptionTextBox.Enabled = false;
            
            editSingleChoiceFirstOptionRadioButton.Checked = false;
            //editSingleChoiceFirstOptionRadioButton.Enabled = false;
            editSingleChoiceSecondOptionRadioButton.Checked = false;
            //editSingleChoiceSecondOptionRadioButton.Enabled = false;
            editSingleChoiceThirdOptionRadioButton.Checked = false;
            //editSingleChoiceThirdOptionRadioButton.Enabled = false;
            editSingleChoiceFourthOptionRadioButton.Checked = false;
            //editSingleChoiceFourthOptionRadioButton.Enabled = false;
            
            editMultipleChoiceFirstOptionCheckBox.Checked = false;
            //editMultipleChoiceFirstOptionCheckBox.Enabled = false;
            editMultipleChoiceSecondOptionCheckBox.Checked = false;
            //editMultipleChoiceSecondOptionCheckBox.Enabled = false;
            editMultipleChoiceThirdOptionCheckBox.Checked = false;
            //editMultipleChoiceThirdOptionCheckBox.Enabled = false;
            editMultipleChoiceFourthOptionCheckBox.Checked = false;
            //editMultipleChoiceFourthOptionCheckBox.Enabled = false;
            
            editTypeComboBox.SelectedIndex = -1;
            //editTypeComboBox.Enabled = false;

            UpdateSubjects();
        }

        private void ClearDeleteTab()
        {
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

        private void AddThemeClear()
        {
            addThemeTextBox.Enabled = true;
            addThemeTextBox.Text = "";
            addThemeButton.Enabled = true;
            isAddClearButtonVisible();
        }

        private void ClearEditSubject()
        {
            editSubjectTextBox.Text = "";
            UpdateSubjects();
        }

        private void ClearEditTheme()
        {
            editThemeTextBox.Text = "";
            editThemeComboBox.SelectedText = "";
        }

        private void ClearEditQuestion()
        {
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

        private void addThemeSubjectComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            addThemeTextBox.Enabled = true;
            addThemeTextBox.Text = "";
            addThemeButton.Enabled = true;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateThemes(addQuestionSubjectComboBox.SelectedItem as Subject, addQuestionThemeComboBox);
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
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

        private void addSubjectButton_Click(object sender, EventArgs e)
        {
            if (addSubjectTextBox.Text != "")
            {
                Subject subject = new Subject()
                {
                    Name = addSubjectTextBox.Text,
                };
                DatabaseHelper.InsertSubject(subject);

                ClearAddSubject();
            }
            else
            {
                MessageBox.Show("Заполните поле!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (addThemeTextBox.Text != "")
            {
                Subject subject = addThemeSubjectComboBox.SelectedItem as Subject;

                Theme theme = new Theme()
                {
                    SubjectId = subject.Id,
                    Name = addThemeTextBox.Text,
                };

                DatabaseHelper.InsertTheme(theme);

                ClearAddTheme();
            }
            else
            {
                MessageBox.Show("Заполните поле!");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            addThemeSubjectComboBox.Text = "Предмет";
            addQuestionSubjectComboBox.Text = "Предмет";
            addQuestionThemeComboBox.Text = "Тема";
            addQuestionThemeComboBox.Enabled = false;
            addSubjectButton.Enabled = true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            addThemeButton.Enabled = true;
        }

        private List<Option> ConfigureAddOptions()
        {
            List<Option> options = new List<Option>();

            Models.Type type = (Models.Type)addTypeComboBox.SelectedIndex + 1;

            switch (type)
            {
                    case Models.Type.single: {      // Вопрос на одиночный ответ
                        
                        // Первый вариант ответа
                        Option option = new Option()
                        {
                            option = addSingleChoiceFirstOptionTextBox.Text,
                            isRight = addSingleChoiceFirstOptionRadioButton.Checked,
                        };
                        options.Add(option);

                        // Второй вариант ответа
                        option = new Option()
                        {
                            option = addSingleChoiceSecondOptionTextBox.Text,
                            isRight = addSingleChoiceSecondOptionRadioButton.Checked,
                        };
                        options.Add(option);

                        // Третий вариант ответа
                        option = new Option()
                        {
                            option = addSingleChoiceThirdOptionTextBox.Text,
                            isRight = addSingleChoiceThirdOptionRadioButton.Checked,
                        };
                        options.Add(option);

                        // Четвертый вариант ответа
                        option = new Option()
                        {
                            option = addSingleChoiceFourthOptionTextBox.Text,
                            isRight = addSingleChoiceFourthOptionRadioButton.Checked,
                        };
                        options.Add(option);

                        break;
                    }
                    case Models.Type.multiple: {    //Вопрос на множественный ответ
                        
                        // Первый вариант ответа
                        Option option = new Option()
                        {
                            option = addMultipleChoiceFirstOptionTextBox.Text,
                            isRight = addMultipleChioceFirstOptionCheckBox.Checked,
                        };
                        options.Add(option);

                        // Второй вариант ответа
                        option = new Option()
                        {
                            option = addMultipleChoiceSecondOptionTextBox.Text,
                            isRight = addMultipleChioceSecondOptionCheckBox.Checked,
                        };
                        options.Add(option);

                        // Третий вариант ответа
                        option = new Option()
                        {
                            option = addMultipleChoiceThirdOptionTextBox.Text,
                            isRight = addMultipleChioceThirdOptionCheckBox.Checked,
                        };
                        options.Add(option);

                        // Четвертый вариант ответа
                        option = new Option()
                        {
                            option = addMultipleChoiceFourthOptionTextBox.Text,
                            isRight = addMultipleChioceFourthOptionCheckBox.Checked,
                        };
                        options.Add(option);

                        break;
                    }
                    case Models.Type.filling: {     // Вопрос на заполнение
                        
                        Option option = new Option()
                        {
                            option = addFillingTextBox.Text,
                        };
                        options.Add(option);

                        break;
                    }
            }
            return options;
        }

        private bool CheckFilledOptions()
        {
            Models.Type type = (Models.Type)addTypeComboBox.SelectedIndex + 1;

            switch (type)
            {
                case Models.Type.single:{
                        if ((addSingleChoiceFirstOptionRadioButton.Checked || addSingleChoiceSecondOptionRadioButton.Checked || addSingleChoiceThirdOptionRadioButton.Checked || addSingleChoiceFourthOptionRadioButton.Checked) 
                            && (addSingleChoiceFirstOptionTextBox.Text != "" && addSingleChoiceSecondOptionTextBox.Text != "" && addSingleChoiceThirdOptionTextBox.Text != "" && addSingleChoiceFourthOptionTextBox.Text != ""))
                        {
                            return true;
                        }
                        return false;   
                    }
                case Models.Type.multiple:{
                        if ((addMultipleChioceFirstOptionCheckBox.Checked || addMultipleChioceSecondOptionCheckBox.Checked || addMultipleChioceThirdOptionCheckBox.Checked || addMultipleChioceFourthOptionCheckBox.Checked) 
                            && (addMultipleChoiceFirstOptionTextBox.Text != "" && addMultipleChoiceSecondOptionTextBox.Text != "" && addMultipleChoiceThirdOptionTextBox.Text != "" && addMultipleChoiceFourthOptionTextBox.Text != ""))
                        {
                            return true;
                        }
                        return false;
                    }
                case Models.Type.filling: {
                        if(addFillingTextBox.Text != "")
                        {
                            return true;
                        }
                        return false;
                    }
            }
            return false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (addQuestionTextBox.Text != "" && CheckFilledOptions())
            {
                string questionName = addQuestionTextBox.Text;
                
                List<Option> options = ConfigureAddOptions();
                
                Theme theme = addQuestionThemeComboBox.SelectedItem as Theme;

                Models.Type type = (Models.Type)addTypeComboBox.SelectedIndex + 1; // Тип вопроса

                Question question = new Question()
                {
                    Id_subject = theme.SubjectId,
                    Id_theme = theme.Id,
                    Name = questionName,
                    Options = options,
                    Type = type,
                };

                DatabaseHelper.InsertQuestion(question);

                ClearAddQuestion();
            }
            else
            {
                MessageBox.Show("Заполните все поля!");
            }
        }

        private void deleteSubjectButton_Click(object sender, EventArgs e)
        {
            Subject subject = deleteSubjectComboBox.SelectedItem as Subject;
            
            DatabaseHelper.DeleteSubjectById(subject.Id);
            deleteSubjectComboBox.Text = "";
            UpdateViews();

            deleteSubjectButton.Enabled = false;
        }

        private void deleteThemeSubjectComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateThemes(deleteThemeSubjectComboBox.SelectedItem as Subject, deleteThemeComboBox);
            deleteThemeComboBox.Enabled = deleteThemeSubjectComboBox.SelectedIndex != -1;
        }

        private void deleteThemeButton_Click(object sender, EventArgs e)
        {
            Theme theme = deleteThemeComboBox.SelectedItem as Theme;

            DatabaseHelper.DeleteThemeById(theme.Id);
            UpdateThemes(deleteThemeSubjectComboBox.SelectedItem as Subject, deleteThemeComboBox);
            deleteThemeComboBox.Text = "";

            UpdateViews();

            deleteThemeButton.Enabled = false;
        }

        private void deleteQuestionSubjectComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            deleteQuestionComboBox.Items.Clear();
            deleteQuestionComboBox.Enabled = false;
            UpdateThemes(deleteQuestionSubjectComboBox.SelectedItem as Subject, deleteQuestionThemeComboBox);
        }

        private void deleteQuestionThemeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(deleteQuestionThemeComboBox.SelectedItem != null)
                UpdateQuestions(deleteQuestionThemeComboBox.SelectedItem as Theme, deleteQuestionComboBox);
        }

        private void deleteQuestionButton_Click(object sender, EventArgs e)
        {
            Question question = deleteQuestionComboBox.SelectedItem as Question;
            DatabaseHelper.DeleteQuestionById(question.Id);

            UpdateViews();

            deleteQuestionButton.Enabled = false;
        }

        private void editSubjectComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Line = editSubjectComboBox.Text;
            editSubjectComboBox.Visible = false;
            groupBox4.Controls.Add(editSubjectTextBox);
            editSubjectTextBox.Text = Line;
            editSubjectTextBox.Visible = true;
            editSubjectTextBox.Location = editSubjectComboBox.Location;
            editSubjectButton.Enabled = true;
            editSubjectClearButton.Enabled = true;
        }

        private void editSubjectButton_Click(object sender, EventArgs e)
        {
            if(editSubjectTextBox.Text != "")
            {
                Subject subject = editSubjectComboBox.SelectedItem as Subject;
                subject.Name = editSubjectTextBox.Text;
                DatabaseHelper.UpdateSubject(subject);

                editSubjectTextBox.Text = "";
                editSubjectComboBox.Visible = true;
                editSubjectComboBox.Text = "";
                editSubjectComboBox.SelectedText = "";
                groupBox4.Controls.Remove(editSubjectTextBox);
                editSubjectTextBox.Visible = false;
                editSubjectButton.Enabled = false;
                editSubjectClearButton.Enabled = false;

                ClearEditSubject();
            }
            else
            {
                MessageBox.Show("Заполните поле!");
            }
            
        }

        private void editSubjectClearButton_Click(object sender, EventArgs e)
        {
            editSubjectTextBox.Text = "";
            editSubjectComboBox.Visible = true;
            groupBox4.Controls.Remove(editSubjectTextBox);
            editSubjectTextBox.Visible = false;
            editSubjectButton.Enabled = false;
            editSubjectClearButton.Enabled = false;
            UpdateViews();
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateThemes(editThemeSubjectComboBox.SelectedItem as Subject, editThemeComboBox);
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            editThemeComboBox.Visible = false;
            groupBox5.Controls.Add(editThemeTextBox);
            editThemeTextBox.Visible = true;
            editThemeTextBox.Text = (editThemeComboBox.SelectedItem as Theme)?.Name;
            editThemeTextBox.Location = editThemeComboBox.Location;
            editThemeButton.Enabled = true;
            editThemeClearButton.Enabled = true;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if(editThemeTextBox.Text != "")
            {
                Theme theme = editThemeComboBox.SelectedItem as Theme;
                theme.Name = editThemeTextBox.Text;
                DatabaseHelper.UpdateTheme(theme);
                UpdateThemes(editThemeSubjectComboBox.SelectedItem as Subject, editThemeComboBox);
                editThemeTextBox.Text = "";
                editThemeComboBox.Visible = true;
                editThemeComboBox.SelectedText = "";
                groupBox5.Controls.Remove(editThemeTextBox);
                editThemeTextBox.Visible = false;
                editThemeButton.Enabled = false;
                editThemeClearButton.Enabled = false;
            }
            else
            {
                MessageBox.Show("Заполните поле!");
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            UpdateThemes(editThemeSubjectComboBox.SelectedItem as Subject, editThemeComboBox);
            editThemeTextBox.Text = "";
            editThemeComboBox.Visible = true;
            editThemeComboBox.SelectedText = "";
            groupBox5.Controls.Remove(editThemeTextBox);
            editThemeTextBox.Visible = false;
            editThemeButton.Enabled = false;
            editThemeClearButton.Enabled = false;
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateThemes(editQuestionSubjectComboBox.SelectedItem as Subject, editQuestionThemeComboBox);
        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateQuestions(editQuestionThemeComboBox.SelectedItem as Theme, editQuestionComboBox);
        }

        private void ConfigureEditOptions(Models.Type type, List<Option> options)
        {
            editSingleGroupBox.Visible = false;
            editMultipleGroupBox.Visible = false;
            editFillingGroupBox.Visible = false;

            DisableAllEditFields();

            switch (type)
            {
                case Models.Type.single:
                    {
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
                case Models.Type.multiple:
                    {
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
                case Models.Type.filling:
                    {
                        editFillingGroupBox.Visible = true;
                        
                        editFillingTextBox.Text = options[0];
                        editFillingTextBox.Enabled = true;

                        return;
                    }
                default:
                    break;
            }
        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            editQuestionButton.Visible = true;
            editQuestionClearButton.Visible = true;

            editQuestionComboBox.Visible = false;
            groupBox6.Controls.Add(editQuestionTextBox);
            editQuestionTextBox.Visible = true;
            editQuestionTextBox.Text = (editQuestionComboBox.SelectedItem as Question).Name;
            editQuestionTextBox.Location = editQuestionComboBox.Location;
            editQuestionButton.Enabled = true;
            editQuestionClearButton.Enabled = true;
            editTypeComboBox.Enabled = true;

            CurrentQuestion = editQuestionComboBox.SelectedItem as Question;

            editQuestionTextBox.Text = CurrentQuestion.Name;

            switch (CurrentQuestion.Type)
            {
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
        }

        private List<Option> GettingEditOptions(Models.Type type)
        {
            List<Option> options = new List<Option>();

            switch (type)
            {
                case Models.Type.single:
                    {
                        Option option = new Option(editSingleChoiceFirstOptionTextBox.Text, editSingleChoiceFirstOptionRadioButton.Checked);
                        options.Add(option);
                        option = new Option(editSingleChoiceSecondOptionTextBox.Text, editSingleChoiceSecondOptionRadioButton.Checked);
                        options.Add(option);
                        option = new Option(editSingleChoiceThirdOptionTextBox.Text, editSingleChoiceThirdOptionRadioButton.Checked);
                        options.Add(option);
                        option = new Option(editSingleChoiceFourthOptionTextBox.Text, editSingleChoiceFourthOptionRadioButton.Checked);
                        options.Add(option);
                        break;
                    }
                case Models.Type.multiple:
                    {
                        Option option = new Option(editMultipleChoiceFirstOptionTextBox.Text, editMultipleChoiceFirstOptionCheckBox.Checked);
                        options.Add(option);
                        option = new Option(editMultipleChoiceSecondOptionTextBox.Text, editMultipleChoiceSecondOptionCheckBox.Checked);
                        options.Add(option);
                        option = new Option(editMultipleChoiceThirdOptionTextBox.Text, editMultipleChoiceThirdOptionCheckBox.Checked);
                        options.Add(option);
                        option = new Option(editMultipleChoiceFourthOptionTextBox.Text, editMultipleChoiceFourthOptionCheckBox.Checked);
                        options.Add(option);
                        break;
                    }
                case Models.Type.filling:
                    {
                        Option option = new Option(editFillingTextBox.Text, true);
                        options.Add(option);
                        break;
                    }
            }
            return options;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if(editQuestionTextBox.Text != "" && CheckEditFieldsFill(CurrentQuestion.Type))
            {
                CurrentQuestion.Name = editQuestionTextBox.Text;
                CurrentQuestion.Options = GettingEditOptions(CurrentQuestion.Type);

                DatabaseHelper.UpdateQuestion(CurrentQuestion);

                editQuestionTextBox.Text = "";
                editQuestionComboBox.Visible = true;
                editQuestionComboBox.Text = "";
                editQuestionComboBox.SelectedText = "";
                groupBox6.Controls.Remove(editQuestionTextBox);
                editQuestionTextBox.Visible = false;
                editQuestionButton.Enabled = false;
                editQuestionClearButton.Enabled = false;
                UpdateQuestions(editQuestionThemeComboBox.SelectedItem as Theme, editQuestionComboBox);

                ClearEditQuestion();
            }
            else
            {
                MessageBox.Show("Заполните все поля!");
            }   
        }

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

        private void button4_Click(object sender, EventArgs e)
        {
            editQuestionTextBox.Text = "";
            editQuestionComboBox.Visible = true;
            editQuestionComboBox.Text = "";
            editQuestionComboBox.SelectedText = "";
            groupBox6.Controls.Remove(editQuestionTextBox);
            editQuestionTextBox.Visible = false;
            editQuestionButton.Enabled = false;
            editQuestionClearButton.Enabled = false;
            UpdateQuestions(editQuestionThemeComboBox.SelectedItem as Theme, editQuestionComboBox);

            ClearEditQuestion();
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void comboBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void comboBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void comboBox16_SelectedIndexChanged(object sender, EventArgs e)
        {
            addSingleChoiceGroupBox.Visible = addTypeComboBox.SelectedIndex == 0;   // Одиночный выбор
            addMultipleChoiceGroupBox.Visible = addTypeComboBox.SelectedIndex == 1; // Множественный выбор
            fillingGroupBox.Visible = addTypeComboBox.SelectedIndex == 2;        // Заполнение
        }

        private void DisableAllEditFields()
        {
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

        private void editTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            editSingleGroupBox.Visible = false;
            editMultipleGroupBox.Visible = false;
            editFillingGroupBox.Visible = false;

            Models.Type type = (Models.Type)editTypeComboBox.SelectedIndex + 1;

            CurrentQuestion.Type = type;

            var options = CurrentQuestion.Options;

            DisableAllEditFields();

            switch (type)
            {
                case Models.Type.single:
                    {
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
                case Models.Type.multiple:
                    {
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
                case Models.Type.filling:
                    {
                        editFillingGroupBox.Visible = true;

                        editFillingTextBox.Text = options[0];
                        editFillingTextBox.Enabled = true;

                        return;
                    }
            }
        }

        private void deleteSubjectComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            deleteSubjectButton.Enabled = deleteSubjectComboBox.SelectedItem != null;
        }

        private void clearAddQuestionButton_Click(object sender, EventArgs e)
        {
            ClearAddQuestion();
        }

        private void isAddClearButtonVisible()
        {
            switch (addTypeComboBox.SelectedIndex)
            {
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

        private void CheckFilling(object sender, EventArgs e)
        {
            isAddClearButtonVisible();
        }

        private void deleteThemeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            deleteThemeButton.Enabled = deleteThemeComboBox.SelectedIndex != -1;
        }

        private void deleteQuestionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            deleteQuestionButton.Enabled = deleteQuestionComboBox.SelectedIndex != -1;
        }
    }
}
