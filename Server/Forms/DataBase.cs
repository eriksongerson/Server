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

        //string Id_q = ""; // TODO: Переделать

        Question CurrentQuestion;

        public DataBase()
        {
            InitializeComponent();
        }



        // TODO: Переписать
        //private void UpdateSubjects(bool isAdd, bool isEdit, bool isDelete)
        //{
        //    List<Subject> subjects = DatabaseHelper.GetSubjects();
           
        //    if(isAdd == true)
        //    {
        //        comboBox1.Items.Clear();
        //        comboBox2.Items.Clear();
        //    }
        //    if(isEdit == true)
        //    {
        //        comboBox4.Items.Clear();
        //        comboBox5.Items.Clear();
        //        comboBox7.Items.Clear();
        //    }
        //    if(isDelete == true)
        //    {
        //        comboBox10.Items.Clear();
        //        comboBox11.Items.Clear();
        //        comboBox13.Items.Clear();
        //    }

        //    foreach (var subject in subjects)
        //    {
        //        if (isAdd == true)
        //        {
        //            comboBox1.Items.Add(subject.Name);
        //            comboBox2.Items.Add(subject.Name);
        //        }
        //        if (isEdit == true)
        //        {
        //            comboBox4.Items.Add(subject.Name);
        //            comboBox5.Items.Add(subject.Name);
        //            comboBox7.Items.Add(subject.Name);
        //        }
        //        if (isDelete == true)
        //        {
        //            comboBox10.Items.Add(subject.Name);
        //            comboBox11.Items.Add(subject.Name);
        //            comboBox13.Items.Add(subject.Name);
        //        }
        //    }
        //}

        private void UpdateThemes(string Subject, ComboBox comboBox)
        {
            Subject subject = DatabaseHelper.GetSubjectByName(Subject);

            try
            {
                List<Theme> themes = DatabaseHelper.GetThemes(subject.Id);

                comboBox.Text = "";
                comboBox.Items.Clear();

                foreach (var theme in themes)
                {
                    comboBox.Items.Add(theme.Name);
                }
                comboBox.Enabled = true;
            }
            catch (SelectQueryException)
            {
                comboBox.Enabled = false;
                comboBox.Text = "Нет тем, связанных с данным предметом.";
            }
        }

        private void UpdateQuestions(string Theme, ComboBox comboBox)
        {
            Theme theme = DatabaseHelper.GetThemeByName(Theme);

            try
            {
                List<Question> questions = DatabaseHelper.GetQuestionsByTestAndSubjectId(theme.SubjectId, theme.Id);

                comboBox.Text = "";
                comboBox.Items.Clear();

                foreach (var question in questions)
                {
                    comboBox.Items.Add(question.Name);
                }
                comboBox.Enabled = true;
            }
            catch (SelectQueryException)
            {
                comboBox.Enabled = false;
                comboBox.Text = "Нет вопросов, связанных с данной темой.";
            }
        }

        private void UpdateViews()
        {
            List<Subject> subjects = DatabaseHelper.GetSubjects();

            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox4.Items.Clear();
            comboBox5.Items.Clear();
            comboBox7.Items.Clear();
            foreach (Subject subject in subjects)
            {
                comboBox1.Items.Add(subject);
                comboBox2.Items.Add(subject);
                comboBox4.Items.Add(subject);
                comboBox5.Items.Add(subject);
                comboBox7.Items.Add(subject);
            }
        }

        private void DataBase_Load(object sender, EventArgs e)
        {
            //TabControl1.Height = 594;
            //groupBox3.Height = 349;
            //this.Height = 729;

            UpdateViews();
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if(TabControl1.SelectedTab.Name == "AddTab")
            {
                //TabControl1.Height = 594;
                //groupBox3.Height = 349;
                //this.Height = 729;

                UpdateViews();
            }
            if (TabControl1.SelectedTab.Name == "EditTab")
            {
                //TabControl1.Height = 396;
                //groupBox6.Height = 154;
                //this.Height = 460;

                UpdateViews();
            }
            if (TabControl1.SelectedTab.Name == "DeleteTab")
            {
                //TabControl1.Height = 396;
                //groupBox9.Height = 154;
                //this.Height = 460;

                UpdateViews();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox2.Enabled = true;
            button2.Enabled = true;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                UpdateThemes(comboBox2.Text, comboBox3);
            }
            catch(SelectQueryException)
            {
                comboBox3.Text = "Нет тем, связанных с данным предметом.";
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.Enabled = true;
            textBox3.Enabled = true;
            addSingleChoiceFirstOptionTextBox.Enabled = true;
            addSingleChoiceSecondOptionTextBox.Enabled = true;
            addSingleChoiceThirdOptionTextBox.Enabled = true;
            addSingleChoiceFourthOptionTextBox.Enabled = true;
            addSingleChoiceFirstOptionRadioButton.Enabled = true;
            addSingleChoiceSecondOptionRadioButton.Enabled = true;
            addSingleChoiceThirdOptionRadioButton.Enabled = true;
            addSingleChoiceFourthOptionRadioButton.Enabled = true;
            button3.Enabled = true;
            addTypeComboBox.Enabled = true;
            addTypeComboBox.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {

                Subject subject = new Subject()
                {
                    Name = textBox1.Text,
                };
                DatabaseHelper.InsertSubject(subject);

                UpdateViews();

                textBox1.Enabled = false;
                button1.Enabled = false;
            }
            else
            {
                MessageBox.Show("Заполните поле!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                Subject subject = DatabaseHelper.GetSubjectByName(comboBox1.Text);

                Theme theme = new Theme()
                {
                    SubjectId = subject.Id,
                    Name = textBox2.Text,
                };

                DatabaseHelper.InsertTheme(theme);

                textBox2.Enabled = false;
                button2.Enabled = false;
            }
            else
            {
                MessageBox.Show("Заполните поле!");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            comboBox1.Text = "Предмет";
            comboBox2.Text = "Предмет";
            comboBox3.Text = "Тема";
            comboBox3.Enabled = false;
            button1.Enabled = true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            button2.Enabled = true;
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
            if (textBox3.Text != "" && CheckFilledOptions())
            {
                string questionName = textBox3.Text;
                
                List<Option> options = ConfigureAddOptions();
                
                Theme theme = DatabaseHelper.GetThemeByName(comboBox3.Text);

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

                comboBox3.Enabled = true;
                textBox3.Enabled = false;
                addSingleChoiceFirstOptionTextBox.Enabled = false;
                addSingleChoiceSecondOptionTextBox.Enabled = false;
                addSingleChoiceThirdOptionTextBox.Enabled = false;
                addSingleChoiceFourthOptionTextBox.Enabled = false;
                addSingleChoiceFirstOptionRadioButton.Enabled = false;
                addSingleChoiceSecondOptionRadioButton.Enabled = false;
                addSingleChoiceThirdOptionRadioButton.Enabled = false;
                addSingleChoiceFourthOptionRadioButton.Enabled = false;
                button3.Enabled = false;
                addTypeComboBox.Enabled = false;
            }
            else
            {
                MessageBox.Show("Заполните все поля!");
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            comboBox3.Enabled = true;
            textBox3.Enabled = true;
            addSingleChoiceFirstOptionTextBox.Enabled = true;
            addSingleChoiceSecondOptionTextBox.Enabled = true;
            addSingleChoiceThirdOptionTextBox.Enabled = true;
            addSingleChoiceFourthOptionTextBox.Enabled = true;
            addSingleChoiceFirstOptionRadioButton.Enabled = true;
            addSingleChoiceSecondOptionRadioButton.Enabled = true;
            addSingleChoiceThirdOptionRadioButton.Enabled = true;
            addSingleChoiceFourthOptionRadioButton.Enabled = true;
            button3.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Subject subject = DatabaseHelper.GetSubjectByName(comboBox10.Text);
            
            DatabaseHelper.DeleteSubjectById(subject.Id);
            comboBox10.Text = "";
            UpdateViews();
        }

        private void comboBox11_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateThemes(comboBox11.Text, comboBox12);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Theme theme = DatabaseHelper.GetThemeByName(comboBox12.Text);

            DatabaseHelper.DeleteThemeById(theme.Id);
            UpdateThemes(comboBox11.Text, comboBox12);
            comboBox12.Text = "";
        }

        private void comboBox13_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateThemes(comboBox13.Text, comboBox14);
        }

        private void comboBox14_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateQuestions(comboBox14.Text, comboBox15);
        }

        private void button7_Click(object sender, EventArgs e)
        {

            Question question = DatabaseHelper.GetQuestionByName(comboBox15.Text);
            DatabaseHelper.DeleteQuestionById(question.Id);

            UpdateQuestions(comboBox14.Text, comboBox15);
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            Line = comboBox4.Text;
            comboBox4.Visible = false;
            groupBox4.Controls.Add(textBoxS);
            textBoxS.Text = Line;
            textBoxS.Visible = true;
            textBoxS.Location = comboBox4.Location;
            button8.Enabled = true;
            button9.Enabled = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {

            Subject subject = DatabaseHelper.GetSubjectByName(Line);
            subject.Name = textBoxS.Text;
            DatabaseHelper.UpdateSubject(subject);

            textBoxS.Text = "";
            comboBox4.Visible = true;
            comboBox4.Text = "";
            comboBox4.SelectedText = "";
            groupBox4.Controls.Remove(textBoxS);
            textBoxS.Visible = false;
            button8.Enabled = false;
            button9.Enabled = false;
            UpdateViews();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBoxS.Text = "";
            comboBox4.Visible = true;
            groupBox4.Controls.Remove(textBoxS);
            textBoxS.Visible = false;
            button8.Enabled = false;
            button9.Enabled = false;
            UpdateViews();
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateThemes(comboBox5.Text, comboBox6);
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            Line = comboBox6.Text;
            comboBox6.Visible = false;
            groupBox5.Controls.Add(textBoxT);
            textBoxT.Visible = true;
            textBoxT.Text = Line;
            textBoxT.Location = comboBox6.Location;
            button10.Enabled = true;
            button11.Enabled = true;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Theme theme = DatabaseHelper.GetThemeByName(Line);
            theme.Name = textBoxT.Text;
            DatabaseHelper.UpdateTheme(theme);
            textBoxT.Text = "";
            comboBox6.Visible = true;
            comboBox6.Text = "";
            comboBox6.SelectedText = "";
            groupBox5.Controls.Remove(textBoxT);
            textBoxT.Visible = false;
            button10.Enabled = false;
            button11.Enabled = false;
            UpdateThemes(comboBox5.Text, comboBox6);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBoxT.Text = "";
            comboBox6.Visible = true;
            comboBox6.Text = "";
            comboBox6.SelectedText = "";
            groupBox5.Controls.Remove(textBoxT);
            textBoxT.Visible = false;
            button10.Enabled = false;
            button11.Enabled = false;
            UpdateThemes(comboBox5.Text, comboBox6);
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateThemes(comboBox7.Text, comboBox8);
        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateQuestions(comboBox8.Text, comboBox9);
        }

        private void ConfigureEditOptions(Models.Type type, List<Option> options)
        {
            editSingleGroupBox.Visible = false;
            editMultipleGroupBox.Visible = false;
            editFillingGroupBox.Visible = false;

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

                        return;
                    }
                case Models.Type.filling:
                    {
                        editFillingGroupBox.Visible = true;
                        
                        editFillingTextBox.Text = options[0];

                        return;
                    }
                default:
                    break;
            }
        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            button12.Visible = true;
            button4.Visible = true;

            Line = comboBox9.Text;
            comboBox9.Visible = false;
            groupBox6.Controls.Add(textBoxQ);
            textBoxQ.Visible = true;
            textBoxQ.Text = Line;
            textBoxQ.Location = comboBox9.Location;
            button12.Enabled = true;
            button4.Enabled = true;
            editTypeComboBox.Enabled = true;

            CurrentQuestion = DatabaseHelper.GetQuestionByName(Line);

            textBoxQ.Text = CurrentQuestion.Name;

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
            CurrentQuestion.Name = textBoxQ.Text;
            CurrentQuestion.Options = GettingEditOptions(CurrentQuestion.Type);

            DatabaseHelper.UpdateQuestion(CurrentQuestion);
           
            textBoxQ.Text = "";
            comboBox9.Visible = true;
            comboBox9.Text = "";
            comboBox9.SelectedText = "";
            groupBox6.Controls.Remove(textBoxQ);
            textBoxQ.Visible = false;
            button12.Enabled = false;
            button4.Enabled = false;
            UpdateQuestions(comboBox8.Text, comboBox9);

            button12.Visible = false;
            button4.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBoxQ.Text = "";
            comboBox9.Visible = true;
            comboBox9.Text = "";
            comboBox9.SelectedText = "";
            groupBox6.Controls.Remove(textBoxQ);
            textBoxQ.Visible = false;
            button12.Enabled = false;
            button4.Enabled = false;
            UpdateQuestions(comboBox8.Text, comboBox9);

            button12.Visible = false;
            button4.Visible = false;
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

        private void editTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            editSingleGroupBox.Visible = false;
            editMultipleGroupBox.Visible = false;
            editFillingGroupBox.Visible = false;

            Models.Type type = (Models.Type)editTypeComboBox.SelectedIndex + 1;

            CurrentQuestion.Type = type;

            var options = CurrentQuestion.Options;

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

                        return;
                    }
                case Models.Type.filling:
                    {
                        editFillingGroupBox.Visible = true;

                        editFillingTextBox.Text = options[0];

                        return;
                    }
            }
        }
    }
}
