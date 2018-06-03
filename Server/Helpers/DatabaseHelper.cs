using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Threading;
using Server.Models;

namespace Server.Helpers
{
    /*
     * Класс DatabaseHelper предоставляет набор функций для доступа к базе данных
     */
    public static class DatabaseHelper
    {
        // Соединение:
        private static SQLiteConnection connection = new SQLiteConnection("Data Source='DataBase.db'");
        // Поле класса для доступа к соединению:
        public static SQLiteConnection Connection   
        {
            get
            {
                return connection;
            }
        }

        static Mutex mutex = new Mutex(); // Мьютекс - объект для синхронизации потоков
        // Функция открытия соединения:
        private static void OpenConnection()
        {
            mutex.WaitOne();        // Мютекс пропускает первый поток и 
                                    // останавливает все остальные потоки до тех пор, 
                                    // пока ему не будет дана команда на пропуск следующего потока. 
                                    // Это как очередь

            Connection.Open();      // Открываем соединение
        }
        // Функция закрытия соединения
        private static void CloseConnection()
        {
            Connection.Close();     // Закрываем соединение

            mutex.ReleaseMutex();   // Даём мьютексу знать, что можно пропускать следующий поток
        }
        // Функция конвертирования строки в число
        private static int ToInt(string line)
        {
            return Convert.ToInt32(line);
        }

        #region Select

        #region SelectSubject
        // Функция выбирает из таблицы "subjects" базы данных все записи. Возвращает список предметов.
        public static List<Subject> GetSubjects()
        {
            // Список предметов, который будем возвращать
            List<Subject> subjects = new List<Subject>();
            // Запрос:
            SQLiteCommand SQLiteCommand = new SQLiteCommand("SELECT id, subject FROM subjects", Connection);
            // Открываем соединение:
            OpenConnection();
            // Выбираем из базы данных данные и формируем из них объекты Предметов
            using (SQLiteDataReader dataReader = SQLiteCommand.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    Subject subject = new Subject();                // Создаём новый пустой предмет
                    subject.Id = ToInt(dataReader[0].ToString());   // Выдаём ему id
                    subject.Name = dataReader[1].ToString();        // Выдаём ему название
                    subjects.Add(subject);                          // Сохраняем в массив предметов
                }
            }
            // Закрываем соединение:
            CloseConnection();
            // Возвращаем список Предметов
            return subjects;
        }

        public static Subject GetSubjectById(string id)
        {
            Subject subject = new Subject();

            SQLiteCommand SQLiteCommand = new SQLiteCommand($"SELECT id, subject FROM subjects WHERE id=@Id", Connection);

            SQLiteCommand.Parameters.AddWithValue("@Id", id);

            OpenConnection();

            using (SQLiteDataReader dataReader = SQLiteCommand.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    subject.Id = ToInt(dataReader[0].ToString());
                    subject.Name = dataReader[1].ToString();
                }
            }

            CloseConnection();

