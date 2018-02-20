using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace getAddress.Sdk.Api.Responses
{
    public class Invoice
    {
        private List<InvoiceLine> _lines = new List<InvoiceLine>();

        public DateTime Date { get; }
        public string Number { get; }
        public InvoiceAddress Address { get;  }
        public decimal Total { get; }
        public decimal Tax { get; }
        public string Pdf { get; }
        public IReadOnlyCollection<InvoiceLine> Lines { get{ return new ReadOnlyCollection<InvoiceLine>(_lines); }  }
        
        internal void AddLine(InvoiceLine invoiceLine){
            _lines.Add(invoiceLine);
        }


        internal static Invoice Blank(string number){

            var address = InvoiceAddress.Blank();
            var invoice=  new Invoice(DateTime.MinValue, number, 0, 0, string.Empty, address);
            return invoice;
        }

        internal Invoice(DateTime date, string number
            ,decimal total,decimal tax,string pdf, InvoiceAddress address)
        {
            Date = date;
            Number = number;
            Total = total;
            Tax = tax;
            Pdf = pdf;
            Address = address;
            
        }

    }
    public class InvoiceLine{
        public int Quantity { get; }
        public string Details { get; }
        public decimal Price { get; }
        public decimal Subtotal { get; }

        internal InvoiceLine(int quantity, string details, decimal price, decimal subtotal)
        {
            Quantity = quantity;
            Details = details;
            Price = price;
            Subtotal = subtotal;
        }
    }

    public class InvoiceAddress{

        internal static InvoiceAddress Blank(){
            return new InvoiceAddress(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty);
        }
        public string Line1 { get; }
        public string Line2 { get; }
        public string Line3 { get; }
        public string Line4 { get; }
        public string Line5 { get; }
        public string Line6 { get; }

        internal InvoiceAddress(string line1,string line2, string line3, 
            string line4, string line5, string line6)
        {
            Line1 = line1 ?? string.Empty;
            Line2 = line2 ?? string.Empty;
            Line3 = line3 ?? string.Empty;
            Line4 = line4 ?? string.Empty;
            Line5 = line5 ?? string.Empty;
            Line6 = line6 ?? string.Empty;
        }
    }
}


