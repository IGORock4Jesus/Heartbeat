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
		public RectangleF Rectangle { get; set; } = new RectangleF(0, 0, 100, 30);


		public Button(Manager manager) : base(manager)
		{
			Visible = true;

			manager.Subsystem.MainForm.MouseClick += MainForm_MouseClick;
		}

		private void MainForm_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (Rectangle.Contains(e.X, e.Y))
			{
				Click?.Invoke(this);
			}
		}

		public event Action<Button> Click;

		internal override void Render(Renderer renderer)
		{
			renderer.DrawRectangle(Rectangle, Color.Red);
		}
	}
}
