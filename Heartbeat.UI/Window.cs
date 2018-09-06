using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Heartbeat.Subsystems;
using SharpDX;

namespace Heartbeat.UI
{
	public class Window : Control
	{
		private RectangleF rectangle = new RectangleF(0, 0, 800, 600);

		public RectangleF Rectangle
		{
			get => rectangle;
			set
			{
				if (rectangle != value)
				{
					OnRectangleChanged(value);
				}
			}
		}
		public Color BackColor { get; set; } = Color.Gray;

		private void OnRectangleChanged(RectangleF value)
		{
			rectangle = value;
		}

		public Window(Manager manager)
			: base(manager)
		{
			// создаем кнопку - закрыть окно
			Button button = new Button(manager)
			{
				Name = "Закрыть",
				Rectangle = new RectangleF(rectangle.Right - 25, 0, 25, 25)
			};
			button.Click += CloseButton_Click;

			Childs.Add(button);
			Visible = true;
		}

		private void CloseButton_Click(Button button)
		{
			// удаляем окно из менеджера
			Manager.Remove(this);
		}

		internal override void Render(Renderer renderer)
		{
			renderer.DrawRectangle(rectangle, BackColor);
		}
	}
}
