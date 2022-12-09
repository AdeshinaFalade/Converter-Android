using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Converter_Android
{
    internal class MainViewModel 
    {
        public int ArabicNumeral { get; set; }
        public string RomanNumeral { get; set; }


        public void IntegerToRoman(int num)
        {
            string result = "";
            Dictionary<string, int> romanDic = new Dictionary<string, int> {
                {"I",1 },{"IV",4},{"V",5},{"IX",9},{"X",10},{"XL",40},{"L",50},{"XC",90},{"C",100},{"CD",400},{"D",500},{"CM",900},{"M",1000}
            };
            try
            {
                foreach (var item in romanDic.Reverse())
                {
                    if (num <= 0) break;
                    while (num >= item.Value)
                    {
                        result += item.Key;
                        num -= item.Value;
                    }
                }

            }
            catch (Exception e)
            {
                var error = e.Message;
            }
            RomanNumeral = result;
        }

        public void Roman(string rom)
        {
            var ro = rom.ToLower();             //convert parameter to lower case
            char[] roman = ro.ToCharArray();        //convert string to an array of characters
            int total = 0;


            try
            {
                for (int i = 0; i < roman.Length; i++)      //loops through the array
                {
                    if (roman[i].ToString() == "i")
                    {
                        total += 1;
                    }
                    if (roman[i].ToString() == "v")
                    {
                        total += 5;
                    }
                    if (roman[i].ToString() == "x")
                    {
                        total += 10;
                    }
                    if (roman[i].ToString() == "l")
                    {
                        total += 50;
                    }
                    if (roman[i].ToString() == "c")
                    {
                        total += 100;
                    }
                    if (roman[i].ToString() == "d")
                    {
                        total += 500;
                    }
                    if (roman[i].ToString() == "m")
                    {
                        total += 1000;
                    }
                    //This part helps with numbers like '4' that have 'i' before 'v'
                    if (roman[i].ToString() == "i" && roman[i + 1].ToString() == "v" && roman.Length >= 2)
                    {
                        total -= 2;
                    }
                    if (roman[i].ToString() == "i" && roman[i + 1].ToString() == "x" && roman.Length >= 2)
                    {
                        total -= 2;
                    }
                    if (roman[i].ToString() == "x" && roman[i + 1].ToString() == "l" && roman.Length >= 2)
                    {
                        total -= 20;
                    }
                    if (roman[i].ToString() == "x" && roman[i + 1].ToString() == "c" && roman.Length >= 2)
                    {
                        total -= 20;
                    }
                    if (roman[i].ToString() == "c" && roman[i + 1].ToString() == "d" && roman.Length >= 2)
                    {
                        total -= 200;
                    }
                    if (roman[i].ToString() == "c" && roman[i + 1].ToString() == "m" && roman.Length >= 2)
                    {
                        total -= 200;
                    }


                }
            }
            catch (Exception e)
            {

                var error = e.Message;
            }
            ArabicNumeral = total;

        }
    }
}