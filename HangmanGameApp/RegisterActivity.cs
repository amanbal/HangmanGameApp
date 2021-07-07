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
    [Activity(Label = "Register User")]
    public class RegisterActivity : AppCompatActivity
    {
        Button btnCreate;
        EditText etUser, etPass, etConfirm;
        DBOperation operation;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_register);
            operation = new DBOperation();
            etUser = FindViewById<EditText>(Resource.Id.etUserName);
            etPass = FindViewById<EditText>(Resource.Id.etPassword);
            etConfirm = FindViewById<EditText>(Resource.Id.etConfirm);
            btnCreate = FindViewById<Button>(Resource.Id.btnCreate);
            btnCreate.Click += Create_Click;
        }
        public void Create_Click(object sender, EventArgs args)
        {
            string username = etUser.Text.Trim();
            string pass = etPass.Text;
            string cpass = etConfirm.Text;
            string message = "";
            if (username.Length == 0 || pass.Length == 0 || cpass.Length == 0)
            {
                message = "Please Fill All Boxes";
            }
            else if (pass.Equals(cpass))
            {
                User user = new User();
                user.UserName = username;
                user.Password = pass;
                if (operation.AddNewUser(user))
                {
                    message = "User is Created";
                    Intent intent = new Intent(this, typeof(HomeActivity));
                    intent.PutExtra("UserName", username);
                    StartActivity(intent);
                    Finish();
                }
                else
                {
                    message = "There is Some Error in Creating in User";
                }
            }
            else
            {
                message = "Confirm Password must be match with Password";
            }
            Toast.MakeText(this, message, ToastLength.Long).Show();
        }
    }
}