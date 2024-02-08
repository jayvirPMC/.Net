using System;
using System.Linq;
using System.Xml.Linq;


public class Program
{
    static void Main(string[] arg) {
        XDocument xmlDoc = XDocument.Load("books.xml");
        // Console.WriteLine("jay");
        Program.selectAll(xmlDoc);
        // Program.addElement(xmlDoc);
        // Program.removeElement(xmlDoc);
        // Program.selectPer(xmlDoc);
    }

    public static void selectAll(XDocument xmlDoc) {
        var Books = from books in xmlDoc.Descendants("book")
                    select books;
        
        foreach (var book in Books)
        {
            Console.WriteLine("Title: " + book.Element("title").Value + " Author: " + book.Element("author").Value + " Genre: " + book.Element("genre").Value + " Year: " + book.Element("year").Value);
        }
    }
    public static void selectPer(XDocument xmlDoc) {
        var Book = from book in xmlDoc.Descendants("book")
                    where (string)book.Element("author") == "Arundhati Roy"
                    select book;

        Console.WriteLine("\n");

        foreach (var book in Book)
        {
            Console.WriteLine("Title: " + book.Element("title").Value + " Author: " + book.Element("author").Value + " Genre: " + book.Element("genre").Value + " Year: " + book.Element("year").Value);
        }
    }

    public static void addElement(XDocument xmlDoc) {
        xmlDoc.Root.Add(
            new XElement("book",
                new XElement("title", "Exprement with Truth"),
                new XElement("author", "gandhi"),
                new XElement("genre", "biography"),
                new XElement("year", "1950")
            )
        );
        xmlDoc.Save("books.xml");
        Console.WriteLine("inserted success\n");
    }
    public static void removeElement(XDocument xmlDoc) {
        var bookToRemove = xmlDoc.Descendants("book").Where(book => (string)book.Element("title") == "The Guide").FirstOrDefault();

        xmlDoc.Save("books.xml");
        Console.WriteLine("remove success\n");
    }

}