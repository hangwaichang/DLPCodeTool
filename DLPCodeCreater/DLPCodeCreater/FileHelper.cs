using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLPCodeCreater
{
    internal class FileHelper
    {
//breach A
        //查詢資料夾目錄下所有資料夾名稱
        public List<string> DirSearch(string sDir)
        {
            List<string> dirlist = new List<string>();
            //先找出所有目錄 
            string[] dirs = Directory.GetDirectories(sDir);/*目錄(含路徑)的陣列*/

            foreach (string item in dirs)
            {
                dirlist.Add(Path.GetFileNameWithoutExtension(item));//走訪每個元素只取得目錄名稱(不含路徑)並加入dirlist集合中
            }

            return dirlist;
        }

        //查詢資料夾目錄下所有檔案名稱
        public List<string> GetFiles(string path)
        {
            List<string> dirlist = new List<string>();

            DirectoryInfo di = new DirectoryInfo(path);
            FileInfo[] files = di.GetFiles();

            foreach (FileInfo file in files)
            {
                dirlist.Add(file.Name);
            }
            return dirlist;
        }

        public void CheckDir(string CheckPath)
        {
            if (!System.IO.Directory.Exists(CheckPath))
            {

                // 顯示MessageBox 
                DialogResult Result = MessageBox.Show("建立新路徑" + CheckPath);

                if (Result == System.Windows.Forms.DialogResult.OK)
                {
                    System.IO.Directory.CreateDirectory(CheckPath);
                }

            }
        }

        public Boolean FileMove(string FromPath, string TargetPath)
        {
            Boolean result = false;
            try
            {
                System.IO.File.Copy(FromPath, TargetPath, true);
                result = true;
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return result;
        }


        public Boolean FileReplace(string FilePath, string Text, string ReplaceText)
        {
            Boolean result = false;
            try
            {
                string text = File.ReadAllText(FilePath);
                text = text.Replace(Text, ReplaceText);
                File.WriteAllText(FilePath, text);
                result = true;
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return result;

        }

        public List<string> FileRead(string FilePath, string KeyWord, string EndWord)
        {
            List<string> CopyString = new List<string>();
            var lines = File.ReadAllLines(FilePath);
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains(KeyWord))
                {
                    for (int j = i; j < lines.Length; j++)
                    {
                        CopyString.Add(lines[j]);
                        if (lines[j].Contains(EndWord)) break;
                    }
                    break;
                }
            }

            return CopyString;
        }


        public void FileWrite(List<string> Text, Boolean append, string Scope)
        {
            TextWriter txt = new StreamWriter(@".\copy.txt", append);

            if (Scope == "Start")
            {
                //Clear
                txt.Write("");
            }
            else
            {
                txt.WriteLine("//===================================[" + Scope + "]===================================//");
                if (Text.Count > 0)
                {
                    foreach (string t in Text)
                    {
                        txt.WriteLine(t);
                    }
                }
                else
                {
                    txt.WriteLine("目的地已存在相同檔案!");
                    txt.WriteLine("請確認是否有填寫 #region 供程式抓取!");
                }
            }


            txt.Close();
        }
    }
}
