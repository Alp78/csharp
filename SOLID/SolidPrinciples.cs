/* 
Single Responsibility: each class has only 1 responsibility
Open/Closed: class open to extension, but closed for modification
Liskov Substitution: substitution of an class by its sublcass should work
Interface Segregation: many specific interfaces are better than one general
Dependency Inversion: class should depend on abstract class, not implementation details
*/


using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace SOLID
{

    // Single Responsibility: Invoice only calculate tax and amounts
    // but has several methods for it - still just one responsibility
    public class Invoice
    {
        public decimal Subtotal { get; set; }
        public decimal TaxRate { get; set; }

        public decimal CalculateTax()
        {
            return Subtotal*TaxRate/100;
        }

        public decimal CalculateTotal()
        {
            return Subtotal + CalculateTax();
        }       

    }

    // validate invoice
    // Open/closed: instead of writing a Validate class that could be internally
    // modified to e.g. add a method to validate something new (extension with modification)
    // we create an abstract class and add each time a new specific validation
    // as new inherited class so no class is modified, but a new one created (extension without modification)
    
    // abstract Validator class
    public abstract class Validator
    {
        public abstract bool Validate(Invoice invoice);
    }

    // InvoiceSubtotalValidator inherited from Validator
    public class InvoiceSubtotalValidator : Validator
    {
        public override bool Validate(Invoice invoice)
        {
            return invoice.Subtotal >= 0;
        }
    }

    // InvoiceTaxRateValidator inherited from Validator
    public class InvoiceTaxRateValidator : Validator
    {
        public override bool Validate(Invoice invoice)
        {
            return invoice.TaxRate >= 0;             
        }
    }

    // InvoiceTaxValidator inherited from Validator
    public class InvoiceTaxValidator : Validator
    {
        public override bool Validate(Invoice invoice)
        {
            return invoice.CalculateTax() >= 0;             
        }
    }
    
    // InvoiceTaxValidator inherited from Validator
    public class InvoiceTotalValidator : Validator
    {
        public override bool Validate(Invoice invoice)
        {
            return invoice.CalculateTotal() >= 0;             
        }
    }
    /* 
    // InvoiceValidator checks if all validators are true
    // we can add any new validator: no need to change the code
    // --> Open/Closed principle
    public class InvoiceValidator
    {
        // declare a list of validators
        private List<Validator> _validators;

        // ctor initializing the list of validators
        public InvoiceValidator (List<Validator> validators)
        {
            _validators = validators;
        }

        // ValidateInvoice returns true if all validators are true
        public bool Validate(Invoice invoice)
        {
            return _validators.ALL(v => v.Validate(invoice));
        }
    }
    */

    // InvoiceModifier
    // Liskov substituation: a ComplexInvoice could be passed to this class
    // without the code breaking --> one choice is to create a new ComplexInvoice
    // class instead of inherit from Invoice --> no Liskov substitution at all
    public class InvoiceModifier {
        private Invoice _invoice;

        public InvoiceModifier (Invoice invoice)
        {
            _invoice = invoice;
        }

        public void SetSubtotal(decimal subtotal)
        {
            _invoice.Subtotal = subtotal;
        }

        public void SetTaxRate(decimal taxRate)
        {
            _invoice.TaxRate = taxRate;
        }

        public Invoice GenerateInvoice()
        {
            return _invoice;
        }       

    }

    // CompexInvoice: add second layer of tax
    // Liskov Substitution: instead of inherit the ComplexInvoice from
    // Invoice, we create a new one with same parameters
    // so the principle is not violated with Modifiers methods
    public class ComplexInvoice
    {
        // same as Invoice
        public decimal Subtotal { get; set; }
        public decimal TaxRate { get; set; }

        // new specific property of CompleXInvoice     
        public decimal SecondTaxRate { get; set; }

        // custom CalculateTax() method
        public decimal CalculateTax() {
            return (Subtotal*TaxRate/100) + (Subtotal*SecondTaxRate/100);
        }

        public decimal CalculateTotal()
        {
            return Subtotal + CalculateTax();
        }           

    }

    // ComplexInvoiceModifier: new modifier class for ComplexInvoice
    public class ComplexInvoiceModifier {
        private ComplexInvoice _complexInvoice;

        public ComplexInvoiceModifier (ComplexInvoice complexInvoice)
        {
            _complexInvoice = complexInvoice;
        }

        public void SetSubtotal(decimal subtotal)
        {
            _complexInvoice.Subtotal = subtotal;
        }

        public void SetTaxRate(decimal taxRate)
        {
            _complexInvoice.TaxRate = taxRate;
        }

        public void SetSecondTaxRate(decimal taxRate)
        {
            _complexInvoice.SecondTaxRate = taxRate;
        }

        public ComplexInvoice GenerateComplexInvoice()
        {
            return _complexInvoice;
        }       
    }

    // Interface: can apply to any of the printers
    // Interface Segregation: we should never force any class to implement
    // that it doesn't use
    public interface IInvoicePrinter
    {
        void Print(Invoice invoice);
        void PrintComplex(ComplexInvoice complexInvoice);

    }

    // PrintingSystem can take whatever class that satisfies IInvoicePrinter
    // instead of taking only printers that have specific members
    // --> Dependency Inversion 
    public class PrintingSystem
    {
        private IInvoicePrinter _invoicePrinter;

        public PrintingSystem(IInvoicePrinter invoicePrinter)
        {
            _invoicePrinter = invoicePrinter;
        }

        public void Print(Invoice invoice)
        {
            _invoicePrinter.Print(invoice);
        }
    }

    // InvoicePrinter implements IInvoicePrinter interface
    public class InvoicePrinter : IInvoicePrinter
    {
        public void Print(Invoice invoice)
        {
            Console.WriteLine("Subtotal: {0}", invoice.Subtotal);
            Console.WriteLine("Tax Rate: {0}", invoice.TaxRate);
            Console.WriteLine("Tax Amount: {0}", invoice.CalculateTax());
            Console.WriteLine("Total Amount: {0}", invoice.CalculateTotal());
        }

        public void PrintComplex(ComplexInvoice complexInvoice)
        {
            Console.WriteLine("Subtotal: {0}", complexInvoice.Subtotal);
            Console.WriteLine("Tax Rate: {0}", complexInvoice.TaxRate);
            Console.WriteLine("Second Tax Rate: {0}", complexInvoice.SecondTaxRate);
            Console.WriteLine("Tax Amount: {0}", complexInvoice.CalculateTax());
            Console.WriteLine("Total Amount: {0}", complexInvoice.CalculateTotal());
        }

    }

    class Program
    {
       
        static void Main(string[] args)
        {
            var invoice = new Invoice();
            invoice.TaxRate = (decimal)15;
            invoice.Subtotal = 500;     

            var invoicePrinter = new InvoicePrinter();
            invoicePrinter.Print(invoice);

        }
    }
}