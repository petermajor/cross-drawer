using System.Linq;
using Android.App;
using Android.OS;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using CrossDrawer.Core;
using MvvmCross.Droid.Support.V7.AppCompat;
using Fragment = Android.Support.V4.App.Fragment;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace CrossDrawer.Android
{
	[Activity]
	public class MainActivity : MvxCachingFragmentCompatActivity<MainViewModel>
	{
		ActionBarDrawerToggle _drawerToggle;

		ListView _drawerListView;

		DrawerLayout _drawerLayout;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.Main);

			var toolbar = FindViewById<Toolbar> (Resource.Id.toolbar);
			SetSupportActionBar (toolbar);

			SupportActionBar.SetDisplayHomeAsUpEnabled (true);

			_drawerListView = FindViewById<ListView> (Resource.Id.drawerListView);
			_drawerListView.ItemClick += (s, e) => ShowFragmentAt (e.Position);
			_drawerListView.Adapter = new ArrayAdapter<string> (this, global::Android.Resource.Layout.SimpleListItem1, ViewModel.MenuItems.ToArray());

			_drawerLayout = FindViewById<DrawerLayout> (Resource.Id.drawerLayout);

			_drawerToggle = new ActionBarDrawerToggle (this, _drawerLayout, Resource.String.OpenDrawerString, Resource.String.CloseDrawerString);

			_drawerLayout.SetDrawerListener (_drawerToggle);

			ShowFragmentAt (0);
		}

		void ShowFragmentAt (int position)
		{
			ViewModel.NavigateTo (position);

			Title = ViewModel.MenuItems.ElementAt (position);

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