using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasterEgg
{
    public class Class1
    {
    }

    public class ShowEasterEggImage
    {
        ShowImage si = new ShowImage();

        public ShowEasterEggImage()
        {
            si.Visible = true;
            si.Show();
        }

    }

}
