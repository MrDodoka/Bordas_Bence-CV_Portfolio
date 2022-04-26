using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordGeneratorLibrary
{
    public class PasswordGeneratorModel
    {
        //Properties for the mixer to work
        public string[] AllLetters { get; private set; }
        public int[] AllNumber { get; private set; }
        public string[] AllSymbols { get; private set; }

        public int letters { get; set; }
        public int numbers { get; set; }
        public int symbols { get; set; }

        public PasswordGeneratorModel()
        {
            AllLetters = new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
            AllNumber = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            AllSymbols = new string[] { "!", "\"", "#", "$", "%", "&", "\'", "(", ")", "*", "+", ",", "-", ".", "/", ":", ";", "<", "=", ">", "?", "@", "[", "\\", "]", "^", "_", "`", "{", "|", "}", "~" };
        }

        /* The main method, it mixes a password, with the given number of letters, numbers and symbols.
         * Randomly makes a letter upper or lower case.
         * Then the randomly gatherd letters, numbers, symbols are randomly built into a string.
         */
        public string PasswordMixer()
        {
            string result = string.Empty;
            List<object> mix = new List<object>();
            Random rnd = new Random();
            int caseOfLatter = 0;

            for (int i = 0; i < letters; i++)
            {
                caseOfLatter = rnd.Next(0, 2);
                if (caseOfLatter.Equals(0))
                    mix.Add(AllLetters[rnd.Next(0, AllLetters.Length)].ToLower());
                else if (caseOfLatter.Equals(1))
                    mix.Add(AllLetters[rnd.Next(0, AllLetters.Length)].ToUpper());
            }

            for (int i = 0; i < numbers; i++)
                mix.Add(AllNumber[rnd.Next(0, AllNumber.Length)]);

            for (int i = 0; i < symbols; i++)
                mix.Add(AllSymbols[rnd.Next(0, AllSymbols.Length)]);

            int length = mix.Count;
            int rndNumber = 0;

            while (mix.Count > 0)
            {
                rndNumber = rnd.Next(0, length);
                result += mix[rndNumber];
                mix.RemoveAt(rndNumber);
                length--;
            }

            return result;
        }
    }
}
