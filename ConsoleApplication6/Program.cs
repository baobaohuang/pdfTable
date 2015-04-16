using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace ConsoleApplication6
{
    class Program
    {
        static void Main(string[] args)
        {
            test3();

        }

        static void test1()
        {
                using (FileStream output =new FileStream(@"c:\helloworld.pdf",FileMode.Create))
            {   
            Document myDoc = new Document();
            PdfWriter.GetInstance(myDoc, output);
            Paragraph p = new Paragraph("hello world!", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 20f));
            myDoc.Open();
            myDoc.Add(p);//加入文章段落
            myDoc.AddTitle("Tutorial-Hello World!");//文件標題
            myDoc.AddAuthor("azion");//文件作者
            myDoc.Close();
            }

        }

        static void test2()
        {
            var doc = new Document(PageSize.A4, 50, 50, 80, 50);
            MemoryStream memory = new MemoryStream();
            PdfWriter PdfWriter = PdfWriter.GetInstance(doc, memory);
            string path = @"c:\test1.pdf";
            PdfWriter pdfwriter = PdfWriter.GetInstance(doc, new FileStream(path, FileMode.Create));

            BaseFont bfchinese = BaseFont.CreateFont(@"C:\Windows\Fonts\kaiu.ttf",BaseFont.IDENTITY_H,BaseFont.NOT_EMBEDDED);
            Font chfont = new Font(bfchinese, 12);
            Font chfont_blue = new Font(bfchinese, 40, Font.NORMAL, new BaseColor(50,0,150) );
            Font chfont_error = new Font(bfchinese, 40, Font.NORMAL, BaseColor.RED);

            doc.Open();
            doc.Add(new Paragraph(10f,"Hello 大家好",chfont_blue ));
            doc.Close();

        }

        static void test3()
        {
            //PdfCell cell = new PdfCell(new Phrase("products"));
            PdfPTable table = new PdfPTable(new float[] { 2, 1, 1, 3 });
            table.TotalWidth = 400f;
            table.LockedWidth = true;
            PdfPCell header = new PdfPCell(new Phrase("header", new Font(Font.FontFamily.HELVETICA, 28f, Font.BOLD)));
            header.Colspan = 4;
            table.AddCell(header);
            table.AddCell("cell 1");
            table.AddCell("cell 2");
            table.AddCell("cell 3");
            table.AddCell("cell 4");
            BaseFont bfchinese = BaseFont.CreateFont(@"C:\Windows\Fonts\kaiu.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            Font chfont = new Font(bfchinese, 12);
            PdfPCell cell21 = new PdfPCell(new Phrase("檢查項目", chfont));
            PdfPCell cell22 = new PdfPCell(new Phrase("內容", chfont));
            cell22.Colspan = 3;
            table.AddCell(cell21);
            table.AddCell(cell22);
            PdfPCell cell3 = new PdfPCell(new Phrase("row span 3", chfont));
            cell3.Rowspan = 3;
            table.AddCell(cell3);
            for (int i = 1; i <= 3; i++)
            {
                table.AddCell("cell" + i.ToString()+"1");
                table.AddCell("cell" + i.ToString() + "2");
                table.AddCell("cell" + i.ToString() + "3");
            }
            table.AddCell("row 1");
            PdfPCell row = new PdfPCell(new Phrase("colspan3 rowspan3 ", chfont));
            row.Rowspan = 3;
            row.Colspan = 3;
            table.AddCell(row);
            table.AddCell("row 2");
            table.AddCell("row 3");

            using (FileStream output = new FileStream(@"c:\table.pdf", FileMode.Create))
            {
                Document myDoc = new Document();
                PdfWriter.GetInstance(myDoc, output);                
                myDoc.Open();
                myDoc.Add(table);
                myDoc.AddTitle("Tutorial-Hello World!");//文件標題
                myDoc.AddAuthor("azion");//文件作者
                myDoc.Close();
            }

        }



    }
}
