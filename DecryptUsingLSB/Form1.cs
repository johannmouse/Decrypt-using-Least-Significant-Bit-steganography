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
                    richTextBox1.Text = ToVietnamese(BinaryToString(rawMessage.ToString()));
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

        private string ToVietnamese(string message)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(message);

            //lower case
            builder.Replace("a{0}", "à");
            builder.Replace("a{1}", "á");
            builder.Replace("a{2}", "ả");
            builder.Replace("a{3}", "ã");
            builder.Replace("a{4}", "ạ");

            builder.Replace("a{5}", "ă");
            builder.Replace("a{6}", "ằ");
            builder.Replace("a{7}", "ắ");
            builder.Replace("a{8}", "ẳ");
            builder.Replace("a{9}", "ẵ");
            builder.Replace("a{10}", "ặ");

            builder.Replace("a{11}", "â");
            builder.Replace("a{12}", "ầ");
            builder.Replace("a{13}", "ấ");
            builder.Replace("a{14}", "ẩ");
            builder.Replace("a{15}", "ẫ");
            builder.Replace("a{16}", "ậ");

            builder.Replace("d{0}", "đ");

            builder.Replace("e{0}", "è");
            builder.Replace("e{1}", "é");
            builder.Replace("e{2}", "ẻ");
            builder.Replace("e{3}", "ẽ");
            builder.Replace("e{4}", "ẹ");

            builder.Replace("e{5}", "ê");
            builder.Replace("e{6}", "ề");
            builder.Replace("e{7}", "ế");
            builder.Replace("e{8}", "ể");
            builder.Replace("e{9}", "ễ");
            builder.Replace("e{10}", "ệ");

            builder.Replace("i{0}", "ì");
            builder.Replace("i{1}", "í");
            builder.Replace("i{2}", "ỉ");
            builder.Replace("i{3}", "ĩ");
            builder.Replace("i{4}", "ị");

            builder.Replace("o{0}", "ò");
            builder.Replace("o{1}", "ó");
            builder.Replace("o{2}", "ỏ");
            builder.Replace("o{3}", "õ");
            builder.Replace("o{4}", "ọ");

            builder.Replace("o{5}", "ô");
            builder.Replace("o{6}", "ồ");
            builder.Replace("o{7}", "ố");
            builder.Replace("o{8}", "ổ");
            builder.Replace("o{9}", "ỗ");
            builder.Replace("o{10}", "ộ");

            builder.Replace("o{11}", "ơ");
            builder.Replace("o{12}", "ờ");
            builder.Replace("o{13}", "ớ");
            builder.Replace("o{14}", "ở");
            builder.Replace("o{15}", "ỡ");
            builder.Replace("o{16}", "ợ");

            builder.Replace("u{0}", "ù");
            builder.Replace("u{1}", "ú");
            builder.Replace("u{2}", "ủ");
            builder.Replace("u{3}", "ũ");
            builder.Replace("u{4}", "ụ");

            builder.Replace("u{5}", "ư");
            builder.Replace("u{6}", "ừ");
            builder.Replace("u{7}", "ứ");
            builder.Replace("u{8}", "ử");
            builder.Replace("u{9}", "ữ");
            builder.Replace("u{10}", "ự");

            builder.Replace("y{0}", "ỳ");
            builder.Replace("y{1}", "ý");
            builder.Replace("y{2}", "ỷ");
            builder.Replace("y{3}", "ỹ");
            builder.Replace("y{4}", "ỵ");

            // upper case
            builder.Replace("A{0}", "À");
            builder.Replace("A{1}", "Á");
            builder.Replace("A{2}", "Ả");
            builder.Replace("A{3}", "Ã");
            builder.Replace("A{4}", "Ạ");

            builder.Replace("A{5}", "Ă");
            builder.Replace("A{6}", "Ằ");
            builder.Replace("A{7}", "Ắ");
            builder.Replace("A{8}", "Ẳ");
            builder.Replace("A{9}", "Ẵ");
            builder.Replace("A{10}", "Ặ");

            builder.Replace("A{11}", "Â");
            builder.Replace("A{12}", "Ầ");
            builder.Replace("A{13}", "Ấ");
            builder.Replace("A{14}", "Ẩ");
            builder.Replace("A{15}", "Ẫ");
            builder.Replace("A{16}", "Ậ");

            builder.Replace("D{0}", "Đ");

            builder.Replace("E{0}", "È");
            builder.Replace("E{1}", "É");
            builder.Replace("E{2}", "Ẻ");
            builder.Replace("E{3}", "Ẽ");
            builder.Replace("E{4}", "Ẹ");

            builder.Replace("E{5}", "Ê");
            builder.Replace("E{6}", "Ề");
            builder.Replace("E{7}", "Ế");
            builder.Replace("E{8}", "Ể");
            builder.Replace("E{9}", "Ễ");
            builder.Replace("E{10}", "Ệ");

            builder.Replace("I{0}", "Ì");
            builder.Replace("I{1}", "Í");
            builder.Replace("I{2}", "Ỉ");
            builder.Replace("I{3}", "Ĩ");
            builder.Replace("I{4}", "Ị");

            builder.Replace("O{0}", "Ò");
            builder.Replace("O{1}", "Ó");
            builder.Replace("O{2}", "Ỏ");
            builder.Replace("O{3}", "Õ");
            builder.Replace("O{4}", "Ọ");

            builder.Replace("O{5}", "Ô");
            builder.Replace("O{6}", "Ồ");
            builder.Replace("O{7}", "Ố");
            builder.Replace("O{8}", "Ổ");
            builder.Replace("O{9}", "Ỗ");
            builder.Replace("O{10}", "Ộ");

            builder.Replace("O{11}", "Ơ");
            builder.Replace("O{12}", "Ờ");
            builder.Replace("O{13}", "Ớ");
            builder.Replace("O{14}", "Ở");
            builder.Replace("O{15}", "Ỡ");
            builder.Replace("O{16}", "Ợ");

            builder.Replace("U{0}", "Ù");
            builder.Replace("U{1}", "Ú");
            builder.Replace("U{2}", "Ủ");
            builder.Replace("U{3}", "Ũ");
            builder.Replace("U{4}", "Ụ");

            builder.Replace("U{5}", "Ư");
            builder.Replace("U{6}", "Ừ");
            builder.Replace("U{7}", "Ứ");
            builder.Replace("U{8}", "Ử");
            builder.Replace("U{9}", "Ữ");
            builder.Replace("U{10}", "Ự");

            builder.Replace("Y{0}", "Ỳ");
            builder.Replace("Y{1}", "Ý");
            builder.Replace("Y{2}", "Ỷ");
            builder.Replace("Y{3}", "Ỹ");
            builder.Replace("Y{4}", "Ỵ");

            return builder.ToString();
        }
    }
}
