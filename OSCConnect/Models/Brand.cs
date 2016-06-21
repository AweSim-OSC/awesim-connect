using System.Drawing;

namespace OSCConnect.Models
{
    /*
     * Interface class for branding elements. Extend this class to change graphical and link elements.
     */
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
