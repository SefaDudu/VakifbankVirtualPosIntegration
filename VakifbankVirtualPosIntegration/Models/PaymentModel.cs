namespace VakifbankVirtualPosIntegration.Models;

public class PaymentModel
{
    public string MerchantId { get; set; }
    public string MerchantPassword { get; set; }
    public string TerminalId { get; set; }
    public string OrderId { get; set; }
    public decimal Amount { get; set; }
    public string CurrencyCode { get; set; } = "949"; // Türk Lirası için
    public string SuccessUrl { get; set; }
    public string FailUrl { get; set; }
}