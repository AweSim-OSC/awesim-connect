using System.Drawing;

namespace OSCConnect.Models
{
    /*
     * Interface class for branding elements. Extend this class to change graphical and link elements.
     */
    interface Brand
    {
        // The name of the Application for this brand scheme name()+" Connect"
        string name();

        // An identifier for locating the proper branding by executable
        string brandString();

        // The link to the appropriate dashboard portal
        string dashboardURI();

        // An image on the dashboard button
        Bitmap dashboardButtonBackground();

        // Icon size ideally 57px x 57px
        Icon icon();

        // An image with the brand name/logo
        Bitmap logoImage();
    }
}
