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

namespace HangmanGameApp.Utility
{
    public class Logic
    {
        private char[] word;
        private char[] guess;
        private int score;
        private int playerScore;

        public Logic(string word)
        {
            this.word = word.ToCharArray();
            CalculateScore();
            PrepareGuess();
        }

        public int WrongAllowed()
        {
            return word.Length - 1;
        }

        public int GetScore()
        {
            return score;
        }

        public int GetPlayerScore()
        {
            return playerScore;
        }

        public string GetGuessString()
        {
            string guess_string = "";
            foreach (char ch in guess)
            {
                guess_string += ch + " ";
            }
            return guess_string;
        }

        private void CalculateScore()
        {
            score = 0;
            for (int index = 0; index < word.Length; index++)
            {
                char ch = word[index];
                if (char.IsLetter(ch))
                {
                    switch (ch)
                    {
                        case 'Y':
                        case 'B':
                        case 'C':
                        case 'F':
                        case 'G':
                        case 'M':
                        case 'P':
                        case 'U':
                        case 'W':
                            score += 2;
                            break;
                        case 'J':
                        case 'K':
                        case 'Q':
                        case 'V':
                        case 'X':
                        case 'Z':
                            score += 5;
                            break;
                        default:
                            score += 1;
                            break;
                    }
                }
            }
        }

        public bool ProcessCharacter(char ch)
        {
            bool found = false;
            for (int index = 0; index < word.Length; index++)
            {
                if (ch == word[index])
                {
                    guess[index] = word[index];
                    switch (ch)
                    {
                        case 'Y':
                        case 'B':
                        case 'C':
                        case 'F':
                        case 'G':
                        case 'M':
                        case 'P':
                        case 'U':
                        case 'W':
                            playerScore += 2;
                            break;
                        case 'J':
                        case 'K':
                        case 'Q':
                        case 'V':
                        case 'X':
                        case 'Z':
                            playerScore += 5;
                            break;
                        default:
                            playerScore += 1;
                            break;
                    }
                    found = true;
                }
            }
            return found;
        }

        private void PrepareGuess()
        {
            guess = new char[word.Length];
            for (int index = 0; index < word.Length; index++)
            {
                if (char.IsLetter(word[index]))
                {
                    guess[index] = '_';
                }
                else
                {
                    guess[index] = word[index];
                }
            }
        }

        public bool Compare()
        {
            for (int index = 0; index < word.Length; index++)
            {
                if (word[index] != guess[index])
                {
                    return false;
                }
            }
            return true;
        }
    }
}