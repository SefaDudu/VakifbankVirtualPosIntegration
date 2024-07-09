using Microsoft.AspNetCore.Mvc;
using VakifbankVirtualPosIntegration.Models;

namespace VakifbankVirtualPosIntegration.Controllers;

public class PaymentController : Controller
{
    // GET
     private readonly string paymentUrl = "https://www.vakifbank.com.tr/sanal-pos"; // Gerçek URL'yi buraya ekleyin

        // GET: Payment
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> ProcessPayment(PaymentModel model)
        {
            model.SuccessUrl = "https://yourwebsite.com/Payment/Success";
            model.FailUrl = "https://yourwebsite.com/Payment/Fail";

            var postData = new Dictionary<string, string>
            {
                { "merchant_id", model.MerchantId },
                { "merchant_password", model.MerchantPassword },
                { "terminal_id", model.TerminalId },
                { "order_id", model.OrderId },
                { "amount", model.Amount.ToString() },
                { "currency_code", model.CurrencyCode },
                { "secure_type", "NON3D" },
                { "success_url", model.SuccessUrl },
                { "fail_url", model.FailUrl }
            };

            using (var client = new HttpClient())
            {
                var content = new FormUrlEncodedContent(postData);
                var response = await client.PostAsync(paymentUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    // Başarılı yanıtı işleyin
                    return Content(responseContent);
                }
                else
                {
                    // Hata yönetimi
                    return Content("Ödeme işlemi sırasında bir hata oluştu.");
                }
            }
        }

        public ActionResult Success()
        {
            // Başarılı ödeme işlemleri burada işlenir
            return View();
        }

        public ActionResult Fail()
        {
            // Başarısız ödeme işlemleri burada işlenir
            return View();
        }
}