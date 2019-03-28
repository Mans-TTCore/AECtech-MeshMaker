using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace MeshMakerGH.Components
{
    public class HelloWorld : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the HelloWorld class.
        /// </summary>
        public HelloWorld()
          : base("Hello World", "Hello", "If True, Say Hi", "Z", "Sample")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddBooleanParameter("Hello?", "B", "If true, will say hi", GH_ParamAccess.item, false);
            pManager[0].Optional = true;


        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("Greeting", "G", "Hello or Goodbye", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            bool isGreeting = false;
            DA.GetData(0, ref isGreeting);

            string text = String.Empty;

            if (isGreeting) { text = "Hello"; } else { text = "Goodbye"; }

            DA.SetData(0, text);
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
                return Properties.Resources.HelloWorld;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("da7d8d59-b1d7-4a42-a713-a62cb99a9514"); }
        }
    }
}