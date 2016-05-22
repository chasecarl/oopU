using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicLoverHandbook
{
    public partial class Form1 : Form
    {
        String forsearch;

        List<String> defaultSongsCollection, defaultGroupsCollection;
        
        TextReader songsReader;
        TextReader groupsReader;

        public Form1()
        {
            InitializeComponent();

            songsReader = new StreamReader("songs.txt");
            defaultSongsCollection = new List<String>();
            Read(songsReader, defaultSongsCollection);

            groupsReader = new StreamReader("groups.txt");
            defaultGroupsCollection = new List<String>();
            Read(groupsReader, defaultGroupsCollection);

            Visualize();

            MessageBox.Show(defaultGroupsCollection[0] + "\n" + defaultSongsCollection[0], "Check");//for checking
        }

        public void Visualize()
        {
            
        }

        public String Search(String[] file)
        {
            for (int i = 0; i < file.Length; i++)
            {
                if (file[i].Contains(forsearch))
                {
                    return file[i];
                }
            }
            return "There is no such a song";
        }

        public void Read(TextReader reader, List<String> col)
        {
            String line;
            while ((line = reader.ReadLine()) != null)
            {
                col.Add(line);
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            
        }

        private void searchBox_Enter(object sender, EventArgs e)
        {
            if (searchBox.Text == "Type in a song name...")
            {
                searchBox.ForeColor = Color.Black;
                searchBox.Text = "";
            }
        }

        private void searchBox_Leave(object sender, EventArgs e)
        {
            if (searchBox.Text == "")
            {
                searchBox.ForeColor = Color.Gray;
                searchBox.Text = "Type in a song name...";
            }
        }

        private void inputGroupName_Enter(object sender, EventArgs e)
        {
            if (inputGroupName.Text == "Type in a group name...")
            {
                inputGroupName.ForeColor = Color.Black;
                inputGroupName.Text = "";
            }
        }

        private void inputSongName_Leave(object sender, EventArgs e)
        {
            if (inputSongName.Text == "")
            {
                inputSongName.ForeColor = Color.Gray;
                inputSongName.Text = "Type in a song name...";
            }
        }

        public void choosePlaylistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog Dialog = new OpenFileDialog();
            Dialog.ShowDialog();
            StreamReader inside = new StreamReader(Dialog.FileName);
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            forsearch = searchBox.Text;

        }
    }
}
