using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace WebShopForm.Business
{
    public class MailSender
    {
        public void SendMail(User user, int orderId, double totalPrice)
        {
            try
            {
                var client = MakeSMTP();
                var message = MakeMessage(user, orderId, totalPrice);
                client.Send(message);
            }
            catch
            {

            }
        }

        private MailMessage MakeMessage(User user, int orderId, double totalPrice)
        {
            MailMessage mailMessage = new MailMessage("csharp6itn2018@outlook.com", user.Email);
            mailMessage.Subject = "Order online guitar shop";
            mailMessage.Body = "Your order with id " + totalPrice + " has been received successfully." +
                            Environment.NewLine + "After a payment of " + totalPrice + " on Bitcoin adress[put butcoin address here] we will  continue the shipment of the products." +
                            Environment.NewLine + "Thank you for yout trust!";
            return mailMessage;
        }

        private SmtpClient MakeSMTP()
        {
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = "smtp-mail.outlook.com";
            smtpClient.Port = 587;
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new System.Net.NetworkCredential("csharp6itn2018@outlook.com", "123Test456");
            return smtpClient;
        }
    }
}