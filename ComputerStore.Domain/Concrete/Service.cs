using Microsoft.Extensions.Logging;
using MimeKit;
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using ComputerStore.Domain.Abstract;
using ComputerStore.Domain.Entities;

namespace ComputerStore.Domain.Concrete
{
    public class Service
    {
        public void SendEmailCustom(Cart cart, ShippingDetails shippingDetails)
        {
            try
            {
                MimeMessage message = new MimeMessage();
                message.From.Add(new MailboxAddress("ComputerStore", "computerstoreee@gmail.com"));
                message.To.Add(new MailboxAddress("artemzaripov2002az@mail.ru", "artemzaripov2002az@mail.ru"));
                message.Subject = "Новый заказ"; //тема сообщения

                var bodyBuilder = new BodyBuilder();
               //  bodyBuilder.TextBody = test;



                StringBuilder body = new StringBuilder()
                 .AppendLine("Новый заказ обработан.")
                 .AppendLine("---")
                 .AppendLine("Товары:");


                foreach (var line in cart.Lines)
                {
                    var subtotal = line.Pprice * line.Quantity;
                    body.AppendFormat("{0} x {1} (итого: {2:c}",
                       line.Quantity, line.Nname, subtotal);
                    body.AppendLine(")");
                }
                body.AppendFormat("Общая стоимость: {0:c}", cart.ComputeTotalValue())
                  .AppendLine("")
                  .AppendLine("---")
                  .AppendLine("Доставка:")
                  .AppendLine("Имя: " + shippingDetails.Name)
                  .AppendLine("Фамилия: " + shippingDetails.Surname)
                  .AppendLine("Страна: " + shippingDetails.Country)
                  .AppendLine("Город: " + shippingDetails.City)
                  .AppendLine("Улица: " + shippingDetails.Street)
                  .AppendLine("Дом: " + shippingDetails.House)
                  .AppendLine("Квартира: " + shippingDetails.Flat ?? "не указано")
                  .AppendLine("Корпус: " + shippingDetails.HouseBuilding ?? "не указано")
                  .AppendLine("Этаж: " + shippingDetails.Floor ?? "не указано");


                bodyBuilder.TextBody = body.ToString(); 
                message.Body = bodyBuilder.ToMessageBody(); // тело сообщения

                using (MailKit.Net.Smtp.SmtpClient client = new MailKit.Net.Smtp.SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 465, true); //либо использум порт 465
                    client.Authenticate("computerstoreee@gmail.com", "ComputerStore"); //логин-пароль от аккаунта
                    client.Send(message);

                    client.Disconnect(true);
                   
                }
            }
            catch
            {

            }
        }
    }
}
