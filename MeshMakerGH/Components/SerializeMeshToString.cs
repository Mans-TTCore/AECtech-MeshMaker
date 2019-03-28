using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;
using MeshMaker;
using System.IO;

namespace MeshMakerGH.Components
{
    public class SerializeMeshToString : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the SerializeMesh class.
        /// </summary>
        public SerializeMeshToString()
          : base("Serialize Mesh To String", "SerText", "Serializes a Mesh Maker model of a Rhino Mesh", "Z", "Mesh")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddMeshParameter("Mesh", "M", "A Rhino Mesh", GH_ParamAccess.item);
            pManager.AddBooleanParameter("Indent", "I", "If true the output will be indented", GH_ParamAccess.item, false);
            pManager[1].Optional = true;
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("Custom Mesh", "C", "The custom mesh object", GH_ParamAccess.item);
            pManager.AddTextParameter("Serialized Mesh", "S", "Serialized Mesh", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            Rhino.Geometry.Mesh mesh = new Rhino.Geometry.Mesh();
            bool isIndented = false;

            DA.GetData(0, ref mesh);
            DA.GetData(1, ref isIndented);

            MeshMaker.Mesh mMesh = mesh.ToCustomMesh();

            DA.SetData(0, mMesh);
            DA.SetData(1, mMesh.Serialize(isIndented));
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
                return Properties.Resources.Serialize;
            }
        }

        /// <summary>
        /// The Exposure property control
        /// </summary>
        public override GH_Exposure Exposure
        {
            get { return GH_Exposure.secondary; }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("8ab9bbcc-1fe8-4da9-b697-0df039e98a44"); }
        }
    }
}