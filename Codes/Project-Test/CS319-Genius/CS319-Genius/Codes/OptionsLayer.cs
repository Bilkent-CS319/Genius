using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS319_Genius
{
    class OptionsLayer
    {
        private System.Windows.Forms.Panel optionsPanel;

        public delegate void settingEvent(bool googleCheck, bool wikiCheck);
        public event settingEvent settingsChanged;

        public OptionsLayer(int x, int y)
        {
            OptionsLayerForm a = new OptionsLayerForm(x,y);

            optionsPanel = a.optionsPanel;
            a.searchHandler += optionEventHandler;
           
        }

        private void optionEventHandler(bool openStart, bool optionsCheck, bool googleCheck, bool wikiCheck)
        {
            settingsChanged(googleCheck,wikiCheck);
            Console.WriteLine("[DEBUG] STATS\n Open Start Up Checked: " + openStart + " Search Option Checked: " + optionsCheck + 
                " Google Search: " + googleCheck + " Wiki Search: " + wikiCheck);
        }

        public void autoSetLocation(int x, int y)
        {
            optionsPanel.Location = new System.Drawing.Point(x - optionsPanel.Width, y);
        }

        public bool getVisibility()
        {
            if (optionsPanel.Visible)
                return true;
            else
                return false;
        }

        // Once panel is constructed, we need to 
        public System.Windows.Forms.Panel getPanel()
        {
            return optionsPanel;
        }

        public void setVisibility(bool a)
        {
            if (a)
                optionsPanel.Show();
            else
                optionsPanel.Hide();
        }

    }
}
