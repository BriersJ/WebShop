using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace WebShopForm.Business
{
    public class MailSender
    {
        public void SendMail(User user, int orderId, double totalPrice)
        {
            //try
            //{
            var client = MakeSMTP();
            var message = MakeMessage(user, orderId, totalPrice);
            client.Send(message);
            //}
            //catch
            //{

            //}
        }

        private MailMessage MakeMessage(User user, int orderId, double totalPrice)
        {
            var message = new MailMessage("webshopjonas@gmail.com", user.Email)
            {
                Subject = "Order online guitar shop",
                Body = "Your order with id " + totalPrice + " has been received successfully." +
                            Environment.NewLine + "After a payment of " + totalPrice + " on Bitcoin adress[put butcoin address here] we will  continue the shipment of the products." +
                            Environment.NewLine + "Thank you for yout trust!"
            };
            return message;
        }

        private SmtpClient MakeSMTP()
        {
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("webshopjonas@gmail.com", "123Test456")
            };
            return smtp;
        }
    }
}