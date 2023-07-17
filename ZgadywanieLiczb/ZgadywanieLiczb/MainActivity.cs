using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace ZgadywanieLiczb
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        private int liczba;
        private Random los = new Random();
        private int ile_prob;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);



        
            liczba = los.Next(1, 100);
            ile_prob = 0;
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View)sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
        }

        public void reset(View v){
            EditText e = this.FindViewById<EditText>(Resource.Id.editText1);
            e.Text = "";
            liczba = los.Next(1, 100);
            ile_prob = 0;
        }

        public void zgaduj(View v)
        {
            EditText e = this.FindViewById<EditText>(Resource.Id.editText1);
            int szukana = int.Parse(e.Text);
            ile_prob++;
            TextView tv = this.FindViewById<TextView>(Resource.Id.textView1);
            if (liczba == szukana) tv.Text = "Zgadłeś po: " + ile_prob.ToString() + " próbach.";
            else if (liczba > szukana) tv.Text = "Szukana liczba jest mniejsza";
            else tv.Text = "Szukana liczba jest większa";
        }
	}
}

