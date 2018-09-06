using SharpDX;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heartbeat.Subsystems
{
	struct Vertex
	{
		public Vector4 pos;
		public uint color;
		public const VertexFormat Format = VertexFormat.PositionRhw | VertexFormat.Diffuse;
	}
}
