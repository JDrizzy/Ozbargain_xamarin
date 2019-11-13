using System.Collections.Generic;
using System.ServiceModel.Syndication;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using ozbargain.Models;

namespace ozbargain.Services
{
    public static class OzbargainFetch
    {
        private const string URL = "https://www.ozbargain.com.au/deals/feed";

        static public List<Item> Execute()
        {
            var list = new List<Item>();

            XmlReader reader = XmlReader.Create(URL);
            var feed = SyndicationFeed.Load(reader);
            reader.Close();

            foreach (SyndicationItem feedItem in feed.Items)
            {
                var item = new Item
                {
                    Id = int.Parse(Regex.Match(feedItem.Id, @"(\d+)").Groups[0].Value),
                    Title = feedItem.Title.Text,
                    Summary = feedItem.Summary.Text,
                    Url = feedItem.Links[0].Uri.ToString()
                };

                list.Add(item);
            }

            return list;
        }
    }
}
