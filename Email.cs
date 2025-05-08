namespace Job_Scraper;

public static class Email
{
    public static string GenerateTemplate(List<Result> jobPosts)
    {
        var previousCompany = string.Empty;
        var body = new StringBuilder();
        body.Append(string.Concat("<html><body style='background-color: rgb(153, 255, 102); " +
                                  "display: flex; " +
                                  "justify-content: center; " +
                                  "align-items: center; " +
                                  "flex-direction: column;'>"));
        body.Append("<h1><b style='color: white;'>Job Posts<b></h1>");

        jobPosts.ForEach(job =>
        {
            if (previousCompany != job.Company)
            {
                previousCompany = job.Company;
                body.Append("<div style='display: inherit; " +
                            "justify-content: inherit; " +
                            "align-items: inherit; " +
                            "flex-direction: inherit;'>" +
                            $"<h4>{job.Company}<h4><div>");
            }

            body.Append("<div style='display: flex; " +
                        "justify-content: center; " +
                        "align-items: center; " +
                        "flex-direction: column; " +
                        "width: 20rem; " +
                        "height: 10rem; " +
                        "border: solid 1px black; " +
                        "box-shadow: 12px 12px 2px 1px rgba(0, 0, 255, 0.2); " +
                        "border-radius: 0.7rem; " +
                        "background-color: white; " +
                        "margin-bottom: 1rem;'>");
            body.Append($"<div>{job.JobTitle}</div>");
            body.Append($"<div>{job.RequestId}</div>");
            body.Append($"<a href={job.JobLink}>Apply To Job</a><br>");
            body.Append("</div>");
        });
        return body.ToString();
    }
}
