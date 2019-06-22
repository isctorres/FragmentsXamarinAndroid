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
    public class EstadosFragment : Android.Support.V4.App.ListFragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        IEstadoSeleccionado estadoSeleccionado;
        public override void OnAttach(Context context)
        {
            base.OnAttach(context);
            estadoSeleccionado = context as IEstadoSeleccionado;
        }
        public override void OnStart()
        {
            base.OnStart();
            ListAdapter = new ArrayAdapter(
                Activity,
                Android.Resource.Layout.SimpleListItem1,
                new[] { "Guanajuato", "Durango", "Zacatecas", "Nayarit", "Michoacan", "Oaxaca", "Hidalgo"});

            string[][] items = new string[][] {
                                                new string[]{ "Irapuato", "León", "Silao", "Salamanca", "Acambaro" },
                                                new string[]{ "Canatlan", "Mapimí", "El Oro", "Guanaceví", "Lerdo" },
                                                new string[]{ "Fresnillo", "Jerez", "Juchipila", "Loreto", "Panuco" },
                                                new string[]{ "Acaponeta", "Ahuacatlán", "Amatlan de Cañas", "Compostela", "Huajicori" },
                                                new string[]{ "Angangueo", "Apatzingán", "Charo", "Huandacareo", "Huetamo" },
                                                new string[]{ "Cosolapa", "Ixtlán de Juarez", "Salina Cruz", "Juchitán de Zaragoza", "Guadalupe Etla" },
                                                new string[]{ "Huejutla de Reyes", "Huichapan", "Ixmiquilpan", "Jacala", "Mineral del Monte" },
                                              };

            int[][] logos = new int[][] {
                                        new int[]{ Resource.Drawable.irapuato, Resource.Drawable.leon, Resource.Drawable.silaon, Resource.Drawable.salamanca, Resource.Drawable.acambaro },
                                        new int[]{ Resource.Drawable.canatlan, Resource.Drawable.mapimi, Resource.Drawable.el_oro, Resource.Drawable.durango, Resource.Drawable.durango },
                                        new int[]{ Resource.Drawable.zacatecas, Resource.Drawable.zacatecas, Resource.Drawable.zacatecas, Resource.Drawable.zacatecas, Resource.Drawable.zacatecas },
                                        new int[]{ Resource.Drawable.nayarit, Resource.Drawable.nayarit, Resource.Drawable.nayarit, Resource.Drawable.nayarit, Resource.Drawable.nayarit },
                                        new int[]{ Resource.Drawable.michoacan, Resource.Drawable.michoacan, Resource.Drawable.michoacan, Resource.Drawable.michoacan, Resource.Drawable.michoacan },
                                        new int[]{ Resource.Drawable.oaxaca, Resource.Drawable.oaxaca, Resource.Drawable.oaxaca, Resource.Drawable.oaxaca, Resource.Drawable.oaxaca },
                                        new int[]{ Resource.Drawable.hidalgo, Resource.Drawable.hidalgo, Resource.Drawable.hidalgo, Resource.Drawable.hidalgo, Resource.Drawable.hidalgo }
                                    };

            string[][] info = new string[][] {
                                        new string[]{ "Información de Irapuato", "Información de León", "Información de Silao", "Información de Salamanca", "Información de Acambaro" },
                                        new string[]{ "Información de Canatlan", "Información de Mapimí", "Información de El Oro", "Información de Guanaceví", "Información de Lerdo" },
                                        new string[]{ "Información de Fresnillo", "Información de Jeréz", "Información de Juchipila", "Información de Loreto", "Información de Panuco" },
                                        new string[]{ "Información de Acaponeta", "Información de Ahuacatlán", "Información de Amatlán de Cañas", "Información de Compostela", "Información de Huajicori"},
                                        new string[]{ "Información de Angangueo", "Información de Apatzingán", "Información de Charo", "Información de Huandacareo", "Información de Huetamo" },
                                        new string[]{ "Información de Cosolapa", "Información de Ixtlán de Juarez", "Información de Salina Cruz", "Información de Juchitán de Zaragoza", "Guadalupe de Etla" },
                                        new string[]{ "Información de Huejutla de Reyes", "Información de Huichapan", "Información de Ixmiquilpan", "Información de Jacala", "Información de Mineral del Monte" }
                                    };

            ListView.ItemClick += (sender, e) => {
                if (estadoSeleccionado != null)
                {
                    estadoSeleccionado.OnEstadoSeleccionado(items, logos, info, e.Position);
                }
            };

        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            return base.OnCreateView(inflater, container, savedInstanceState);
        }
    }
}