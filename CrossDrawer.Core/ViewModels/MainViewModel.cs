using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;

namespace CrossDrawer.Core
{
	public class MainViewModel : MvxViewModel
	{
		readonly Type[] _menuItemTypes = {
			typeof(MyListViewModel),
			typeof(MySettingsViewModel),
		};

		public IEnumerable<string> MenuItems { get; private set; } = new [] { "My List", "My Settings" };

		public void ShowDefaultMenuItem()
		{
			NavigateTo (0);
		}

		public void NavigateTo (int position)
		{
			ShowViewModel (_menuItemTypes [position]);
		}
	}

	public class MenuItem : Tuple<string, Type>
	{
		public MenuItem (string displayName, Type viewModelType)
			: base (displayName, viewModelType)
		{}

		public string DisplayName
		{
			get { return Item1; }
		}

		public Type ViewModelType
		{
			get { return Item2; }
		}
	}
}