using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskParallelProgramming
{
    public partial class Form1 : Form
    {
        public Task1 Task1_Window = new Task1();
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Task1_Window.ShowDialog();
        }
    }
}
