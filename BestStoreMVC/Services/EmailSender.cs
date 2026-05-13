namespace BestStoreMVC.Services
{

    using Mailtrap;
    using Mailtrap.Emails.Requests;
    using Mailtrap.Emails.Responses;

    public class EmailSender
    {
        public static async Task SendEmail(string senderName, string senderEmail, string toName, string toEmail,
            string subject, string textContent)
        {
            try
            {
                var apiToken = "4f2102d771bd378bd496bf3ec84f9d6a";
                using var mailtrapClientFactory = new MailtrapClientFactory(apiToken);
                IMailtrapClient mailtrapClient = mailtrapClientFactory.CreateClient();
                SendEmailRequest request = SendEmailRequest
                    .Create()
                    .From("hello@demomailtrap.co", "Mailtrap Test")
                    .To("jkeisker@protonmail.com")
                    .Subject("You are awesome!")
                    .Category("Integration Test")
                    .Text("Congrats for sending test email with Mailtrap!");
                SendEmailResponse? response = await mailtrapClient
                    .Email()
                    .Send(request);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while sending email: {0}", ex);
            }
        }


        //public static void SendEmail(string senderName, string senderEmail, string toName, string toEmail,
        //    string subject, string textContent)
        //{
        //    var apiInstance = new TransactionalEmailsApi();
        //    SendSmtpEmailSender Email = new SendSmtpEmailSender(senderName, senderEmail);
        //    SendSmtpEmailTo smtpEmailTo = new SendSmtpEmailTo(toEmail, toName);
        //    List<SendSmtpEmailTo> To = new List<SendSmtpEmailTo>();
        //    To.Add(smtpEmailTo);

        //    try
        //    {
        //        var sendSmtpEmail = new SendSmtpEmail(Email, To, null, null, null, textContent, subject);
        //        CreateSmtpEmail result = apiInstance.SendTransacEmail(sendSmtpEmail);
        //        Console.WriteLine("Email Sender OK: \n" + result.ToJson());
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Email Sender Failure: \n" + ex.Message);
        //    }
        //}
    }
}
