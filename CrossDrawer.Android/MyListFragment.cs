using Android.OS;
using Android.Runtime;
using Android.Views;
using CrossDrawer.Core;
using MvvmCross.Droid.Support.V7.Fragging.Attributes;
using MvvmCross.Droid.Support.V7.Fragging.Fragments;

namespace CrossDrawer.Android
{
	[MvxFragmentAttribute(typeof(MainViewModel), Resource.Id.frameLayout)]
	[Register("crossdrawer.android.MyListFragment")]
	public class MyListFragment : MvxFragment<MyListViewModel>
	{
		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			return inflater.Inflate(Resource.Layout.MyListView, container, false);
		}
	}
}