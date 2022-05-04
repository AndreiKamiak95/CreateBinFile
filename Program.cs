using System;
using System.IO;

namespace CreateBinFile
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string nameFile = args[0];
                if(args[0] == "help")
                {
                    PrintHelp();
                    return;
                }

                BinaryWriter binaryWriter = new BinaryWriter(File.Create(nameFile));

                ulong numByte;
                if (args[1].IndexOf('M') > 0)
                {
                    numByte = Convert.ToUInt64(args[1].Substring(0, args[1].Length - 1)) * 1024 * 1024;
                }
                else if (args[1].IndexOf('K') > 0)
                {
                    numByte = Convert.ToUInt64(args[1].Substring(0, args[1].Length - 1)) * 1024;
                }
                else if (args[1].IndexOf('k') > 0)
                {
                    numByte = Convert.ToUInt64(args[1].Substring(0, args[1].Length - 1)) * 1024;
                }
                else
                {
                    numByte = Convert.ToUInt64(args[1]);
                }

                Console.WriteLine("Name file: {0}", nameFile);
                Console.WriteLine("Size in bytes: {0}", numByte);

                for (ulong i = 0; i < numByte; i++)
                {
                    if (args.Length < 3)
                    {
                        binaryWriter.Write((byte)i);
                    }
                    else
                    {
                        binaryWriter.Write(Convert.ToByte(args[2], 16));
                    }
                }

                binaryWriter.Close();
                Console.WriteLine("File create");
            }
            catch(Exception)
            {
                PrintHelp();
            }
        }

        static void PrintHelp()
        {
            Console.WriteLine("file_name.bin numByte[p] [code_symbol_in_hex]");
            Console.WriteLine("Example: ");
            Console.WriteLine("data.bin 1024");
            Console.WriteLine("data1.bin 512 0xAA");
            Console.WriteLine("data2.bin 5M");
            Console.WriteLine("data2.bin 3K 0x55");
        }
    }
}
