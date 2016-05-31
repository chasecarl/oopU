using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicLoverHandbookV1._5
{
    public partial class Form2 : Form
    {
        Form1 owner;

        public Form2(Form1 f1)
        {
            this.owner = f1;

            InitializeComponent();
        }

        #region okButton_Click
        /// <summary>
        /// Confirms additing or changing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void okButton_Click(object sender, EventArgs e)
        {
            if (this.Text == "Editing")
            {
                owner.Delete();
            }
            try
            {
                owner.currentSongs[artistTextBox.Text].Add(songTextBox.Text);
            }
            catch (KeyNotFoundException ex)
            {
                owner.currentSongs.Add(artistTextBox.Text, new List<string> { songTextBox.Text });
            }
            owner.dataGridView1.Rows.Add(artistTextBox.Text, songTextBox.Text);
            this.Close();
        }
        #endregion

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region artistTextBoxStyle
        private void artistTextBox_Enter(object sender, EventArgs e)
        {
            owner.textBoxPlaceholderEnter(artistTextBox, "Type in an artist...");
        }

        private void artistTextBox_Leave(object sender, EventArgs e)
        {
            owner.textBoxPlaceholderLeave(artistTextBox, "Type in an artist...");
        }
        #endregion

        #region songTextBoxStyle
        private void songTextBox_Enter(object sender, EventArgs e)
        {
            owner.textBoxPlaceholderEnter(songTextBox, "Type in a song name...");
        }

        private void songTextBox_Leave(object sender, EventArgs e)
        {
            owner.textBoxPlaceholderLeave(songTextBox, "Type in a song name...");
        }
        #endregion
    }
}
