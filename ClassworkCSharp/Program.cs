using System;
using System.IO;
using System.Text;

namespace ClassworkCSharp
{
    //class that takes 2 arrays as input and has fields for storing their data???
    //so when you need to access them in a particular order you go like TwoArraysAnalyzer.dataPiece
    internal class TwoArraysAnalyzer
    {
        //hehe hardcoding goes brrr
        public readonly string name = "Lev";
        public readonly string surname = "Kristenko";
        public readonly string lastname = "Igorevich";
        public readonly string datebirth = "11.01.2002";
         
        public int rowsCountInt      { get; set; }
        public int columnsCountInt   { get; set; }
        public int rowsCountFloat    { get; set; }
        public int columnsCountFloat { get; set; }
         
        public float[,] arrFloat { get; set; }
        public int[,] arrInt { get; set; }

        public TwoArraysAnalyzer(float[,] inputArrFloat, int[,] inputArrInt)
        {
            rowsCountFloat = inputArrFloat.GetLength(1);
            columnsCountFloat = inputArrFloat.GetLength(0);
            rowsCountInt = inputArrInt.GetLength(1);
            columnsCountInt = inputArrInt.GetLength(0);

            arrFloat = new float[columnsCountFloat, rowsCountFloat];
            arrInt = new int[columnsCountInt, rowsCountInt];

            for (int i = 0; i<columnsCountFloat; i++)
                for (int j = 0; j<rowsCountFloat; j++)
                {
                    arrFloat[i, j] = inputArrFloat[i, j];
                }
            for (int i = 0; i <columnsCountInt ; i++)
                for (int j = 0; j < rowsCountInt; j++)
                {
                    arrInt[i, j] = inputArrInt[i, j];
                }
        }

        public TwoArraysAnalyzer()
        {
            rowsCountFloat = 1;
            columnsCountFloat = 1;
            rowsCountInt = 1;
            columnsCountInt = 1;

            arrFloat = new float[columnsCountFloat, rowsCountFloat];
            arrInt = new int[columnsCountInt, rowsCountInt];
        }
    }

    
    internal class Program
    {
        static void Main(string[] args)
        {
            const string FILE_NAME = "Day17_WIP";
            int arrsizeintx, arrsizeinty, arrsizefloatx, arrsizefloaty;
            int[,] inputArrInt;
            float[,] inputArrFloat;
            TwoArraysAnalyzer arraysAnalyzer = new TwoArraysAnalyzer();
            //read the sizes and arrays and then shove them into the analyzer???
            //TaskReadFile() must read sizes of arrays, then the arrays themselves, i guess
            //but then that means that you must basically pass in an empty TwoArrayAnalyzer and change values inside it???
            //There's probably a better way to do all this. Too bad! 

            //if (File.Exists($"{FILE_NAME}.txt"))
            //{
            //    Console.WriteLine("it exists but i can't read lmao");
            //    //Task1ReadFile($"{FILE_NAME}.txt", ref arraysAnalyzer);
            //}
            //else //randomly generate arrays here if the array data has not been read from file
            //{
                Random rng = new Random();

                arrsizefloatx = rng.Next(1, 5);
                arrsizefloaty = rng.Next(1, 5);
                arrsizeintx = rng.Next(1, 5);
                arrsizeinty = rng.Next(1, 5);

                inputArrInt = new int[arrsizeintx, arrsizeinty];
                inputArrFloat = new float[arrsizefloatx, arrsizefloaty];

                for (int i = 0; i<arrsizeintx; i++)
                {
                    for (int j = 0; j<arrsizeinty; j++)
                    {
                        inputArrInt[i, j] = rng.Next(0,10);
                    }
                }
                for (int i = 0; i<arrsizefloatx; i++)
                {
                    for (int j = 0; j< arrsizefloaty; j++)
                    {
                        inputArrFloat[i, j] = rng.Next(0,10);
                    }
                }
            //}

            arraysAnalyzer = new TwoArraysAnalyzer(inputArrFloat, inputArrInt);

            Task1WriteIntoFile(FILE_NAME, arraysAnalyzer);

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
        private static void Task1ReadFile(string filename, ref TwoArraysAnalyzer arraysAnalyzer)
        {
            if (!File.Exists($"{filename}.txt"))
            {
                Console.WriteLine("file does not exist");
                return;
            }
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
        private static void Task1WriteIntoFile(string filename, TwoArraysAnalyzer twoArraysData)
        {
            using (FileStream fs = new FileStream($"{filename}.txt", FileMode.Create))
            using (BinaryWriter file = new BinaryWriter(fs,Encoding.UTF8))
            {
                file.Write(twoArraysData.name);
                file.Write(twoArraysData.surname);
                file.Write(twoArraysData.lastname);
                file.Write('\n');
                file.Write(twoArraysData.rowsCountFloat);
                file.Write(twoArraysData.columnsCountFloat);
                for (int i = 0; i < twoArraysData.columnsCountFloat; i++)
                {
                    for (int j = 0; j<twoArraysData.rowsCountFloat; j++)
                    {
                        file.Write(twoArraysData.arrFloat[i, j]);
                    }
                    file.Write('\n');
                }
                file.Write(twoArraysData.rowsCountInt);
                file.Write(twoArraysData.columnsCountInt);
                for (int i = 0; i < twoArraysData.columnsCountInt; i++)
                {
                    for (int j = 0; j < twoArraysData.rowsCountInt; j++)
                    {
                        file.Write(twoArraysData.arrInt[i, j]);
                    }
                    file.Write('\n');
                }
                file.Write(DateTime.Now.Day);
                file.Write(DateTime.Now.Month);
                file.Write(DateTime.Now.Year);
            }
        }
    }
}
