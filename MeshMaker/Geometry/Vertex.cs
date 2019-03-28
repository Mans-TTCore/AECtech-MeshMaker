using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeshMaker
{
    [Serializable]
    public class Vertex
    {

        #region members

        [JsonIgnore]
        protected double x = 0;

        [JsonIgnore]
        protected double y = 0;

        [JsonIgnore]
        protected double z = 0;

        #endregion

        #region constructors

        public Vertex()
        {

        }

        public Vertex(Vertex vertex)
        {
            this.x = vertex.x;
            this.y = vertex.y;
            this.z = vertex.z;
        }

        public Vertex(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        #endregion

        #region properties
        
        [JsonProperty(PropertyName = "x")]
        public virtual double X
        {
            get { return Math.Round(x,4); }
            set { x = value; }
        }

        [JsonProperty(PropertyName = "y")]
        public virtual double Y
        {
            get { return Math.Round(y,4); }
            set { y = value; }
        }

        [JsonProperty(PropertyName = "z")]
        public virtual double Z
        {
            get { return Math.Round(z,4); }
            set { z = value; }
        }
        
        #endregion

    }
}
