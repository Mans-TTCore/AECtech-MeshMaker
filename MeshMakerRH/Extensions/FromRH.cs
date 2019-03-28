using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Rhino.Geometry;

namespace MeshMaker
{
    public static class FromRH
    {

        public static MeshMaker.Vertex ToCustomVertex(this Point3d point)
        {
            return new MeshMaker.Vertex(point.X, point.Y, point.Z);
        }

        public static MeshMaker.Face ToCustomFace(this MeshFace face)
        {
            return new MeshMaker.Face(face.A, face.B, face.C);
        }

        public static MeshMaker.Color ToCustomColor(this System.Drawing.Color color)
        {
            return new MeshMaker.Color(color.A, color.R, color.G, color.B);
        }

        public static MeshMaker.Mesh ToCustomMesh(this Rhino.Geometry.Mesh mesh)
        {
            MeshMaker.Mesh output = new MeshMaker.Mesh();

            foreach(Point3d pt in mesh.Vertices)
            {
                output.Vertices.Add(pt.ToCustomVertex());
            }

            foreach (System.Drawing.Color clr in mesh.VertexColors)
            {
                output.Colors.Add(clr.ToCustomColor());
            }

            foreach (MeshFace face in mesh.Faces)
            {
                output.Faces.Add(face.ToCustomFace());
            }

            return output;
        }

    }
}
