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
        private static SQLiteConnection connection = new SQLiteConnection(@"Data Source='DataBase.db'; Password='^06%#0#u43vT6^B%7k725&3%90&ot#!w'");

        // Поле класса для доступа к соединению:
        public static SQLiteConnection Connection   
        {
            get => connection;
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

        // Начало региона Select. В этом регионе содержатся функции, обеспечивающие выборку информации из базы данных
        #region Select 
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
                    Subject subject = new Subject
                    {
                        Id = Convert.ToInt32(dataReader[0].ToString()),   // Выдаём ему id
                        Name = dataReader[1].ToString()        // Выдаём ему название
                    };                // Создаём новый пустой предмет
                    subjects.Add(subject);                          // Сохраняем в массив предметов
                }
            }
            // Закрываем соединение:
            CloseConnection();
            // Возвращаем список Предметов
            return subjects;
        }
        // Функция выбирает из таблицы "themes" все темы, связанные с определенным предметом. Возвращает массив тем
        public static List<Theme> GetThemes(int id_subject)
        {
            List<Theme> themes = new List<Theme>();
            // Запрос:
            SQLiteCommand SQLiteCommand = new SQLiteCommand($"SELECT id, id_subject, theme FROM themes WHERE id_subject=@Id_subject", Connection);
            // Экранирование символов:
            SQLiteCommand.Parameters.AddWithValue("@Id_subject", id_subject);
            // Открытие соединения к базе данных
            OpenConnection();
            // Читаем из базы данных записи
            using (SQLiteDataReader dataReader = SQLiteCommand.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    // Создание элемента тема
                    Theme theme = new Theme
                    {
                        Id = Convert.ToInt32(dataReader[0].ToString()),
                        SubjectId = Convert.ToInt32(dataReader[1].ToString()),
                        Name = dataReader[2].ToString()
                    };
                    // Сохранение темы в массив
                    themes.Add(theme);
                }
            }
            // Закрытие соединения
            CloseConnection();
            // возврат значения
            return themes;
        }
        // Функция выбирает все вопросы, связанные с определенными предметом и темой.
        // Возвращает список вопросов
        public static List<Question> GetQuestionsByTestAndSubjectId(int SubjectId, int ThemeId)
        {
            List<Question> questions = new List<Question>();
            // Запрос:
            SQLiteCommand SQLiteCommand = new SQLiteCommand($"SELECT id, id_subject, id_theme, question, type FROM questions WHERE id_subject=@Id_subject AND id_theme=@Id_theme", Connection);
            // Экранирование символов:
            SQLiteCommand.Parameters.AddWithValue("@Id_subject", SubjectId);
            SQLiteCommand.Parameters.AddWithValue("@Id_theme", ThemeId);
            // Открытие соединения к базе данных
            OpenConnection();
            // Чтение записей
            using (SQLiteDataReader dataReader = SQLiteCommand.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    // Создание объекта вопрос
                    Question question = new Question
                    {
                        Id = Convert.ToInt32(dataReader[0].ToString()),
                        Id_subject = Convert.ToInt32(dataReader[1].ToString()),
                        Id_theme = Convert.ToInt32(dataReader[2].ToString()),
                        Name = dataReader[3].ToString(),
                        Type = (Models.Type)Convert.ToInt32(dataReader[4].ToString())
                    };
                    // и сохранение его в список
                    questions.Add(question);
                }
            }
            // Закрытие соединения
            CloseConnection();
            // Перебор всех выбранных вопросов
            foreach (Question question in questions)
            {
                // Заполнение у каждого списка вариантов ответа
                question.Options = GetOptionsByQuestionId(question.Id);
            }
            // возврат списка
            return questions;
        }
        // Функция выбирает все варианты ответа, связанные с вопросом 
        public static List<Option> GetOptionsByQuestionId(int id)
        {
            List<Option> options = new List<Option>();
            // Запрос
            SQLiteCommand SQLiteCommand = new SQLiteCommand($"SELECT id, id_question, option, isRight FROM options WHERE id_question = @Id", Connection);
            // Экранизация символов
            SQLiteCommand.Parameters.AddWithValue("@Id", id);
            // Открываем соединение с БД
            OpenConnection();
            // Выбираем значения в массив
            using (SQLiteDataReader dataReader = SQLiteCommand.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    Option option = new Option
                    {
                        id = Convert.ToInt32(dataReader[0].ToString()),
                        id_question = Convert.ToInt32(dataReader[1].ToString()),
                        option = dataReader[2].ToString(),
                        isRight = Convert.ToBoolean(dataReader[3])
                    };
                    options.Add(option);
                }
            }
            // Закрываем соединение
            CloseConnection();
            // Возвращаем массив
            return options;
        }
        // Функция выборки всех групп. Работает аналогично предыдущим функциям
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
                        Id = Convert.ToInt32(dataReader[0].ToString()),
                        Name = dataReader[1].ToString(),
                    };
                    groups.Add(group);
                }
            }

            CloseConnection();

            return groups;
        }
        // Функци выборки журнала по ID. Работает аналогично предыдущим функциям
        public static List<Journal> GetJournalsByGroupId(Theme theme, Group group)
        {
            List<Journal> journals = new List<Journal>();

            SQLiteCommand SQLiteCommand = new SQLiteCommand("SELECT " +
                    "surname, " +
                    "name, " +
                    "mark " +
                "FROM journals WHERE id_theme = @ThemeId AND id_group = @GroupId", Connection);

            SQLiteCommand.Parameters.AddWithValue("@ThemeId", theme.Id);
            SQLiteCommand.Parameters.AddWithValue("@GroupId", group.Id);

            OpenConnection();

            using (SQLiteDataReader dataReader = SQLiteCommand.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    Journal journal = new Journal()
                    {
                        client = new Client()
                        {
                            surname = dataReader[0].ToString(),
                            name = dataReader[1].ToString(),
                        },
                        mark = Convert.ToInt32(dataReader[2].ToString()),
                    };
                    journals.Add(journal);
                }
            }

            CloseConnection();

            return journals;
        }
        // Конец региона Select
        #endregion
        // Начало региона Insert. Здесь содержатся все функции для добавления информации
        #region Insert
        // Функция добавления предмета
        public static void InsertSubject(Subject subject)
        {
            // Запрос
            SQLiteCommand SQLiteCommand = new SQLiteCommand($"INSERT INTO subjects (subject) VALUES (@Name)", Connection);
            // Экранизация символов
            SQLiteCommand.Parameters.AddWithValue("@Name", subject.Name);
            // Открытие соединения
            OpenConnection();
            SQLiteCommand.ExecuteNonQuery(); // Выполнение запроса
            // Закрытие соединения
            CloseConnection();
        }
        // Функция добавления темы. Работает аналогично предыдущей функции
        public static void InsertTheme(Theme theme)
        {
            SQLiteCommand SQLiteCommand = new SQLiteCommand($"INSERT INTO themes (id_subject, theme) VALUES (@Id_subject, @Name)", Connection);
            
            SQLiteCommand.Parameters.AddWithValue("@Id_subject", theme.SubjectId);
            SQLiteCommand.Parameters.AddWithValue("@Name", theme.Name);
            
            OpenConnection();
            SQLiteCommand.ExecuteNonQuery();
            CloseConnection();
        }
        // Функция добавления вопроса. Работает аналогично предыдущей функции
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
                    lastInsertedId = Convert.ToInt32(dataReader[0].ToString());
                }
            }

            CloseConnection();

            foreach (Option option in question.Options)
            {
                option.id_question = lastInsertedId;
            }
            InsertOptions(question.Options);
        }
        // Функция добавления варианта ответа. Работает аналогично предыдущей функции
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
        // Функция добавления журнала. Работает аналогично предыдущей функции
        public static void InsertJournal(Models.Journal journal)
        {
            SQLiteCommand SQLiteCommand = new SQLiteCommand($"INSERT INTO journals (surname, name, id_subject, id_theme, mark, id_group, datetime) VALUES (@Surname, @Name, @Id_subject, @Id_theme, @Mark, @Group, @Datetime)", Connection);

            SQLiteCommand.Parameters.AddWithValue("@Surname", journal.client.surname);
            SQLiteCommand.Parameters.AddWithValue("@Name", journal.client.name);
            SQLiteCommand.Parameters.AddWithValue("@Id_subject", journal.subject.Id);
            SQLiteCommand.Parameters.AddWithValue("@Id_theme", journal.theme.Id);
            SQLiteCommand.Parameters.AddWithValue("@Mark", journal.mark);
            SQLiteCommand.Parameters.AddWithValue("@Group", journal.client.group.Id);
            SQLiteCommand.Parameters.AddWithValue("@Datetime", DateTime.Now);

            OpenConnection();
            SQLiteCommand.ExecuteNonQuery();
            CloseConnection();
        }
        // Функция добавления группы. Работает аналогично предыдущей функции
        public static void InsertGroup(Group group)
        {
            SQLiteCommand SQLiteCommand = new SQLiteCommand($"INSERT INTO groups (name) VALUES (@Name)", Connection);

            SQLiteCommand.Parameters.AddWithValue("@Name", group.Name);

            OpenConnection();
            SQLiteCommand.ExecuteNonQuery();
            CloseConnection();
        }
        // Конец региона Insert
        #endregion
        // Начало региона Delete. Здесь содержатся функции удаления данных
        #region Delete
        // Функция удаления предмета по id
        public static void DeleteSubjectById(int id)
        {
            // Запрос
            SQLiteCommand SQLiteCommand = new SQLiteCommand()
            {
                CommandText = $"DELETE FROM subjects WHERE id = @Id;" +
                $"DELETE FROM themes WHERE id_subject = @Id;" +
                $"DELETE FROM questions WHERE id_subject = @Id;",
                Connection = Connection,
            };
            // Экранирование символов
            SQLiteCommand.Parameters.AddWithValue("@Id", id);

            OpenConnection(); // открытие соединения с БД
            SQLiteCommand.ExecuteNonQuery(); // Выполнение запроса
            CloseConnection(); // закрытие соединения с БД
        }
        // Функция удаления темы по id. Работает аналогично предыдущей функции
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
        // Функция удаления вопроса по id. Работает аналогично предыдущей функции
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
        // Функция удаления группы. Работает аналогично предыдущей функции
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
        // Функция удаления журнала по id. Работает аналогично предыдущей функции
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
        // конец региона Delete
        #endregion
        // Начало региона Update
        #region Update
        // Функция обновления предмета
        public static void UpdateSubject(Subject subject)
        {
            // Запрос
            SQLiteCommand SQLiteCommand = new SQLiteCommand($"UPDATE subjects SET subject = @Name WHERE id = @Id_subject", Connection);
            // Экранирование символов
            SQLiteCommand.Parameters.AddWithValue("@Name", subject.Name);
            SQLiteCommand.Parameters.AddWithValue("@Id_subject", subject.Id);

            OpenConnection(); // Открытие соединения с БД
            SQLiteCommand.ExecuteNonQuery(); // Выполнение запроса
            CloseConnection(); // Закрытие соединения с БД
        }
        // Функция обновления темы. Работает аналогично предыдущей функции
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
        // Функция обновления вопроса. Работает аналогично предыдущей функции
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
        // Функция обновления варианта ответа. Работает аналогично предыдущей функции
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
        // Функция обновления группы. Работает аналогично предыдущей функции
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
        // конец региона Update
        #endregion
        // Функция выборки журналов в виде виртуальной таблицы
        public static DataTable SelectJournalsAdapter()
        {
            // виртуальная таблица
            DataTable DTable = new DataTable();
            // Запрос
            SQLiteCommand com = new SQLiteCommand()
            {
                CommandText = "SELECT " +
                    "id, " +
                    "surname As Фамилия, " +
                    "name As Имя, " +
                    "(SELECT subject FROM subjects WHERE subjects.id = id_subject) As Предмет, " +
                    "(SELECT theme FROM themes WHERE themes.id = id_theme) As Тема, " +
                    "mark As Оценка, " +
                    "(SELECT name FROM groups WHERE groups.id = id_group) As Группа, " +
                    "datetime as Дата " +
                "FROM journals;",
                Connection = Connection,
            };
            // адаптер для выгрузки значений в таблицу
            SQLiteDataAdapter DAdapter = new SQLiteDataAdapter(com);
            // Открытие соединения с БД
            OpenConnection();
            // Выполнение запроса
            com.ExecuteNonQuery();
            DAdapter.Fill(DTable); // Заполнение таблицы
            // Закрытие соединения с БД
            CloseConnection();
            // Возврат виртуальной таблицы
            return DTable;
        }
        // Функция выборки групп в виде виртуальной таблицы
        public static DataTable SelectGroupsAdapter()
        {
            // виртуальная таблица
            DataTable dataTable = new DataTable();
            // Запрос
            SQLiteCommand command = new SQLiteCommand()
            {
                CommandText = "SELECT id, name as Группа FROM groups",
                Connection = Connection,
            };
            // Адаптер для заполнения таблицы
            SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(command);
            // Открытие соединения
            OpenConnection();
            // выполнение запроса
            command.ExecuteNonQuery();
            dataAdapter.Fill(dataTable); // Заполнение таблицы
            // закрытие соединения
            CloseConnection();
            // возврат таблицы
            return dataTable;
        }
    }
}
