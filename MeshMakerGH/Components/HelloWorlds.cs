using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;
using Grasshopper.Kernel.Parameters;

namespace MeshMakerGH.Components
{
    public class HelloWorlds : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the HelloWorlds class.
        /// </summary>
        public HelloWorlds()
          : base("Hello Worlds", "Greeting", "Greetings in multiple lanuages", "Z", "Sample")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddBooleanParameter("Hello?", "B", "If true, will say hi", GH_ParamAccess.item, false);
            pManager[0].Optional = true;
            pManager.AddIntegerParameter("Language", "L", "Select Language", GH_ParamAccess.item,0);
            pManager[1].Optional = true;

            Param_Integer param = (Param_Integer)pManager[1];
            param.AddNamedValue("English", 0);
            param.AddNamedValue("Spanish", 1);
            param.AddNamedValue("Japanese", 2);
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
            int mode = 0;
            DA.GetData(0, ref isGreeting);
            DA.GetData(1, ref mode);

            string text = String.Empty;

            switch(mode)
            {
                default:
                    if (isGreeting) { text = "Hello"; } else { text = "Goodbye"; }
                    break;
                case 1:
                    if (isGreeting) { text = "Hola"; } else { text = "Adios"; }
                    break;
                case 2:
                    if (isGreeting) { text = "Kon'nichiwa"; } else { text = "Jaa Ne"; }
                    break;
            }


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
                return null;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("554628c1-7d0c-481b-966e-d27127fc801e"); }
        }
    }
}