﻿using System;
using System.Collections.Generic;
using System.IO;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace DosBoxLoader
{
	/// <summary>
	/// Holds information relating to an individual DOSProgram
	/// </summary>
	public class DosProgram : INotifyPropertyChanged
	{
		string _file_name = "File unset";
		public string file_name
		{
			get { return _file_name; }
			set
			{
				_file_name = value;
				NotifyPropertyChanged("file_name");
			}
		}

		string _directory = "Directory unset";
		public string directory
		{

			get { return _directory; }
			set
			{
				_directory = value;
				NotifyPropertyChanged("directory");
			}
		}


		ObservableCollection<string> _additional_exe = new ObservableCollection<string>();
		public ObservableCollection<string> additional_exe
		{
			get { return _additional_exe; }
			set
			{
				_additional_exe = value;
				NotifyPropertyChanged("additional_exe");
            }
		}

		public void InputProgramLocation(string input_file_location)
		{
			file_name = Path.GetFileNameWithoutExtension(input_file_location);
			directory = Path.GetDirectoryName(input_file_location);
		}

		//Constructors
		public DosProgram() { }
		public DosProgram(string input_string)
		{
			StringRead(input_string);
		}

		//IO
		public void StringRead(string input)
		{
			var inputs = input.Split(' ');
			file_name = inputs[0];
			directory = inputs[1];
		}

		public override string ToString()
		{
			List<string> values = new List<string>() { file_name, directory };
			return String.Join(" ", values);
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