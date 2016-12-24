using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS319_Genius
{
    public partial class OptionsLayerForm : Form
    {
        public delegate void searchEvent(bool openStart, bool optionsCheck, bool googleCheck, bool wikiCheck);
        public event searchEvent searchHandler;

        public OptionsLayerForm(int x, int y)
        {
            InitializeComponent();
            googleRadio.Enabled = false;
            wikiRadio.Enabled = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void searchCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (searchCheck.Checked == true)
            {
                googleRadio.Enabled = true;
                wikiRadio.Enabled = true;
                googleRadio.Checked = true;
                wikiRadio.Checked = false;
            }else
            {
                googleRadio.Enabled = false;
                wikiRadio.Enabled = false;
            }
            searchHandler(startCheck.Checked, searchCheck.Checked, true, false);
        }

        private void googleRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (googleRadio.Checked == true)
                wikiRadio.Checked = false;
            else
                wikiRadio.Checked = true;

            searchHandler(startCheck.Checked, searchCheck.Checked, googleRadio.Checked, wikiRadio.Checked);
        }

        private void wikiRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (wikiRadio.Checked == true)
                googleRadio.Checked = false;
            else
                googleRadio.Checked = true;

            searchHandler(startCheck.Checked, searchCheck.Checked, googleRadio.Checked, wikiRadio.Checked);
        }

        private void startCheck_CheckedChanged(object sender, EventArgs e)
        {
            searchHandler(startCheck.Checked, searchCheck.Checked, googleRadio.Checked, wikiRadio.Checked);
        }
    }
}
