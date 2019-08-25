using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibFileManagement;

namespace CSharpLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            //読み込みファイルのパスを指定
            string filePath = @"D:\Users\YU\Desktop\csvComma.csv";
            string[][] csvData = CsvReader.Read(filePath);
            for (int i = 0; i < csvData.Length; i++)
            {
                for (int j = 0; j < csvData[i].Length; j++)
                {
                    Console.Write(csvData[i][j] + " ");
                }
                Console.WriteLine();
            }
            Console.Read();
        }
    }
}
