using Android.App;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using Android.Widget;
using System;
using Android.Views;
using AndroidX.AppCompat.Widget;
using Google.Android.Material.FloatingActionButton;
using Google.Android.Material.Snackbar;
using System.Collections.Generic;
using Google.Android.Material.Button;
using Android.Content;

namespace Converter_Android
{
    [Activity(Label = "Roman Numeral Converter", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        TextView txtResult;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            var edt = FindViewById<EditText>(Resource.Id.edtRoman);
            txtResult = FindViewById<TextView>(Resource.Id.txtResult);
            FindViewById<Button>(Resource.Id.btnConvert).Click += (o, e) =>
            txtResult.Text = Roman(edt.Text).ToString();
            
            

        }

        public static int Roman(string rom)
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
            return total;

        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}