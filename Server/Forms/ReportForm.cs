using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OfficeOpenXml;
using OfficeOpenXml.Drawing;

using Server.Helpers;
using Server.Models;

namespace Server.Forms
{
    public partial class ReportForm : Form
    {
        public ReportForm()
        {
            InitializeComponent();
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var newFile = new FileInfo("tmp/tmp.xlsx");
            using (ExcelPackage xlPackage = new ExcelPackage(newFile))
            {
                ExcelWorksheet ws = xlPackage.Workbook.Worksheets.Add("testsheet");
                // do work here                            
                xlPackage.Save();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0: 
                    {
                        byGroupReportGroupBox.Visible = true;
                        byGroupReportGroupBox.Location = new Point(16, 76);

                        List<Group> groups = DatabaseHelper.GetGroups();

                        foreach (var item in groups)
                        {
                            groupsComboBox.Items.Add(item);
                        }

                        List<Subject> subjects = DatabaseHelper.GetSubjects();

                        foreach (var item in subjects)
                        {
                            subjectsComboBox.Items.Add(item);
                        }

                        break;
                    }
                case 1:
                    {

                        break;
                    }
                case 2:
                    {

                        break;
                    }
                case 3:
                    {

                        break;
                    }
                case 4:
                    {

                        break;
                    }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
