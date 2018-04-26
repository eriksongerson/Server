using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace Server.Helpers
{
    public static class DatabaseHelper
    {
        public static SQLiteConnection SQLiteConnection = new SQLiteConnection("Data Source='DataBase.db'");

        private static int convertionInt(string line)
        {
            return Convert.ToInt32(line);
        }

        public static List<Subject> GetSubjects()
        {
            List<Subject> subjects = new List<Subject>();
            
            SQLiteCommand SQLiteCommand = new SQLiteCommand("SELECT id, subject FROM subjects", SQLiteConnection);

            SQLiteConnection.Open();

            using (SQLiteDataReader dataReader = SQLiteCommand.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    Subject subject = new Subject();
                    subject.Id = convertionInt(dataReader[0].ToString());
                    subject.Name = dataReader[1].ToString();
                    subjects.Add(subject);
                }
            }

            SQLiteConnection.Close();

            return subjects;
        }

        public static Subject GetSubjectById(string id)
        {
            Subject subject = new Subject();

            SQLiteCommand SQLiteCommand = new SQLiteCommand($"SELECT id, subject FROM subjects WHERE id={id}", SQLiteConnection);

            SQLiteConnection.Open();

            using (SQLiteDataReader dataReader = SQLiteCommand.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    subject.Id = convertionInt(dataReader[0].ToString());
                    subject.Name = dataReader[1].ToString();
                }
            }

            SQLiteConnection.Close();

            return subject;
        }

        public static Subject GetSubjectByName(string name)
        {
            Subject subject = new Subject();

            SQLiteCommand SQLiteCommand = new SQLiteCommand($"SELECT id, subject FROM subjects WHERE subject='{name}'", SQLiteConnection);

            SQLiteConnection.Open();

            using (SQLiteDataReader dataReader = SQLiteCommand.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    subject.Id = convertionInt(dataReader[0].ToString());
                    subject.Name = dataReader[1].ToString();
                }
            }

            SQLiteConnection.Close();

            return subject;
        }

        public static List<Theme> GetThemes(int id_subject)
        {
            List<Theme> themes = new List<Theme>();

            SQLiteCommand SQLiteCommand = new SQLiteCommand($"SELECT id, id_subject, theme FROM themes WHERE id_subject={id_subject}", SQLiteConnection);

            SQLiteConnection.Open();

            using (SQLiteDataReader dataReader = SQLiteCommand.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    Theme theme = new Theme();
                    theme.Id = convertionInt(dataReader[0].ToString());
                    theme.SubjectId = convertionInt(dataReader[1].ToString());
                    theme.Name = dataReader[2].ToString();
                    themes.Add(theme);
                }
            }

            SQLiteConnection.Close();

            return themes;
        }

        public static Theme GetThemeById(string id)
        {
            Theme theme = new Theme();

            SQLiteCommand SQLiteCommand = new SQLiteCommand($"SELECT id, id_subject, theme FROM themes WHERE id={id}", SQLiteConnection);

            SQLiteConnection.Open();

            using (SQLiteDataReader dataReader = SQLiteCommand.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    theme.Id = convertionInt(dataReader[0].ToString());
                    theme.SubjectId = convertionInt(dataReader[1].ToString());
                    theme.Name = dataReader[2].ToString();
                }
            }

            SQLiteConnection.Close();

            return theme;
        }

        public static Theme GetThemeByName(string name)
        {
            Theme theme = new Theme();

            SQLiteCommand SQLiteCommand = new SQLiteCommand($"SELECT id, id_subject, theme FROM themes WHERE theme='{name}'", SQLiteConnection);

            SQLiteConnection.Open();

            using (SQLiteDataReader dataReader = SQLiteCommand.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    theme.Id = convertionInt(dataReader[0].ToString());
                    theme.SubjectId = convertionInt(dataReader[1].ToString());
                    theme.Name = dataReader[2].ToString();
                }
            }

            SQLiteConnection.Close();

            return theme;
        }

        public static List<Question> GetQuestionsByTestAndSubjectId(int SubjectId, int ThemeId)
        {
            List<Question> questions = new List<Question>();

            // TODO: Переделать запрос
            SQLiteCommand SQLiteCommand = new SQLiteCommand($"SELECT * FROM questions WHERE id_subject={SubjectId} AND id_theme={ThemeId}", SQLiteConnection);

            SQLiteConnection.Open();

            using (SQLiteDataReader dataReader = SQLiteCommand.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    Question question = new Question();
                    question.Id = convertionInt(dataReader[0].ToString());
                    question.Id_subject = convertionInt(dataReader[1].ToString());
                    question.Id_theme = convertionInt(dataReader[2].ToString());
                    question.Name = dataReader[3].ToString();
                    question.FirstOption = dataReader[4].ToString();
                    question.SecondOption = dataReader[5].ToString();
                    question.ThirdOption = dataReader[6].ToString();
                    question.FourthOption = dataReader[7].ToString();
                    question.RightOption = convertionInt(dataReader[8].ToString());
                    questions.Add(question);
                }
            }

            SQLiteConnection.Close();

            return questions;
        }

        public static List<Question> GetQuestions()
        {
            List<Question> questions = new List<Question>();

            // TODO: Переделать запрос
            SQLiteCommand SQLiteCommand = new SQLiteCommand("SELECT * FROM questions", SQLiteConnection);

            SQLiteConnection.Open();

            using (SQLiteDataReader dataReader = SQLiteCommand.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    Question question = new Question();
                    question.Id = convertionInt(dataReader[0].ToString());
                    question.Id_subject = convertionInt(dataReader[1].ToString());
                    question.Id_theme = convertionInt(dataReader[2].ToString());
                    question.Name = dataReader[3].ToString();
                    question.FirstOption = dataReader[4].ToString();
                    question.SecondOption = dataReader[5].ToString();
                    question.ThirdOption = dataReader[6].ToString();
                    question.FourthOption = dataReader[7].ToString();
                    question.RightOption = convertionInt(dataReader[8].ToString());
                    questions.Add(question);
                }
            }

            SQLiteConnection.Close();

            return questions;
        }

        public static Question GetQuestionById(int id)
        {
            Question question = new Question();

            // TODO: Переделать запрос
            SQLiteCommand SQLiteCommand = new SQLiteCommand($"SELECT * FROM questions WHERE id={id}", SQLiteConnection);

            SQLiteConnection.Open();

            using (SQLiteDataReader dataReader = SQLiteCommand.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    question.Id = convertionInt(dataReader[0].ToString());
                    question.Id_subject = convertionInt(dataReader[1].ToString());
                    question.Id_theme = convertionInt(dataReader[2].ToString());
                    question.Name = dataReader[3].ToString();
                    question.FirstOption = dataReader[4].ToString();
                    question.SecondOption = dataReader[5].ToString();
                    question.ThirdOption = dataReader[6].ToString();
                    question.FourthOption = dataReader[7].ToString();
                    question.RightOption = convertionInt(dataReader[8].ToString());
                }
            }

            SQLiteConnection.Close();

            return question;
        }

        public static Question GetQuestionByName(string name)
        {
            Question question = new Question();

            // TODO: Переделать запрос
            SQLiteCommand SQLiteCommand = new SQLiteCommand($"SELECT * FROM questions WHERE question='{name}'", SQLiteConnection);

            SQLiteConnection.Open();

            using (SQLiteDataReader dataReader = SQLiteCommand.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    question.Id = convertionInt(dataReader[0].ToString());
                    question.Id_subject = convertionInt(dataReader[1].ToString());
                    question.Id_theme = convertionInt(dataReader[2].ToString());
                    question.Name = dataReader[3].ToString();
                    question.FirstOption = dataReader[4].ToString();
                    question.SecondOption = dataReader[5].ToString();
                    question.ThirdOption = dataReader[6].ToString();
                    question.FourthOption = dataReader[7].ToString();
                    question.RightOption = convertionInt(dataReader[8].ToString());
                }
            }

            SQLiteConnection.Close();

            return question;
        }

        //public static string SelectQuery(string Attribute, string Table, string Where = null)
        //{
        //    string Result = null;

        //    if(Where != null) { Where = " WHERE " + Where; }

        //    SQLiteCommand com = new SQLiteCommand("", SQLiteConnection)
        //    {
        //        CommandText = "SELECT " + Attribute + " FROM " + Table + Where + ""
        //    };

        //    SQLiteConnection.Open();

        //    using (SQLiteDataReader DReader = com.ExecuteReader())
        //    {
        //        while (DReader.Read())
        //        {
        //            Result += DReader[0].ToString() + ";";
        //        }
        //    }

        //    SQLiteConnection.Close();

        //    if(Result != null)
        //    {
        //        Result = Result.Substring(0, Result.Length - 1);
        //        return Result;
        //    }
        //    else
        //    {
        //        throw new SelectQueryException("Result is null");
        //    }
            
        //}

        public static void InsertQuery(string Table, string Attributes, string Condition)
        {
            
            SQLiteCommand com = new SQLiteCommand("", SQLiteConnection) {
                CommandText = "INSERT INTO " + Table + " (" + Attributes + ")" + " VALUES (" + Condition + ");"
            };

            SQLiteConnection.Open();

            com.ExecuteNonQuery();

            SQLiteConnection.Close();
        }

        public static void DeleteQuery(string Attributes, string Table, string Where = null)
        {
            
            if (Where != null) { Where = " WHERE " + Where; }

            SQLiteCommand com = new SQLiteCommand("", SQLiteConnection)
            {
                CommandText = "DELETE " + Attributes + " FROM " + Table + Where
            };

            SQLiteConnection.Open();

            com.ExecuteNonQuery();

            SQLiteConnection.Close();
        }

        public static void UpdateQuery(string Table, string Attributes, string Where = null)
        {
            
            if (Where != null) { Where = " WHERE " + Where; }

            SQLiteCommand com = new SQLiteCommand("", SQLiteConnection)
            {
                CommandText = "UPDATE " + Table + " SET " + Attributes + Where
            };

            SQLiteConnection.Open();

            com.ExecuteNonQuery();

            SQLiteConnection.Close();
        }

        public static DataTable SelectAdapter()
        {
            DataTable DTable = new DataTable();

            SQLiteCommand com = new SQLiteCommand("", SQLiteConnection);

            com.CommandText = "SELECT Id, Surname As Фамилия, Name As Имя, Subject As Предмет, Theme As Тема, Mark As Оценка FROM Journal;";

            SQLiteDataAdapter DAdapter = new SQLiteDataAdapter(com);

            SQLiteConnection.Open();

            com.ExecuteNonQuery();
            DAdapter.Fill(DTable);

            SQLiteConnection.Close();

            return DTable;
        }

    }

    [Serializable]
    public class SelectQueryException: Exception
    {
        public SelectQueryException() { }
        public SelectQueryException(string message) : base(message) { }
        public SelectQueryException(string message, Exception inner) : base(message, inner) { }
        protected SelectQueryException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

}
