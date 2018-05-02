using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;
using System.Diagnostics;
using System.Threading;


namespace TaskParallelProgramming
{
    public partial class Task1 : Form
    {
        
        public Task1()
        {
            InitializeComponent();
            this.Activated += Task1_Activated;
        }

        private void Task1_Activated(object sender, EventArgs e)
        {
            int N = 10;
            Random rand = new Random();
            var timer = new Stopwatch();

            richTextBox1.Text += N.ToString() + "\n";
            var vector = (from i in new int[N] select rand.Next(0, 10));
            vector.Where(i => (i > 0));
            for (int k = 10; k < 1000000; k *= 10)
            {
                for (int i = 1; i < 7; i++)
                {
                    if (i == 6)
                    {
                        timer.Start();
                        ComputingMethod(vector.ToArray(), k, 10);
                        timer.Stop();
                        richTextBox1.Text +=
                           String.Format($"\n elapsed time(in milliseconds; M = 10,N={k}): ") + timer.ElapsedMilliseconds.ToString();
                        timer.Reset();
                    }
                    else
                    {
                        timer.Start();
                        ComputingMethod(vector.ToArray(), k, i);
                        timer.Stop();
                        richTextBox1.Text +=
                                String.Format($"\n elapsed time(in milliseconds; M = {i},N={k}): ") + timer.ElapsedMilliseconds.ToString();
                        timer.Reset();
                    }
                }
            }
        }


        public int[] ComputingMethod(int[] vector,int N)
        {
            Random rand = new Random();
            var ComputedVector = new int[vector.Length];
            for (int i=0;i<vector.Length;i++)
            {
                ComputedVector[i] = vector[i] * N;
                for (int k = 0; k < 1000000; k++)
                { }
            }
            return ComputedVector.ToArray();
        }

        public int[] ComputingMethod(int[] vector, int N, int M)
        {
            Random rand = new Random();
            var ComputedVector = vector;
            for (int i =0;i<M;i++)
            {
                Thread thrd = new Thread(() => {
                    for (int j = i * (vector.Length / M); j < (vector.Length / (M - i + 1)); j++)
                    {
                        ComputedVector[j] = vector[j] * N;
                        for (int k = 0; k < 1000000; k++)
                        { }
                    }
                });
                thrd.Start();
                thrd.Join();
            }
           
            return ComputedVector;
        }
    }
}
