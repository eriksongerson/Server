using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Linq;
using OfficeOpenXml;

using Server.Helpers;
using Server.Models;
using Server.Properties;

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

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (reportTypeComboBox.SelectedIndex)
            {
                case 0: 
                    {
                        byGroupReportGroupBox.Visible = true;
                        byGroupReportGroupBox.Location = new Point(4, 76);

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

        private void SubjectsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Subject subject = subjectsComboBox.SelectedItem as Subject;
            List<Theme> themes = DatabaseHelper.GetThemes(subject.Id);
            themesComboBox.Items.Clear();
            foreach (var item in themes)
            {
                themesComboBox.Items.Add(item);
            }
            if(themesComboBox.Items.Count != 0) themesComboBox.Enabled = true;
        }

        private void ThemesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            saveButton.Enabled = true;
            watchButton.Enabled = true;
            printButton.Enabled = true;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            CreateNewReport();
            MessageBox.Show("Отчёт сохранён");
            saveButton.Enabled = false;
        }

        private void WatchButton_Click(object sender, EventArgs e)
        {
            
        }

        private void CreateNewReport()
        {
            Stream stream = new MemoryStream(Resources.Report);

            ExcelPackage excelPackage = new ExcelPackage(stream);

            ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets.First();

            excelPackage.Workbook.Names["TestName"].Value = (themesComboBox.SelectedItem as Theme).Name;
            excelPackage.Workbook.Names["GroupName"].Value = (groupsComboBox.SelectedItem as Group).Name;

            int row = 10;
            double Average = 0;

            var selectedTheme = themesComboBox.SelectedItem as Theme;
            var selectedGroup = groupsComboBox.SelectedItem as Group;
            List<Models.Journal> journals = DatabaseHelper.GetJournalsByGroupId(selectedTheme, selectedGroup);

            for (int i = 0; i < journals.Count; i++, row++)
            {
                excelWorksheet.Cells[row, 1].Value = i + 1;
                excelWorksheet.Cells[row, 1].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                excelWorksheet.Cells[row, 2].Value = journals[i].client.surname;
                excelWorksheet.Cells[row, 2].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                excelWorksheet.Cells[row, 3].Value = journals[i].client.name;
                excelWorksheet.Cells[row, 3].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                excelWorksheet.Cells[row, 4].Value = journals[i].mark;
                excelWorksheet.Cells[row, 4].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                Average += journals[i].mark;
            }

            Average /= journals.Count;

            excelWorksheet.Cells[row, 3].Value = "Средний балл";
            excelWorksheet.Cells[row, 3].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            excelWorksheet.Cells[row, 4].Value = Average;

            row += 2;
            excelWorksheet.Cells[row, 3].Value = "Дата";
            excelWorksheet.Cells[row, 4].Value = $"{DateTime.Now.ToString("dd/MM/yyyy")}";

            excelWorksheet.Cells[10, 1, row - 3, 4].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thick);
            excelWorksheet.Cells[row - 2, 3, row - 2, 4].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thick);

            excelWorksheet.Cells[10, 1, row, 4].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
            excelWorksheet.Cells[10, 1, row, 4].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

            excelWorksheet.Cells[10, 1, excelWorksheet.Dimension.End.Row, excelWorksheet.Dimension.End.Column].Style.Font.SetFromFont(new Font("Times New Roman", 12));

            if (!Directory.Exists("Отчёты"))
            {
                Directory.CreateDirectory("Отчёты");
            }

            string addition = reportTypeComboBox.SelectedItem.ToString();

            try
            {
                excelPackage.SaveAs(new FileInfo($"Отчёты/Отчёт_{addition}_{DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss")}.xlsx"));
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Невозможно созранить файл");
            }
        }
    }
}
