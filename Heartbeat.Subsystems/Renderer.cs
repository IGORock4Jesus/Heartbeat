using SharpDX;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heartbeat.Subsystems
{
	public class Renderer
	{
		private MainForm mainForm;
		private Direct3D direct;
		private Device device;

		public event Action<Renderer> Drawing;

		public Renderer(MainForm mainForm)
		{
			this.mainForm = mainForm;

			direct = new Direct3D();
			device = new Device(direct, 0, DeviceType.Hardware, mainForm.Handle, CreateFlags.HardwareVertexProcessing, new PresentParameters
			{
				AutoDepthStencilFormat = Format.D24S8,
				BackBufferCount = 1,
				BackBufferFormat = Format.X8R8G8B8,
				BackBufferHeight = mainForm.Height,
				BackBufferWidth = mainForm.Width,
				DeviceWindowHandle = mainForm.Handle,
				EnableAutoDepthStencil = true,
				SwapEffect = SwapEffect.Discard,
				Windowed = true
			});
		}

		public void Render()
		{
			device.Clear(ClearFlags.All, Color.DarkGray, 1.0f, 0);
			device.BeginScene();

			Drawing?.Invoke(this);

			device.EndScene();
			device.Present();
		}

		public void DrawRectangle(RectangleF rectangle, Color color)
		{
			Vertex[] vertices = new Vertex[]
			{
				new Vertex{ pos =new Vector4( rectangle.TopLeft, 0.0f, 1.0f), color = color.ToArgb() },
				new Vertex{ pos =new Vector4( rectangle.TopRight, 0.0f, 1.0f), color = color.ToArgb() },
				new Vertex{ pos =new Vector4( rectangle.BottomRight, 0.0f, 1.0f), color = color.ToArgb() },
				new Vertex{ pos =new Vector4( rectangle.BottomLeft, 0.0f, 1.0f), color = color.ToArgb() },
			};

			device.VertexFormat = Vertex.Format;
			device.DrawUserPrimitives(PrimitiveType.TriangleFan, 2, vertices);
		}

		public void DrawString(RectangleF rectangle, string text, Color color)
		{
			using (var font = new Font(device, 24, 0, FontWeight.Normal, 0, false, FontCharacterSet.Russian, FontPrecision.TrueType, FontQuality.ClearType, FontPitchAndFamily.Roman, "Consolas"))
			{
				font.DrawText(null, text, rectangle, FontDrawFlags.Center | FontDrawFlags.VerticalCenter, color);
			}
		}

	}
}
