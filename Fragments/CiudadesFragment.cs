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
    public class CiudadesFragment : Android.Support.V4.App.ListFragment
    {
        ICiudadSeleccionada ciudadSeleccionada;
        string[] Ciudades;
        int[] logosCiudades;
        string[] infoCiudades;
        public override void OnAttach(Context context)
        {
            base.OnAttach(context);
            ciudadSeleccionada = context as ICiudadSeleccionada;
        }

        public override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            HasOptionsMenu = true;

            if (bundle != null)
            {
                updateCiudades(bundle.GetStringArray("CIUDADES"), bundle.GetIntArray("LOGOS"), bundle.GetStringArray("INFO"));
            }
            // Create your fragment here
        }

        public override void OnCreateOptionsMenu(IMenu menu, MenuInflater inflater)
        {
            if(!menu.HasVisibleItems)
                inflater.Inflate(Resource.Menu.menu_ciudades, menu);
        }
        public override void OnSaveInstanceState(Bundle outState)
        {
            outState.PutStringArray("CIUDADES",Ciudades);
            outState.PutIntArray("LOGOS", logosCiudades);
            outState.PutStringArray("INFO", infoCiudades);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle bundle)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            //return inflater.Inflate(Resource.Layout.content_detalles_ciudad, container, false);
            return base.OnCreateView(inflater, container, bundle);
        }

        public override void OnStart()
        {
            base.OnStart();

            if (Arguments != null)
                updateCiudades(Arguments.GetStringArray("ciudades"), Arguments.GetIntArray("logos"), Arguments.GetStringArray("info"));

            ListView.ItemClick += (sender, e) => {
                if (ciudadSeleccionada != null)
                {
                    ciudadSeleccionada.OnCiudadSeleccionada(infoCiudades[e.Position], logosCiudades[e.Position]);
                }
            };

        }
        
        public void updateCiudades(string[] ciudades, int[] logosCiudades, string[] infoCiudades)
        {
            this.Ciudades = ciudades;
            this.logosCiudades = logosCiudades;
            this.infoCiudades = infoCiudades;
            ListAdapter = new ArrayAdapter(
                Activity,
                Android.Resource.Layout.SimpleListItem1,
                ciudades);
        }
    }
}