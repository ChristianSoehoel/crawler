using System;

namespace Crawler
{
    class MainClass
    {
        public static void Main(string[] args)
        {
			var spider = new Spider("http://dr.dk");
            spider.Crawl();
		}
    }
}
