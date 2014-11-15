using System;
using System.Windows;
using System.Windows.Controls;
using System.Diagnostics;
using System.IO;

namespace DosBoxLoader
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		const string saveto_filename = "configs.txt";
		ViewModel vm = new ViewModel();

		public MainWindow()
		{
			//Check for dosbox location
			if(!File.Exists(vm.dosbox_exe_location))
			{
				const string default_dosbox_location = @"C:\Program Files (x86)\DOSBox-0.74\DOSBox.exe";
				if (File.Exists(default_dosbox_location))
					vm.dosbox_exe_location = default_dosbox_location;
				else
					MessageBox.Show("Couldn't locate DOSBox.exe, please set you DOSBox.exe location before launching a game");
			}

			//Load previous config
			if (File.Exists(saveto_filename))
			{
				using (StreamReader reader = new StreamReader(saveto_filename))
				{
					vm.dosbox_exe_location = reader.ReadLine();
					while (reader.Peek() >= 0)
						vm.programs.Add(new DosProgram(reader.ReadLine()));
				}
			}

			InitializeComponent();
			this.DataContext = vm;
		}

		//Define location of DOSBox.exe
		private void SetDosLocation_Button(object sender, RoutedEventArgs e)
		{
			var of = new System.Windows.Forms.OpenFileDialog();
			of.ShowDialog();

			if (!String.IsNullOrEmpty(of.FileName))
				vm.dosbox_exe_location = of.FileName;
			SaveToFile();
		}

		//Add a new DOSProgram
		private void AddNewExe_Button(object sender, RoutedEventArgs e)
		{
			var of = new System.Windows.Forms.OpenFileDialog();
			of.ShowDialog();

			DosProgram add_prog = new DosProgram();
			if (!String.IsNullOrEmpty(of.FileName))
				add_prog.InputProgramLocation(of.FileName);

			vm.programs.Add(add_prog);
			SaveToFile();
		}

		//Remove a DOSProgram
		private void DeleteDosProgram_Button(object sender, RoutedEventArgs e)
		{
			vm.programs.Remove((sender as Button).Tag as DosProgram);
			SaveToFile();
		}

		//Load up the game to be played
		private void LoadDosProgram_Button(object sender, RoutedEventArgs e)
		{
			Process dos_box = new Process();
			dos_box.StartInfo.FileName = vm.dosbox_exe_location;
			dos_box.Start();
			dos_box.WaitForInputIdle();
			System.Threading.Thread.Sleep(1000);
			dos_box.WaitForInputIdle();
			System.Threading.Thread.Sleep(1000);

			var dos_program = (sender as Button).Tag as DosProgram;
			System.Windows.Forms.SendKeys.SendWait(String.Format("mount {0} {1}{3}{0}:{3}{2}{3}", "c", dos_program.directory, dos_program.file_name, "{ENTER}"));
		}

		//Exports the configuration to a textfile when data changes
		private void SaveToFile()
		{
			using (StreamWriter writer = new StreamWriter(saveto_filename))
			{
				writer.WriteLine(vm.dosbox_exe_location);
				foreach (DosProgram p in vm.programs)
					writer.WriteLine(p.ToString());
			}
		}
	}
}