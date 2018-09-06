using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Heartbeat.Test
{
	static class Program
	{
		/// <summary>
		/// Главная точка входа для приложения.
		/// </summary>
		[STAThread]
		static void Main()
		{
			TestApp app = new TestApp();
			app.Run();
		}
	}
}
