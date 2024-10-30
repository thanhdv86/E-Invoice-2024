using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cskh.domain.HInvoiceAuto.Class
{
    public class result
    {
        public string supplierTaxCode { get; set; }
        public string invoiceNo { get; set; }
        public string transactionID { get; set; }
        public string reservationCode { get; set; }
    }
    public class createInvoiceOutputs
    {
        public string transactionUuid { get; set; }
        public string errorCode { get; set; }
        public string description { get; set; }
        public result result { get; set; }
    }
    public class lstMapError
    {
        public string msg { get; set; }public string invoiceSeri { get; set; }
        public string errorCode { get; set; }
    }
    public class InvoiceOutputs
    {
        public List<createInvoiceOutputs> createInvoiceOutputs { get; set; }
        public List<lstMapError> lstMapError { get; set; }
        public int totalSuccess { get; set; }
        public int totalFail { get; set; }
        public object errorCode { get; set; }
        public object description { get; set; }
        public Result result { get; set; }
    }
    
    public class Result
    {
        public string supplierTaxCode { get; set; }
        public string invoiceNo { get; set; }
        public string transactionID { get; set; }
        public string reservationCode { get; set; }
        public string transactionUuid { get; set; }
    }

}
