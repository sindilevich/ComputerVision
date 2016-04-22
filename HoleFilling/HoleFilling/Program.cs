using System;
using System.Windows.Forms;
using log4net;

namespace HoleFilling
{
	internal static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		private static void Main()
		{
			ILog logger = LogManager.GetLogger("HoleFilling Application");

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			try
			{
				Application.Run(new MainForm());
			}
			catch (Exception e)
			{
				logger.Fatal(e);

				MessageBox.Show(
					text: $"An error occured. Please examine logs for more details.{Environment.NewLine}The error message: \"{e.Message}\"",
					caption: "Fatal Application Error",
					buttons: MessageBoxButtons.OK,
					icon: MessageBoxIcon.Error);
			}
		}
	}
}