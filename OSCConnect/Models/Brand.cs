using System;
using System.Collections.Generic;
using System.Text;

namespace OSCConnect.Models
{
    interface Brand
    {
        string name();

        string dashboardURI();

        System.Drawing.Bitmap dashboardButtonBackground();

        System.Drawing.Icon icon();


    }
}
