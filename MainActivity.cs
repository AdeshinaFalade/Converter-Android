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
using System.Linq;

namespace Converter_Android
{
    [Activity(Label = "Roman Numeral Converter", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        TextView txtResult;
        Spinner spinner;
        EditText edt;
        MainViewModel viewModel;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            edt = FindViewById<EditText>(Resource.Id.edtRoman);
            txtResult = FindViewById<TextView>(Resource.Id.txtResult);
            spinner = FindViewById<Spinner>(Resource.Id.spinner1);
            viewModel= new MainViewModel();
            
            //spinner setup
            ArrayAdapter adapter;
            adapter = ArrayAdapter.CreateFromResource(this, Resource.Array.option, Android.Resource.Layout.SimpleSpinnerItem);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner.Adapter = adapter;
            spinner.ItemSelected += Spinner_ItemSelected;
           


            FindViewById<Button>(Resource.Id.btnConvert).Click += (o, e) => {
                var action = spinner.SelectedItem.ToString(); 
                try
                {

                    if (action == "Roman to Integer")
                    {
                        viewModel.Roman(edt.Text);
                        txtResult.Text = viewModel.ArabicNumeral.ToString();
                    }
                    else
                    {
                        viewModel.IntegerToRoman(int.Parse(edt.Text));
                        txtResult.Text = viewModel.RomanNumeral.ToString();     //here
                    }
                }
                catch (Exception ex)
                {
                    txtResult.Text = ex.Message;
                }

            };
            
        }

        private void Spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            var action = spinner.SelectedItem.ToString();
            if (action == "Roman to Integer")
            {
                edt.InputType = Android.Text.InputTypes.ClassText;
            }
            else if (action == "Integer to Roman")
            {
                edt.InputType = Android.Text.InputTypes.ClassNumber;
            }
        }

        

       
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}