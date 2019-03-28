using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace MeshMakerGH.Components
{
    public class CreateMesh : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the CreateMesh class.
        /// </summary>
        public CreateMesh()
          : base("Create Mesh", "Mesh", "Description", "Z", "Mesh")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddPointParameter("Points", "P", "Mesh Vertices", GH_ParamAccess.list);
            pManager.AddMeshFaceParameter("Faces", "F", "Mesh Faces", GH_ParamAccess.list);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddMeshParameter("Mesh", "M", "The resulting mesh", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            List<Point3d> points = new List<Point3d>();
            List<MeshFace> faces = new List<MeshFace>();

            if(!DA.GetDataList(0, points))return;
            if (!DA.GetDataList(1, faces)) return;

            Mesh mesh = new Mesh();

            mesh.Vertices.AddVertices(points);
            mesh.Faces.AddFaces(faces);

            DA.SetData(0, mesh);
        }

        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                //You can add image files to your project resources and access them like this:
                // return Resources.IconForThisComponent;
                return Properties.Resources.Mesh;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("df4155be-53fd-4a19-ab20-c6a267f854fd"); }
        }
    }
}