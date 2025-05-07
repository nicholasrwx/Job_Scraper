var postResults = await Scraper.UsePlayWright(Website.Posts);

EmailPosts.SendJobPosts(postResults);

// Filter results further to Software Engineer I and II
// Send an Email which contains the poasts 
// Setup a Cron Job that checks for results every 2 hours and sends emails
// Make Search Elements more job specific
// Make Better config files
// Add in other websites
