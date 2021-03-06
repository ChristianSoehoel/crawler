﻿using System;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace Crawler
{
    public class Spider
    {
		public Spider()
        {
            Console.WriteLine("Spider initiated ...");
        }

        private string siteUrl;

        public string SiteUrl
        {
            get { return siteUrl; }
            set { siteUrl = value; }
        }

		string page;

		public string Page 
		{
			get { return page; } 
		}

		List<string> hrefs = new List<string>();

		public List<string> Hrefs 
		{
            get { return hrefs; }
        }

        public void Crawl()
        {
            Console.WriteLine("Start crawling: " + SiteUrl);

			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(SiteUrl);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            Stream resStream = response.GetResponseStream();

            Console.WriteLine(response.StatusDescription);

            StreamReader reader = new StreamReader(resStream);
            page = reader.ReadToEnd();

            getLinks(page);

        }   



        private void getLinks(string page)
        {
            // Looking for string '<a some characters href>some text</a>'
            var regex = new Regex("(?s)<a .*?>.*?</a>");

            MatchCollection matches = regex.Matches(page);
            Console.WriteLine("Number of <a> </a> founds: " + matches.Count);

            getHrefs(matches);
        }

        private void getHrefs(MatchCollection matches)
        {
            // Looking for string href="<some characters>"
            var regex = new Regex("(href=(\'|\"))\\s*[\\s,:,.,?,-,\\/,a-z,A-Z,=,0-9,_,-]+(\'|\")");
            Console.WriteLine("Number of href founds: " + matches.Count);

            foreach (Match elementMatch in matches)
            {
                var element = elementMatch.ToString();
                string[] hRefSplit = new String[3];
                if ((regex.Match(element)).Success)
                {
                    var hRef = element.Substring(regex.Match(element).Index, regex.Match(element).Length);
                    if (hRef.IndexOf('"') > 0)
                    {
                        hRefSplit = hRef.Split('"');
                    }
                    else if (hRef.IndexOf('\'') > 0)
                    {
                        hRefSplit = hRef.Split('\'');
                    }
                    else
                    {
                        Console.WriteLine("String does not contain either ' or \" " + hRef);
                    }

                    //Console.WriteLine("href element: " + hRefSplit[1]);
					hrefs.Add(hRefSplit[1]);
                }
            }
        }
    }
}
