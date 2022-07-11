using MediumFeed.Models;
using MediumFeed.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MediumFeed.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BlogPage : ContentPage
    {
        BlogVM ViewModel;

        public BlogPage()
        {
            InitializeComponent();
        }

        public BlogPage(Topic topic)
        {
            InitializeComponent();
            ViewModel = Resources["vm"] as BlogVM;
            ViewModel.SelectedTopic = topic;
            ViewModel.LoadPosts();
        }
    }
}