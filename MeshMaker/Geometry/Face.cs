using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MeshMaker
{
    [Serializable]
    public class Face
    {

        #region members

        [JsonIgnore]
        protected int a = 0;

        [JsonIgnore]
        protected int b = 1;

        [JsonIgnore]
        protected int c = 2;

        #endregion

        #region constructors

        public Face()
        {

        }

        public Face(Face face)
        {
            this.a = face.a;
            this.b = face.b;
            this.c = face.c;
        }

        public Face(int a, int b, int c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        #endregion

        #region properties

        [JsonProperty(PropertyName ="a") ]
        public virtual int A
        {
            get { return a; }
            set { a = value; }
        }

        [JsonProperty(PropertyName = "b")]
        public virtual int B
        {
            get { return b; }
            set { b = value; }
        }

        [JsonProperty(PropertyName = "c")]
        public virtual int C
        {
            get { return c; }
            set { c = value; }
        }

        #endregion

    }
}
