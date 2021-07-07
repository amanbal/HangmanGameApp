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
    [Activity(Label = "Login To Game")]
    public class LoginActivity : AppCompatActivity
    {
        Button btnLogin, btnRegister;
        EditText etUser, etPassword;
        DBOperation operation;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_login);
            operation = new DBOperation();
            etUser = FindViewById<EditText>(Resource.Id.etUserName);
            etPassword = FindViewById<EditText>(Resource.Id.etPassword);

            btnLogin = FindViewById<Button>(Resource.Id.btnLogin);
            btnRegister = FindViewById<Button>(Resource.Id.btnRegister);
            btnLogin.Click += Login_Click;
            btnRegister.Click += Register_Click;
        }
        private void Login_Click(object sender, EventArgs args)
        {
            string username = etUser.Text.Trim();
            string pass = etPassword.Text;
            string message = "";
            if (username.Length == 0 || pass.Length == 0)
            {
                message = "Please Fill All Boxes";
            }
            else
            {
                if (operation.ValidUser(username, pass))
                {
                    Intent intent = new Intent(this, typeof(HomeActivity));
                    intent.PutExtra("UserName", username);
                    StartActivity(intent);
                    Finish();
                }
                else
                {
                    message = "Invalid User Name and Password";
                }
            }
            if (!message.Equals(""))
            {
                Toast.MakeText(this, message, ToastLength.Long).Show();
            }            
        }

        private void Register_Click(object sender, EventArgs args)
        {
            StartActivity(typeof(RegisterActivity));
            Finish();
        }
    }
}