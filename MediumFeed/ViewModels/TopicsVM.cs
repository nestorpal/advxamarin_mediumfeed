using MediumFeed.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MediumFeed.ViewModels
{
    public class TopicsVM
    {
        public ObservableCollection<Topic> TopicsCollection { get; set; }

        public TopicsVM()
        {
            TopicsCollection = new ObservableCollection<Topic>();
            LoadTopics();
        }

        private void LoadTopics()
        {
            TopicsCollection.Clear();
            TopicsCollection.Add(new Topic { DisplayName = "Visual Design", InternalName = "visualdesign" });
            TopicsCollection.Add(new Topic { DisplayName = "Gaming", InternalName = "gaming" });
            TopicsCollection.Add(new Topic { DisplayName = "Programming", InternalName = "programming" });
            TopicsCollection.Add(new Topic { DisplayName = "Technology", InternalName = "technology" });
            TopicsCollection.Add(new Topic { DisplayName = "Money", InternalName = "money" });
        }
    }

}
