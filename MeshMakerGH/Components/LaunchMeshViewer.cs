using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

using MeshMaker;
using MeshMakerViewer;

namespace MeshMakerGH.Components
{
    public class LaunchMeshViewer : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the MeshViewer class.
        /// </summary>
        public LaunchMeshViewer()
          : base("Mesh Viewer", "Viewer", "Mesh Viewer", "Z", "Viewer")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddMeshParameter("Mesh", "M", "---", GH_ParamAccess.item);
            pManager.AddBooleanParameter("Open", "O", "Open Viewer", GH_ParamAccess.item, false);

        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            Rhino.Geometry.Mesh mesh = new Rhino.Geometry.Mesh();
            bool open = false;

            DA.GetData(0, ref mesh);
            DA.GetData(1, ref open);

            MeshViewer viewer = new MeshViewer(mesh.ToCustomMesh());

            if (open)
            {
                viewer.BuildViewer();
            }
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
                return Properties.Resources.Viewer;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("4b6c6828-f66b-451c-8e36-2f751a2a7829"); }
        }
    }
}