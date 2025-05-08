namespace Job_Scraper;

public static class Constants
{
    // Dictionary Keys
    public const string Company = "Company";
    public const string Element = "Element";
    public const string JobTitle = "JobTitle";
    public const string RequestId = "RequestId";
    public const string JobLink = "JobLink";

    // Console Messages
    public const string Start = "Scraping Started...";
    public const string CompanyName = "Company Name:";
    public const string Address = "Website Address:";
    public const string PostingCount = "Website Posting Count:";
    public const string NoMatch = "No Match Found";
    public const string Finish = "Scraping Finished.";
    public const string Sent = "Email Sent!";

    // Email Configuration
    public const string Host = "smtp.mailersend.net";
    public const string Subject = "Job Posts";
    public const int Port = 587;

    // Email Credentials
    public const string FromEmail = "JOB_EMAIL";
    public const string ToEmail = "EMAIL";

    // Scraper Configuration
    public const int ScraperTimeout = 120000;
    public const string LinkExpression = "el => el.href";

    // Garmin
    public const string Garmin = "https://www.garmin.com/en-CA/careers/job-listings";

    /* Company Names */
    public const string GitHubUnitedStates = "Github - United States";
    public const string GitHubCanada = "Github - Canada";

    /* Website Elements To Target */
    public const string GitHubTargetElement = ".search-result-item";
    public const string GitHubJobTitle = "a.job-title-link";
    public const string GitHubRequestId = "p.req-id";
    public const string GitHubJobLink = "a.apply-button";

    public static readonly string ScrapingError = string.Concat("There was an error processing the requests. " +
                                                                "Check internet connection, VPN status (off), " +
                                                                "company urls, and try again.");

    /* Websites To Scrape */
    // GitHub
    public static readonly string GitHubCaLink = string.Concat("https://www.github.careers/careers-home/jobs?" +
                                                               "&locations=,,Canada" +
                                                               "&limit=50" +
                                                               "&sortBy=relevance" +
                                                               "&page=1categories=Engineering" +
                                                               "&tags6=Yes" +
                                                               "&keywords=Software%20Engineer");

    public static readonly string GitHubUsLink = string.Concat("https://www.github.careers/careers-home/jobs?" +
                                                               "&locations=,,United%20States" +
                                                               "&limit=50" +
                                                               "&sortBy=relevance" +
                                                               "&page=1categories=Engineering" +
                                                               "&tags6=Yes" +
                                                               "&keywords=Software%20Engineer");
}
