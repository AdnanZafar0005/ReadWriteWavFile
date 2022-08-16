

using ReadWriteWavFile;
using WavFile;

        string filePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\Files\\", "WavFile.wav");
        if (!String.IsNullOrEmpty(filePath))
        {
            // Read Header
            WavFileHeader header = ReadWriteFile.ReadWavFile(filePath);        

            // Read Data 
            byte[] dataArray = ReadWriteFile.ReadWavData(filePath);
            Console.WriteLine("Displaying Data");
            Console.WriteLine(header);
            Console.WriteLine("\n\n");
            Console.WriteLine("Displaying Data");

            if (dataArray.Length > 0)
            {
                foreach (var data in dataArray)
                {
                    Console.Write(data);
                }
            }

            // Write channel files
            double channelData = ReadWriteFile.WriteWavFile(filePath);
            Console.WriteLine(channelData);
            Console.WriteLine("Channel Files created.\n");

             // Creating csv file
            string csvfilePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\Files\\Csv\\", "WavFile.csv");
            ReadWriteFile.CreateCsvFile(csvfilePath);

            Console.WriteLine("Csv file created and channel name and data written.\n");
        }

        Console.ReadKey();
