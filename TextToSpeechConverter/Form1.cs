using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech;
using System.Speech.Synthesis;
using System.Threading;

namespace TextToSpeechConverter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            Thread t = new Thread(new ThreadStart(SplashStart));
            t.Start();
            Thread.Sleep(5000);
            InitializeComponent();
            t.Abort();
        }

        public void SplashStart()
        {
            Application.Run(new Splash());
        }

        SpeechSynthesizer reader = new SpeechSynthesizer();
        private void button1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text != "")
            {
                reader.Dispose();
                reader = new SpeechSynthesizer();
                reader.SpeakAsync(richTextBox1.Text);
            }
            else
            {
                MessageBox.Show("Please Enter Some Text to Speech!", "Message");
                richTextBox1.Focus();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (reader != null)
            {
                if (reader.State == SynthesizerState.Speaking)
                {
                    reader.Pause();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (reader != null)
            {
                if (reader.State == SynthesizerState.Paused)
                {
                    reader.Resume();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (reader != null)
            {
                    reader.Dispose();
            }
        }
    }
}
