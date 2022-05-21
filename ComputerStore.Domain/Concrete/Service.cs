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



                StringBuilder body = new StringBuilder();
                 //.AppendLine("Новый заказ обработан.")
                 //.AppendLine("---")
                 //.AppendLine("Товары:");


                foreach (var line in cart.Lines)
                {
                    var subtotal = line.Pprice * line.Quantity;
                    body.AppendFormat("{0} x {1} (итого: {2:c}\n",
                       line.Quantity, line.Nname, subtotal);
                    body.AppendLine("), ");
                }
                body.AppendFormat("Общая стоимость: {0:c}", cart.ComputeTotalValue());

                string Name = "Имя: " + shippingDetails.Name;
                string Surname = "Фамилия: " + shippingDetails.Surname;
                string Patronomic = "Отчество: " + shippingDetails.Partonomic;
                string Phone = "Номер телефона: " + shippingDetails.Phone;
                string Country = "Страна: " + shippingDetails.Country;
                string City = "Город: " + shippingDetails.City;
                string Street = "Улица: " + shippingDetails.Street;
                string House = "Дом: " + shippingDetails.House;
                string Flat = "Квартира: " + shippingDetails.Flat;
                string HouseBuilding = "Корпус: " + shippingDetails.HouseBuilding;
                string Floor = "Этаж: " + shippingDetails.Floor;

                bodyBuilder.TextBody = body.ToString();
                //message.Body = bodyBuilder.ToMessageBody(); // тело сообщения
                message.Body = new BodyBuilder() { HtmlBody =
                   //"<div style=\"color: green;\">Сообщение от MailKit</div>" + shippingDetails.Name + "<div style=\"color: green;\">Сообщение от MailKit</div>"
                   "<img src = https://imgur.com/zbfOXgD.jpg>" +
                   "<div style=\"border: 2px; border: solid; border-color: gray; border-radius: 5px; width: 596px;\"> <div style =\"font-weight: bold; font-size: 20px; text-align: center;\">Новый заказ обработан</div><br>" +
                   body  + "<hr>"
                   + "<br>" + Name
                   + "<br>" + Surname
                   + "<br>" + Patronomic
                   + "<br>" + Phone
                   + "<br>" + Country
                   + "<br>" + City
                   + "<br>" + Street
                   + "<br>" + House
                   + "<br>" + Flat
                   + "<br>" + HouseBuilding
                   + "<br>" + Floor
                   + "</div>" +
                   "<br><div style=\"color: #adadad;\">Copyright © 2022 Computer Store std. <br>Все права защищены<br>Большая красная, 55.</div>" 






                }.ToMessageBody(); //тело сообщения (так же в формате HTML)
                

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
