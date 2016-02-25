using MvvmCross.Core.ViewModels;

namespace CrossDrawer.Core
{
	public class App : MvxApplication
	{
		public override void Initialize()
		{
			base.Initialize();

			InitializeNavigation();
		}

		void InitializeNavigation()
		{
			RegisterAppStart<MainViewModel>();
		}
	}
}
