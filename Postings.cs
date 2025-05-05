namespace CompanyList;

internal class Post
{
    public string Address { get; }
    public string ElementType { get; }
    public string ClassName { get; }
    public string Id { get; }
    public string CompanyName { get; set; } = string.Empty;
    public string PositionTitle { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Experience { get; set; } = string.Empty;

    public Post(string address, string elementType, string className, string id = string.Empty) {
        Address = address;
        ElementType = elementType;
        ClassName = className;
        Id = id;
    }
}

public static class Website
{
    // Elements
    private string div = "div"

    // Github Element Property Values
    private string githubClass = ""
    private string githubId = ""

    // Github Search Strings
    private string canada = "?keywords=canada";
    private string unitedStates = "?keywords=united%20states";

    // Base URLs
    private string github = "https://www.github.careers/careers-home/jobs";

    // Finalized URLs
    private string githubCA = String.Concat(github, canada);
    private string githubUS = String.Concat(github, unitedStates);

    public static IReadOnlyList<Post> Posts = new()
    {
        new Post(githubCA, div, githubClass, githubId),
        new Post(githubUS, div, githubClass, githubId)
    }
}