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

            MessageBox.Show(defaultSongsCollection[0]);//for checking
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

        private void searchButton_Click(object sender, EventArgs e)
        {
            forsearch = searchBox.Text;
        }
    }
}
