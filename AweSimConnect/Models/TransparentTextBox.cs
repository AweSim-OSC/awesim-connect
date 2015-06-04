using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace AweSimConnect.Models
{
    class TransparentTextBox : TextBox
    {
        public TransparentTextBox()
        {
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }
    }
}
