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
using System.Windows.Shapes;

namespace DosBoxLoader
{
	/// <summary>
	/// Interaction logic for DOSProgramSettings.xaml
	/// </summary>
	public partial class DOSProgramSettings : Window
	{
		public DosProgram display_program;

		public DOSProgramSettings()
		{
			InitializeComponent();
			DataContext = display_program;
		}
	}
}
