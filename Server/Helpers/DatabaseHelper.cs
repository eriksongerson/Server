using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace Server.Helpers
{
    public static class DatabaseHelper
    {
        public static SQLiteConnection Connection = new SQLiteConnection("Data Source='DataBase.db'");

        private static int convertionInt(string line)
        {
            return Convert.ToInt32(line);
        }

        #region Select

        #region SelectSubject

        public static List<Subject> GetSubjects()
        {
            List<Subject> subjects = new List<Subject>();
            
            SQLiteCommand SQLiteCommand = new SQLiteCommand("SELECT id, subject FROM subjects", Connection);

            Connection.Open();

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

            Connection.Close();

            return subjects;
        }

        public static Subject GetSubjectById(string id)
        {
            Subject subject = new Subject();

            SQLiteCommand SQLiteCommand = new SQLiteCommand($"SELECT id, subject FROM subjects WHERE id={id}", Connection);

            Connection.Open();

            using (SQLiteDataReader dataReader = SQLiteCommand.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    subject.Id = convertionInt(dataReader[0].ToString());
                    subject.Name = dataReader[1].ToString();
                }
            }

            Connection.Close();

            return subject;
        }

        public static Subject GetSubjectByName(string name)
        {
            Subject subject = new Subject();

            SQLiteCommand SQLiteCommand = new SQLiteCommand($"SELECT id, subject FROM subjects WHERE subject='{name}'", Connection);

            Connection.Open();

            using (SQLiteDataReader dataReader = SQLiteCommand.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    subject.Id = convertionInt(dataReader[0].ToString());
                    subject.Name = dataReader[1].ToString();
                }
            }

            Connection.Close();

            return subject;
        }

        #endregion

        #region SelectTheme

        public static List<Theme> GetThemes(int id_subject)
        {
            List<Theme> themes = new List<Theme>();

            SQLiteCommand SQLiteCommand = new SQLiteCommand($"SELECT id, id_subject, theme FROM themes WHERE id_subject={id_subject}", Connection);

            Connection.Open();

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

            Connection.Close();

            return themes;
        }

        public static Theme GetThemeById(string id)
        {
            Theme theme = new Theme();

            SQLiteCommand SQLiteCommand = new SQLiteCommand($"SELECT id, id_subject, theme FROM themes WHERE id={id}", Connection);

            Connection.Open();

            using (SQLiteDataReader dataReader = SQLiteCommand.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    theme.Id = convertionInt(dataReader[0].ToString());
                    theme.SubjectId = convertionInt(dataReader[1].ToString());
                    theme.Name = dataReader[2].ToString();
                }
            }

            Connection.Close();

            return theme;
        }

        public static Theme GetThemeByName(string name)
        {
            Theme theme = new Theme();

            SQLiteCommand SQLiteCommand = new SQLiteCommand($"SELECT id, id_subject, theme FROM themes WHERE theme='{name}'", Connection);

            Connection.Open();

            using (SQLiteDataReader dataReader = SQLiteCommand.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    theme.Id = convertionInt(dataReader[0].ToString());
                    theme.SubjectId = convertionInt(dataReader[1].ToString());
                    theme.Name = dataReader[2].ToString();
                }
            }

            Connection.Close();

            return theme;
        }

        #endregion

        #region SelectQuestion

        public static List<Question> GetQuestionsByTestAndSubjectId(int SubjectId, int ThemeId)
        {
            List<Question> questions = new List<Question>();

            // TODO: Переделать запрос
            SQLiteCommand SQLiteCommand = new SQLiteCommand($"SELECT * FROM questions WHERE id_subject={SubjectId} AND id_theme={ThemeId}", Connection);

            Connection.Open();

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

            Connection.Close();

            return questions;
        }

        public static List<Question> GetQuestions()
        {
            List<Question> questions = new List<Question>();

            // TODO: Переделать запрос
            SQLiteCommand SQLiteCommand = new SQLiteCommand("SELECT * FROM questions", Connection);

            Connection.Open();

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

            Connection.Close();

            return questions;
        }

        public static Question GetQuestionById(int id)
        {
            Question question = new Question();

            // TODO: Переделать запрос
            SQLiteCommand SQLiteCommand = new SQLiteCommand($"SELECT * FROM questions WHERE id={id}", Connection);

            Connection.Open();

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

            Connection.Close();

            return question;
        }

        public static Question GetQuestionByName(string name)
        {
            Question question = new Question();

            // TODO: Переделать запрос
            SQLiteCommand SQLiteCommand = new SQLiteCommand($"SELECT * FROM questions WHERE question='{name}'", Connection);

            Connection.Open();

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

            Connection.Close();

            return question;
        }

        #endregion

        public static string SelectQuery(string Attribute, string Table, string Where = null)
        {
            string Result = null;

            if (Where != null) { Where = " WHERE " + Where; }

            SQLiteCommand com = new SQLiteCommand()
            {
                CommandText = "SELECT " + Attribute + " FROM " + Table + Where + "",
                Connection = Connection,
            };

            Connection.Open();

            using (SQLiteDataReader DReader = com.ExecuteReader())
            {
                while (DReader.Read())
                {
                    Result += DReader[0].ToString() + ";";
                }
            }

            Connection.Close();

            if (Result != null)
            {
                Result = Result.Substring(0, Result.Length - 1);
                return Result;
            }
            else
            {
                throw new SelectQueryException("Result is null");
            }

        }


        #endregion

        #region Insert

        public static void InsertSubject(Subject subject)
        {
            SQLiteCommand SQLiteCommand = new SQLiteCommand($"INSERT INTO subjects (subject) VALUES ('{subject.Name}')", Connection);

            Connection.Open();
            SQLiteCommand.ExecuteNonQuery();
            Connection.Close();
        }

        public static void InsertTheme(Theme theme)
        {
            SQLiteCommand SQLiteCommand = new SQLiteCommand($"INSERT INTO themes (id_subject, theme) VALUES ({theme.SubjectId}, '{theme.Name}')", Connection);
            
            Connection.Open();
            SQLiteCommand.ExecuteNonQuery();
            Connection.Close();
        }

        public static void InsertQuestion(Question question)
        {
            SQLiteCommand SQLiteCommand = new SQLiteCommand($"INSERT INTO questions (id_subject, id_theme, question, firstOption, secondOption, thirdOption, fourthOption, rightOption) VALUES ({question.Id_subject}, {question.Id_theme}, '{question.Name}', '{question.FirstOption}', '{question.SecondOption}', '{question.ThirdOption}', '{question.FourthOption}', {question.RightOption})", Connection);

            Connection.Open();
            SQLiteCommand.ExecuteNonQuery();
            Connection.Close();
        }

        public static void InsertQuery(string Table, string Attributes, string Condition)
        {

            SQLiteCommand com = new SQLiteCommand("", Connection)
            {
                CommandText = "INSERT INTO " + Table + " (" + Attributes + ")" + " VALUES (" + Condition + ");"
            };

            Connection.Open();

            com.ExecuteNonQuery();

            Connection.Close();
        }

        #endregion

        #region Delete
        //TODO: Есть вариант по-другому удалять предметы, добавив поле isActive(bool)

        public static void DeleteSubjectById(int id)
        {
            SQLiteCommand SQLiteCommand = new SQLiteCommand()
            {
                CommandText = $"DELETE FROM subjects WHERE id = {id};" +
                $"DELETE FROM themes WHERE id_subject = {id};" +
                $"DELETE FROM questions WHERE id_subject = {id};",
                Connection = Connection,
            };

            Connection.Open();
            SQLiteCommand.ExecuteNonQuery();
            Connection.Close();
        }

        public static void DeleteThemeById(int id)
        {
            SQLiteCommand SQLiteCommand = new SQLiteCommand()
            {
                CommandText = $"DELETE FROM themes WHERE id={id};" +
                $"DELETE FROM questions WHERE id_theme = {id};",
                Connection = Connection,
            };

            Connection.Open();
            SQLiteCommand.ExecuteNonQuery();
            Connection.Close();
        }

        public static void DeleteQuestionById(int id)
        {
            SQLiteCommand SQLiteCommand = new SQLiteCommand()
            {
                CommandText = $"DELETE FROM questions WHERE id={id}",
                Connection = Connection,
            };                

            Connection.Open();
            SQLiteCommand.ExecuteNonQuery();
            Connection.Close();
        }

        public static void DeleteQuery(string Attributes, string Table, string Where = null)
        {

            if (Where != null) { Where = " WHERE " + Where; }

            SQLiteCommand com = new SQLiteCommand("", Connection)
            {
                CommandText = "DELETE " + Attributes + " FROM " + Table + Where
            };

            Connection.Open();

            com.ExecuteNonQuery();

            Connection.Close();
        }

        #endregion

        #region Update

        public static void UpdateSubject(Subject subject)
        {
            SQLiteCommand SQLiteCommand = new SQLiteCommand($"UPDATE subjects SET subject = '{subject.Name}' WHERE id = {subject.Id}", Connection);

            Connection.Open();
            SQLiteCommand.ExecuteNonQuery();
            Connection.Close();
        }

        public static void UpdateTheme(Theme theme)
        {
            SQLiteCommand SQLiteCommand = new SQLiteCommand($"UPDATE themes SET id_subject = {theme.SubjectId}, theme = '{theme.Name}' WHERE id = {theme.Id}", Connection);

            Connection.Open();
            SQLiteCommand.ExecuteNonQuery();
            Connection.Close();
        }

        public static void UpdateQuestion(Question question)
        {
            SQLiteCommand SQLiteCommand = new SQLiteCommand($"UPDATE questions SET id_subject = {question.Id_subject} , id_theme = {question.Id_theme} , question = ' {question.Name} ', firstOption = ' {question.FirstOption} ', secondOption = ' {question.SecondOption} ', thirdOption = ' {question.ThirdOption} ', fourthOption = ' {question.FourthOption} ', rightOption = {question.RightOption} WHERE id = {question.Id}", Connection);

            Connection.Open();
            SQLiteCommand.ExecuteNonQuery();
            Connection.Close();
        }

        public static void UpdateQuery(string Table, string Attributes, string Where = null)
        {

            if (Where != null) { Where = " WHERE " + Where; }

            SQLiteCommand com = new SQLiteCommand("", Connection)
            {
                CommandText = "UPDATE " + Table + " SET " + Attributes + Where
            };

            Connection.Open();
            com.ExecuteNonQuery();
            Connection.Close();
        }

        #endregion

        public static DataTable SelectAdapter()
        {
            DataTable DTable = new DataTable();

            SQLiteCommand com = new SQLiteCommand("", Connection);

            com.CommandText = "SELECT Id, Surname As Фамилия, Name As Имя, Subject As Предмет, Theme As Тема, Mark As Оценка FROM Journal;";

            SQLiteDataAdapter DAdapter = new SQLiteDataAdapter(com);

            Connection.Open();

            com.ExecuteNonQuery();
            DAdapter.Fill(DTable);

            Connection.Close();

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
