namespace Job_Scraper;

public static class Scraper
{
    public static async Task<List<string>> UsePlayWright(List<Post> posts)
    {
        using var playwright = await Playwright.CreateAsync();
        var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
        var postList = new List<string>();
        
        try
        {
            Console.WriteLine("Running...");
            foreach(var post in posts)
            {
                Console.WriteLine($"Addy: {post.Address}");
                var page = await browser.NewPageAsync();
                await page.GotoAsync(post.Address,
                    new PageGotoOptions { Timeout = 120000, WaitUntil = WaitUntilState.Load });
                
                var elements = page.QuerySelectorAllAsync(post.ClassName["Element"]).Result;
                Console.WriteLine($"Element Count: {elements.Count}");
                foreach(var element in elements)
                {
                    var title = await element.QuerySelectorAsync(post.ClassName["JobTitle"]);
                    var requestIdElement = await element.QuerySelectorAsync(post.ClassName["RequestId"]);
                    var requestId = requestIdElement?.InnerTextAsync().Result;
                    var applyButton = await element.QuerySelectorAsync(post.ClassName["ApplyButton"]);
                    var applyLink = await page.EvaluateAsync<string>("el => el.href", applyButton);
                    var text = title?.InnerTextAsync().Result;
                    var postResult = $"Title: {text}, ID: {requestId}, Link: {applyLink}";
                    postList.Add(postResult);
                }
            }
            Console.WriteLine("Finished.");
        } catch
        {
            Console.WriteLine("There was an error processing the request");
        }

        return postList;
    }
}
