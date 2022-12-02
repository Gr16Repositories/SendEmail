// The 'From' and 'To' fields are automatically populated with the values specified by the binding settings.
//
// You can also optionally configure the default From/To addresses globally via host.config, e.g.:
//
// {
//   "sendGrid": {
//      "to": "user@host.com",
//      "from": "Azure Functions <samples@functions.com>"
//   }
// }
using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using SendGrid.Helpers.Mail;
using Microsoft.Extensions.Logging;
using SendEmail.Models;

namespace SendEmail
{
    public class EmailSender
    {
        [FunctionName("EmailSender")]
        [return: SendGrid(ApiKey = "SendGridKey", From = "anton.ortlund@gmail.com")]
        public SendGridMessage Run([QueueTrigger("mailqueue", Connection = "AzureWebJobsStorage")] Email newEmail, ILogger log)
        {
            log.LogInformation($"C# Queue trigger function processed subscription: {newEmail.SubscriberName}");

            SendGridMessage message = new SendGridMessage()
            {
                Subject = $"Thanks for your subscribing with us (#{newEmail.SubscriberName})!"
            };

            message.AddContent("text/html", $"<h1> Hello {newEmail.SubscriberName},</h1> <p>your subscription ({newEmail.SubscriptionTypeName}) is being processed!</p>");
            message.AddTo(newEmail.SubscriberEmail, newEmail.SubscriberName);
            return message;
        }
    }
   
}
