using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Server.Helpers;

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
                //string[] StringArray = DatabaseHelper.SelectQuery("Theme", "themes", "Id_s =" + Id_s).Split(';');

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
            //string Id_t = DatabaseHelper.SelectQuery("Id_t", "Theme", "Theme='" + Theme + "'");
            Theme theme = DatabaseHelper.GetThemeByName(Theme);

            try
            {
                List<Question> questions = DatabaseHelper.GetQuestionsByTestAndSubjectId(theme.SubjectId, theme.Id);
                //string[] StringArray = DatabaseHelper.SelectQuery("Question", "Question", "Id_t=" + Id_t).Split(';');

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
                //string ID = DatabaseHelper.SelectQuery("Id_s", "Subject", "Subject='" + comboBox2.Text + "'");

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
                //string ID = DatabaseHelper.IdDistributor("Subject", "Id_s");

                Subject subject = new Subject()
                {
                    Name = textBox1.Text,
                };
                DatabaseHelper.InsertSubject(subject);

                //DatabaseHelper.InsertQuery("subjects", "subject", $"'{textBox1.Text}'");

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
                //string Id_s = DatabaseHelper.SelectQuery("Id_s", "Subject", "Subject='" + comboBox1.Text + "'");
                Subject subject = DatabaseHelper.GetSubjectByName(comboBox1.Text);

                Theme theme = new Theme()
                {
                    SubjectId = subject.Id,
                    Name = textBox2.Text,
                };

                DatabaseHelper.InsertTheme(theme);

                //DatabaseHelper.InsertQuery("themes", "id_subject, theme", subject.Id + ", '" + textBox2.Text + "'");

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
                string firstOption = textBox4.Text;
                string secondOption = textBox5.Text;
                string thirdOption = textBox6.Text;
                string fourthOption = textBox7.Text;
                int rightOption = 0;

                if (checkBox1.Checked == true) { rightOption = 1; }
                if (checkBox2.Checked == true) { rightOption = 2; }
                if (checkBox3.Checked == true) { rightOption = 3; }
                if (checkBox4.Checked == true) { rightOption = 4; }

                //string Id_s = DatabaseHelper.SelectQuery("Id_s", "Subject", "Subject='" + comboBox2.Text + "'");

                Theme theme = DatabaseHelper.GetThemeByName(comboBox3.Text);

                Question question = new Question()
                {
                    Id_subject = theme.SubjectId,
                    Id_theme = theme.Id,
                    Name = questionName,
                    FirstOption = firstOption,
                    SecondOption = secondOption,
                    ThirdOption = thirdOption,
                    FourthOption = fourthOption,
                    RightOption = rightOption,
                };

                //DatabaseHelper.InsertQuery("questions", "id_subject, id_theme, question, firstOption, secondOption, thirdOption, fourthOption, rightOption", theme.SubjectId + ", " + theme.Id + ", '" + Question + "', '" + FirstOption + "', '" + SecondOption + "', '" + ThirdOption + "', '" + FourthOption + "', " + RightOption);

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
            //string Id_s = DatabaseHelper.SelectQuery("Id_s", "Subject", "Subject = '" + comboBox10.Text + "'");
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
            //string Id_t = DatabaseHelper.SelectQuery("Id_t", "Theme", "Theme='" + comboBox12.Text + "'");

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
            //string ID = DatabaseHelper.SelectQuery("Id", "Question", "Question='" + comboBox15.Text + "'");
            Question question = DatabaseHelper.GetQuestionByName(comboBox15.Text);
            DatabaseHelper.DeleteQuestionById(question.Id);
            //DatabaseHelper.DeleteQuery("", "question", "id=" + question.Id);
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
            //string Id_s = DatabaseHelper.SelectQuery("Id_s", "Subject", "Subject='" + Line + "'");
            Subject subject = DatabaseHelper.GetSubjectByName(Line);
            subject.Name = textBoxS.Text;
            DatabaseHelper.UpdateSubject(subject);
            //DatabaseHelper.UpdateQuery("subjects", "subject = '" + textBoxS.Text + "'", "id = "+ subject.Id);
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
            //string Id_t = DatabaseHelper.SelectQuery("Id_t", "Theme", "Theme='" + Line + "'");
            Theme theme = DatabaseHelper.GetThemeByName(Line);
            theme.Name = textBoxT.Text;
            DatabaseHelper.UpdateTheme(theme);
            //DatabaseHelper.UpdateQuery("themes", "theme = '" + textBoxT.Text + "'", "id = " + theme.Id);
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

            //Id_q = DatabaseHelper.SelectQuery("Id", "Question", "Question='" + Line + "'");

            CurrentQuestion = DatabaseHelper.GetQuestionByName(Line);
            Id_q = CurrentQuestion.Id.ToString();

            //string[] StringArray = DatabaseHelper.SelectQuery("Question + ':' + FirstOption + ':' + SecondOption + ':' + ThirdOption + ':' + FourthOption + ':' + CONVERT(nvarchar, RightOption)", "Question", "Question='" + Line + "'").Split(';');

            //string[] StringLines = StringArray[0].Split(':');

            textBoxQ.Text = CurrentQuestion.Name;
            textBox8.Text = CurrentQuestion.FirstOption;
            textBox9.Text = CurrentQuestion.SecondOption;
            textBox10.Text = CurrentQuestion.ThirdOption;
            textBox11.Text = CurrentQuestion.FourthOption;

            switch (CurrentQuestion.RightOption)
            {
                case 1:
                    {
                        checkBox5.Checked = true;
                        break;
                    }
                case 2:
                    {
                        checkBox6.Checked = true;
                        break;
                    }
                case 3:
                    {
                        checkBox7.Checked = true;
                        break;
                    }
                case 4:
                    {
                        checkBox8.Checked = true;
                        break;
                    }
            }
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
            int RO = 0;//RightOption
            if (checkBox5.Checked == true) { RO = 1; }
            if (checkBox6.Checked == true) { RO = 2; }
            if (checkBox7.Checked == true) { RO = 3; }
            if (checkBox8.Checked == true) { RO = 4; }

            CurrentQuestion.Name = textBoxQ.Text;
            CurrentQuestion.FirstOption = textBox8.Text;
            CurrentQuestion.SecondOption = textBox9.Text;
            CurrentQuestion.ThirdOption = textBox10.Text;
            CurrentQuestion.FourthOption = textBox11.Text;
            CurrentQuestion.RightOption = RO;

            DatabaseHelper.UpdateQuestion(CurrentQuestion);
            //DatabaseHelper.UpdateQuery("questions", "question='" + textBoxQ.Text + "', firstOption='" + textBox8.Text + "', secondOption='" + textBox9.Text + "', thirdOption='" + textBox10.Text + "', fourthOption='" + textBox11.Text + "', rightOption=" + RO + "", "id=" + Id_q);

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
