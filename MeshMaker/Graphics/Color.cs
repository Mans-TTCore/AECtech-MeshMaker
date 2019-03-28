using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeshMaker
{
    [Serializable]
    public class Color
    {

        #region members

        [JsonIgnore]
        protected int a = 255;

        [JsonIgnore]
        protected int r = 0;

        [JsonIgnore]
        protected int g = 0;

        [JsonIgnore]
        protected int b = 0;

        #endregion

        #region constructors

        public Color()
        {

        }

        public Color(Color color)
        {
            this.a = color.a;
            this.r = color.r;
            this.g = color.g;
            this.b = color.b;
        }

        public Color(int r, int g, int b)
        {
            this.a = 255;
            this.r = r;
            this.g = g;
            this.b = b;
        }

        public Color(int a, int r, int g, int b)
        {
            this.a = a;
            this.r = r;
            this.g = g;
            this.b = b;
        }
        
        #endregion

        #region properties

        [JsonProperty(PropertyName = "a")]
        public virtual int A
        {
            get { return a; }
            set { a = value; }
        }

        [JsonIgnore]
        public virtual int R
        {
            get { return r; }
            set { r = value; }
        }

        [JsonIgnore]
        public virtual int G
        {
            get { return g; }
            set { g = value; }
        }

        [JsonIgnore]
        public virtual int B
        {
            get { return b; }
            set { b = value; }
        }

        [JsonProperty(PropertyName = "hex")]
        public virtual string hex
        {
            get { return ToHexadecimal(); }
        }

        #endregion

        #region methods

        public string ToHexadecimal()
        {
            string rs = DecimalToHexadecimal(r);
            string gs = DecimalToHexadecimal(g);
            string bs = DecimalToHexadecimal(b);

            return '#' + rs + gs + bs;
        }

        private static string DecimalToHexadecimal(int dec)
        {
            if (dec <= 0)
                return "00";

            int hex = dec;
            string hexStr = string.Empty;

            while (dec > 0)
            {
                hex = dec % 16;

                if (hex < 10)
                    hexStr = hexStr.Insert(0, Convert.ToChar(hex + 48).ToString());
                else
                    hexStr = hexStr.Insert(0, Convert.ToChar(hex + 55).ToString());

                dec /= 16;
            }

            return hexStr;
        }

        #endregion

    }
}
