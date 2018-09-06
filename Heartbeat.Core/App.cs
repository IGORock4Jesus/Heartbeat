using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Heartbeat.UI;

namespace Heartbeat.Core
{
	public class App
	{
		Subsystems.Manager subsystem;
		UI.Manager ui;
		

		public App()
		{
			subsystem = new Subsystems.Manager();
			ui = new UI.Manager(subsystem);
		}

		public Manager UI => ui;

		public void Run()
		{
			subsystem.Run();
		}
	}
}
