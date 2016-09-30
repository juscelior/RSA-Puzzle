using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using RSA_Puzzle.Portable;

namespace RSA_Puzzle.Android
{
    [Activity(Label = "RSA_Puzzle.Android", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.btnProcessar);
            EditText edtChavePublica = FindViewById<EditText>(Resource.Id.edtChavePublica);
            EditText edtCorpoN = FindViewById<EditText>(Resource.Id.edtCorpoN);
            EditText edtMensagemCifrada = FindViewById<EditText>(Resource.Id.edtMensagemCifrada);

            edtChavePublica.Text = "107074310067384015279771780359";
            edtCorpoN.Text = "716986706621138193334849008809";
            edtMensagemCifrada.Text = "609810477808753196933983953492";

            button.Click += delegate
            {
                RSAPuzzle rsa = new RSAPuzzle(edtChavePublica.Text.Trim(), edtCorpoN.Text.Trim(), edtMensagemCifrada.Text.Trim());

                RSAInfo info = rsa.Resolver();

                TextView textView01 = FindViewById<TextView>(Resource.Id.textView01);

                textView01.Text = info.Imprimir();

                textView01.Text += new RSATest(info).Imprimir();

            };
        }
    }
}

