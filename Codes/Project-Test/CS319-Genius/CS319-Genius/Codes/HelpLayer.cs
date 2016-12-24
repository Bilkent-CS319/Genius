using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS319_Genius
{
    class HelpLayer
    {
        private System.Windows.Forms.Panel helpLayerPanel;

        public HelpLayer(int x , int y)
        {
            // Once this created, immediately call the reading function which will fill the 
            // panel's textbox with required text in the data set.

            HelpLayerForm helplayerform = new HelpLayerForm(0,0);
            helpLayerPanel = helplayerform.HelpLayerPanel;

        }


        public void autoSetLocation(int x, int y)
        {
            helpLayerPanel.Location = new System.Drawing.Point(x - helpLayerPanel.Width, y);
        }

        public bool getVisibility()
        {
            if (helpLayerPanel.Visible)
                return true;
            else
                return false;
        }

        // Once panel is constructed, we need to 
        public System.Windows.Forms.Panel getPanel()
        {
            return helpLayerPanel;
        }

        public void setVisibility(bool a)
        {
            if (a)
                helpLayerPanel.Show();
            else
                helpLayerPanel.Hide();
        }

    }
}
