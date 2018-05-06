using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Server.Helpers;
using Server.Models;

namespace Server
{
    public partial class DataBase : Form
    {

        /**
         * Сразу же введу некоторые пояснения:
         * Во время добавления для адекватной работы связей необходимо задавать некоторые id новым записям.
         * Для id, который только предстоит задать используется переменная "ID".
         * Для id, который уже существует используется переменная, называющаяся как атрибут, который предстоит задать в новой записи (Id_s, Id_t, Id_q etc.).
         **/

        /**
         * Строка подключения: 
         * Data Source='BDServer.sdf'
        **/

        string Line = "";

        string Id_q = ""; // TODO: Переделать

        Question CurrentQuestion;

        public DataBase()
        {
            InitializeComponent();
        }

        // TODO: Переписать
        private void UpdateSubjects(bool isAdd, bool isEdit, bool isDelete)
        {
            List<Subject> subjects = DatabaseHelper.GetSubjects();
           
            if(isAdd == true)
            {
                comboBox1.Items.Clear();
                comboBox2.Items.Clear();
            }
            if(isEdit == true)
            {
                comboBox4.Items.Clear();
                comboBox5.Items.Clear();
                comboBox7.Items.Clear();
            }
            if(isDelete == true)
            {
                comboBox10.Items.Clear();
                comboBox11.Items.Clear();
                comboBox13.Items.Clear();
            }

            foreach (var subject in subjects)
            {
                if (isAdd == true)
                {
                    comboBox1.Items.Add(subject.Name);
                    comboBox2.Items.Add(subject.Name);
                }
                if (isEdit == true)
                {
                    comboBox4.Items.Add(subject.Name);
                    comboBox5.Items.Add(subject.Name);
                    comboBox7.Items.Add(subject.Name);
                }
                if (isDelete == true)
                {
                    comboBox10.Items.Add(subject.Name);
                    comboBox11.Items.Add(subject.Name);
                    comboBox13.Items.Add(subject.Name);
                }
            }
        }

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

