using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlServerCe;

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

        const bool t = true;
        const bool f = false;

        string Line = "";

        string Id_q = "";

        public DataBase()
        {
            InitializeComponent();
        }
        
        private void UpdateSubjects(bool isAdd, bool isEdit, bool isDelete)
        {
            string[] StringArray = DataBaseController.SelectQuery("Subject", "Subject").Split(';');

            if(isAdd == t)
            {
                comboBox1.Items.Clear();
                comboBox2.Items.Clear();
            }
            if(isEdit == t)
            {
                comboBox4.Items.Clear();
                comboBox5.Items.Clear();
                comboBox7.Items.Clear();
            }
            if(isDelete == t)
            {
                comboBox10.Items.Clear();
                comboBox11.Items.Clear();
                comboBox13.Items.Clear();
            }
            

            for (int i = 0; i <= StringArray.Length - 1; i++)
            {
                if (isAdd == t)
                {
                    comboBox1.Items.Add(StringArray[i]);
                    comboBox2.Items.Add(StringArray[i]);
                }
                if (isEdit == t)
                {
                    comboBox4.Items.Add(StringArray[i]);
                    comboBox5.Items.Add(StringArray[i]);
                    comboBox7.Items.Add(StringArray[i]);
                }
                if (isDelete == t)
                {
                    comboBox10.Items.Add(StringArray[i]);
                    comboBox11.Items.Add(StringArray[i]);
                    comboBox13.Items.Add(StringArray[i]);
                }
            }
        }

        private void UpdateThemes(string Subject, ComboBox comboBox)
        {
            string Id_s = DataBaseController.SelectQuery("Id_s", "Subject", "Subject='" + Subject + "'");

            try
            {
                string[] StringArray = DataBaseController.SelectQuery("Theme", "Theme", "Id_s =" + Id_s).Split(';');

                comboBox.Text = "";
                comboBox.Items.Clear();

                for (int i = 0; i <= StringArray.Length - 1; i++)
                {
                    comboBox.Items.Add(StringArray[i]);
                }
                comboBox.Enabled = t;
            }
            catch (SelectQueryException)
            {
                comboBox.Enabled = f;
                comboBox.Text = "Нет тем, связанных с данным предметом.";
            }
        }

        private void UpdateQuestions(string Theme, ComboBox comboBox)
        {

            string Id_t = DataBaseController.SelectQuery("Id_t", "Theme", "Theme='" + Theme + "'");

            try
            {
                string[] StringArray = DataBaseController.SelectQuery("Question", "Question", "Id_t=" + Id_t).Split(';');

                comboBox.Text = "";
                comboBox.Items.Clear();

                for (int i = 0; i <= StringArray.Length - 1; i++)
                {
                    comboBox.Items.Add(StringArray[i]);
                }
                comboBox.Enabled = t;
            }
            catch (SelectQueryException)
            {
                comboBox.Enabled = f;
                comboBox.Text = "Нет вопросов, связанных с данной темой.";
            }
        }

        private void DataBase_Load(object sender, EventArgs e)
        {
            TabControl1.Height = 594;
            groupBox9.Height = 349;
            this.Height = 661;

            UpdateSubjects(t,f,f);
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if(TabControl1.SelectedTab.Name == "AddTab")
            {
                TabControl1.Height = 594;
                groupBox9.Height = 349;
                this.Height = 661;

                UpdateSubjects(t, f, f);
            }
            if (TabControl1.SelectedTab.Name == "EditTab")
            {
                TabControl1.Height = 396;
                groupBox6.Height = 154;
                this.Height = 460;

                UpdateSubjects(f, t, f);
            }
            if (TabControl1.SelectedTab.Name == "DeleteTab")
            {
                TabControl1.Height = 396;
                groupBox9.Height = 154;
                this.Height = 460;

                UpdateSubjects(f, f, t);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox2.Enabled = t;
            button2.Enabled = t;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string ID = DataBaseController.SelectQuery("Id_s", "Subject", "Subject='" + comboBox2.Text + "'");

                UpdateThemes(comboBox2.Text, comboBox3);
            }
            catch(SelectQueryException)
            {
                comboBox3.Text = "Нет тем, связанных с данным предметом.";
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.Enabled = t;
            textBox3.Enabled = t;
            textBox4.Enabled = t;
            textBox5.Enabled = t;
            textBox6.Enabled = t;
            textBox7.Enabled = t;
            checkBox1.Enabled = t;
            checkBox2.Enabled = t;
            checkBox3.Enabled = t;
            checkBox4.Enabled = t;
            button3.Enabled = t;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                string ID = DataBaseController.IdDistributor("Subject", "Id_s");

                DataBaseController.InsertQuery("Subject", "Id_s, Subject", ID + ", '" + textBox1.Text + "'");

                UpdateSubjects(t, f, f);

                textBox1.Enabled = f;
                button1.Enabled = f;
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
                string Id_s = DataBaseController.SelectQuery("Id_s", "Subject", "Subject='" + comboBox1.Text + "'");

                string ID = DataBaseController.IdDistributor("Theme", "Id_t");

                DataBaseController.InsertQuery("Theme", "Id_s, Id_t, Theme", Id_s + ", " + ID + ", '" + textBox2.Text + "'");

                textBox2.Enabled = f;
                button2.Enabled = f;
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
            comboBox3.Enabled = f;
            button1.Enabled = t;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            button2.Enabled = t;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "" && 
                ((checkBox1.Checked == t && checkBox2.Checked == f && checkBox3.Checked == f && checkBox4.Checked == f) 
                || (checkBox1.Checked == f && checkBox2.Checked == t && checkBox3.Checked == f && checkBox4.Checked == f) 
                || (checkBox1.Checked == f && checkBox2.Checked == f && checkBox3.Checked == t && checkBox4.Checked == f) 
                || (checkBox1.Checked == f && checkBox2.Checked == f && checkBox3.Checked == f && checkBox4.Checked == t)))
            {
                string Question = textBox3.Text;
                string FirstOption = textBox4.Text;
                string SecondOption = textBox5.Text;
                string ThirdOption = textBox6.Text;
                string FourthOption = textBox7.Text;
                string RightOption = "";

                if (checkBox1.Checked == t) { RightOption = "1"; }
                if (checkBox2.Checked == t) { RightOption = "2"; }
                if (checkBox3.Checked == t) { RightOption = "3"; }
                if (checkBox4.Checked == t) { RightOption = "4"; }

                string Id_s = DataBaseController.SelectQuery("Id_s", "Subject", "Subject='" + comboBox2.Text + "'");

                string Id_t = DataBaseController.SelectQuery("Id_t", "Theme", "Theme='" + comboBox3.Text + "'");

                DataBaseController.InsertQuery("Question", "Id_s, Id_t, Question, FirstOption, SecondOption, ThirdOption, FourthOption, RightOption", Id_s + ", " + Id_t + ", '" + Question + "', '" + FirstOption + "', '" + SecondOption + "', '" + ThirdOption + "', '" + FourthOption + "', " + RightOption);

                comboBox3.Enabled = t;
                textBox3.Enabled = f;
                textBox4.Enabled = f;
                textBox5.Enabled = f;
                textBox6.Enabled = f;
                textBox7.Enabled = f;
                checkBox1.Enabled = f;
                checkBox2.Enabled = f;
                checkBox3.Enabled = f;
                checkBox4.Enabled = f;
                button3.Enabled = f;
            }
            else
            {
                MessageBox.Show("Заполните все поля!");
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            comboBox3.Enabled = t;
            textBox3.Enabled = t;
            textBox4.Enabled = t;
            textBox5.Enabled = t;
            textBox6.Enabled = t;
            textBox7.Enabled = t;
            checkBox1.Enabled = t;
            checkBox2.Enabled = t;
            checkBox3.Enabled = t;
            checkBox4.Enabled = t;
            button3.Enabled = t;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string Id_s = DataBaseController.SelectQuery("Id_s", "Subject", "Subject = '" + comboBox10.Text + "'");
            DataBaseController.DeleteQuery("", "Subject", "Subject='" + comboBox10.Text + "'");
            DataBaseController.DeleteQuery("", "Theme", "Id_s=" + Id_s);
            DataBaseController.DeleteQuery("", "Question", "Id_s=" + Id_s);
            comboBox10.Text = "";
            UpdateSubjects(f, f, t);
        }

        private void comboBox11_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateThemes(comboBox11.Text, comboBox12);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string Id_t = DataBaseController.SelectQuery("Id_t", "Theme", "Theme='" + comboBox12.Text + "'");
            DataBaseController.DeleteQuery("", "Theme", "Id_t=" + Id_t);
            DataBaseController.DeleteQuery("", "Question", "Id_t=" + Id_t);
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
            string ID = DataBaseController.SelectQuery("Id", "Question", "Question='" + comboBox15.Text + "'");
            DataBaseController.DeleteQuery("", "Question", "Id=" + ID);
            UpdateQuestions(comboBox14.Text, comboBox15);
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            Line = comboBox4.Text;
            comboBox4.Visible = f;
            groupBox4.Controls.Add(textBoxS);
            textBoxS.Text = Line;
            textBoxS.Visible = t;
            textBoxS.Location = comboBox4.Location;
            button8.Enabled = t;
            button9.Enabled = t;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string Id_s = DataBaseController.SelectQuery("Id_s", "Subject", "Subject='" + Line + "'");
            DataBaseController.UpdateQuery("Subject", "Subject = '" + textBoxS.Text + "'", "Id_s = "+Id_s);
            textBoxS.Text = "";
            comboBox4.Visible = t;
            comboBox4.Text = "";
            comboBox4.SelectedText = "";
            groupBox4.Controls.Remove(textBoxS);
            textBoxS.Visible = f;
            button8.Enabled = f;
            button9.Enabled = f;
            UpdateSubjects(f, t, f);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBoxS.Text = "";
            comboBox4.Visible = t;
            groupBox4.Controls.Remove(textBoxS);
            textBoxS.Visible = f;
            button8.Enabled = f;
            button9.Enabled = f;
            UpdateSubjects(f, t, f);
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateThemes(comboBox5.Text, comboBox6);
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            Line = comboBox6.Text;
            comboBox6.Visible = f;
            groupBox5.Controls.Add(textBoxT);
            textBoxT.Visible = t;
            textBoxT.Text = Line;
            textBoxT.Location = comboBox6.Location;
            button10.Enabled = t;
            button11.Enabled = t;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string Id_t = DataBaseController.SelectQuery("Id_t", "Theme", "Theme='" + Line + "'");
            DataBaseController.UpdateQuery("Theme", "Theme = '" + textBoxT.Text + "'", "Id_t = " + Id_t);
            textBoxT.Text = "";
            comboBox6.Visible = t;
            comboBox6.Text = "";
            comboBox6.SelectedText = "";
            groupBox5.Controls.Remove(textBoxT);
            textBoxT.Visible = f;
            button10.Enabled = f;
            button11.Enabled = f;
            UpdateThemes(comboBox5.Text, comboBox6);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBoxT.Text = "";
            comboBox6.Visible = t;
            comboBox6.Text = "";
            comboBox6.SelectedText = "";
            groupBox5.Controls.Remove(textBoxT);
            textBoxT.Visible = f;
            button10.Enabled = f;
            button11.Enabled = f;
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
            label6.Visible = t;
            label7.Visible = t;
            label8.Visible = t;
            label9.Visible = t;

            textBox8.Visible = t;
            textBox9.Visible = t;
            textBox10.Visible = t;
            textBox11.Visible = t;

            checkBox5.Visible = t;
            checkBox6.Visible = t;
            checkBox7.Visible = t;
            checkBox8.Visible = t;

            button12.Visible = t;
            button4.Visible = t;

            TabControl1.Height = 594;
            groupBox6.Height = 349;
            this.Height = 661;


            Line = comboBox9.Text;
            comboBox9.Visible = f;
            groupBox6.Controls.Add(textBoxQ);
            textBoxQ.Visible = t;
            textBoxQ.Text = Line;
            textBoxQ.Location = comboBox9.Location;
            button12.Enabled = t;
            button4.Enabled = t;

            Id_q = DataBaseController.SelectQuery("Id", "Question", "Question='" + Line + "'");

            string[] StringArray = DataBaseController.SelectQuery("Question + ':' + FirstOption + ':' + SecondOption + ':' + ThirdOption + ':' + FourthOption + ':' + CONVERT(nvarchar, RightOption)", "Question", "Question='" + Line + "'").Split(';');

            string[] StringLines = StringArray[0].Split(':');

            textBoxQ.Text = StringLines[0];
            textBox8.Text = StringLines[1];
            textBox9.Text = StringLines[2];
            textBox10.Text = StringLines[3];
            textBox11.Text = StringLines[4];

            if (StringLines[5] == "1") { checkBox5.Checked = t; }
            if (StringLines[5] == "2") { checkBox6.Checked = t; }
            if (StringLines[5] == "3") { checkBox7.Checked = t; }
            if (StringLines[5] == "4") { checkBox8.Checked = t; }

        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            checkBox6.Checked = f;
            checkBox7.Checked = f;
            checkBox8.Checked = f;
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            checkBox5.Checked = f;
            checkBox7.Checked = f;
            checkBox8.Checked = f;
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            checkBox5.Checked = f;
            checkBox6.Checked = f;
            checkBox8.Checked = f;
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            checkBox5.Checked = f;
            checkBox6.Checked = f;
            checkBox7.Checked = f;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string RO = "";//RightOption
            if (checkBox5.Checked == t) { RO = "1"; }
            if (checkBox6.Checked == t) { RO = "2"; }
            if (checkBox7.Checked == t) { RO = "3"; }
            if (checkBox8.Checked == t) { RO = "4"; }

            DataBaseController.UpdateQuery("Question", "Question='" + textBoxQ.Text + "', FirstOption='" + textBox8.Text + "', SecondOption='" + textBox9.Text + "', ThirdOption='" + textBox10.Text + "', FourthOption='" + textBox11.Text + "', RightOption=" + RO + "", "Id=" + Id_q);

            textBoxQ.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            comboBox9.Visible = t;
            comboBox9.Text = "";
            comboBox9.SelectedText = "";
            groupBox6.Controls.Remove(textBoxQ);
            textBoxQ.Visible = f;
            button12.Enabled = f;
            button4.Enabled = f;
            UpdateQuestions(comboBox8.Text, comboBox9);

            label6.Visible = f;
            label7.Visible = f;
            label8.Visible = f;
            label9.Visible = f;

            textBox8.Visible = f;
            textBox9.Visible = f;
            textBox10.Visible = f;
            textBox11.Visible = f;

            checkBox5.Visible = f;
            checkBox6.Visible = f;
            checkBox7.Visible = f;
            checkBox8.Visible = f;

            button12.Visible = f;
            button4.Visible = f;

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
            comboBox9.Visible = t;
            comboBox9.Text = "";
            comboBox9.SelectedText = "";
            groupBox6.Controls.Remove(textBoxQ);
            textBoxQ.Visible = f;
            button12.Enabled = f;
            button4.Enabled = f;
            UpdateQuestions(comboBox8.Text, comboBox9);

            label6.Visible = f;
            label7.Visible = f;
            label8.Visible = f;
            label9.Visible = f;

            textBox8.Visible = f;
            textBox9.Visible = f;
            textBox10.Visible = f;
            textBox11.Visible = f;

            checkBox5.Visible = f;
            checkBox6.Visible = f;
            checkBox7.Visible = f;
            checkBox8.Visible = f;

            button12.Visible = f;
            button4.Visible = f;

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
