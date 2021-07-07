using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using HangmanGameApp.Database;
using HangmanGameApp.Utility;
using Java.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HangmanGameApp
{
    [Activity(Label = "Hangman Game")]
    public class HangmanActivity : AppCompatActivity
    {
        string username;
        HardWords hardWords;
        TextView textGuess, textScore, textMaxScore, textWrongAttempt;
        Logic logic;
        int wrong;
        DBOperation operation;
        Button btn;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_hangman);
            operation = new DBOperation();
            hardWords = new HardWords(this);
            logic = new Logic(hardWords.GetWord());
            username = Intent.GetStringExtra("UserName");
            textGuess = FindViewById<TextView>(Resource.Id.textGuess);
            textScore = FindViewById<TextView>(Resource.Id.textScore);
            textMaxScore = FindViewById<TextView>(Resource.Id.textMaxScore);
            textWrongAttempt = FindViewById<TextView>(Resource.Id.textWrongAttempt);
            textGuess.Text = logic.GetGuessString();
            textMaxScore.Text = " Max Score: " + logic.GetScore();
            wrong = logic.WrongAllowed();
            textWrongAttempt.Text = "Remaining Attempt: " + wrong;
            btn = FindViewById<Button>(Resource.Id.btn);
            btn.Click += Btn_Click;
            
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            UserGame game = new UserGame();
            game.Score = logic.GetPlayerScore();
            game.UserName = username;
            game.Status = "LOSE";
            operation.AddNewUserGame(game);
            Intent intent = new Intent(this, typeof(GameResultActivity));
            intent.PutExtra("Status", game.Status);
            intent.PutExtra("UserName", username);
            StartActivity(intent);
            Finish();
        }

        [Export("OnClick")]
        public void OnClick(View view)
        {
            if (view is Button)
            {
                Button btn = view as Button;
                if (btn.Enabled)
                {
                    char ch = btn.Text[0];
                    btn.Enabled = false;
                    btn.SetBackgroundResource(Resource.Drawable.button1);
                    if (logic.ProcessCharacter(ch))
                    {
                        textGuess.Text = logic.GetGuessString();
                        textScore.Text = " Your Score: " + logic.GetPlayerScore();
                        if (logic.Compare())
                        {
                            ProcessResult();
                        }
                    }
                    else
                    {
                        wrong--;
                        if (wrong == -1)
                        {
                            ProcessResult();
                        }
                        else
                        {
                            textWrongAttempt.Text = "Remaining Attempt: " + wrong;
                        }

                    }
                }
            }
        }

        public void ProcessResult()
        {
            UserGame game = new UserGame();
            game.Score = logic.GetPlayerScore();
            game.UserName = username;
            if (logic.Compare())
            {
                game.Status = "WIN";
            }
            else
            {
                game.Status = "LOSE";
            }
            operation.AddNewUserGame(game);
            Intent intent = new Intent(this, typeof(GameResultActivity));
            intent.PutExtra("Status", game.Status);
            intent.PutExtra("UserName", username);
            StartActivity(intent);
            Finish();
        }
    }
}