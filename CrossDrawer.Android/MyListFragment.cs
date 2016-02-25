using Android.OS;
using Android.Views;
using Fragment = Android.Support.V4.App.Fragment;

namespace CrossDrawer.Android
{
	public class MyListFragment : Fragment
	{
		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			return inflater.Inflate(Resource.Layout.MyListView, container, false);
		}
	}
}