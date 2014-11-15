using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.Threading;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;

namespace DosBoxLoader
{
	public class ViewModel : INotifyPropertyChanged
	{
		BindingList<DosProgram> _programs = new BindingList<DosProgram>();
		public BindingList<DosProgram> programs
		{
			get { return _programs; }
			set
			{
				_programs = value;
				NotifyPropertyChanged("programs");
			}
		}

		string _dosbox_exe_location = "";
		public string dosbox_exe_location
		{
			get { return _dosbox_exe_location; }
			set
			{
				_dosbox_exe_location = value;
				NotifyPropertyChanged("dosbox_exe_location");
			}
		}

		//EVENT
		public event PropertyChangedEventHandler PropertyChanged;
		private void NotifyPropertyChanged(string property_name)
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(property_name));
		}
	}
}