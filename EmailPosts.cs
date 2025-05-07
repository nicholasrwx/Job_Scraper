using static Meziantou.Framework.Win32.CredentialManager;

namespace Job_Scraper;

public static class EmailPosts
{
    public static void SendJobPosts(List<string> jobPosts)
    {
        
        var body = string.Empty;

        jobPosts.ForEach(job => body += $"{job}<br>");

#pragma warning disable CA1416
        var fromEmail = ReadCredential("JOB_EMAIL");
        var toEmail = ReadCredential("EMAIL");
#pragma warning restore CA1416
        
        var smtp = new SmtpClient
        {
            Host = "smtp.mailersend.net",
            Port = 587,
            EnableSsl = true,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential(fromEmail?.UserName, fromEmail?.Password)
        };
        
        using (var message = new MailMessage(fromEmail.UserName, toEmail.UserName)
               {
                   Subject = "Gitub Job Posts",
                   Body = body
               })
        {
            smtp.Send(message);
        }
        
        Console.WriteLine("Email Sent!");
    }
}