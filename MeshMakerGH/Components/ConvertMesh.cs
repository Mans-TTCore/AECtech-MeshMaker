using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

using MeshMaker;

namespace MeshMakerGH.Components
{
    public class ConvertMesh : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the ConvertMesh class.
        /// </summary>
        public ConvertMesh()
          : base("Convert Mesh", "Convert", "No Description", "Z", "Mesh")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddMeshParameter("Mesh", "M", "A Rhino Mesh", GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("", "C", "", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            Rhino.Geometry.Mesh mesh = new Rhino.Geometry.Mesh();
            DA.GetData(0, ref mesh);

            DA.SetData(0, mesh.ToCustomMesh());
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
                return null;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("3e5681c8-3b4a-4523-a7bd-326a4108017c"); }
        }
    }
}