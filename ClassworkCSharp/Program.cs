using System;
using System.IO;
using System.Text;

namespace ClassworkCSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //TODO: вынести в отдельную функцию
            FileStream file = Task1CreateFile("Day17_VERY_WIP");
            string aaaa = "I don't know what I'm doing";

            foreach (char c in aaaa)
                file.WriteByte(((byte)c));
            file.Close();

            Task1ReadFile("Day17_VERY_WIP");
            Console.ReadKey();
        }

        private static FileStream Task1CreateFile(string filename)
        {
            FileStream trytoreadfile;

            try
            {
                trytoreadfile = new FileStream($"{filename}.txt", FileMode.Open);
            }
            catch (FileNotFoundException)
            {
                FileStream fs = new FileStream($"{filename}.txt", FileMode.Create);
                return fs;
            }
            Console.WriteLine("File already exists");

            return trytoreadfile;
        }
        private static void Task1ReadFile(string filename)
        {
            using (FileStream fs = new FileStream($"{filename}.txt", FileMode.Open))
            using (BinaryReader file = new BinaryReader(fs, Encoding.UTF8))
            { 
                for (int i = 0; i < fs.Length; i++)
                {
                    Console.Write(file.ReadChar());
                }
                //Console.WriteLine(file.ReadString()); //System.IO.EndOfStreamException: "Unable to read beyond the end of the stream."
            }

        }
        private static void Task1WriteIntoFile(string filename)
        {

        }
    }
}
