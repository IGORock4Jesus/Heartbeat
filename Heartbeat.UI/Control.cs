using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Heartbeat.Subsystems;

namespace Heartbeat.UI
{
	public class Control
	{
		public string Name { get; set; }
		public ObservableCollection<Control> Childs { get; } = new ObservableCollection<Control>();
		public bool Visible { get; set; }
		public Manager Manager { get; }

		public event Action<Control, Control> ChildsChanged;


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
	}
}
