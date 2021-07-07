using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HangmanGameApp.Database
{
    public class UserGame
    {
        [PrimaryKey, AutoIncrement]
        public int UserGameID { get; set; }

        public string UserName { get; set; }

        public int Score { get; set; }

        public string Status { get; set; } 
    }
}