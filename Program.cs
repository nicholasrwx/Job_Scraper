var postResults = await Scraper.CollectJobPosts(Website.Posts);
EmailClient.SendJobPosts(Email.GenerateTemplate(postResults));
