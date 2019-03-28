using System;
using System.Drawing;
using Grasshopper.Kernel;

namespace MeshMakerGH
{
    public class MeshMakerGHInfo : GH_AssemblyInfo
    {
        public override string Name
        {
            get
            {
                return "MeshMakerGH";
            }
        }
        public override Bitmap Icon
        {
            get
            {
                //Return a 24x24 pixel bitmap to represent this GHA library.
                return null;
            }
        }
        public override string Description
        {
            get
            {
                //Return a short string describing the purpose of this GHA library.
                return "";
            }
        }
        public override Guid Id
        {
            get
            {
                return new Guid("630796d5-895b-4ab4-9a59-9285a1d07769");
            }
        }

        public override string AuthorName
        {
            get
            {
                //Return a string identifying you or your company.
                return "";
            }
        }
        public override string AuthorContact
        {
            get
            {
                //Return a string representing your preferred contact details.
                return "";
            }
        }
    }
}
