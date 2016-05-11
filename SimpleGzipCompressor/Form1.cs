using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SimpleGzipCompressor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        public void ButtonActivateSwitch(bool onProcess)
        {
            button_cancel.Enabled = onProcess;

            button_process.Enabled = !onProcess;
            checkBox_delete.Enabled = !onProcess;
            checkBox_removeext.Enabled = !onProcess;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ButtonActivateSwitch(false);
        }

        private void button_process_DragEnter(object sender, DragEventArgs e)
        {
            var drags = (string[])e.Data.GetData(DataFormats.FileDrop);

            if(e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                foreach(var s in drags)
                {
                    if (File.Exists(s)) continue;
                    if (Directory.Exists(s)) continue;

                    return;
                }
            }

            e.Effect = DragDropEffects.Move;
        }

        CancellationTokenSource token = null;
        private async void button_process_DragDrop(object sender, DragEventArgs e)
        {
            var drags = (string[])e.Data.GetData(DataFormats.FileDrop);
            var flist = new List<string>();
            
            foreach(var d in drags)
            {
                //ディレクトリならば
                if (Directory.Exists(d)) flist.AddRange(Directory.GetFiles(d));
                //ファイルならば
                else if (File.Exists(d)) flist.Add(d);
            }

            token = new CancellationTokenSource();

            //ボタンの無効化
            ButtonActivateSwitch(true);

            //圧縮開始
            await GzipCompressor.CompressAsync(flist, checkBox_delete.Checked, checkBox_removeext.Checked,
                new Progress<string>(prog =>
                {
                    label_progress.Text = prog;
                }), token.Token);

            ButtonActivateSwitch(false);
            label_progress.Text = "完了(" + flist.Count + "件)";
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            if (token != null) token.Cancel();
        }
    }
}
