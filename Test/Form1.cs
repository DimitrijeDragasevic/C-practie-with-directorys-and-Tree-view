using System;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;

namespace Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // celect the drive to display there directorys 
            DirectoryInfo directoryInfo = new DirectoryInfo(@"C:\test");
            

            if (directoryInfo.Exists)
            {
                treeView1.AfterSelect += treeView1_AfterSelect;
                BuildTree(directoryInfo, treeView1.Nodes);
                
                
            }
           
        }
             private void BuildTree(DirectoryInfo directoryInfo, TreeNodeCollection addInMe)
        {
            TreeNode curNode = addInMe.Add(directoryInfo.Name);
            
            
            foreach (FileInfo file in directoryInfo.GetFiles())
            {
                //file name and size 
                curNode.Nodes.Add(file.FullName, file.Name);
               curNode.Nodes.Add("file size",file.Length.ToString());
              
                
            }
            foreach (DirectoryInfo dir in directoryInfo.GetDirectories())
            {
                curNode.Nodes.Add(dir.LastWriteTime.ToString());
                

            }

            
            foreach (DirectoryInfo subdir in directoryInfo.GetDirectories())
            {
                BuildTree(subdir, curNode.Nodes);
               
            }



            
        }
        // displays the text files in the directorys in a rich text box
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Name.EndsWith("txt"))
            {
                this.richTextBox1.Clear();
                StreamReader reader = new StreamReader(e.Node.Name);
                this.richTextBox1.Text = reader.ReadToEnd();
                reader.Close();
            }
          
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }

        
       
    }

