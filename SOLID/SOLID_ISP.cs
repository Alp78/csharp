/*
Interface Segregation: build interfaces whose methods are strictly needed by classes
--> small specific interfaces rather than large general
--> "don't pay for what you don't need"
--> small interfaces can be combined on a need-to basis to create classes
*/

using System;
using System.Collections.Generic;

namespace DesignPatterns
{
    public class Document
    {

    }

    // Interface Segregation: instead of having a general interface, divide it in small specific ones
    public interface IMachine
    {
        void Print(Document d);
        void Scan(Document d);
        void Fax(Document d);
    }

    // segregating the Print method to its own interface
    public interface IPrint
    {
        void Print(Document d);
    }

    // segregating the Scan method to its own interface
    public interface IScan
    {
        void Scan(Document d);
    }

    // segregating the Fax method to its own interface
    public interface IFax
    {
        void Fax(Document d);
    }

    // class that implements IMachine and uses all its methods
    public class MultiFunctionPrinter : IMachine
    {
        public void Fax(Document d)
        {
           
        }

        public void Print(Document d)
        {
            
        }

        public void Scan(Document d)
        {
            
        }
    }

    // class that has only 2 methods of IMachine: better create smaller interfaces and combine them 
    public class OldPrinter : IPrint, IFax //...
    {
        public void Fax(Document d)
        {
           
        }

        public void Print(Document d)
        {
            
        }
    }

    // a combination of interfaces to create a new interface..
    public interface IScanPrint : IScan, IPrint { };

    // class that implements the combined interface IScanPrint implementing itself IScan and IPrint
    // Decorator pattern: delegate calls to inner variables rather than base methods
    public class PrinterScanner : IScanPrint
    {
        private IPrint printer;
        private IScan scanner;

        // ctor to initialize variables
        public PrinterScanner(IPrint printer, IScan scanner)
        {
            this.printer = printer ?? throw new ArgumentNullException(paramName: nameof(printer));
            this.scanner = scanner ?? throw new ArgumentNullException(paramName: nameof(scanner));
        }

        // delegation of calls to Print and Scan to inner printer and scanner variables
        public void Print(Document d)
        {
            printer.Print(d);
        }

        public void Scan(Document d)
        {
            scanner.Scan(d);
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            
            Console.ReadKey();
        }
    }
}
