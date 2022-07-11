using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using static MediumFeed.Models.Feed;

namespace MediumFeed.Views.Behaviors
{
    public class PostListViewBehavior : Behavior<ListView>
    {
        ListView _listView;

        protected override void OnAttachedTo(ListView bindable)
        {
            base.OnAttachedTo(bindable);

            _listView = bindable;
            _listView.ItemSelected += ListView_ItemSelected;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedPost = _listView.SelectedItem as Post;
            Application.Current.MainPage.Navigation.PushAsync(new PostPage(selectedPost));
        }

        protected override void OnDetachingFrom(ListView bindable)
        {
            base.OnDetachingFrom(bindable);

            _listView.ItemSelected -= ListView_ItemSelected;
        }
    }
}
