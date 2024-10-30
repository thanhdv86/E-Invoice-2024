using System;
using System.Collections.Generic;
using System.Text;

namespace cskh.domain.HInvoiceAuto.SInvoice
{
    public class InvoiceInfo
    {
        public string uuId { get; set; }
        public string templateCode { get; set; }
        public string invoiceSeries { get; set; }
        public string invoiceIssuedDate { get; set; }
        public string invoiceType { get; set; }
        public string currencyCode { get; set; }
        public string adjustmentType { get; set; }
        public string paymentStatus { get; set; }
        public string paymentType { get; set; }
        public string paymentTypeName { get; set; }
        public string cusGetInvoiceRight { get; set; }
        public string buyerIdNo { get; set; }
        public string buyerIdType { get; set; }
        public string invoiceNote { get; set; }
        public string adjustmentInvoiceType { get; set; }
        public string originalInvoiceId { get; set; }
        public string originalInvoiceIssueDate { get; set; }
        public string additionalReferenceDesc { get; set; }
        public string additionalReferenceDate { get; set; }
    }

    public class BuyerInfo
    {
        public string buyerName { get; set; }
        public string buyerLegalName { get; set; }
        public string buyerTaxCode { get; set; }
        public string buyerAddressLine { get; set; }
        public string buyerPhoneNumber { get; set; }
        public string buyerEmail { get; set; }
        public string buyerIdNo { get; set; }
        public string buyerIdType { get; set; }
    }

    public class SellerInfo
    {
        public string sellerLegalName { get; set; }
        public string sellerTaxCode { get; set; }
        public string sellerAddressLine { get; set; }
        public string sellerPhoneNumber { get; set; }
        public string sellerEmail { get; set; }
        public string sellerBankName { get; set; }
        public string sellerBankAccount { get; set; }
    }

    public class ItemInfo
    {
        public string lineNumber { get; set; }
        public string itemCode { get; set; }
        public string itemName { get; set; }
        public string unitName { get; set; }
        public string unitPrice { get; set; }
        public string quantity { get; set; }
        public string itemTotalAmountWithoutTax { get; set; }
        public string taxPercentage { get; set; }
        public string taxAmount { get; set; }
        public string discount { get; set; }
        public string itemDiscount { get; set; }
        public string adjustmentTaxAmount { get; set; }
        public string isIncreaseItem { get; set; }
    }

    public class ZipFileResponse
    {
        public string errorCode { get; set; }
        public string description { get; set; }
        public string fileName { get; set; }
        public byte[] fileToBytes { get; set; }
        public bool paymentStatus { get; set; }
    }

    public class GetFileRequest
    {
        public string invoiceNo { get; set; }
        public string fileType { get; set; }
        public string strIssueDate { get; set; }
        public string additionalReferenceDesc { get; set; }
        public string additionalReferenceDate { get; set; }
        public string pattern { get; set; }
        public string transactionUuid { get; set; }
    }

    public class PDFFileResponse
    {
        public string errorCode { get; set; }
        public string description { get; set; }
        public string fileName { get; set; }
        public byte[] fileToBytes { get; set; }
    }

    public class SummarizeInfo
    {
        public string sumOfTotalLineAmountWithoutTax { get; set; }
        public string totalAmountWithoutTax { get; set; }
        public string totalTaxAmount { get; set; }
        public string totalAmountWithTax { get; set; }
        public string totalAmountWithTaxInWords { get; set; }
        public string discountAmount { get; set; }
        public string settlementDiscountAmount { get; set; }
        public string taxPercentage { get; set; }
    }
    public class TaxBreakdowns
    {
        public string taxPercentage { get; set; }
        public string taxableAmount { get; set; }
        public string taxAmount { get; set; }
    }
    public class responseGetAccessToken
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public string refresh_token { get; set; }
        public string expires_in { get; set; }
        public string scope { get; set; }
        public string iat { get; set; }
        public string invoice_cluster { get; set; }
        public string type { get; set; }
        public string jti { get; set; }

    }


    public class requestGetInvoice
    {
        public string startDate { get; set; }
        public string endDate { get; set; }
        public string invoiceType { get; set; }
        public int rowPerPage { get; set; }
        public int pageNum { get; set; }
        public object templateCode { get; set; }
        public string invoiceNo { get; set; }
    }

    
public class InvoiceResults
{
    public object errorCode { get; set; }
    public object description { get; set; }
    public int totalRows { get; set; }
    public Invoice[] invoices { get; set; }
    public int? code { get; set; }
    public string message { get; set; }
    public string data { get; set; }
}
 


public class Invoice
{
    public int invoiceId { get; set; }
    public string invoiceType { get; set; }
    public string adjustmentType { get; set; }
    public string templateCode { get; set; }
    public string invoiceSeri { get; set; }
    public string invoiceNumber { get; set; }
    public string invoiceNo { get; set; }
    public string currency { get; set; }
    public float total { get; set; }
    public object issueDate { get; set; }
    public DateTime issueDateStr { get; set; }
    public int state { get; set; }
    public object requestDate { get; set; }
    public object description { get; set; }
    public string buyerIdNo { get; set; }
    public int stateCode { get; set; }
    public object subscriberNumber { get; set; }
    public int paymentStatus { get; set; }
    public object viewStatus { get; set; }
    public object downloadStatus { get; set; }
    public int exchangeStatus { get; set; }
    public object numOfExchange { get; set; }
    public object createTime { get; set; }
    public object contractId { get; set; }
    public object contractNo { get; set; }
    public string supplierTaxCode { get; set; }
    public string buyerTaxCode { get; set; }
    public string totalBeforeTax { get; set; }
    public float taxAmount { get; set; }
    public object taxRate { get; set; }
    public string paymentMethod { get; set; }
    public object paymentTime { get; set; }
    public object customerId { get; set; }
    public object no { get; set; }
    public string paymentStatusName { get; set; }
    public string buyerName { get; set; }
    public object transactionUuid { get; set; }
}


}
