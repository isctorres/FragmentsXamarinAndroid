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
            View view = inflater.Inflate(Resource.Layout.informacion_fragment, container, false);
            imgLogo = view.FindViewById<ImageView>(Resource.Id.imgLogo);
            edtTexto = view.FindViewById<TextView>(Resource.Id.edtTexto);

            return view;
            //return base.OnCreateView(inflater, container, savedInstanceState);
        }

        public void updateInformacion(string informacion, int logo)
        {
            imgLogo.SetImageResource(logo);
            edtTexto.SetText(informacion, TextView.BufferType.Normal);
        }
    }
}