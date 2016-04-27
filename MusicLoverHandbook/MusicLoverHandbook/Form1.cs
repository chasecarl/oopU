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

        String[] defaultSongsCollection;
        String[] defaultGroupsCollection;
        
        TextReader songsReader;
        TextReader groupsReader;

        public Form1()
        {
            InitializeComponent();

            songsReader = new StreamReader("songs.txt");
            defaultSongsCollection = new String[getLines(songsReader)];
            Read(songsReader, defaultSongsCollection);

            groupsReader = new StreamReader("groups.txt");
            defaultGroupsCollection = new String[getLines(groupsReader)];
            Read(groupsReader, defaultGroupsCollection);

            MessageBox.Show(defaultSongsCollection[0]);
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

        public void Read(TextReader reader, String[] col)
        {
            String line;
            int i = 0;
            while ((line = reader.ReadLine()) != null)
            {
                col[i] = line;
                i++;
            }
        }

        public int getLines(TextReader reader)
        {
            String line;
            int count = 0;
            while ((line = reader.ReadLine()) != null)
            {
                count++;
            }
            return count;
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            forsearch = searchBox.Text;
        }
    }
}
