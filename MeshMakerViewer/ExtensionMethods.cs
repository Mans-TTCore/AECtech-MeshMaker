using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;
using MeshMaker;

namespace MeshMakerViewer
{
    public static class ExtensionMethods
    {
        public static MeshGeometry3D ToMediaMesh(this Mesh mesh)
        {
            MeshGeometry3D output = new MeshGeometry3D();
            foreach (Vertex vert in mesh.Vertices)
            {
                output.Positions.Add(new Point3D(vert.X, vert.Y, vert.Z));
            }
            foreach(Face face in mesh.Faces)
            {
                output.TriangleIndices.Add(face.A);
                output.TriangleIndices.Add(face.B);
                output.TriangleIndices.Add(face.C);
            }

            return output;
        }
    }
}
