using CsvHelper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WavFile;

namespace ReadWriteWavFile;

public static class ReadWriteFile
{

    public static WavFileHeader ReadWavFile(string fileName)
    {
        WavFileHeader header = new WavFileHeader();
        using (var fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
        {
            header = WavFileInfo.ReadFileHeader(fs);
        }
        return header;
    }

    public static byte[] ReadWavData(string filePath)
    {
        byte[] data = File.ReadAllBytes(filePath);
        return data;
    }

    public static double WriteWavFile(string fileName)
    {
        string outputPath = string.Empty;
        outputPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\Files\\ChannelWavFiles\\";
          
        double bytesTotal = 0;
        try
        {
                var splitter = new WavFileSplitter(value => { });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        return bytesTotal;
    }

    public static void CreateCsvFile(string csvPath)
    {
        string channelFilesPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\Files\\ChannelWavFiles\\";

        List<string> files = Directory.EnumerateFiles(channelFilesPath, "*.wav").ToList();
        List<CsvMappingModel> recordsToAdd = new List<CsvMappingModel>();

        foreach (string filePath in files)
        {
            string filename = Path.GetFileName(filePath);
            var data = File.ReadAllLines(filePath);
            var record = new CsvMappingModel()
            {
                Name = filename,
                Data = string.Join("", data)
            };
            recordsToAdd.Add(record);
        }

        //Writing Channel file name and data into csv
        using (var writer = new StreamWriter(csvPath))
        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
        {
            csv.WriteRecords(recordsToAdd);
        }
    }
}
