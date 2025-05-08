namespace Job_Scraper;

public class Post(string address, Dictionary<string, string> information)
{
    public string Address { get; } = address;
    public Dictionary<string, string> Information { get; } = information;
}

public static class Website
{
    private static readonly Dictionary<string, string> GitHubCa = new()
    {
        { Company, GitHubCanada },
        { Element, GitHubTargetElement },
        { JobTitle, GitHubJobTitle },
        { RequestId, GitHubRequestId },
        { JobLink, GitHubJobLink }
    };

    private static readonly Dictionary<string, string> GitHubUs = new()
    {
        { Company, GitHubUnitedStates },
        { Element, GitHubTargetElement },
        { JobTitle, GitHubJobTitle },
        { RequestId, GitHubRequestId },
        { JobLink, GitHubJobLink }
    };

    public static readonly List<Post> Posts =
    [
        new(GitHubCaLink, GitHubCa),
        new(GitHubUsLink, GitHubUs)
    ];
}
