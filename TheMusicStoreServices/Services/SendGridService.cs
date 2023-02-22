using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using TheMusicStoreRepositories.Interfaces;
using TheMusicStoreServices.Interfaces;
using TheMusicStoreServices.Models;

namespace TheMusicStoreServices.Services
{
    internal class SendGridService : ISendGridService
    {
        private IUserService userService;
        private IOrderRepository orderRepository;
        private readonly IConfiguration configuration;


        public SendGridService(IUserService userService, IConfiguration configuration, IOrderRepository orderRepository)
        {
            this.userService = userService;
            this.configuration = configuration;
            this.orderRepository = orderRepository;
        }

        public async void SendMail(int userId, int orderId)
        {
            var user = await userService.GetUserById(userId);
            var order = await orderRepository.GetOrderById(orderId);



            var apiKey = configuration.GetSection("AppSettings:SENDGRID_API_KEY").Value;
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("mak.alijevic@authoritypartners.com", "CarGear Shop");
            var subject = "CarGear Shop Order Receipt";
            var to = new EmailAddress(user.Email, "User");
            var plainTextContent = "";
            var htmlContent =
                "<h1 style='font-style:italic;'>You successfully made an order!</h1>" +
                "<h2> Your products will arrive in approximately 7 working days!</h2>" +
                "<br><strong>Total Price: $" + order.Total + ".00</strong>" +
                "<h1 style='font-style:italic;'>Thank you for your purchase!</h1>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);

        }
    }
}
