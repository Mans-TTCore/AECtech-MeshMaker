using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeshMaker
{
    [Serializable]
    public class Mesh
    {
        
        #region members

        [JsonIgnore]
        protected List<Vertex> vertices = new List<Vertex>();

        [JsonIgnore]
        protected List<Color> colors = new List<Color>();

        [JsonIgnore]
        protected List<Face> faces = new List<Face>();

        #endregion

        #region constructors

        public Mesh()
        {

        }

        public Mesh(Mesh mesh)
        {
            foreach(Vertex vert in mesh.vertices)
            {
                this.vertices.Add(vert);
            }
            foreach (Color color in mesh.colors)
            {
                this.colors.Add(color);
            }
            foreach (Face face in mesh.faces)
            {
                this.faces.Add(face);
            }
        }

        public Mesh(List<Vertex> vertices, List<Face> faces)
        {
            this.vertices = vertices;
            this.faces = faces;
        }

        public Mesh(List<Vertex> vertices, List<Color> colors, List<Face> faces)
        {
            this.vertices = vertices;
            this.colors = colors;
            this.faces = faces;
        }

        #endregion

        #region properties

        [JsonProperty(PropertyName = "vertices")]
        public virtual List<Vertex> Vertices
        {
            get { return vertices; }
            set { vertices = value; }
        }

        [JsonProperty(PropertyName = "colors")]
        public virtual List<Color> Colors
        {
            get { return colors; }
            set { colors = value; }
        }

        [JsonProperty(PropertyName = "faces")]
        public virtual List<Face> Faces
        {
            get { return faces; }
            set { faces = value; }
        }

        #endregion

        #region methods
        
        public string Serialize(bool isIndented = false)
        {
            if(isIndented)
            {
                return JsonConvert.SerializeObject(this, Formatting.Indented);
            }
            else
            {
                return JsonConvert.SerializeObject(this, Formatting.None);
            }
        }

        public override string ToString()
        {
            return "Mesh (V:"+Vertices.Count+" F:"+Faces.Count+")";
        }

        #endregion
    }
}
