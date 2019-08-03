using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace Fragments
{
    public class InformacionFragment : Android.Support.V4.App.Fragment
    {
        ImageView imgLogo;
        TextView edtTexto;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
       }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment


            //return base.OnCreateView(inflater, container, savedInstanceState);
            //return base.OnCreateView(inflater, container, savedInstanceState);
            return inflater.Inflate(Resource.Layout.informacion_fragment, container, false);
        }

        public void updateInformacion(string informacion, int logo)
        {
           
            imgLogo = Activity.FindViewById<ImageView>(Resource.Id.imgLogo);
            edtTexto = Activity.FindViewById<TextView>(Resource.Id.edtTexto);

            imgLogo.SetImageResource(logo);
            edtTexto.SetText(informacion, TextView.BufferType.Normal);
        }

        public override void OnStart()
        {
            base.OnStart();

            if (Arguments != null)
                updateInformacion(Arguments.GetString("informacion"), Arguments.GetInt("logo"));
        }

    }
}