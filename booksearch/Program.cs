using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
namespace booksearch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ENTER THE WORD !!  :");
            string word = Console.ReadLine();
            StringBuilder stringb = new StringBuilder();
            string file = @"file:///D:/Books/Malala.pdf";
            PdfReader reader = new PdfReader(file);
                int i =0;
            for(int pageNo=1; pageNo <= reader.NumberOfPages; pageNo++)
            {
                ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
                string text = PdfTextExtractor.GetTextFromPage(reader, pageNo, strategy);
                text = Encoding.UTF8.GetString(ASCIIEncoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(text)));
                stringb.Append(text);
                if (text.Contains(word)) 
                {
                    ++i;
                    Console.WriteLine($"FOUND IN PAGE {pageNo}!!!!");
                    Console.WriteLine();
                    Console.WriteLine($"THE OCCURENCE NO {i} !!!!!");
                    Console.WriteLine();
                    if(i == 15)
                    {
                        break;
                    }
                }
            }
            Console.WriteLine("PRESS ENTER TO LEAVE!!!!");
            Console.ReadKey();
        }
    }
}
