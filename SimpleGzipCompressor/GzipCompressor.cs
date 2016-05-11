using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
using System.Threading;

namespace SimpleGzipCompressor
{
    public static class GzipCompressor
    {
        private static void CompressFile(string filePath, bool deleteOnCompleted, bool removeExtension)
        {
            if (!File.Exists(filePath)) return;

            //出力ファイル名
            string outFile;
            if (removeExtension) outFile = Path.GetDirectoryName(filePath) + "\\" + Path.GetFileNameWithoutExtension(filePath) + ".gz";
            else outFile = Path.GetDirectoryName(filePath) + "\\" + Path.GetFileName(filePath) + ".gz";

            //バッファー
            int num;
            var buf = new byte[4096];

            try
            {
                //圧縮
                using (var inStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                using (var outStream = new FileStream(outFile, FileMode.Create))
                using (var gzipStream = new GZipStream(outStream, CompressionMode.Compress))
                {
                    while ((num = inStream.Read(buf, 0, buf.Length)) > 0)
                        gzipStream.Write(buf, 0, num);
                }
                //完了後削除
                if (deleteOnCompleted) File.Delete(filePath);
            }
            catch(Exception)
            {

            }
        }

        public static async Task CompressAsync(IEnumerable<string> filePaths, bool deleteOnCompleted, bool removeExtension, IProgress<string> progress, CancellationToken token)
        {
            await Task.Factory.StartNew(() =>
                {
                    int cnt = 1;
                    int n = filePaths.Count();
                    foreach (var f in filePaths)
                    {
                        if(token.IsCancellationRequested)
                        {
                            throw new OperationCanceledException();
                        }
                        //gzipファイルは無視する
                        if (Path.GetExtension(f) == ".gz") continue;

                        CompressFile(f, deleteOnCompleted, removeExtension);

                        progress.Report(string.Format("進捗 : {0} / {1}", cnt, n));
                        cnt++;
                    }
                });
        }
    }
}
