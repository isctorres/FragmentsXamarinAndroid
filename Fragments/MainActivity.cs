using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;

namespace Fragments
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, IEstadoSeleccionado, ICiudadSeleccionada
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public void OnEstadoSeleccionado(string[][] ciudades, int[][] logos, string[][] info, int posicion)
        {
            var ciudadesFragment = SupportFragmentManager.FindFragmentById(Resource.Id.ciudades) as CiudadesFragment;
            ciudadesFragment.updateCiudades(ciudades[posicion], logos[posicion], info[posicion]);
        }

        public void OnCiudadSeleccionada(string informacion, int logo)
        {
            var informacionFragment = SupportFragmentManager.FindFragmentById(Resource.Id.informacion) as InformacionFragment;
            informacionFragment.updateInformacion(informacion, logo);
        }
    }
}