using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ハローメモ帳モザイク
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text += "Hello, World!";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text += comboBox1.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox1.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text += Clipboard.GetText();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Replace(textBox2.Text, textBox3.Text);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            using (var sw = new StreamWriter("aaa.txt", false, Encoding.GetEncoding("shift_jis")))
            {
                sw.Write(textBox1.Text);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            using (var sr = new StreamReader("aaa.txt", Encoding.GetEncoding("shift_jis")))
            {
                textBox1.Text = sr.ReadToEnd();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            using (var sr = new StreamReader(openFile(), Encoding.GetEncoding("shift_jis")))
            {
                textBox1.Text = sr.ReadToEnd();
            }
        }

        private string openFile()
        {
            //OpenFileDialogクラスのインスタンスを作成
            OpenFileDialog ofd = new OpenFileDialog();

            //はじめのファイル名を指定する
            //はじめに「ファイル名」で表示される文字列を指定する
            ofd.FileName = "default.html";
            //はじめに表示されるフォルダを指定する
            //指定しない（空の文字列）の時は、現在のディレクトリが表示される
            ofd.InitialDirectory = @"C:\";
            //[ファイルの種類]に表示される選択肢を指定する
            //指定しないとすべてのファイルが表示される
            ofd.Filter =
                "HTMLファイル(*.html;*.htm)|*.html;*.htm|すべてのファイル(*.*)|*.*";
            //[ファイルの種類]ではじめに
            //「すべてのファイル」が選択されているようにする
            ofd.FilterIndex = 2;
            //タイトルを設定する
            ofd.Title = "開くファイルを選択してください";
            //ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
            ofd.RestoreDirectory = true;
            //存在しないファイルの名前が指定されたとき警告を表示する
            //デフォルトでTrueなので指定する必要はない
            ofd.CheckFileExists = true;
            //存在しないパスが指定されたとき警告を表示する
            //デフォルトでTrueなので指定する必要はない
            ofd.CheckPathExists = true;

            string ret = "";
            //ダイアログを表示する
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //OKボタンがクリックされたとき
                //選択されたファイル名を表示する
                ret = ofd.FileName;
            }
            return ret;
        }
    }
}
