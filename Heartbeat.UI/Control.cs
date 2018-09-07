using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Heartbeat.Subsystems;
using SharpDX;

namespace Heartbeat.UI
{
	public class Control
	{
		private RectangleF _absoluteRect = new RectangleF();
		private RectangleF _relativeRect = new RectangleF();

		public string Name { get; set; }
		public ObservableCollection<Control> Childs { get; } = new ObservableCollection<Control>();
		public bool Visible { get; set; }
		public Manager Manager { get; }
		public Control Parent { get; private set; }
		public RectangleF AbsoluteRect
		{
			get => _absoluteRect;
			set { if (_absoluteRect != value) { _absoluteRect = value; UpdateAbsChildRects(); } }
		}

		public RectangleF RelativeRect
		{
			get => _relativeRect;
			set { if (_relativeRect != value) { _relativeRect = value; UpdateAbsChildRects(); } }
		}


		public event Action<Control, Control> ChildsChanged;


		protected bool CheckPoint(Vector2 point)
		{
			return _absoluteRect.Contains(point);
		}
		private void UpdateAbsChildRects()
		{
			_absoluteRect = Parent._absoluteRect + _relativeRect;

			foreach (var child in Childs)
			{
				child.UpdateAbsChildRects();
			}
		}

		public Control(Manager manager)
		{
			Childs.CollectionChanged += Childs_CollectionChanged;
			Manager = manager;
		}

		private void Childs_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
		{
			//e.
		}

		internal virtual void Render(Renderer renderer)
		{
		}

		public virtual void AddChild(Control control)
		{
			Childs.Add(control);
			control.Parent = this;
		}
	}
}
