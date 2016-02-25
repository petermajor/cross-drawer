using Android.App;
using Android.OS;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Fragment = Android.Support.V4.App.Fragment;

namespace CrossDrawer.Android
{
	[Activity (MainLauncher = true)]
	public class MainActivity : AppCompatActivity
	{
		Fragment[] _fragments = { new MyListFragment(), new MySettingsFragment() };

		string[] _titles = { "My List", "My Settings" };

		ActionBarDrawerToggle _drawerToggle;

		ListView _drawerListView;

		DrawerLayout _drawerLayout;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			SetContentView (Resource.Layout.Main);

			SupportActionBar.SetDisplayHomeAsUpEnabled (true);

			_drawerListView = FindViewById<ListView> (Resource.Id.drawerListView);
			_drawerListView.ItemClick += (s, e) => ShowFragmentAt (e.Position);
			_drawerListView.Adapter = new ArrayAdapter<string> (this, global::Android.Resource.Layout.SimpleListItem1, _titles);

			_drawerLayout = FindViewById<DrawerLayout> (Resource.Id.drawerLayout);

			_drawerToggle = new ActionBarDrawerToggle (this, _drawerLayout, Resource.String.OpenDrawerString, Resource.String.CloseDrawerString);

			_drawerLayout.SetDrawerListener (_drawerToggle);

			ShowFragmentAt (0);
		}

		void ShowFragmentAt (int position)
		{
			SupportFragmentManager.BeginTransaction ().Replace (Resource.Id.frameLayout, _fragments [position]).Commit ();

			Title = _titles [position];

			_drawerLayout.CloseDrawer (_drawerListView);
		}

		protected override void OnPostCreate (Bundle savedInstanceState)
		{
			_drawerToggle.SyncState ();

			base.OnPostCreate (savedInstanceState);
		}

		public override bool OnOptionsItemSelected (IMenuItem item)
		{
			if (_drawerToggle.OnOptionsItemSelected (item))
				return true;

			return base.OnOptionsItemSelected (item);
		}
	}
}