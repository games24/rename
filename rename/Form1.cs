using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rename
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] hairetu = Directory.GetFiles(textBox1.Text);

            string xx = String.Copy(textBox1.Text);
            xx=xx.Remove(textBox1.Text.LastIndexOf('\\'));//文字列削除 後方から\\

            var za = xx.LastIndexOf('\\');
            za++;
            var aa=textBox1.Text.Substring(za,(textBox1.Text.Length-1-za));
            var d = from z in hairetu where true == z.Contains(aa) select z;
            foreach (var item in d)
            {


                Regex regex = new Regex(@"\d.*\.ts$");
                MatchCollection matchCol = regex.Matches(item);
                Match xxx = null;
                foreach (Match match in matchCol)
                {
                    xxx = match;
                }
                if (xxx == null)
                {
                    System.IO.File.Delete(item);
                    continue;
                }

                var ree=item.Remove(0, item.IndexOf('-')+1);
                File.Move(item, textBox1.Text+ ree);
            }
        }
    }

}