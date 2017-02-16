using Microsoft.VisualBasic.FileIO;
using System;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Globalization;
using System.IO;

public struct icon
{
    public string id;
    public int x;
    public int y;
    public int width;
    public int height;

    public icon(string hex, int x, int y, int width, int height)
    {
        this.id = hex;
        this.x = x;
        this.y = y;
        this.width = width;
        this.height = height;
    }
}
class Program
{

    static List<icon> icons;//= new List<icon>();
    static void Main(string[] args)
    {
        icons = new List<icon>();
        using (TextFieldParser parser = new TextFieldParser(@"c:\temp\map.csv"))
        {
            parser.TextFieldType = FieldType.Delimited;
            parser.SetDelimiters(",");
            while (!parser.EndOfData)
            {

                //Process row                  s
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

                string[] fields = parser.ReadFields();       
                var str1 = Strings.StrConv(fields[0], VbStrConv.Wide, 1041);
                var idd = (int)char.Parse(str1);
                icon s = new icon
                {
                    id = idd.ToString(),
                    x = ToInt(fields[2]),
                    y = ToInt(fields[3]),
                    height = ToInt(fields[4]),
                    width = ToInt(fields[3])
                };
                icons.Add(s);

            }
            //foreach (var item in icons)
            //{
            //    Console.WriteLine($"{item.id} {item.x} {item.y} {item.height} {item.width}");
            //}
        }
        using (StreamReader sw = new StreamReader(@"c:\temp\m.fnt"))
        {
            string s = sw.ReadToEnd();
            FntParse.DoXMLPase(s, icons);
        }
  

       // Console.ReadKey();
    }
    private static int ToInt(string s)
    {
        if (string.IsNullOrEmpty(s))
        {
            return 0;
        }
        else
        {
            try
            {
                return int.Parse(s);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return 0;
            }
        }
    }
}
