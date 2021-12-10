using DotNetGraphQL.Mobile.Pages;
using Xamarin.Forms;

namespace DotNetGraphQL.Mobile
{
    public class App : Application
    {
        public App() => MainPage = new BaseNavigationPage(new DogImageListPage());
    }
}
