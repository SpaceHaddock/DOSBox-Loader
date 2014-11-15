using System.ComponentModel;

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