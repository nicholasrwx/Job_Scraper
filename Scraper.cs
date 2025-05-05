namespace Utilities;

public static class Scraper
{
    public static async Task<IReadOnlyList<Post>> UsePlayWright(IReadOnlyList<Post> posts)
    {
        using var playwright = await Playwright.CreateAsync();
        var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
        var page = await browser.NewPageAsync();

        foreach(var post in posts)
        {
            await page.GotoAsync(post.Address);
        }

        return posts;
    }
}
