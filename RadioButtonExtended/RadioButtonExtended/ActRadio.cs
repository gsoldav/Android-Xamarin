using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace RadioButtonExtended
{
    [Activity(Label = "RadioButtonExtended", Icon = "@drawable/RadioButtonExtended")]
    public class ActRadio : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.ActRadio);
        }
    }
}

