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
        public int rowsCountDouble    { get; set; }
        public int columnsCountDouble { get; set; }
         
        public double[,] arrDouble { get; set; }
        public int[,] arrInt { get; set; }

        public TwoArraysAnalyzer(double[,] inputArrDouble, int[,] inputArrInt)
        {
            rowsCountDouble = inputArrDouble.GetLength(1);
            columnsCountDouble = inputArrDouble.GetLength(0);
            rowsCountInt = inputArrInt.GetLength(1);
            columnsCountInt = inputArrInt.GetLength(0);

            arrDouble = new double[columnsCountDouble, rowsCountDouble];
            arrInt = new int[columnsCountInt, rowsCountInt];

            for (int i = 0; i<columnsCountDouble; i++)
                for (int j = 0; j<rowsCountDouble; j++)
                {
                    arrDouble[i, j] = inputArrDouble[i, j];
                }
            for (int i = 0; i <columnsCountInt ; i++)
                for (int j = 0; j < rowsCountInt; j++)
                {
                    arrInt[i, j] = inputArrInt[i, j];
                }
        }

        public TwoArraysAnalyzer()
        {
            rowsCountDouble = 1;
            columnsCountDouble = 1;
            rowsCountInt = 1;
            columnsCountInt = 1;

            arrDouble = new double[columnsCountDouble, rowsCountDouble];
            arrInt = new int[columnsCountInt, rowsCountInt];
        }
    }

    
    internal class Program
    {
        static void Main(string[] args)
        {
            const string FILE_NAME = "Day17_WIP";
            int arrsizeintx, arrsizeinty, arrsizedoublex, arrsizedoubley;
            int[,] inputArrInt;
            double[,] inputArrDouble;
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

                arrsizedoublex = rng.Next(1, 5);
                arrsizedoubley = rng.Next(1, 5);
                arrsizeintx = rng.Next(1, 5);
                arrsizeinty = rng.Next(1, 5);

                inputArrInt = new int[arrsizeintx, arrsizeinty];
                inputArrDouble = new double[arrsizedoublex, arrsizedoubley];

                for (int i = 0; i<arrsizeintx; i++)
                {
                    for (int j = 0; j<arrsizeinty; j++)
                    {
                        inputArrInt[i, j] = rng.Next(0,10);
                    }
                }
                for (int i = 0; i<arrsizedoublex; i++)
                {
                    for (int j = 0; j< arrsizedoubley; j++)
                    {
                        inputArrDouble[i, j] = rng.Next(0,10);
                    }
                }
            //}
            arraysAnalyzer = new TwoArraysAnalyzer(inputArrDouble, inputArrInt);

            Task1WriteIntoFile(FILE_NAME, arraysAnalyzer);

            Task1ReadFile(FILE_NAME, ref arraysAnalyzer);
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
                //for (int i = 0; i < fs.Length; i++)
                //{
                //    Console.Write(file.ReadChar());
                //}

                Console.Write(file.ReadString());
                Console.Write(file.ReadString());
                Console.Write(file.ReadString());
                file.ReadChar();
                int intsizex = file.ReadInt32();
                Console.Write(file.ReadInt32());
                Console.Write(" ");
                int intsizey = file.ReadInt32();
                Console.Write(file.ReadInt32());
                for (int i = 0; i < intsizex; i++)
                {
                    for (int j = 0; j < intsizey; j++)
                        Console.Write(file.ReadInt32());
                    Console.Write(file.ReadChar());
                }
                int doublesizex = file.ReadInt32();
                Console.Write(file.ReadInt32());
                Console.Write(" ");
                int doublesizey = file.ReadInt32();
                Console.Write(file.ReadInt32());
                for (int i = 0; i < doublesizex; i++)
                {
                    for (int j = 0; j < doublesizey; j++)
                        Console.Write(file.ReadInt32());
                    Console.Write(file.ReadChar());
                }
            }

        }
        private static void Task1WriteIntoFile(string filename, TwoArraysAnalyzer twoArraysData)
        {
            using (FileStream fs = new FileStream($"{filename}.txt", FileMode.Create))
            using (BinaryWriter file = new BinaryWriter(fs,Encoding.UTF8))
            {
                file.Write(twoArraysData.name);
                Console.Write(twoArraysData.name);
                file.Write(twoArraysData.surname);
                Console.Write(twoArraysData.surname);
                file.Write(twoArraysData.lastname);
                Console.Write(twoArraysData.lastname);
                Console.Write('\n');
                file.Write(twoArraysData.rowsCountDouble);
                Console.Write(twoArraysData.rowsCountDouble);
                file.Write(twoArraysData.columnsCountDouble);
                Console.Write(twoArraysData.columnsCountDouble);
                Console.Write('\n');
                for (int i = 0; i < twoArraysData.columnsCountDouble; i++)
                {
                    for (int j = 0; j<twoArraysData.rowsCountDouble; j++)
                    {
                        file.Write(twoArraysData.arrDouble[i, j]);
                        Console.Write(twoArraysData.arrDouble[i, j]);
                    }
                    file.Write('\n');
                    Console.Write('\n');
                }
                file.Write(twoArraysData.rowsCountInt);
                Console.Write(twoArraysData.rowsCountInt);
                file.Write(twoArraysData.columnsCountInt);
                Console.Write(twoArraysData.columnsCountInt);
                Console.Write('\n');
                for (int i = 0; i < twoArraysData.columnsCountInt; i++)
                {
                    for (int j = 0; j < twoArraysData.rowsCountInt; j++)
                    {
                        file.Write(twoArraysData.arrInt[i, j]);
                        Console.Write(twoArraysData.arrInt[i, j]);
                    }
                    file.Write('\n');
                    Console.Write('\n');
                }
                file.Write(DateTime.Now.Day);
                Console.Write(DateTime.Now.Day);
                file.Write(DateTime.Now.Month);
                Console.Write(DateTime.Now.Month);
                file.Write(DateTime.Now.Year);
                Console.Write(DateTime.Now.Year);
            }
        }
    }
}
