namespace Job_Scraper;

public static class Scraper
{
    public static async Task<List<Post>> UsePlayWright(List<Post> posts)
    {
        using var playwright = await Playwright.CreateAsync();
        var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
        var page = await browser.NewPageAsync();

        try
        {
            Console.WriteLine("Running...");
            foreach(var post in posts)
            {
                Console.WriteLine($"Addy: {post.Address}");
                await page.GotoAsync(posts[0].Address, new PageGotoOptions { Timeout = 120000, WaitUntil = WaitUntilState.DOMContentLoaded});
                var elements = page.QuerySelectorAllAsync(post.ClassName).Result;
                foreach(var element in elements)
                {
                    var text = element.InnerTextAsync();
                    var type = element.GetType().ToString();
                    Console.WriteLine($"{type}, {text}");
                }
            }
            Console.WriteLine("Finished.");
        } catch
        {
            Console.WriteLine("There was an error processing the request");
        }

        return posts;
    }
}
