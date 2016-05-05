using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using PdfFileWriter;
using System.IO;

namespace OpenToBuy___Admin
{
    class PdfBuilder
    {
        PdfDocument document = new PdfDocument(); //obiectul document
        PdfPage page1; //obiectul pagina
        PdfContents contents; //obiectul continut
        PdfFont font; //obiectul font
        Point pointInFile = new Point(70, 650); //punctul de la care se incepe scrierea
        public PdfBuilder()
        {
            page1 = new PdfPage(document); //atribuirea paginii la document
            contents = new PdfContents(document); //atribuirea continutului la document
            font = new PdfFont(document,"Arial",FontStyle.Regular,true); //declararea fontului
            contents.DrawRectangle(50, 670, 510, 2,PaintOp.Fill); //desenarea unui dreptunghi cu cele 2 dimensiuni si punctul de origine a coltului de stanga-sus
            contents.DrawText(font, 45,50,700, "Open To Buy - Factura"); //desenarea textului cu fontul de mai sus si de o anumita dimensiune
            page1.AddContents(contents); //adaugarea continutului la pagina
            document.CreateFile("../factura.pdf"); //crearea fisierului propriu zis la directiva data
        }

        public void drawString(String s) //functie de desenat string
        {
            contents.DrawText(font, 14, pointInFile.X, pointInFile.Y, s); //deseneaza text la punctele date
            page1.AddContents(contents); //adaugare continut la pagina
            pointInFile.Y = pointInFile.Y - 30; //modifica Y-ul punctului de la care se deseneaza
            document.CreateFile("../factura.pdf"); //crearea fisierului cu noul continut
        }
        public void drawTotal(float Total) //functie de desenat pret total
        {
            int j = 0;
            contents.DrawRectangle(50, pointInFile.Y, 510, 2, PaintOp.Fill); //deseneaza un dreptunghi
            pointInFile.Y = pointInFile.Y - j - 30; //modifica pozitia punctului
            contents.DrawText(font, 14, pointInFile.X, pointInFile.Y, "Total: " + Total.ToString() + " $"); //deseneaza suma totala de bani (dolari)
            contents.DrawText(font, 14, pointInFile.X + 100, pointInFile.Y - 30, "Thank you for doing business with us!"); //deseneaza un mesaj de multumire
            page1.AddContents(contents); //adaugarea noului continut la pagina
            document.CreateFile("../factura.pdf"); //crearea fisierului final
            String path1 = @"../factura.pdf"; //directiva actuala a facturi (fisierului pdf)
            string path2 = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\factura.pdf"; //crearea unei noi directive pentru desktop
            if (!File.Exists(path2)) //verifica existenta unui fisier factura pe desktop
            {
                File.Move(path1, path2); //muta factura pe desktop
            }
            else
            {
                File.Delete(path2); //sterge factura deja existenta
                File.Move(path1, path2); //muta factura actuala pe desktop
            }
        }
    }
}
