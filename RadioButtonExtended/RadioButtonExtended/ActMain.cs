using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace RadioButtonExtended
{
    [Activity(Label = "RadioButtonExtended", MainLauncher = true, Icon = "@drawable/RadioButtonExtended")]
    public class ActMain : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.ActMain);
            Button btnRadio = this.FindViewById<Button>(Resource.Id.btnRadio);
            btnRadio.Click += new EventHandler(btnRadio_Click);
        }

        void btnRadio_Click(object sender, EventArgs e)
        {
            try
            {
                Intent iActRadio = new Intent(this.ApplicationContext, typeof(ActRadio));
                this.StartActivity(iActRadio);
            }
            catch (Exception)
            { }
        }
    }
}

