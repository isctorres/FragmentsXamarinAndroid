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
        bool contiene;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            if (savedInstanceState != null)
                contiene = savedInstanceState.ContainsKey("horizontal-first");

            FrameLayout contenedor = FindViewById<FrameLayout>(Resource.Id.contenedorFragment);
            if (contenedor != null)
            {
                Android.Support.V4.App.Fragment estados = SupportFragmentManager.FindFragmentById(Resource.Id.estados);

                if (savedInstanceState == null || estados == null || savedInstanceState.GetBoolean("horizontal-first") )
                {
                    estados = new EstadosFragment();
                    SupportFragmentManager.BeginTransaction().Add(Resource.Id.contenedorFragment, estados).Commit();
                }
            }

            SupportFragmentManager.BackStackChanged += delegate {
                OnBackStackChanged();
            };
            OnBackStackChanged();
        }

        private void OnBackStackChanged()
        {
            bool hasBack = SupportFragmentManager.BackStackEntryCount > 0;
            SupportActionBar.SetDisplayHomeAsUpEnabled(hasBack);
        }
        public override bool OnSupportNavigateUp()
        {
            SupportFragmentManager.PopBackStack();
            return true;
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public void OnEstadoSeleccionado(string[][] ciudades, int[][] logos, string[][] info, int posicion)
        {
        
            FrameLayout contenedor = FindViewById<FrameLayout>(Resource.Id.contenedorFragment);
            if (contenedor != null)
            {
                Bundle args = new Bundle();
                args.PutStringArray("ciudades", ciudades[posicion]);
                args.PutIntArray("logos", logos[posicion]);
                args.PutStringArray("info", info[posicion]);

                CiudadesFragment ciudadesFragment = new CiudadesFragment();
                ciudadesFragment.Arguments = args;
                SupportFragmentManager.BeginTransaction().SetCustomAnimations(
                     Resource.Animator.voltear_a_la_derecha_in,
                     Resource.Animator.voltear_a_la_derecha_out,
                     Resource.Animator.voltear_a_la_izquierda,
                     Resource.Animator.voltear_a_la_izquierda_out
                     ).Replace(Resource.Id.contenedorFragment, ciudadesFragment).AddToBackStack(null).Commit();

            }
            else
            {
                var ciudadesFragment = SupportFragmentManager.FindFragmentById(Resource.Id.ciudades) as CiudadesFragment;
                ciudadesFragment.updateCiudades(ciudades[posicion], logos[posicion], info[posicion]);
            }

        }

        public void OnCiudadSeleccionada(string informacion, int logo)
        {

            FrameLayout contenedor = FindViewById<FrameLayout>(Resource.Id.contenedorFragment);
            if (contenedor != null)
            {
                Bundle args = new Bundle();
                args.PutString("informacion", informacion);
                args.PutInt("logo", logo);

                InformacionFragment infoCiudad = new InformacionFragment();
                infoCiudad.Arguments = args;
                SupportFragmentManager.BeginTransaction().Replace(Resource.Id.contenedorFragment, infoCiudad).SetTransition(Android.Support.V4.App.FragmentTransaction.TransitFragmentOpen).AddToBackStack(null).Commit();
            }
            else
            {
                var informacionFragment = SupportFragmentManager.FindFragmentById(Resource.Id.informacion) as InformacionFragment;
                informacionFragment.updateInformacion(informacion, logo);
            }
        }

        protected override void OnSaveInstanceState(Bundle outState)
        {
            base.OnSaveInstanceState(outState);
            FrameLayout contenedor = FindViewById<FrameLayout>(Resource.Id.contenedorFragment);
            if (contenedor == null && !contiene)//Se inició en horizontal
                outState.PutBoolean("horizontal-first", true);
            else
                outState.PutBoolean("horizontal-first", false);
        }

    }
}