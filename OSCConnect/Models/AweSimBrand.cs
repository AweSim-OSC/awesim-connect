using System.Drawing;

namespace OSCConnect.Models
{
    internal class AweSimBrand : Brand
    {
        public string name()
        {
            return "AweSim";
        }

        public string brandString()
        {
            return "awesim";
        }

        public string dashboardURI()
        {
            return "http://apps.awesim.org/";
        }

        public Icon icon()
        {
            return Properties.Resources.awesim_ball1;
        }

        public Bitmap dashboardButtonBackground()
        {
            return Properties.Resources.awesim_ball_sm;
        }

        public Bitmap logoImage()
        {
            return Properties.Resources.awesim_logo_txt;
        }
    }
}