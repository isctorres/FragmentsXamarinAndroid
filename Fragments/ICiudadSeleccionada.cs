using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Fragments
{
    interface ICiudadSeleccionada
    {
        void OnCiudadSeleccionada(string informacion, int logo);
    }
}