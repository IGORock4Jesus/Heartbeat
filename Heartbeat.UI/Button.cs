using Heartbeat.Subsystems;
using SharpDX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heartbeat.UI
{
	public class Button : Control
	{
		public string Text { get; set; }

		public Button(Manager manager) : base(manager)
		{
			Visible = true;

			manager.Subsystem.MainForm.MouseClick += MainForm_MouseClick;
		}

		private void MainForm_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (new RectangleF(AbsoluteRect.X, AbsoluteRect.Y, .Contains(e.X, e.Y))
			{
				Click?.Invoke(this);
			}
		}

		public event Action<Button> Click;

		internal override void Render(Renderer renderer)
		{
			renderer.DrawRectangle(Rectangle, Color.Red);
			renderer.DrawString(Rectangle, Text, Color.White);
		}
	}
}
