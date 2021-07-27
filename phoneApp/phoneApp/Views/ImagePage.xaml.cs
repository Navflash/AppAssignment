using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace phoneApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImagePage : ContentPage
    {
        public ImagePage()
        {
            InitializeComponent();
        }
    }

    public class ImageModel
    {
        public ImageSource Image { get; set; }

        public ImageModel()
        {
            Assembly assembly = typeof(ImageModel).GetTypeInfo().Assembly;
            Image = ImageSource.FromResource("phoneApp.xamImage.png", assembly);
        }
    }
}