using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cskh.domain.HInvoiceAuto.Class
{
    public class generalInvoiceInfo
    {
        public string invoiceType { get;set;}
        public string templateCode { get; set; }
        public string invoiceSeries { get; set; }
        public string currencyCode { get; set; }
        public string adjustmentType { get; set; }
        public string adjustmentInvoiceType { get; set; }
        public string originalInvoiceId { get; set; }
        public string originalInvoiceIssueDate { get; set; }
        public string additionalReferenceDesc { get; set; }
        public string additionalReferenceDate { get; set; }
        public string adjustedNote { get; set; }
        public string originalInvoiceType { get; set; }
        public string originalTemplateCode { get; set; }
        public string paymentStatus { get; set; }
        public string cusGetInvoiceRight { get; set; }
        public string transactionUuid { get; set; }
            
        public string Body
        {
            get
            {

//                string body = @"""generalInvoiceInfo"": {
//                      ""invoiceType"": """ + invoiceType + @""",
//                      ""templateCode"": """ + templateCode + @""",
//                      ""invoiceSeries"": """ + invoiceSeries + @""",
//                      ""currencyCode"": """ + currencyCode + @""",
//                      ""adjustmentType"": """ + adjustmentType + @""",
//                      ""adjustmentInvoiceType"": """ + adjustmentInvoiceType + @""",
//                      ""originalInvoiceId"": """ + originalInvoiceId + @""",
//                      ""originalInvoiceIssueDate"": """ + originalInvoiceIssueDate + @""",
//                      ""additionalReferenceDesc"": """ + additionalReferenceDesc + @""",
//                      ""additionalReferenceDate"": """ + additionalReferenceDate + @""",
//                      ""adjustedNote"": """ + adjustedNote + @""",
//                      ""originalInvoiceType"": """ + originalInvoiceType + @""",
//                      ""originalTemplateCode"": """ + originalTemplateCode + @""",
//                      ""paymentStatus"": " + paymentStatus + @",
//                      ""cusGetInvoiceRight"": " + cusGetInvoiceRight + @",
//                      ""transactionUuid"":""" + transactionUuid + @"""
//                   }";
//                return body;
                string body = @"""generalInvoiceInfo"": {
                      ""invoiceType"": """ + invoiceType + @""",
                      ""templateCode"": """ + templateCode + @""",
                      ""invoiceSeries"": """ + invoiceSeries + @""",
                      ""currencyCode"": """ + currencyCode + @""",
                      ""adjustmentType"": """ + adjustmentType + @""",";
                if (adjustmentType != "1")
                {
                    body = body + @"
                      ""adjustmentInvoiceType"": """ + adjustmentInvoiceType + @""",
                      ""originalInvoiceId"": """ + originalInvoiceId + @""",
                      ""originalInvoiceIssueDate"": """ + originalInvoiceIssueDate + @""",
                      ""additionalReferenceDesc"": """ + additionalReferenceDesc + @""",
                      ""additionalReferenceDate"": """ + additionalReferenceDate + @""",
                      ""adjustedNote"": """ + adjustedNote + @""",";
                }
                body = body +  @"
                      ""paymentStatus"": " + paymentStatus + @",
                      ""cusGetInvoiceRight"": " + cusGetInvoiceRight + @",
                      ""transactionUuid"":""" + transactionUuid + @"""" + @"}";
                return body;
            }
        }
    }
    public class buyerInfo
    {
        public string buyerCode { get; set; }
        public string buyerName { get; set; }
        public string buyerLegalName { get; set; }
        public string buyerTaxCode { get; set; }
        public string buyerAddressLine { get; set; }
        public string buyerPhoneNumber { get; set; }
        public string buyerEmail { get; set; }
        public string buyerBankName { get; set; }
        public string buyerBankAccount { get; set; }
        

        public string Body
        {
            get
            {
                string body = @"""buyerInfo"": {
                        ""buyerCode"": """ + buyerCode + @""","
                        + (buyerName == null || buyerName == "" ? "" : @"""buyerName"": """ + buyerName + @""",")
                        + (buyerLegalName == null || buyerLegalName == "" ? "" : @"""buyerLegalName"": """ + buyerLegalName + @""",")
                        //@"""buyerLegalName"": """ + buyerLegalName + @""","
                        + (buyerTaxCode == null || buyerTaxCode == "" ? ""  : @"""buyerTaxCode"": """ + buyerTaxCode + @"""," ) 
                        + (buyerAddressLine == null || buyerAddressLine == "" ? ""  : @"""buyerAddressLine"": """ + buyerAddressLine + @""",")
                        + (buyerPhoneNumber == null || buyerPhoneNumber == "" ? ""  : @"""buyerPhoneNumber"": """ + buyerPhoneNumber + @""",")
                        + (buyerEmail == null || buyerEmail == "" ? "" : @"""buyerEmail"": """ + buyerEmail + @""",")
                        + (buyerBankName == null || buyerBankName == "" ? ""  : @"""buyerBankName"": """ + buyerBankName + @""",")
                        + @"""buyerBankAccount"": """ + buyerBankAccount + @"""
                   }";
                return body;
            }
        }
    }
    public class payments
    {
        public string paymentMethodName { get; set; }

        public string Body
        {
            get
            {
                string body = @"""payments"": [{
                        ""paymentMethodName"": """ + paymentMethodName + @"""
                   }]";
                return body;
            }
        }
    }
    public class taxBreakdowns
    {
        public double taxPercentage { get; set; }
        public double taxableAmount { get; set; }
        public double taxAmount { get; set; }

        public string Body
        {
            get
            {
                string body = @"""taxBreakdowns"": [{
                        ""taxPercentage"": """ + taxPercentage.ToString().Replace(",", ".") + @""",
                        ""taxableAmount"": """ + Math.Round(taxableAmount,0).ToString().Replace(",", ".") + @""",
                        ""taxAmount"": """ + Math.Round(taxAmount,0).ToString().Replace(",",".") + @"""
                   }]";

                return body;
            }
        }
    }
    public class itemInfo
    {
        public string lineNumber { get; set; }
        public string itemCode { get; set; }
        public string itemName { get; set; }
        public string unitName { get; set; }
        public double unitPrice { get; set; }
        public double quantity { get; set; }
        public string selection { get; set; }
        public double itemTotalAmountWithoutTax { get; set; }
        public string taxPercentage { get; set; }
        public double taxAmount { get; set; }
        public string discount { get; set; }
        public string discount2 { get; set; }
        public string itemDiscount { get; set; }
        public string itemNote { get; set; }
        public string batchNo { get; set; }
        public string expDate { get; set; }

        public string Body
        {
            get
            {
                string body = @"{
                        ""lineNumber"": """ + lineNumber + @""",
                        ""itemCode"": """ + itemCode + @""",
                        ""itemName"": """ + itemName + @""",
                        ""unitName"": """ + unitName + @""",
                        ""unitPrice"": """ + Math.Round(unitPrice,5).ToString().Replace(",", ".") + @""",
                        ""quantity"": """ + Math.Round(quantity, 5).ToString().Replace(",", ".") + @""",
                        ""selection"": """ + selection + @""",
                        ""itemTotalAmountWithoutTax"": """ + Math.Round(itemTotalAmountWithoutTax,0).ToString().Replace(",", ".") + @""",
                        ""taxPercentage"": """ + taxPercentage.ToString().Replace(",", ".") + @""",
                        ""taxAmount"": """ + Math.Round(taxAmount,0).ToString().Replace(",", ".") + @""",
                        ""discount"": """ + (discount == null ? "null" : discount) + @""",
                        ""discount2"": """ + (discount2 == null ? "null" : discount2) + @""",
                        ""itemDiscount"": """ + (itemDiscount == null ? "0" : itemDiscount) + @""",
                        ""itemNote"": """ + (itemNote == null ? "null" : itemNote) + @""",
                        ""batchNo"": """ + (batchNo == null ? "null" : batchNo) + @""",
                        ""expDate"": """ + (expDate == null ? "null" : expDate) + @"""
                   }";

                return body;
            }
        }
    }
    public class summarizeInfo
    {
        public double sumOfTotalLineAmountWithoutTax { get; set; }
        public double totalAmountWithoutTax { get; set; }
        public double totalTaxAmount { get; set; }
        public double totalAmountWithTax { get; set; }
        public double totalAmountWithTaxFrn { get; set; }
        public string totalAmountWithTaxInWords { get; set; }
        public string isTotalTaxAmountPos { get; set; }
        public string isTotalAmtWithoutTaxPos { get; set; }
        public double discountAmount { get; set; }
        public string Body
        {
            get
            { 
                string body = @"""summarizeInfo"": {
                        ""sumOfTotalLineAmountWithoutTax"": """ + Math.Round(sumOfTotalLineAmountWithoutTax, 5).ToString().Replace(",", ".") + @""",
                        ""totalAmountWithoutTax"": """ + Math.Round(totalAmountWithoutTax, 5).ToString().Replace(",", ".") + @""",                       
                        ""totalTaxAmount"": """ + Math.Round(totalTaxAmount, 0).ToString().Replace(",", ".") + @""",                        
                        ""totalAmountWithTax"": """ + Math.Round(totalAmountWithTax, 0).ToString().Replace(",", ".") + @""",
                        ""totalAmountWithTaxFrn"": """ + Math.Round(totalAmountWithTaxFrn, 0).ToString().Replace(",", ".") + @""",
                        ""totalAmountWithTaxInWords"": """ + totalAmountWithTaxInWords + @""",
                        ""isTotalTaxAmountPos"": """ + isTotalTaxAmountPos + @""",
                        ""isTotalAmtWithoutTaxPos"": """ + isTotalAmtWithoutTaxPos + @""",
                        ""discountAmount"": """ + Math.Round(discountAmount, 0).ToString().Replace(",", ".") + @"""
                   }";
                return body;
            }
        }
    }
    public class metadata
    {
        public string keyTag { get; set; }
        public string valueType { get; set; }
        public string keyLabel { get; set; }
        public string stringValue { get; set; }
        public string isRequired { get; set; }
        public string isSeller { get; set; }

        public string Body
        {
            get
            {
                string body = @"{
                        ""keyTag"": """ + keyTag + @""",
                        ""valueType"": """ + valueType + @""",
                        ""keyLabel"": """ + keyLabel + @""",
                        ""stringValue"": """ + stringValue + @""",
                        ""isRequired"": " + isRequired + @",
                        ""isSeller"": " + isSeller + @"
                    }";
                return body;
            }
        }
    }
    public class meterReading
    {
        public double meterName { get; set; }
        public double previousIndex { get; set; }
        public double currentIndex { get; set; }
        public string factor { get; set; }
        public double amount { get; set; }
        public string Body
        {
            get
            {
                string body = @"{
                        ""meterName"": """ + Math.Round(meterName, 5).ToString().Replace(",", ".") + @""",
                        ""previousIndex"": """ + Math.Round(previousIndex, 5).ToString().Replace(",", ".") + @""",
                        ""currentIndex"": """ + Math.Round(currentIndex, 5).ToString().Replace(",", ".") + @""",
                        ""factor"": """ + factor + @""",
                        ""amount"": """ + Math.Round(amount, 5).ToString().Replace(",", ".") + @"""                        
                   }";
                return body;
            }
        }
    }
    public class commonInvoiceInput
    {
        public generalInvoiceInfo generalInvoiceInfo { get;set;}
        public buyerInfo buyerInfo { get; set; }
        public payments payments { get; set; }
        public taxBreakdowns taxBreakdowns { get; set; }
        public List<itemInfo> itemInfos { get; set; }
        public summarizeInfo summarizeInfo { get; set; }
        public List<metadata> metadatas { get; set; }
        public List<meterReading> meterReadings { get; set; }
        public string Body
        {
            get
            {
                string sItemInfos = "";
                for (int i = 0; i < itemInfos.Count; i++)
                    if (sItemInfos == "")
                        sItemInfos = itemInfos[i].Body;
                    else
                        sItemInfos += "," + itemInfos[i].Body;

                string smetadatas = "";
                for (int i = 0; i < metadatas.Count; i++)
                    if (smetadatas == "")
                        smetadatas = metadatas[i].Body;
                    else
                        smetadatas += "," + metadatas[i].Body;

                string smeterReadings = "";
                for (int i = 0; i < meterReadings.Count; i++)
                    if (smeterReadings == "")
                        smeterReadings = meterReadings[i].Body;
                    else
                        smeterReadings += "," + meterReadings[i].Body;

                string body = @"{"
                        + generalInvoiceInfo.Body + ","
                        + buyerInfo.Body + ","
                        + payments.Body + ","
                        + summarizeInfo.Body + ","
                        + @"""itemInfo"": ["
                        + sItemInfos
                        + @"],"
                        + @"""metadata"": ["
                        + smetadatas
                        + @"],"
                        + @"""meterReading"": ["
                        + smeterReadings
                        + @"],"
                        + taxBreakdowns.Body
                 + "}";

                return body;
            }
        }
    }
    public class commonInvoiceInputs
    {
        public List<commonInvoiceInput> iCommonInvoiceInputs { get; set; }
        public string Body
        {
            get
            {
                string str = "";
                string body = "";
                for (int i = 0; i < iCommonInvoiceInputs.Count; i++)
                    if (str == "")
                        str = iCommonInvoiceInputs[i].Body;
                    else
                        str += "," + iCommonInvoiceInputs[i].Body;
                if (iCommonInvoiceInputs[0].generalInvoiceInfo.adjustmentType != "1")
                {
                    body = str;
                }
                else
                {
                    body = @"{
                    ""commonInvoiceInputs"": ["
                   + str
                   + "]}";
                }
                
                return body;
            }
        }
    }
//    public class commonInvoiceInputs
//    {
//        public List<commonInvoiceInput> iCommonInvoiceInputs { get; set; }
//        public string Body
//        {
//            get
//            {
//                string str = "";
//                for (int i = 0; i < iCommonInvoiceInputs.Count; i++)
//                    if (str == "")
//                        str = iCommonInvoiceInputs[i].Body;
//                    else
//                        str += "," + iCommonInvoiceInputs[i].Body;
//                string body = @"{
//                    ""commonInvoiceInputs"": ["
//                    + str
//                    + "]}";
//                return body;
//            }
//        }
//    }
}
