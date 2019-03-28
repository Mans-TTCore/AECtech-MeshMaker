using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;
using MeshMaker;
using System.IO;

namespace MeshMakerGH.Components
{
    public class SerializeMeshToFile : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the SerializeMeshToFile class.
        /// </summary>
        public SerializeMeshToFile()
          : base("Serialize Mesh To File", "SerFile", "Serializes a Mesh Maker model of a Rhino Mesh", "Z", "Mesh")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddMeshParameter("Mesh", "M", "A Rhino Mesh", GH_ParamAccess.item);
            pManager.AddTextParameter("Filepath", "P", "Filepath", GH_ParamAccess.item, "C:\\Users\\Public\\Documents\\untitled.json");
            pManager.AddBooleanParameter("Save", "S", "If true the file will be saved", GH_ParamAccess.item, false);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("File Path", "P", "The Location of the serialized file", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            Rhino.Geometry.Mesh mesh = new Rhino.Geometry.Mesh();
            string filePath = "C:\\Users\\Public\\Documents\\untitled.json";
            bool save = false;

            DA.GetData(0, ref mesh);
            DA.GetData(1, ref filePath);
            DA.GetData(2, ref save);

            MeshMaker.Mesh mMesh = mesh.ToCustomMesh();

            if (save)
            {
                StreamWriter Writer = new StreamWriter(filePath);
                Writer.Write(mMesh.Serialize());
                Writer.Close();
            }

            DA.SetData(0, filePath);
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
                return Properties.Resources.Save;
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
            get { return new Guid("406c214b-fa9e-4ad3-adbd-0a80ce2c0576"); }
        }
    }
}