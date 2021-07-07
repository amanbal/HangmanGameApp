using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using HangmanGameApp.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HangmanGameApp
{
    [Activity(Label = "Game History Report")]
    public class ReportActivity : AppCompatActivity
    {
        ListView listReport;
        DBOperation operation;
        ReportAdapter adapter;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_report);
            operation = new DBOperation();
            string type = Intent.GetStringExtra("Type");

            listReport = FindViewById<ListView>(Resource.Id.listReport);
            List<Report> reports = operation.GetAllUserReport();
            if(type.Equals("WIN"))
            {
                Report.SortByWin(reports);
            }
            else if(type.Equals("LOSE"))
            {
                Report.SortByLose(reports);
            }
            else
            {
                Report.SortByScore(reports);
            }
            adapter = new ReportAdapter(this, reports);
            listReport.Adapter = adapter;
        }
    }
}