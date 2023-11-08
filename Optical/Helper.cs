﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Drawing;
using System.Data.SQLite;

namespace Optical
{
    internal static class Helper
    {
        //Create an instance from SqlConnection
        public static SQLiteConnection sqliteConn =
            new SQLiteConnection(@"Data Source=.\database.db;");

        //Create a function to add Click Events on a specific Control and its Children Controls
        public static void AddAction(this Control control, Action action)
        {
            control.Click += (s, e) =>
            {
                action.Invoke();
            };
            foreach (Control con in control.Controls)
            {
                con.Click += (s, e) =>
                {
                    action.Invoke();
                };
            }
        }
    }
}