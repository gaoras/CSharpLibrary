using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibFileManagement
{
    /// <summary>
    /// csvファイルを読み込むクラス
    /// </summary>
    public class CsvReader
    {
        /// <summary>
        /// 指定したファイルの内容の読み取り
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string[][] Read(string path)
        {
            List<string[]> data = new List<string[]>();
            try
            {
                //ファイルが存在するか確認
                if (File.Exists(path) == true)
                {
                    using (StreamReader sr = new StreamReader(path, Encoding.GetEncoding("Shift-JIS")))
                    {
                        //EOFまで読み取り
                        while (sr.Peek() > -1)
                        {
                            data.Add(sr.ReadLine().Split(','));
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return data.ToArray();
        }
    }
}
