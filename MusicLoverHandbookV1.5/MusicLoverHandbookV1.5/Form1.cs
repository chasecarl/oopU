using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MusicLoverHandbookV1._5
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

            setWindowName();
            using (songsReader = new StreamReader(currentPath))
            {
                Read(songsReader, currentSongs);
            }
            Show(currentSongs);
        }

        //dictionary for storing current list of songs (artist - song)
        public Dictionary<string, List<string>> currentSongs = new Dictionary<string, List<string>>();
        //var for reading a file
        TextReader songsReader;
        //specifies whether search goes on artists or songs
        bool searchByArtist = false;
        //current file path
        string currentPath = "empty.txt";

        
        public void setWindowName()
        {
            try
            {
                this.Text = "MusicLover Handbook [" + currentPath.Substring(currentPath.LastIndexOf("\\") + 1) + "]";
            }
            catch (ArgumentOutOfRangeException ex)
            {
                this.Text = "MusicLover Handbook [" + currentPath + "]";
            }
        }

        #region Read
        /// <summary>
        /// Puts data from the file to the dictionary
        /// </summary>
        /// <param name="reader">A file that we are reading from</param>
        /// <param name="dictionary">Dictionary that we are writing to</param>
        public void Read(TextReader reader, Dictionary<string, List<string>> dictionary)
        {
            dictionary.Clear();
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string artist = line.Split('↕')[0];//alt+18
                string song = line.Split('↕')[1];
                try
                {
                    dictionary[artist].Add(song);
                }
                catch (KeyNotFoundException ex)
                {
                    dictionary.Add(artist, new List<string> { song });
                }
            }
        }
        #endregion

        #region Show
        /// <summary>
        ///Represents dictionary in the dataGridView 
        /// </summary>
        /// <param name="dictionary">Dictionary that we need to show</param>
        public void Show(Dictionary<string, List<string>> dictionary)
        {
            dataGridView1.Rows.Clear();
            foreach (string artist in dictionary.Keys)
            {
                foreach (string song in dictionary[artist])
                {
                    dataGridView1.Rows.Add(artist, song);
                }
            }
        }
        #endregion

        #region deleteButton_Click
        /// <summary>
        /// Deletes selected element from current song list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteButton_Click(object sender, EventArgs e)
        {
            Delete();
        }
        
        //Used in deleteButton_Click and in the Form2 in okButton_click
        public void Delete()
        {
            int i = dataGridView1.SelectedCells[0].RowIndex;
            string artist = dataGridView1.Rows[i].Cells[0].Value.ToString();
            string song = dataGridView1.Rows[i].Cells[1].Value.ToString();
            currentSongs[artist].Remove(song);
            dataGridView1.Rows.RemoveAt(i);
        }
        #endregion

        #region refreshButton_Click
        /// <summary>
        /// Refill dataGridView with the current song list (originally designed to check whether deletion was right or not)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void refreshButton_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            Show(currentSongs);
        }
        #endregion

        private void addButton_Click(object sender, EventArgs e)
        {
            Form2 x = new Form2(this);
            x.Owner = this;
            x.ShowDialog();
            x.Text = "Adding";
        }

        #region openSongListToolStripMenuItem_Click
        /// <summary>
        /// Displays a dialog to open a song list file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openSongListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream stream = null;
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.InitialDirectory = "c:\\";
            dialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            dialog.FilterIndex = 2;
            dialog.RestoreDirectory = true;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((stream = dialog.OpenFile()) != null)
                    {
                        using (stream)
                        {
                            using (songsReader = new StreamReader(dialog.FileName))
                            {
                                Read(songsReader, currentSongs);
                                Show(currentSongs);
                                currentPath = dialog.FileName;
                                setWindowName();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }
        #endregion

        //edites a song by double-clicking the row cell
        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Form2 x = new Form2(this);
            x.Visible = true;
            x.Text = "Editing";
            int i = dataGridView1.SelectedCells[0].RowIndex;
            string artist = dataGridView1.Rows[i].Cells[0].Value.ToString();
            string song = dataGridView1.Rows[i].Cells[1].Value.ToString();
            x.artistTextBox.Text = artist;
            x.songTextBox.Text = song;
            x.artistTextBox.ForeColor = Color.Black;
            x.songTextBox.ForeColor = Color.Black;
        }

        //changes the value of searchByArtist
        private void artistSearchCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            searchByArtist = !searchByArtist;
        }

        #region searchButton_Click
        /// <summary>
        /// Searches song list by artist or song name
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void searchButton_Click(object sender, EventArgs e)
        {
            Dictionary<string, List<string>> searchResult = new Dictionary<string, List<string>>();

            foreach (string artist in currentSongs.Keys)
            {
                if (searchByArtist)
                {
                    if (artist.Contains(searchBox.Text))
                    {
                        searchResult.Add(artist, currentSongs[artist]);
                    }
                }
                else
                {
                    foreach (string song in currentSongs[artist])
                    {
                        if (song.Contains(searchBox.Text))
                        {
                            try
                            { 
                                searchResult[artist].Add(song);
                            }
                            catch (KeyNotFoundException ex)
                            {
                                searchResult.Add(artist, new List<string> { song });
                            }
                        }
                    }
                }
            }

            if (searchResult.Count == 0)
            {
                MessageBox.Show("Unfortunately, nothing was found. Try another criterias.", "Not found!");
                searchBox.Focus();
            }
            else
            {
                Show(searchResult);
                backButton.Enabled = true;
            }

        }
        #endregion

        #region backButton_Click
        /// <summary>
        /// Restores current song list after search results generating
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backButton_Click(object sender, EventArgs e)
        {
            backButton.Enabled = false;
            Show(currentSongs);
        }
        #endregion

        #region saveToolStripMenuItem_Click
        /// <summary>
        /// Saving file to the current path
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            File.Delete(currentPath);
            using (StreamWriter document = new StreamWriter(currentPath))
            {
                foreach (string artist in currentSongs.Keys)
                {
                    foreach (string song in currentSongs[artist])
                    {
                        document.WriteLine(artist + '↕' + song);
                    }
                }
            }
            MessageBox.Show("Song list was successfully saved!");
        }
        #endregion

        #region saveSongListAsToolStripMenuItem_Click
        /// <summary>
        /// Saving file to the path chosen by user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveSongListAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();

            dialog.Filter = "Txt files (*.txt)|*.txt|All files (*.*)|*.*";
            dialog.FilterIndex = 2;
            dialog.RestoreDirectory = true;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter document = new StreamWriter(dialog.OpenFile()))
                {
                    foreach (string artist in currentSongs.Keys)
                    {
                        foreach (string song in currentSongs[artist])
                        {
                            document.WriteLine(artist + '↕' + song);
                        }
                    }
                }
                MessageBox.Show("Song list was successfully saved!");
            }
        }
        #endregion

        #region searchBoxTextStyle
        private void searchBox_Enter(object sender, EventArgs e)
        {
            textBoxPlaceholderEnter(searchBox, "Type in an artist or a song name...");
        }

        private void searchBox_Leave(object sender, EventArgs e)
        {
            textBoxPlaceholderLeave(searchBox, "Type in an artist or a song name...");
        }
        #endregion

        #region placeholder
        public void textBoxPlaceholderEnter(TextBox textBox, string defaultText)
        {
            if (textBox.Text == defaultText)
            {
                textBox.ForeColor = Color.Black;
                textBox.Text = "";
            }
        }

        public void textBoxPlaceholderLeave(TextBox textBox, string defaultText)
        {
            if (textBox.Text == "")
            {
                textBox.ForeColor = Color.Gray;
                textBox.Text = defaultText;
            }
        }
        #endregion

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3();
            f.Show();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.Show();
        }
    }
}
