using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

using Server.Models;

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
                    questions.Add(question);
                }
            }

            Connection.Close();

            foreach (Question question in questions)
            {
                question.Options = GetOptionsByQuestionId(question.Id);
            }

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
                    questions.Add(question);
                }
            }

            Connection.Close();

            foreach (Question question in questions)
            {
                question.Options = GetOptionsByQuestionId(question.Id);
            }

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
                }
            }

            Connection.Close();

            question.Options = GetOptionsByQuestionId(question.Id);

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
                }
            }

            Connection.Close();

            question.Options = GetOptionsByQuestionId(question.Id);

            return question;
        }

        public static List<Option> GetOptionsByQuestionId(int id)
        {
            List<Option> options = new List<Option>();

            SQLiteCommand command = new SQLiteCommand($"SELECT id, id_question, option, isRight FROM options WHERE id_question = {id}", Connection);

            Connection.Open();
            using (SQLiteDataReader dataReader = command.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    Option option = new Option();
                    option.id = convertionInt(dataReader[0].ToString());
                    option.id_question = convertionInt(dataReader[1].ToString());
                    option.option = dataReader[2].ToString();
                    option.isRight = Convert.ToBoolean(dataReader[3]);
                    options.Add(option);
                }
            }

            Connection.Close();

            return options;
        }

        #endregion

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
            SQLiteCommand SQLiteCommand = new SQLiteCommand($"INSERT INTO questions (id_subject, id_theme, question) VALUES ({question.Id_subject}, {question.Id_theme}, '{question.Name}')", Connection);

            Connection.Open();
            SQLiteCommand.ExecuteNonQuery();
            Connection.Close();

            int lastInsertedId = 0;
            SQLiteCommand.CommandText = "SELECT last_insert_rowid() FROM questions";
            Connection.Open();

            using (SQLiteDataReader dataReader = SQLiteCommand.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    lastInsertedId = convertionInt(dataReader[0].ToString());
                }
            }

            Connection.Close();

            foreach (Option option in question.Options)
            {
                option.id_question = lastInsertedId;
            }
            InsertOptions(question.Options);
        }

        public static void InsertOptions(List<Option> options)
        {
            foreach (Option option in options)
            {
                SQLiteCommand SQLiteCommand = new SQLiteCommand($"INSERT INTO options (id_question, option, isRight) VALUES ({option.id_question}, '{option.option}', {option.isRight})", Connection);

                Connection.Open();
                SQLiteCommand.ExecuteNonQuery();
                Connection.Close();
            }
        }

        public static void InsertJournal(Models.Journal journal)
        {
            SQLiteCommand SQLiteCommand = new SQLiteCommand($"INSERT INTO journals (surname, name, id_subject, id_theme, mark) VALUES ('{journal.client.surname}', '{journal.client.name}', {journal.subject.Id}, {journal.theme.Id}, {journal.mark})", Connection);

            Connection.Open();
            SQLiteCommand.ExecuteNonQuery();
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
            SQLiteCommand SQLiteCommand =
                new SQLiteCommand(
                    $"UPDATE questions SET id_subject = {question.Id_subject} , id_theme = {question.Id_theme} , question = '{question.Name}' WHERE id = {question.Id}",
                    Connection);

            Connection.Open();
            SQLiteCommand.ExecuteNonQuery();
            Connection.Close();

            UpdateOptions(question.Options);
        }

        public static void UpdateOptions(List<Option> options)
        {
            foreach (Option option in options)
            {
                SQLiteCommand command = new SQLiteCommand(
                    $"UPDATE options SET option = '{option.option}', isRight = {option.isRight} WHERE id = {option.id}",
                    Connection);

                Connection.Open();
                command.ExecuteNonQuery();
                Connection.Close();
            }
        }

        #endregion

        public static DataTable SelectAdapter()
        {
            DataTable DTable = new DataTable();

            SQLiteCommand com = new SQLiteCommand("", Connection);

            com.CommandText = "SELECT id, surname As Фамилия, name As Имя, id_subject As Предмет, id_theme As Тема, mark As Оценка FROM journals;";

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
