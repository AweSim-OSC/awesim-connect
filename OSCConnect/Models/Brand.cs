using System.Drawing;

namespace OSCConnect.Models
{
    interface Brand
    {
        string name();

        string dashboardURI();

        Bitmap dashboardButtonBackground();

        // Icon size ideally 57px x 57px
        Icon icon();

        Bitmap logoImage();
    }
}
