using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Windows.Forms;
namespace DataAccessLayer.Classes
{
    public static class Media
    {
        public static void Sound_NewOrder()
        {
            SoundPlayer newOrder = new SoundPlayer();

            //MessageBox.Show(Application.StartupPath);
            newOrder.SoundLocation = Application.StartupPath + @"\SoundEffect\NewOrder.wav";
            newOrder.Play();
        }
    }
}
