﻿using System;
using System.Windows.Forms;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using Server.Forms;
using Server.Helpers;
namespace Server {
    static class Program {
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Получаем guid приложения
            string guid = Marshal.GetTypeLibGuidForAssembly(Assembly.GetExecutingAssembly()).ToString();
            // Создаём мьютекс и узнаём у него, запущен ли хоть один процесс с таким guid
            Mutex mutexObj = new Mutex(true, guid, out bool existed);
            // Если запущен, этот экземпляр программы необходимо закрыть
            if (!existed) {
                MessageBox.Show("Программа уже запущена");
                mutexObj.Dispose();
                return;
            }
            // Настраиваем сервер
            SocketHelper.ConfigureListener();
            // Запускаем пргограмму
            Application.Run(new MainForm());
            // При выходе из программы нужно отключить всех клиентов
            if (SocketHelper.Status) {
                SocketHelper.ChangeStatus();
            }
        }
    }
}
