﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;
using System.Threading.Tasks;

namespace Cookie_listener
{
    [RunInstaller(true)]
    public partial class Cookie_listener_Installer : System.Configuration.Install.Installer
    {
        ServiceInstaller _service_installer = new ServiceInstaller();
        ServiceProcessInstaller _process_installer = new ServiceProcessInstaller();
        public Cookie_listener_Installer()
        {
            InitializeComponent();
            //обьязательно !
            _process_installer.Account = ServiceAccount.User; // тип учетной записи от которой запускать
            // что бы не просило логин и пароль учетки но хз будет ли работать
            _process_installer.Password = null;
            _process_installer.Username = null;
            //===========================================//
            _service_installer.StartType = ServiceStartMode.Manual; // вид запуска 
            _service_installer.ServiceName = "Arlam"; // имя службы в спике
            _service_installer.Description = "запускает мой будильник"; // описание

            _service_installer.AfterInstall += _installer_AfterInstall; // после установки
            _service_installer.AfterRollback += _installer_AfterRollback; // после ошибки
            _service_installer.AfterUninstall += _installer_AfterUninstall; // после удаления

            Installers.Add(_service_installer);
            Installers.Add(_process_installer);
        }
        private void _installer_AfterUninstall(object sender, InstallEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Удалили", ConsoleColor.Blue);
            Console.ForegroundColor = ConsoleColor.White;
        }

        private void _installer_AfterRollback(object sender, InstallEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Не получилось");
            Console.ForegroundColor = ConsoleColor.White;
        }

        private void _installer_AfterInstall(object sender, InstallEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Установилось");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}