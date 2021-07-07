using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HangmanGameApp.Database
{
    public class DBOperation
    {
        private SQLiteConnection conn;

        public DBOperation()
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            conn = new SQLiteConnection(Path.Combine(path, "hangdb.db"));
            CreateDBTable();
        }

        public bool AddNewUser(User user)
        {
            try
            {
                conn.Insert(user);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool AddNewUserGame(UserGame userGame)
        {
            try
            {
                conn.Insert(userGame);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool ValidUser(string username, string password)
        {
            List<User> users = conn.Query<User>("Select * from User");
            if(users!=null && users.Count > 0)
            {
                foreach (User user in users)
                {
                    if (user.UserName.Equals(username) && user.Password.Equals(password))
                    {
                        return true;
                    }

                }
            }
            return false;
        }

        public Report GetReport(string username)
        {
            Report report = new Report(username);
            try
            {
                string query = "Select * from UserGame Where UserName='" + username + "'";
                List<UserGame> games = conn.Query<UserGame>(query);
                if(games!=null && games.Count > 0 )
                {
                    foreach (UserGame game in games)
                    {
                        report.Score += game.Score;
                        if (game.Status.Equals("WIN"))
                        {
                            report.Win += 1;
                        }
                        else
                        {
                            report.Lose += 1;
                        }
                        report.Total += 1;
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return report;
        }

        public List<Report> GetAllUserReport()
        {
            List<Report> reports = new List<Report>();
            try
            {
                List<User> users = conn.Query<User>("Select * from User");
                if(users!=null && users.Count > 0)
                {
                    foreach(User user in users)
                    {
                        Report report = GetReport(user.UserName);
                        reports.Add(report);
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return reports;
        }

        public void CreateDBTable()
        {
            try
            {
                conn.CreateTable<User>();
                conn.CreateTable<UserGame>();
            }
            catch (Exception ex) { }
            }
        
    }
}