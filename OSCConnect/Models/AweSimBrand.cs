using System;
using System.Drawing;
using OSCConnect.Models;

namespace OSCConnect.Views
{
    internal class AweSimBrand : Brand
    {
        public string name()
        {
            return "AweSim";
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