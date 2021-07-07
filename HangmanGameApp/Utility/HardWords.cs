using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HangmanGameApp.Utility
{
    public class HardWords
    {
        private List<string> hardWords;

        private Context context;

        public HardWords(Context context)
        {
            this.context = context;
            hardWords = new List<string>();
            try
            {
                using (StreamReader reader = new StreamReader(context.Assets.Open("hardwords.txt")))
                {
                    while (!reader.EndOfStream)
                    {
                        string word = reader.ReadLine();
                        hardWords.Add(word.ToUpper());
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        public string GetWord()
        {
            if(hardWords.Count > 0)
            {
                hardWords = hardWords.OrderBy(i => Guid.NewGuid()).ToList();
                return hardWords[0];
            }
            return null;
        }
    }
}