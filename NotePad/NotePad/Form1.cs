using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using File = System.IO.File;

namespace NotePad
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = " ";

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "TextDocument|*.txt", ValidateNames = true, Multiselect = false }) ;
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    richTextBox1.Text = File.ReadAllText(openFileDialog1.FileName);
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.DefaultExt = ".txt";
            saveFileDialog1.Filter = "Text File|*.txt|PDF file|*.pdf|Word File|*.doc";
            DialogResult dr = saveFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog1.FileName, richTextBox1.Text);
            }

        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sw = new SaveFileDialog();

            string filename = sw.FileName;

            String filter = "Text Files|*.txt|All Files|*.*";


            sw.Filter = filter;

            sw.Title = "Save";

            if (sw.ShowDialog(this) == DialogResult.OK)
            {


                System.IO.File.WriteAllText(filename, richTextBox1.Text);


            }

            else
            {

                return;

            }
        }

        System.Drawing.Printing.PrintDocument prntDoc = new System.Drawing.Printing.PrintDocument();
        private object get;

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintDialog print = new PrintDialog();
            prntDoc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(prntDoc_PrintPage);
      
            print.Document = prntDoc;
            if (print.ShowDialog(this) == DialogResult.OK)
            {
                prntDoc.Print();
            }
        }
        private void prntDoc_PrintPage(Object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawString(richTextBox1.Text, richTextBox1.Font, Brushes.Black, 0, 0);

        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintPreviewDialog preview = new PrintPreviewDialog();
            prntDoc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(prntDoc_PrintPage);
     
            preview.Document = prntDoc;
            if (preview.ShowDialog(this) == DialogResult.OK)
            {
                prntDoc.Print();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();          
            if (richTextBox1.Modified == true)
            {
                DialogResult dr = MessageBox.Show("Do you want to save the file before exiting", "unsaved file", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    string filename = sfd.FileName;
                    String filter = "Text Files|*.txt|All Files|*.*";
                    sfd.Filter = filter;
                    sfd.Title = "Save";

                    if (sfd.ShowDialog(this) == DialogResult.OK)
                    {
                    System.IO.File.WriteAllText(filename, richTextBox1.Text);
}

                    else
                    {
                        return;

                    }
                }
                else
                {
                    richTextBox1.Modified = false;
                    Application.Exit();
                }
            }

        }



        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();

        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();

        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }


        private void dateTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = System.DateTime.Now.ToString();
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Font = fontDialog1.Font;
            }
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.ForeColor = colorDialog1.Color;
            }

        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Shortcuts for notepad \n  ctrl+n - new file\n ctrl + o - open file\n  ctrl + p - print file\n  ctrl + e - exit\nctrl + f - find\n  ctrl + r - replace\n  f1 - help\n", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        
    }
    }
    

