using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Heartbeat.Subsystems
{
	public class Manager
	{
		MainForm mainForm;
		Renderer renderer;
		Task task;
		private bool taskEnabled;


		public MainForm MainForm => mainForm;
		public Renderer Renderer => renderer;

		public Manager()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			mainForm = new MainForm();
			mainForm.Load += MainForm_Load;
			mainForm.FormClosed += MainForm_FormClosed;

			renderer = new Renderer(mainForm);
		}

		private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			taskEnabled = false;
			task.Wait();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			taskEnabled = true;
			task = Task.Run(new Action(StartMainTask));
		}

		private void StartMainTask()
		{
			while (taskEnabled)
			{
				renderer.Render();

				System.Threading.Thread.Sleep(0);
			}
		}

		public void Run()
		{
			Application.Run(mainForm);
		}
	}
}
