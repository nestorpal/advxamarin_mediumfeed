using MediumFeed.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Xml.Serialization;
using static MediumFeed.Models.Feed;

namespace MediumFeed.ViewModels
{
    public class BlogVM
    {
        private readonly string _feedUrlBase = "https://medium.com/feed/tag/{0}";
        
        public Topic SelectedTopic { get; set; }
        public Feed FeedSource { get; set; }

        public ObservableCollection<Post> Posts { get; set; }

        public BlogVM()
        {
            Posts = new ObservableCollection<Post>();
        }

        public void LoadPosts()
        {
            Posts.Clear();

            XmlSerializer serializer = new XmlSerializer(typeof(Feed));

            using (WebClient client = new WebClient())
            {
                string xmlContent = Encoding.Default.GetString(client.DownloadData(string.Format(_feedUrlBase, SelectedTopic.InternalName)));
                using (Stream reader = new MemoryStream(Encoding.UTF8.GetBytes(xmlContent)))
                {
                    FeedSource = (Feed)serializer.Deserialize(reader);

                    if (FeedSource.FeedChannel.Items.Count > 0)
                    {
                        foreach (var item in FeedSource.FeedChannel.Items)
                        {
                            Posts.Add(new Post { Description = item.Description, Link = item.Link, Title = item.Title });
                        }
                    }
                }
            }
        }
    }
}
