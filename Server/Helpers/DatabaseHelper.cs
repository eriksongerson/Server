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

        private static int ToInt(string line)
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
                    subject.Id = ToInt(dataReader[0].ToString());
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

            SQLiteCommand SQLiteCommand = new SQLiteCommand($"SELECT id, subject FROM subjects WHERE id=@Id", Connection);

            SQLiteCommand.Parameters.AddWithValue("@Id", id);

            Connection.Open();

            using (SQLiteDataReader dataReader = SQLiteCommand.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    subject.Id = ToInt(dataReader[0].ToString());
                    subject.Name = dataReader[1].ToString();
                }
            }

            Connection.Close();

            return subject;
        }

        public static Subject GetSubjectByName(string name)
        {
            Subject subject = new Subject();

            SQLiteCommand SQLiteCommand = new SQLiteCommand($"SELECT id, subject FROM subjects WHERE subject=@Name", Connection);

            SQLiteCommand.Parameters.AddWithValue("@Name", name);

            Connection.Open();

            using (SQLiteDataReader dataReader = SQLiteCommand.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    subject.Id = ToInt(dataReader[0].ToString());
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

            SQLiteCommand SQLiteCommand = new SQLiteCommand($"SELECT id, id_subject, theme FROM themes WHERE id_subject=@Id_subject", Connection);

            SQLiteCommand.Parameters.AddWithValue("@Id_subject", id_subject);

            Connection.Open();

            using (SQLiteDataReader dataReader = SQLiteCommand.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    Theme theme = new Theme();
                    theme.Id = ToInt(dataReader[0].ToString());
                    theme.SubjectId = ToInt(dataReader[1].ToString());
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

            SQLiteCommand SQLiteCommand = new SQLiteCommand($"SELECT id, id_subject, theme FROM themes WHERE id=@Id", Connection);

            SQLiteCommand.Parameters.AddWithValue("@Id", id);

            Connection.Open();

            using (SQLiteDataReader dataReader = SQLiteCommand.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    theme.Id = ToInt(dataReader[0].ToString());
                    theme.SubjectId = ToInt(dataReader[1].ToString());
                    theme.Name = dataReader[2].ToString();
                }
            }

            Connection.Close();

            return theme;
        }

        public static Theme GetThemeByName(string name)
        {
            Theme theme = new Theme();

            SQLiteCommand SQLiteCommand = new SQLiteCommand($"SELECT id, id_subject, theme FROM themes WHERE theme=@Name", Connection);

            SQLiteCommand.Parameters.AddWithValue("@Name", name);

            Connection.Open();

            using (SQLiteDataReader dataReader = SQLiteCommand.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    theme.Id = ToInt(dataReader[0].ToString());
                    theme.SubjectId = ToInt(dataReader[1].ToString());
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

            SQLiteCommand SQLiteCommand = new SQLiteCommand($"SELECT id, id_subject, id_theme, question, type FROM questions WHERE id_subject=@Id_subject AND id_theme=@Id_theme", Connection);

            SQLiteCommand.Parameters.AddWithValue("@Id_subject", SubjectId);
            SQLiteCommand.Parameters.AddWithValue("@Id_theme", ThemeId);

            Connection.Open();

            using (SQLiteDataReader dataReader = SQLiteCommand.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    Question question = new Question();
                    question.Id = ToInt(dataReader[0].ToString());
                    question.Id_subject = ToInt(dataReader[1].ToString());
                    question.Id_theme = ToInt(dataReader[2].ToString());
                    question.Name = dataReader[3].ToString();
                    question.Type = (Models.Type) ToInt(dataReader[4].ToString());
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

            SQLiteCommand SQLiteCommand = new SQLiteCommand("SELECT id, id_subject, id_theme, question, type FROM questions", Connection);

            Connection.Open();

            using (SQLiteDataReader dataReader = SQLiteCommand.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    Question question = new Question();
                    question.Id = ToInt(dataReader[0].ToString());
                    question.Id_subject = ToInt(dataReader[1].ToString());
                    question.Id_theme = ToInt(dataReader[2].ToString());
                    question.Name = dataReader[3].ToString();
                    question.Type = (Models.Type) ToInt(dataReader[4].ToString());
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

            SQLiteCommand SQLiteCommand = new SQLiteCommand($"SELECT id, id_subject, id_theme, question, type FROM questions WHERE id=@Id", Connection);

            SQLiteCommand.Parameters.AddWithValue("@Id", id);

            Connection.Open();

            using (SQLiteDataReader dataReader = SQLiteCommand.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    question.Id = ToInt(dataReader[0].ToString());
                    question.Id_subject = ToInt(dataReader[1].ToString());
                    question.Id_theme = ToInt(dataReader[2].ToString());
                    question.Name = dataReader[3].ToString();
                    question.Type = (Models.Type) ToInt(dataReader[4].ToString());
                }
            }

            Connection.Close();

            question.Options = GetOptionsByQuestionId(question.Id);

            return question;
        }

        public static Question GetQuestionByName(string name)
        {
            Question question = new Question();

            SQLiteCommand SQLiteCommand = new SQLiteCommand($"SELECT id, id_subject, id_theme, question, type FROM questions WHERE question=@Name", Connection);

            SQLiteCommand.Parameters.AddWithValue("@Name", name);

            Connection.Open();

            using (SQLiteDataReader dataReader = SQLiteCommand.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    question.Id = ToInt(dataReader[0].ToString());
                    question.Id_subject = ToInt(dataReader[1].ToString());
                    question.Id_theme = ToInt(dataReader[2].ToString());
                    question.Name = dataReader[3].ToString();
                    question.Type = (Models.Type) ToInt(dataReader[4].ToString());
                }
            }

            Connection.Close();

            question.Options = GetOptionsByQuestionId(question.Id);

            return question;
        }

        public static List<Option> GetOptionsByQuestionId(int id)
        {
            List<Option> options = new List<Option>();

            SQLiteCommand SQLiteCommand = new SQLiteCommand($"SELECT id, id_question, option, isRight FROM options WHERE id_question = @Id", Connection);

            SQLiteCommand.Parameters.AddWithValue("@Id", id);

            Connection.Open();
            using (SQLiteDataReader dataReader = SQLiteCommand.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    Option option = new Option();
                    option.id = ToInt(dataReader[0].ToString());
                    option.id_question = ToInt(dataReader[1].ToString());
                    option.option = dataReader[2].ToString();
                    option.isRight = Convert.ToBoolean(dataReader[3]);
                    options.Add(option);
                }
            }

            Connection.Close();

            return options;
        }

        #endregion

        #region SelectGroups

        public static List<Group> GetGroups()
        {
            List<Group> groups = new List<Group>();

            SQLiteCommand SQLiteCommand = new SQLiteCommand("SELECT id, name FROM groups", Connection);

            Connection.Open();

            using (SQLiteDataReader dataReader = SQLiteCommand.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    Group group = new Group()
                    {
                        Id = ToInt(dataReader[0].ToString()),
                        Name = dataReader[1].ToString(),
                    };
                    groups.Add(group);
                }
            }

            Connection.Close();

            return groups;
        }

        #endregion

        #endregion

        #region Insert

        public static void InsertSubject(Subject subject)
        {
            SQLiteCommand SQLiteCommand = new SQLiteCommand($"INSERT INTO subjects (subject) VALUES (@Name)", Connection);

            SQLiteCommand.Parameters.AddWithValue("@Name", subject.Name);

            Connection.Open();
            SQLiteCommand.ExecuteNonQuery();
            Connection.Close();
        }

        public static void InsertTheme(Theme theme)
        {
            SQLiteCommand SQLiteCommand = new SQLiteCommand($"INSERT INTO themes (id_subject, theme) VALUES (@Id_subject, @Name)", Connection);
            
            SQLiteCommand.Parameters.AddWithValue("@Id_subject", theme.SubjectId);
            SQLiteCommand.Parameters.AddWithValue("@Name", theme.Name);
            
            Connection.Open();
            SQLiteCommand.ExecuteNonQuery();
            Connection.Close();
        }

        public static void InsertQuestion(Question question)
        {
            SQLiteCommand SQLiteCommand = new SQLiteCommand($"INSERT INTO questions (id_subject, id_theme, question, type) VALUES (@Id_subject, @Id_theme, @Name, @Type)", Connection);

            SQLiteCommand.Parameters.AddWithValue("@Id_subject", question.Id_subject);
            SQLiteCommand.Parameters.AddWithValue("@Id_theme", question.Id_theme);
            SQLiteCommand.Parameters.AddWithValue("@Name", question.Name);
            SQLiteCommand.Parameters.AddWithValue("@Type", Convert.ToInt32(question.Type));

            Connection.Open();
            SQLiteCommand.ExecuteNonQuery();
            Connection.Close();

            int lastInsertedId = 0;
            SQLiteCommand.CommandText = $"SELECT id FROM questions WHERE id_subject = @Id_subject AND id_theme = @Id_theme AND question = @Name";

            SQLiteCommand.Parameters.AddWithValue("@Id_subject", question.Id_subject);
            SQLiteCommand.Parameters.AddWithValue("@Id_theme", question.Id_theme);
            SQLiteCommand.Parameters.AddWithValue("@Name", question.Name);

            Connection.Open();

            using (SQLiteDataReader dataReader = SQLiteCommand.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    lastInsertedId = ToInt(dataReader[0].ToString());
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
                SQLiteCommand SQLiteCommand = new SQLiteCommand($"INSERT INTO options (id_question, option, isRight) VALUES (@Id_question, @Option, @IsRight)", Connection);

                SQLiteCommand.Parameters.AddWithValue("@Id_question", option.id_question);
                SQLiteCommand.Parameters.AddWithValue("@Option", option.option);
                SQLiteCommand.Parameters.AddWithValue("@IsRight", Convert.ToInt32(option.isRight));

                Connection.Open();
                SQLiteCommand.ExecuteNonQuery();
                Connection.Close();
            }
        }

        public static void InsertJournal(Models.Journal journal)
        {
            SQLiteCommand SQLiteCommand = new SQLiteCommand($"INSERT INTO journals (surname, name, id_subject, id_theme, mark) VALUES (@Surname, @Name, @Id_subject, @Id_theme, @Mark)", Connection);

            SQLiteCommand.Parameters.AddWithValue("@Surname", journal.client.surname);
            SQLiteCommand.Parameters.AddWithValue("@Name", journal.client.name);
            SQLiteCommand.Parameters.AddWithValue("@Id_subject", journal.subject.Id);
            SQLiteCommand.Parameters.AddWithValue("@Id_theme", journal.theme.Id);
            SQLiteCommand.Parameters.AddWithValue("@Mark", journal.mark);

            Connection.Open();
            SQLiteCommand.ExecuteNonQuery();
            Connection.Close();
        }

        public static void InsertGroup(Group group)
        {
            SQLiteCommand SQLiteCommand = new SQLiteCommand($"INSERT INTO groups (name) VALUES (@Name)", Connection);

            SQLiteCommand.Parameters.AddWithValue("@Name", group.Name);

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
                CommandText = $"DELETE FROM subjects WHERE id = @Id;" +
                $"DELETE FROM themes WHERE id_subject = @Id;" +
                $"DELETE FROM questions WHERE id_subject = @Id;",
                Connection = Connection,
            };

            SQLiteCommand.Parameters.AddWithValue("@Id", id);

            Connection.Open();
            SQLiteCommand.ExecuteNonQuery();
            Connection.Close();
        }

        public static void DeleteThemeById(int id)
        {
            SQLiteCommand SQLiteCommand = new SQLiteCommand()
            {
                CommandText = $"DELETE FROM themes WHERE id=@Id;" +
                $"DELETE FROM questions WHERE id_theme = @Id;",
                Connection = Connection,
            };

            SQLiteCommand.Parameters.AddWithValue("@Id", id);

            Connection.Open();
            SQLiteCommand.ExecuteNonQuery();
            Connection.Close();
        }

        public static void DeleteQuestionById(int id)
        {
            SQLiteCommand SQLiteCommand = new SQLiteCommand()
            {
                CommandText = $"DELETE FROM questions WHERE id=@Id",
                Connection = Connection,
            };                

            SQLiteCommand.Parameters.AddWithValue("@Id", id);

            Connection.Open();
            SQLiteCommand.ExecuteNonQuery();
            Connection.Close();
        }

        public static void DeleteGroup(Group group)
        {
            SQLiteCommand SQLiteCommand = new SQLiteCommand()
            {
                CommandText = $"DELETE FROM groups WHERE id=@Id",
                Connection = Connection,
            };

            SQLiteCommand.Parameters.AddWithValue("@Id", group.Id);

            Connection.Open();
            SQLiteCommand.ExecuteNonQuery();
            Connection.Close();
        }

        #endregion

        #region Update

        public static void UpdateSubject(Subject subject)
        {
            SQLiteCommand SQLiteCommand = new SQLiteCommand($"UPDATE subjects SET subject = @Name WHERE id = @Id_subject", Connection);

            SQLiteCommand.Parameters.AddWithValue("@Name", subject.Name);
            SQLiteCommand.Parameters.AddWithValue("@Id_subject", subject.Id);

            Connection.Open();
            SQLiteCommand.ExecuteNonQuery();
            Connection.Close();
        }

        public static void UpdateTheme(Theme theme)
        {
            SQLiteCommand SQLiteCommand = new SQLiteCommand($"UPDATE themes SET id_subject = @Id_subject, theme = @Name WHERE id = @Id", Connection);

            SQLiteCommand.Parameters.AddWithValue("@Id_subject", theme.SubjectId);
            SQLiteCommand.Parameters.AddWithValue("@Name", theme.Name);
            SQLiteCommand.Parameters.AddWithValue("@Id", theme.Id);

            Connection.Open();
            SQLiteCommand.ExecuteNonQuery();
            Connection.Close();
        }

        public static void UpdateQuestion(Question question)
        {
            SQLiteCommand SQLiteCommand =
                new SQLiteCommand(
                    $"UPDATE questions SET id_subject = @Id_subject , id_theme = @Id_theme , question = @Name, type = @Type WHERE id = @Id",
                    Connection);

            SQLiteCommand.Parameters.AddWithValue("@Id_subject", question.Id_subject);
            SQLiteCommand.Parameters.AddWithValue("@Id_theme", question.Id_theme);
            SQLiteCommand.Parameters.AddWithValue("@Name", question.Name);
            SQLiteCommand.Parameters.AddWithValue("@Type", question.Type);
            SQLiteCommand.Parameters.AddWithValue("@Id", question.Id);

            Connection.Open();
            SQLiteCommand.ExecuteNonQuery();
            Connection.Close();

            UpdateOptions(question.Options);
        }

        public static void UpdateOptions(List<Option> options)
        {
            foreach (Option option in options)
            {
                SQLiteCommand SQLiteCommand = new SQLiteCommand(
                    $"UPDATE options SET option = @Option, isRight = @IsRight WHERE id = @id",
                    Connection);

                SQLiteCommand.Parameters.AddWithValue("@Option", option.option);
                SQLiteCommand.Parameters.AddWithValue("@IsRight", Convert.ToInt32(option.isRight));
                SQLiteCommand.Parameters.AddWithValue("@Id", option.id);

                Connection.Open();
                SQLiteCommand.ExecuteNonQuery();
                Connection.Close();
            }
        }

        public static void UpdateGroup(Group group)
        {
            
            SQLiteCommand SQLiteCommand = new SQLiteCommand(
                $"UPDATE groups SET name = @Name WHERE id = @id",
                Connection);

            SQLiteCommand.Parameters.AddWithValue("@Name", group.Name);
            SQLiteCommand.Parameters.AddWithValue("@id", group.Id);

            Connection.Open();
            SQLiteCommand.ExecuteNonQuery();
            Connection.Close();
            
        }

        #endregion

        public static DataTable SelectJournalsAdapter()
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

        public static DataTable SelectGroupsAdapter()
        {
            DataTable dataTable = new DataTable();

            SQLiteCommand command = new SQLiteCommand()
            {
                CommandText = "SELECT id, name as Группа FROM groups",
                Connection = Connection,
            };

            SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(command);

            Connection.Open();

            command.ExecuteNonQuery();
            dataAdapter.Fill(dataTable);

            Connection.Close();

            return dataTable;
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