            return subject;
        }

        public static Subject GetSubjectByName(string name)
        {
            Subject subject = new Subject();

            SQLiteCommand SQLiteCommand = new SQLiteCommand($"SELECT id, subject FROM subjects WHERE subject=@Name", Connection);

            SQLiteCommand.Parameters.AddWithValue("@Name", name);

            OpenConnection();

            using (SQLiteDataReader dataReader = SQLiteCommand.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    subject.Id = ToInt(dataReader[0].ToString());
                    subject.Name = dataReader[1].ToString();
                }
            }

            CloseConnection();

            return subject;
        }

        #endregion

        #region SelectTheme

        public static List<Theme> GetThemes(int id_subject)
        {
            List<Theme> themes = new List<Theme>();

            SQLiteCommand SQLiteCommand = new SQLiteCommand($"SELECT id, id_subject, theme FROM themes WHERE id_subject=@Id_subject", Connection);

            SQLiteCommand.Parameters.AddWithValue("@Id_subject", id_subject);

            OpenConnection();

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

            CloseConnection();

            return themes;
        }

        public static Theme GetThemeById(string id)
        {
            Theme theme = new Theme();

            SQLiteCommand SQLiteCommand = new SQLiteCommand($"SELECT id, id_subject, theme FROM themes WHERE id=@Id", Connection);

            SQLiteCommand.Parameters.AddWithValue("@Id", id);

            OpenConnection();

            using (SQLiteDataReader dataReader = SQLiteCommand.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    theme.Id = ToInt(dataReader[0].ToString());
                    theme.SubjectId = ToInt(dataReader[1].ToString());
                    theme.Name = dataReader[2].ToString();
                }
            }

            CloseConnection();

            return theme;
        }

        public static Theme GetThemeByName(string name)
        {
            Theme theme = new Theme();

            SQLiteCommand SQLiteCommand = new SQLiteCommand($"SELECT id, id_subject, theme FROM themes WHERE theme=@Name", Connection);

            SQLiteCommand.Parameters.AddWithValue("@Name", name);

            OpenConnection();

            using (SQLiteDataReader dataReader = SQLiteCommand.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    theme.Id = ToInt(dataReader[0].ToString());
                    theme.SubjectId = ToInt(dataReader[1].ToString());
                    theme.Name = dataReader[2].ToString();
                }
            }

            CloseConnection();

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

            OpenConnection();

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

            CloseConnection();

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

            OpenConnection();

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

            CloseConnection();

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

            OpenConnection();

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

            CloseConnection();

            question.Options = GetOptionsByQuestionId(question.Id);

            return question;
        }

        public static Question GetQuestionByName(string name)
        {
            Question question = new Question();

            SQLiteCommand SQLiteCommand = new SQLiteCommand($"SELECT id, id_subject, id_theme, question, type FROM questions WHERE question=@Name", Connection);

            SQLiteCommand.Parameters.AddWithValue("@Name", name);

            OpenConnection();

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

            CloseConnection();

            question.Options = GetOptionsByQuestionId(question.Id);

            return question;
        }

        public static List<Option> GetOptionsByQuestionId(int id)
        {
            List<Option> options = new List<Option>();

            SQLiteCommand SQLiteCommand = new SQLiteCommand($"SELECT id, id_question, option, isRight FROM options WHERE id_question = @Id", Connection);

            SQLiteCommand.Parameters.AddWithValue("@Id", id);

            OpenConnection();
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

            CloseConnection();

            return options;
        }

        #endregion

        #region SelectGroups

        public static List<Group> GetGroups()
        {
            List<Group> groups = new List<Group>();

            SQLiteCommand SQLiteCommand = new SQLiteCommand("SELECT id, name FROM groups", Connection);
            
            OpenConnection();

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

            CloseConnection();

            return groups;
        }

        #endregion

        #endregion

        #region Insert

        public static void InsertSubject(Subject subject)
        {
            SQLiteCommand SQLiteCommand = new SQLiteCommand($"INSERT INTO subjects (subject) VALUES (@Name)", Connection);

            SQLiteCommand.Parameters.AddWithValue("@Name", subject.Name);

            OpenConnection();
            SQLiteCommand.ExecuteNonQuery();
            CloseConnection();
        }

        public static void InsertTheme(Theme theme)
        {
            SQLiteCommand SQLiteCommand = new SQLiteCommand($"INSERT INTO themes (id_subject, theme) VALUES (@Id_subject, @Name)", Connection);
            
            SQLiteCommand.Parameters.AddWithValue("@Id_subject", theme.SubjectId);
            SQLiteCommand.Parameters.AddWithValue("@Name", theme.Name);
            
            OpenConnection();
            SQLiteCommand.ExecuteNonQuery();
            CloseConnection();
        }

        public static void InsertQuestion(Question question)
        {
            SQLiteCommand SQLiteCommand = new SQLiteCommand($"INSERT INTO questions (id_subject, id_theme, question, type) VALUES (@Id_subject, @Id_theme, @Name, @Type)", Connection);

            SQLiteCommand.Parameters.AddWithValue("@Id_subject", question.Id_subject);
            SQLiteCommand.Parameters.AddWithValue("@Id_theme", question.Id_theme);
            SQLiteCommand.Parameters.AddWithValue("@Name", question.Name);
            SQLiteCommand.Parameters.AddWithValue("@Type", Convert.ToInt32(question.Type));

            OpenConnection();
            SQLiteCommand.ExecuteNonQuery();
            CloseConnection();

            int lastInsertedId = 0;
            SQLiteCommand.CommandText = $"SELECT id FROM questions WHERE id_subject = @Id_subject AND id_theme = @Id_theme AND question = @Name";

            SQLiteCommand.Parameters.AddWithValue("@Id_subject", question.Id_subject);
            SQLiteCommand.Parameters.AddWithValue("@Id_theme", question.Id_theme);
            SQLiteCommand.Parameters.AddWithValue("@Name", question.Name);

            OpenConnection();

            using (SQLiteDataReader dataReader = SQLiteCommand.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    lastInsertedId = ToInt(dataReader[0].ToString());
                }
            }

            CloseConnection();

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

                OpenConnection();
                SQLiteCommand.ExecuteNonQuery();
                CloseConnection();
            }
        }

        public static void InsertJournal(Models.Journal journal)
        {
            SQLiteCommand SQLiteCommand = new SQLiteCommand($"INSERT INTO journals (surname, name, id_subject, id_theme, mark, id_group) VALUES (@Surname, @Name, @Id_subject, @Id_theme, @Mark, @Group)", Connection);

            SQLiteCommand.Parameters.AddWithValue("@Surname", journal.client.surname);
            SQLiteCommand.Parameters.AddWithValue("@Name", journal.client.name);
            SQLiteCommand.Parameters.AddWithValue("@Id_subject", journal.subject.Id);
            SQLiteCommand.Parameters.AddWithValue("@Id_theme", journal.theme.Id);
            SQLiteCommand.Parameters.AddWithValue("@Mark", journal.mark);
            SQLiteCommand.Parameters.AddWithValue("@Group", journal.client.group.Id);

            OpenConnection();
            SQLiteCommand.ExecuteNonQuery();
            CloseConnection();
        }

        public static void InsertGroup(Group group)
        {
            SQLiteCommand SQLiteCommand = new SQLiteCommand($"INSERT INTO groups (name) VALUES (@Name)", Connection);

            SQLiteCommand.Parameters.AddWithValue("@Name", group.Name);

            OpenConnection();
            SQLiteCommand.ExecuteNonQuery();
            CloseConnection();
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

            OpenConnection();
            SQLiteCommand.ExecuteNonQuery();
            CloseConnection();
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

            OpenConnection();
            SQLiteCommand.ExecuteNonQuery();
            CloseConnection();
        }

        public static void DeleteQuestionById(int id)
        {
            SQLiteCommand SQLiteCommand = new SQLiteCommand()
            {
                CommandText = $"DELETE FROM questions WHERE id=@Id",
                Connection = Connection,
            };                

            SQLiteCommand.Parameters.AddWithValue("@Id", id);

            OpenConnection();
            SQLiteCommand.ExecuteNonQuery();
            CloseConnection();
        }

        public static void DeleteGroup(Group group)
        {
            SQLiteCommand SQLiteCommand = new SQLiteCommand()
            {
                CommandText = $"DELETE FROM groups WHERE id=@Id",
                Connection = Connection,
            };

            SQLiteCommand.Parameters.AddWithValue("@Id", group.Id);

            OpenConnection();
            SQLiteCommand.ExecuteNonQuery();
            CloseConnection();
        }

        public static void DeleteJournalByID(int id)
        {
            SQLiteCommand SQLiteCommand = new SQLiteCommand()
            {
                CommandText = $"DELETE FROM journals WHERE id=@Id",
                Connection = Connection,
            };

            SQLiteCommand.Parameters.AddWithValue("@Id", id);

            OpenConnection();
            SQLiteCommand.ExecuteNonQuery();
            CloseConnection();
        }

        #endregion

        #region Update

        public static void UpdateSubject(Subject subject)
        {
            SQLiteCommand SQLiteCommand = new SQLiteCommand($"UPDATE subjects SET subject = @Name WHERE id = @Id_subject", Connection);

            SQLiteCommand.Parameters.AddWithValue("@Name", subject.Name);
            SQLiteCommand.Parameters.AddWithValue("@Id_subject", subject.Id);

            OpenConnection();
            SQLiteCommand.ExecuteNonQuery();
            CloseConnection();
        }

        public static void UpdateTheme(Theme theme)
        {
            SQLiteCommand SQLiteCommand = new SQLiteCommand($"UPDATE themes SET id_subject = @Id_subject, theme = @Name WHERE id = @Id", Connection);

            SQLiteCommand.Parameters.AddWithValue("@Id_subject", theme.SubjectId);
            SQLiteCommand.Parameters.AddWithValue("@Name", theme.Name);
            SQLiteCommand.Parameters.AddWithValue("@Id", theme.Id);

            OpenConnection();
            SQLiteCommand.ExecuteNonQuery();
            CloseConnection();
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

            OpenConnection();
            SQLiteCommand.ExecuteNonQuery();
            CloseConnection();

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

                OpenConnection();
                SQLiteCommand.ExecuteNonQuery();
                CloseConnection();
            }
        }

        public static void UpdateGroup(Group group)
        {
            
            SQLiteCommand SQLiteCommand = new SQLiteCommand(
                $"UPDATE groups SET name = @Name WHERE id = @id",
                Connection);

            SQLiteCommand.Parameters.AddWithValue("@Name", group.Name);
            SQLiteCommand.Parameters.AddWithValue("@id", group.Id);

            OpenConnection();
            SQLiteCommand.ExecuteNonQuery();
            CloseConnection();
            
        }

        #endregion

        public static DataTable SelectJournalsAdapter()
        {
            DataTable DTable = new DataTable();

            SQLiteCommand com = new SQLiteCommand("", Connection);

            com.CommandText = "SELECT " +
                    "id, " +
                    "surname As Фамилия, " +
                    "name As Имя, " +
                    "(SELECT subject FROM subjects WHERE subjects.id = id_subject) As Предмет, " +
                    "(SELECT theme FROM themes WHERE themes.id = id_theme) As Тема, " +
                    "mark As Оценка, " +
                    "(SELECT name FROM groups WHERE groups.id = id_group) As Группа " +
                "FROM journals;";

            SQLiteDataAdapter DAdapter = new SQLiteDataAdapter(com);

            OpenConnection();

            com.ExecuteNonQuery();
            DAdapter.Fill(DTable);

            CloseConnection();

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

            OpenConnection();

            command.ExecuteNonQuery();
            dataAdapter.Fill(dataTable);

            CloseConnection();

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
