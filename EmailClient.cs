namespace Job_Scraper;

public static class EmailClient
{
    public static void SendJobPosts(string body)
    {
#pragma warning disable CA1416
        var fromEmail = CredentialManager.ReadCredential(FromEmail);
        var toEmail = CredentialManager.ReadCredential(ToEmail);
#pragma warning restore CA1416

        var smtp = new SmtpClient
        {
            Host = Host,
            Port = Port,
            EnableSsl = true,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential(fromEmail?.UserName, fromEmail?.Password)
        };

        if (fromEmail?.UserName != null && toEmail?.UserName != null)
        {
            using var message = new MailMessage(fromEmail.UserName, toEmail.UserName);
            message.Subject = Subject;
            message.Body = body;
            message.IsBodyHtml = true;
            smtp.Send(message);
        }

        Console.WriteLine(Sent);
    }
}
