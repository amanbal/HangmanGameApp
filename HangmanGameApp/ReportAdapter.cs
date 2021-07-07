using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using HangmanGameApp.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HangmanGameApp
{
    public class ReportAdapter : BaseAdapter<Report>
    {
        private readonly Activity context;
        private readonly List<Report> reports;

        public ReportAdapter(Activity context, List<Report> reports)
        {
            this.reports = reports;
            this.context = context;
        }

        public override int Count
        {
            get { return reports.Count; }

        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override Report this[int position]
        {
            get { return reports[position]; }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var row = convertView;

            if (row == null)
            {
                row = LayoutInflater.From(context).Inflate(Resource.Layout.list_report_row, null, false);
            }

            TextView t1 = row.FindViewById<TextView>(Resource.Id.text1);
            TextView t2 = row.FindViewById<TextView>(Resource.Id.text2);
            TextView t3 = row.FindViewById<TextView>(Resource.Id.text3);
            TextView t4 = row.FindViewById<TextView>(Resource.Id.text4);

            Report report = reports[position];

            t1.Text = "User Name: " + report.UserName;
            t2.Text = "Total Game Played: " + report.Total;
            t3.Text = report.Win + " Win(s) " + report.Lose + " Lose(s)";
            t4.Text = "Total Score: " + report.Score;

            return row;
        }
    }
}