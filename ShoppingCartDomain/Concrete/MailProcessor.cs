using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.ModelBinding;
using ShoppingCartDomain.Abstract;
using ShoppingCartDomain.Entity;

namespace ShoppingCartDomain.Concrete
{
    public class MailProcessor:IOrderProcessor
    {

        public EmailSettings emailSettings;
        public string ErrorMessage { get; set; }

        public MailProcessor(EmailSettings emailSettings)
        {
            this.emailSettings = emailSettings;
        }
    
        public bool ProcessOrder(Cart cart,ShippingDetails detail)
        {
            using (var smtpClient=new SmtpClient())
            {
                smtpClient.EnableSsl = emailSettings.UseSsl;
                smtpClient.Host = emailSettings.ServerName;
                smtpClient.Port = emailSettings.ServerPort;
                smtpClient.UseDefaultCredentials = true;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.Credentials
                    = new NetworkCredential(emailSettings.Username,
                        emailSettings.Password);
                
                StringBuilder body = new StringBuilder()
                    .AppendLine("A new order has been submitted")
                    .AppendLine("---")
                    .AppendLine("Items:");

                foreach (var cartLine in cart.Lines)
                {
                    decimal value = cartLine.Quantity * cartLine.Product.Price;
                    body.AppendLine(
                        $"{cartLine.Quantity} {cartLine.Product.Name}s (Unit price: {cartLine.Product.Price:C}), total: {value}");
                }

                body.AppendLine($"Total order value: {cart.ComputeToSum()}")
                    .AppendLine($"---")
                    .AppendLine("Ship to: ")
                    .AppendLine(detail.Name)
                    .AppendLine(detail.Line1)
                    .AppendLine(detail.Line2 ?? "")
                    .AppendLine(detail.Line3 ?? "")
                    .AppendLine(detail.City)
                    .AppendLine(detail.State ?? "")
                    .AppendLine(detail.Country)
                    .AppendLine(detail.Zip)
                    .AppendLine("---")
                    .AppendFormat("Gift wrap: {0}", detail.GiftWrap ? "Yes": "No");

                MailMessage mailMessage=new MailMessage(emailSettings.MailFromAddress,emailSettings.MailToAddress,"New order submitted",body.ToString());
                mailMessage.BodyEncoding=Encoding.UTF8;

                if (emailSettings.WriteAsFile)
                {
                    mailMessage.BodyEncoding=Encoding.Default;
                }

                try
                {
                    smtpClient.Send(mailMessage);
                }
                catch(Exception ex)
                {
                    ErrorMessage = ex.Message;
                    return false;
                }

                return true;
            }
        }

    }
}