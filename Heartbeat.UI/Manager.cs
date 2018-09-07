using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Heartbeat.Subsystems;

namespace Heartbeat.UI
{
	public class Manager
	{
		readonly List<Control> controls = new List<Control>();
		readonly object locker = new object();
		private Subsystems.Manager subsystem;

		public Subsystems.Manager Subsystem => subsystem;

		public Manager(Subsystems.Manager subsystem)
		{
			this.subsystem = subsystem;

			subsystem.Renderer.Drawing += Renderer_Drawing;
		}

		private void Renderer_Drawing(Subsystems.Renderer renderer)
		{
			lock (locker)
				foreach (var control in controls)
				{
					RenderControl(renderer, control);
				}
		}

		public void Add(Control control)
		{
			lock (locker)
				controls.Add(control);
		}

		public void Remove(Control control)
		{
			lock (locker)
				controls.Remove(control);
		}

		private void RenderControl(Subsystems.Renderer renderer, Control control)
		{
			if (control == null || !control.Visible) return;

			control.Render(renderer);

			foreach (var child in control.Childs)
			{
				RenderControl(renderer, child);
			}
		}


		public Window Window()
		{
			return new Window(this);
		}

	}
}
