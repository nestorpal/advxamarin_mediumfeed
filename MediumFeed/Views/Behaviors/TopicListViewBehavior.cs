using MediumFeed.Models;
using Xamarin.Forms;

namespace MediumFeed.Views.Behaviors
{
    public class TopicListViewBehavior : Behavior<ListView>
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
            Topic selectedTopic = _listView.SelectedItem as Topic;
            Application.Current.MainPage.Navigation.PushAsync(new BlogPage(selectedTopic));
        }

        protected override void OnDetachingFrom(ListView bindable)
        {
            base.OnDetachingFrom(bindable);

            _listView.ItemSelected -= ListView_ItemSelected;
        }
    }
}
