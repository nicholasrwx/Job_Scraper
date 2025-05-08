namespace Job_Scraper;

public static class Scraper
{
    public static async Task<List<Result>> CollectJobPosts(List<Post> posts)
    {
        using var playwright = await Playwright.CreateAsync();
        var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
        var postList = new List<Result>();

        try
        {
            Console.WriteLine(Start);
            foreach (var post in posts)
            {
                Console.WriteLine($"{CompanyName} {post.Information[Company]}");
                Console.WriteLine($"{Address} {post.Address}");
                var page = await browser.NewPageAsync();
                await page.GotoAsync(post.Address,
                    new PageGotoOptions { Timeout = ScraperTimeout, WaitUntil = WaitUntilState.Load });
                var elements = page.QuerySelectorAllAsync(post.Information[Element]).Result;
                Console.WriteLine($"{PostingCount} {elements.Count}");

                foreach (var element in elements)
                {
                    var result = new Result();

                    foreach (var entry in post.Information)
                    {
                        var property = typeof(Result).GetProperty(entry.Key);
                        switch (entry.Key)
                        {
                            case Element:
                                break;
                            case Company:
                                property?.SetValue(result, entry.Value);
                                break;
                            case JobTitle or RequestId:
                                var innerElement = await element.QuerySelectorAsync(entry.Value);
                                property?.SetValue(result, innerElement?.InnerTextAsync().Result);
                                break;
                            case JobLink:
                                var linkElement = await element.QuerySelectorAsync(entry.Value);
                                property?.SetValue(result,
                                    await page.EvaluateAsync<string>(LinkExpression, linkElement));
                                break;
                            default:
                                Console.WriteLine(NoMatch);
                                break;
                        }
                    }

                    postList.Add(result);
                }
            }

            Console.WriteLine(Finish);
        }
        catch
        {
            Console.WriteLine(ScrapingError);
        }

        return postList;
    }
}
