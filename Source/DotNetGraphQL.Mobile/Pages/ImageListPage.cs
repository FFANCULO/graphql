using System;
using System.Linq;
using DotNetGraphQL.Common.Models;
using Xamarin.CommunityToolkit.Markup;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace DotNetGraphQL.Mobile.Pages
{
    class DogImageListPage : BaseContentPage<DogImageListViewModel>
    {
        public DogImageListPage()
        {
            ViewModel.PullToRefreshFailed += (sender, message) => MainThread.BeginInvokeOnMainThread(async () => await DisplayAlert("Refresh Failed", message, "OK"));

            Title = "Favorite Dogs";

            Content = new RefreshView
            {
                RefreshColor = Color.FromHex("1F2B2E"),

                Content = new CollectionView
                {
                    EmptyView = new Label { Text = "🐶" }.Font(size: 128).Center().TextCenter(),
                    ItemTemplate = new DogImageListDataTemplateSelector(),
                    SelectionMode = SelectionMode.Single,
                }.Bind(CollectionView.ItemsSourceProperty, nameof(DogImageListViewModel.DogImageList))
                 .Invoke(collectionView => collectionView.SelectionChanged += (sender, e) =>
                 {
                     var collectionView1 = (CollectionView)sender;
                     collectionView1.SelectedItem = null;

                     //if (e.CurrentSelection.FirstOrDefault() is DogImagesModel dogImagesModel
                     //    && Uri.TryCreate(dogImagesModel.Breed, UriKind.Absolute, out _))
                     //{
                     //    await OpenBrowser(dogImagesModel.Breed);
                     //}
                 })

            }.Bind(RefreshView.CommandProperty, nameof(DogImageListViewModel.RefreshDogCollectionCommand))
             .Bind(RefreshView.IsRefreshingProperty, nameof(DogImageListViewModel.IsDogImageCollectionRefreshing));
        }
    }
}
