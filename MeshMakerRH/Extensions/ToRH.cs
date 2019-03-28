using Rhino.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeshMaker
{
    public static class ToRH
    {

        public static Point3d ToRhPoint(this MeshMaker.Vertex point)
        {
            return new Point3d(point.X, point.Y, point.Z);
        }

        public static MeshFace ToRhFace(this MeshMaker.Face face)
        {
            return new MeshFace(face.A, face.B, face.C);
        }

        public static System.Drawing.Color ToDwgColor(this MeshMaker.Color color)
        {
            return System.Drawing.Color.FromArgb(color.A, color.R, color.G, color.B);
        }

        public static Rhino.Geometry.Mesh ToRhMesh(this MeshMaker.Mesh mesh)
        {
            Rhino.Geometry.Mesh output = new Rhino.Geometry.Mesh();

            foreach(Vertex pt in mesh.Vertices)
            {
                output.Vertices.Add(pt.ToRhPoint());
            }

            foreach (MeshMaker.Color clr in mesh.Colors)
            {
                output.VertexColors.Add(clr.ToDwgColor());
            }

            foreach (MeshMaker.Face face in mesh.Faces)
            {
                output.Faces.AddFace(face.ToRhFace());
            }

            return output;
        }
    }
}
