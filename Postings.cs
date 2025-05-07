namespace Job_Scraper;

public class Post(string address, string elementType, Dictionary<string, string> className, string id)
{
    public string Address { get; } = address;
    public string ElementType { get; } = elementType;
    public Dictionary<string, string> ClassName { get; } = className;
    public string Id { get; } = id;
    public string? CompanyName { get; set; }
    public string? PositionTitle { get; set; }
    public string? Description { get; set; }
    public string? Experience { get; set; }
}

public static class Website
{
    // Elements
    private const string GithubCustomElement = "mat-expansion-panel";
    private const string Div = "div";
    private const string Span = "Span";

    // Github Element Property Values
    private static readonly Dictionary<string, string> GithubClasses = new()
    {
        {"Element", ".search-result-item"},
        {"JobTitle", "a.job-title-link"},
        {"RequestId", "p.req-id"},
        {"ApplyButton", "a.apply-button"}
    };

    // GitHub Search Keywords
    private const string Canada = "&locations=,,Canada";
    private const string UnitedStates = "&locations=,,United%20States";

    // Parameters
    private const string Limit = "&limit=50";
    private const string SortBy = "&sortBy=relevance";
    private const string Page = "&page=1";
    private const string Categories = "categories=Engineering";
    private const string Remote = "&tags6=Yes";
    private const string GithubKeywords = "&keywords=Software%20Engineer";
    

    // Base URLs
    private const string Github = "https://www.github.careers/careers-home/jobs?";
    //private const string Garmin = "https://www.garmin.com/en-CA/careers/job-listings";

    
    
    // Finalized URLs
    private static readonly string GithubCa = string.Concat(Github, Canada, Limit, SortBy, Page, Categories, Remote, GithubKeywords);
    private static readonly string GithubUs = string.Concat(Github, UnitedStates, Limit, SortBy, Page, Categories, Remote, GithubKeywords);

    public static readonly List<Post> Posts =
    [
        new(GithubCa, Span, GithubClasses, string.Empty)
        {
            CompanyName = null,
            PositionTitle = null,
            Description = null,
            Experience = null
        },
        new(GithubUs, Span, GithubClasses, string.Empty)
        {
            CompanyName = null,
            PositionTitle = null,
            Description = null,
            Experience = null
        }
    ];
}
