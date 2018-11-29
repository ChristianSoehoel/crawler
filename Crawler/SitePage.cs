using System;
using System.Collections.Generic;

namespace Crawler
{
    public class SitePage
    {
		public String URL;
		public String content;
		public int numberOfHrefs;
		public List<string> hrefs;

        public SitePage()
		{
		}
        
	}
}
