using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DecryptUsingLSB
{
    public partial class Form1 : Form
    {
        Bitmap bmp;
        Bitmap bmpResize;
        const string END_MARK = "vinhy9x";
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog
            {
                Filter = "Image Files(*.jpg; .jpeg; .gif; .bmp; .png)|*.jpg; .jpeg; .gif; *.bmp ;*.png"
            };
            if (open.ShowDialog() == DialogResult.OK)
            {
                bmp = new Bitmap(new Bitmap(open.FileName));
                if (bmp.Width <= bmp.Height && bmp.Height >= 281)
                {
                    bmpResize = new Bitmap(bmp, (int)(bmp.Width / ((float)bmp.Height / 281)), 281);
                }
                else if (bmp.Width > bmp.Height && bmp.Width >= 547)
                {
                    bmpResize = new Bitmap(bmp, 547, (int)(bmp.Height / ((float)bmp.Width / 547)));
                    MessageBox.Show(bmpResize.Width + " - " + bmpResize.Height);
                }
                else
                {
                    bmpResize = bmp;
                }
                pictureBox1.Image = bmpResize;
                textBox1.Text = open.FileName;
            }
        }

        private void Decrypt(object sender, EventArgs e)
        {
            int count = 0;
            if (bmp == null)
            {
                MessageBox.Show("Choose the image containing message");
                return;
            }
            StringBuilder rawMessage = new StringBuilder();
            bool endMarkFound = false;
            for (int i = 0; i < bmp.Height; i++)
            {
                count++;
                if (AddBitOfMessage(i, ref rawMessage))
                {
                    endMarkFound = true;
                    break;
                }
            }
            Clipboard.SetText(rawMessage.ToString());
            if (!endMarkFound)
            {
                MessageBox.Show("Can not find end point of the message in this picture.");
            }
        }
        private bool AddBitOfMessage(int i, ref StringBuilder rawMessage)
        {
            for (int j = 0; j < bmp.Width; j++)
            {
                rawMessage.Append(Convert.ToString(bmp.GetPixel(i, j).R, 2).PadLeft(8, '0')[7]);
                if (rawMessage.ToString().Contains(StringToBinary(END_MARK)))
                {
                    rawMessage.Remove(rawMessage.Length - 56, 56);
                    richTextBox1.Text = BinaryToString(rawMessage.ToString());
                    return true;
                }
            }
            return false;
        }
        public static string StringToBinary(string message)
        {
            StringBuilder sb = new StringBuilder();

            foreach (char c in message)
            {
                sb.Append(Convert.ToString(c, 2).PadLeft(8, '0'));
            }
            return sb.ToString();
        }

        public static string BinaryToString(string binary)
        {
            try
            {
                List<Byte> byteList = new List<Byte>();

                for (int i = 0; i < binary.Length; i += 8)
                {
                    byteList.Add(Convert.ToByte(binary.Substring(i, 8), 2));
                }
                return Encoding.ASCII.GetString(byteList.ToArray());
            }
            catch
            {
                MessageBox.Show("Invalid binary string.");
                return string.Empty;
            }
        }
    }
}