        private void DataBase_Load(object sender, EventArgs e)
        {
            TabControl1.Height = 594;
            groupBox9.Height = 349;
            this.Height = 661;

            UpdateSubjects(true,false,false);
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if(TabControl1.SelectedTab.Name == "AddTab")
            {
                TabControl1.Height = 594;
                groupBox9.Height = 349;
                this.Height = 661;

                UpdateSubjects(true, false, false);
            }
            if (TabControl1.SelectedTab.Name == "EditTab")
            {
                TabControl1.Height = 396;
                groupBox6.Height = 154;
                this.Height = 460;

                UpdateSubjects(false, true, false);
            }
            if (TabControl1.SelectedTab.Name == "DeleteTab")
            {
                TabControl1.Height = 396;
                groupBox9.Height = 154;
                this.Height = 460;

                UpdateSubjects(false, false, true);
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
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            textBox6.Enabled = true;
            textBox7.Enabled = true;
            checkBox1.Enabled = true;
            checkBox2.Enabled = true;
            checkBox3.Enabled = true;
            checkBox4.Enabled = true;
            button3.Enabled = true;
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

                UpdateSubjects(true, false, false);

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

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "" && 
                ((checkBox1.Checked == true && checkBox2.Checked == false && checkBox3.Checked == false && checkBox4.Checked == false) 
                || (checkBox1.Checked == false && checkBox2.Checked == true && checkBox3.Checked == false && checkBox4.Checked == false) 
                || (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == true && checkBox4.Checked == false) 
                || (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == false && checkBox4.Checked == true)))
            {

                string questionName = textBox3.Text;
                
                List<Option> options = new List<Option>();
                string firstOption = textBox4.Text;
                Option option = new Option(firstOption, checkBox1.Checked);
                options.Add(option);

                string secondOption = textBox5.Text;
                option = new Option(secondOption, checkBox2.Checked);
                options.Add(option);

                string thirdOption = textBox6.Text;
                option = new Option(thirdOption, checkBox3.Checked);
                options.Add(option);

                string fourthOption = textBox7.Text;
                option = new Option(fourthOption, checkBox4.Checked);
                options.Add(option);

                Theme theme = DatabaseHelper.GetThemeByName(comboBox3.Text);

                Question question = new Question()
                {
                    Id_subject = theme.SubjectId,
                    Id_theme = theme.Id,
                    Name = questionName,
                    Options = options,
                };

                DatabaseHelper.InsertQuestion(question);

                comboBox3.Enabled = true;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                textBox5.Enabled = false;
                textBox6.Enabled = false;
                textBox7.Enabled = false;
                checkBox1.Enabled = false;
                checkBox2.Enabled = false;
                checkBox3.Enabled = false;
                checkBox4.Enabled = false;
                button3.Enabled = false;
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
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            textBox6.Enabled = true;
            textBox7.Enabled = true;
            checkBox1.Enabled = true;
            checkBox2.Enabled = true;
            checkBox3.Enabled = true;
            checkBox4.Enabled = true;
            button3.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Subject subject = DatabaseHelper.GetSubjectByName(comboBox10.Text);
            
            DatabaseHelper.DeleteSubjectById(subject.Id);
            comboBox10.Text = "";
            UpdateSubjects(false, false, true);
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
            UpdateSubjects(false, true, false);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBoxS.Text = "";
            comboBox4.Visible = true;
            groupBox4.Controls.Remove(textBoxS);
            textBoxS.Visible = false;
            button8.Enabled = false;
            button9.Enabled = false;
            UpdateSubjects(false, true, false);
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

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            label6.Visible = true;
            label7.Visible = true;
            label8.Visible = true;
            label9.Visible = true;

            textBox8.Visible = true;
            textBox9.Visible = true;
            textBox10.Visible = true;
            textBox11.Visible = true;

            checkBox5.Visible = true;
            checkBox6.Visible = true;
            checkBox7.Visible = true;
            checkBox8.Visible = true;

            button12.Visible = true;
            button4.Visible = true;

            TabControl1.Height = 594;
            groupBox6.Height = 349;
            this.Height = 661;

            Line = comboBox9.Text;
            comboBox9.Visible = false;
            groupBox6.Controls.Add(textBoxQ);
            textBoxQ.Visible = true;
            textBoxQ.Text = Line;
            textBoxQ.Location = comboBox9.Location;
            button12.Enabled = true;
            button4.Enabled = true;

            CurrentQuestion = DatabaseHelper.GetQuestionByName(Line);
            Id_q = CurrentQuestion.Id.ToString();

            textBoxQ.Text = CurrentQuestion.Name;

            textBox8.Text = CurrentQuestion.Options[0];
            checkBox5.Checked = CurrentQuestion.Options[0].isRight;
            textBox9.Text = CurrentQuestion.Options[1];
            checkBox6.Checked = CurrentQuestion.Options[1].isRight;
            textBox10.Text = CurrentQuestion.Options[2];
            checkBox7.Checked = CurrentQuestion.Options[2].isRight;
            textBox11.Text = CurrentQuestion.Options[3];
            checkBox8.Checked = CurrentQuestion.Options[3].isRight;
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            checkBox6.Checked = false;
            checkBox7.Checked = false;
            checkBox8.Checked = false;
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            checkBox5.Checked = false;
            checkBox7.Checked = false;
            checkBox8.Checked = false;
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            checkBox5.Checked = false;
            checkBox6.Checked = false;
            checkBox8.Checked = false;
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            checkBox5.Checked = false;
            checkBox6.Checked = false;
            checkBox7.Checked = false;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            CurrentQuestion.Name = textBoxQ.Text;
            CurrentQuestion.Options = new List<Option>()
            {
                new Option(textBox8.Text, checkBox5.Checked),
                new Option(textBox9.Text, checkBox6.Checked),
                new Option(textBox10.Text, checkBox7.Checked),
                new Option(textBox11.Text, checkBox8.Checked),
            };

            DatabaseHelper.UpdateQuestion(CurrentQuestion);
           
            textBoxQ.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            comboBox9.Visible = true;
            comboBox9.Text = "";
            comboBox9.SelectedText = "";
            groupBox6.Controls.Remove(textBoxQ);
            textBoxQ.Visible = false;
            button12.Enabled = false;
            button4.Enabled = false;
            UpdateQuestions(comboBox8.Text, comboBox9);

            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;

            textBox8.Visible = false;
            textBox9.Visible = false;
            textBox10.Visible = false;
            textBox11.Visible = false;

            checkBox5.Visible = false;
            checkBox6.Visible = false;
            checkBox7.Visible = false;
            checkBox8.Visible = false;

            button12.Visible = false;
            button4.Visible = false;

            TabControl1.Height = 396;
            groupBox6.Height = 154;
            this.Height = 460;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBoxQ.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            comboBox9.Visible = true;
            comboBox9.Text = "";
            comboBox9.SelectedText = "";
            groupBox6.Controls.Remove(textBoxQ);
            textBoxQ.Visible = false;
            button12.Enabled = false;
            button4.Enabled = false;
            UpdateQuestions(comboBox8.Text, comboBox9);

            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;

            textBox8.Visible = false;
            textBox9.Visible = false;
            textBox10.Visible = false;
            textBox11.Visible = false;

            checkBox5.Visible = false;
            checkBox6.Visible = false;
            checkBox7.Visible = false;
            checkBox8.Visible = false;

            button12.Visible = false;
            button4.Visible = false;

            TabControl1.Height = 396;
            groupBox6.Height = 154;
            this.Height = 460;

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

    }
}
