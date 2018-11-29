using System;
using System.Collections.Generic;

namespace Crawler
{
    class MainClass
    {
        public static void Main(string[] args)
        {
			Dictionary<string, SitePage> siteData = new Dictionary<string, SitePage>();

			SitePage page = new SitePage();
			page.URL = "http://fruhedevigbagger.dk";

			var spider = new Spider();
			spider.SiteUrl = page.URL;
            spider.Crawl();

			page.content = spider.Page;
			page.hrefs = spider.Hrefs;

			foreach (string href in page.hrefs)
            {
                Console.WriteLine("href on page {0} ", href);
            }

			//Console.WriteLine("Content of page: " + page.content);
		}
    }
}
