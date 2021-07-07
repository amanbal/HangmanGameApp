using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HangmanGameApp
{
    [Activity(Label = "Hangman Game Home")]
    public class HomeActivity : AppCompatActivity
    {
        string username;
        TextView textWelcome;
        Button btnPlay, btnGameReport1, btnGameReport2, btnGameReport3, btnLogOut;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState); 
            SetContentView(Resource.Layout.activity_home);
            textWelcome = FindViewById<TextView>(Resource.Id.textWelcome);
            
            username = Intent.GetStringExtra("UserName");
            textWelcome.Text = "Welcome " + username + "!!!";
            
            btnPlay = FindViewById<Button>(Resource.Id.btnPlay);
            btnPlay.Click += Play_Click;
            btnGameReport1 = FindViewById<Button>(Resource.Id.btnGameReport1);
            btnGameReport1.Click += BtnGameReport1_Click;
            btnGameReport2 = FindViewById<Button>(Resource.Id.btnGameReport2);
            btnGameReport2.Click += BtnGameReport2_Click;
            btnGameReport3 = FindViewById<Button>(Resource.Id.btnGameReport3);
            btnGameReport3.Click += BtnGameReport3_Click;
            btnLogOut = FindViewById<Button>(Resource.Id.btnLogOut);
            btnLogOut.Click += LogOut_Click;
        }

        private void BtnGameReport1_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(ReportActivity));
            intent.PutExtra("Type", "WIN");
            intent.PutExtra("UserName", username);
            StartActivity(intent);
        }

        private void BtnGameReport2_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(ReportActivity));
            intent.PutExtra("Type", "LOSE");
            intent.PutExtra("UserName", username);
            StartActivity(intent);
        }

        private void BtnGameReport3_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(ReportActivity));
            intent.PutExtra("Type", "SCORE");
            intent.PutExtra("UserName", username);
            StartActivity(intent);
        }

        private void Play_Click(object sender, EventArgs args)
        {
            Intent intent = new Intent(this, typeof(HangmanActivity));
            intent.PutExtra("UserName", username);
            StartActivity(intent);
        }
        private void LogOut_Click(object sender, EventArgs args)
        {
            StartActivity(typeof(LoginActivity));
            Finish();
        }
    }
}