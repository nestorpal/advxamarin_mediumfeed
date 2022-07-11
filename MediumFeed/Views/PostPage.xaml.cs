﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static MediumFeed.Models.Feed;

namespace MediumFeed.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PostPage : ContentPage
    {
        public PostPage()
        {
            InitializeComponent();
        }

        public PostPage(Post post)
        {
            InitializeComponent();
            webView.Source = post.Link;
        }
    }
}