using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HangmanGameApp.Database
{
    public class Report
    {
        public string UserName { get; set; }

        public int Score { get; set; }

        public int Win { get; set; }

        public int Lose { get; set; }

        public int Total { get; set; }

        public Report()
        {

        }
        public Report(string username)
        {
            UserName = username;
        }
        public Report(string username, int score, int win, int lose)
        {
            UserName = username;
            Win = win;
            Lose = lose;
            Score = score;
            Total = Win + Lose;
        }

        public static void SortByWin(List<Report> reports)
        {
            for (int i = 0; i < reports.Count - 1; i++)
            {
                for (int j = 0; j < reports.Count - i - 1; j++)
                {
                    if (reports[j].Win < reports[j + 1].Win)
                    {
                        Report temp = reports[j];
                        reports[j] = reports[j + 1];
                        reports[j + 1] = temp;
                    }
                }
            }
        }

        public static void SortByLose(List<Report> reports)
        {
            for (int i = 0; i < reports.Count - 1; i++)
            {
                for (int j = 0; j < reports.Count - i - 1; j++)
                {
                    if (reports[j].Lose < reports[j + 1].Lose)
                    {
                        Report temp = reports[j];
                        reports[j] = reports[j + 1];
                        reports[j + 1] = temp;
                    }
                }
            }
        }

        public static void SortByScore(List<Report> reports)
        {
            for (int i = 0; i < reports.Count - 1; i++)
            {
                for (int j = 0; j < reports.Count - i - 1; j++)
                {
                    if (reports[j].Score < reports[j + 1].Score)
                    {
                        Report temp = reports[j];
                        reports[j] = reports[j + 1];
                        reports[j + 1] = temp;
                    }
                }
            }
        }
    }
}