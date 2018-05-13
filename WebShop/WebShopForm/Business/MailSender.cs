using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace WebShopForm.Business
{
    /// <summary>
    /// This class is responsible for all E-mail messaging
    /// </summary>
    public class MailSender
    {
        /// <summary>
        /// Send a confirmation E-mail to a certain <code>User</code>.
        /// </summary>
        /// <param name="user">The <code>User</code> who should receive a mail</param>
        /// <param name="orderId">The order ID</param>
        /// <param name="totalPrice">The total price that should be payed</param>
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
            var message = new MailMessage("webshopjonas@gmail.com", user.Email)
            {
                Subject = "Order online guitar shop",
                Body = "Your order with id " + orderId + " has been received successfully." +
                            Environment.NewLine + "After a payment of " + totalPrice + " on bank account number BE91 5612 1236 7895 we will  continue the shipment of the products." +
                            Environment.NewLine + "Please add your order id as a payment reference." +
                            Environment.NewLine + "Thank you for your trust!"
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