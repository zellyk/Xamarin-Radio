﻿using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Assign1
{
    public partial class App : Application
    {
        static DBEmployee database;
        public static DBEmployee Database
        {
            get
            {
                if(database == null)
                {
                    database = new DBEmployee(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "employee.db3"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
