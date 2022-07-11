using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace MediumFeed.Models
{
    [XmlRoot(ElementName = "rss")]
    public class Feed
    {
        [XmlElement(ElementName = "channel")]
        public Channel FeedChannel { get; set; }

        [XmlRoot(ElementName = "channel")]
        public class Channel
        {
            [XmlElement(ElementName = "title")]
            public string Title { get; set; }

            [XmlElement(ElementName = "image")]
            public ChannelImage Image { get; set; }

            [XmlElement(ElementName = "item")]
            public List<Post> Items { get; set; }
        }

        [XmlRoot(ElementName = "image")]
        public class ChannelImage
        {
            [XmlElement(ElementName = "url")]
            public string Url { get; set; }

            [XmlElement(ElementName = "title")]
            public string Title { get; set; }
        }

        [XmlRoot(ElementName = "item")]
        public class Post
        {
            [XmlElement(ElementName = "title")]
            public string Title { get; set; }

            [XmlElement(ElementName = "description")]
            public string Description { get; set; }

            [XmlElement(ElementName = "link")]
            public string Link { get; set; }

            public string DescriptionText
            {
                get
                {
                    string result = string.Empty;
                    try
                    {
                        if (!string.IsNullOrEmpty(Description))
                        {
                            Regex regRule = new Regex("<p class=\"medium-feed-snippet\">(.*)</p><p");
                            Match match = regRule.Match(Description);
                            if (match.Success)
                            {
                                result = match.Groups[1].Value;
                            }
                        }
                    }
                    catch { }

                    return result;
                }
            }

            public string ImageLink
            {
                get
                {
                    string result = string.Empty;
                    try
                    {
                        if (!string.IsNullOrEmpty(Description))
                        {
                            Regex regRule = new Regex("img src=\"(.*)\" width=");
                            Match match = regRule.Match(Description);
                            if (match.Success)
                            {
                                result = match.Groups[1].Value;
                            }
                        }
                    }
                    catch { }

                    return result;
                }
            }
        }
    }
}
