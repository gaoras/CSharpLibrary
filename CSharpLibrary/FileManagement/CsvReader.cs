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
                        //1行分のデータ
                        while (sr.Peek() > -1)
                        {
                            List<string> fields = new List<string>();
                            //1行取得
                            string line = sr.ReadLine();
                            //"内かどうかフラグ
                            int InDoubleQuote = 0;
                            //フィールド1個分を保持
                            string cell = "";

                            for (int i = 0; i < line.Length; i++)
                            {
                                switch (line[i])
                                {
                                    case '"':
                                        if (InDoubleQuote == 1)
                                        {
                                            //"が2つ連続の際は1つの"に変換する
                                            if (line.Length > (i + 1) && line[i + 1] == '"')
                                            {
                                                //”２文字を１文字に変換
                                                cell += '"';
                                                i++;
                                            }
                                            else
                                            {
                                                //コンマフラグ反転
                                                InDoubleQuote ^= 1;
                                            }
                                        }
                                        else
                                        {
                                            //コンマフラグ反転
                                            InDoubleQuote ^= 1;
                                        }
                                        break;
                                    case ',':
                                        //,の処理
                                        //"内ならデータとして処理
                                        //"外なら区切り文字として処理
                                        if (InDoubleQuote == 1)
                                        {
                                            cell += line[i];
                                        }
                                        else
                                        {
                                            fields.Add(cell);
                                            cell = "";
                                        }
                                        break;
                                    default:
                                        //それ以外はデータとして処理
                                        cell += line[i];
                                        break;
                                }

                            }
                            //最後のデータを追加
                            fields.Add(cell);
                            data.Add(fields.ToArray());
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
