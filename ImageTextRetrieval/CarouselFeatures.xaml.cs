using Syncfusion.Maui.Carousel;
using System.Collections.ObjectModel;
namespace ImageTextRetrieval;
    public partial class CarouselFeatures : ContentPage
    {
        public CarouselFeatures()
        {
            InitializeComponent();
            ObservableCollection<SfCarouselItem> items = new ObservableCollection<SfCarouselItem>();
            items.Add(new SfCarouselItem() { ImageName = "image1.png" });
            items.Add(new SfCarouselItem() { ImageName = "image2.png" });
            items.Add(new SfCarouselItem() { ImageName = "image3.png" });
            items.Add(new SfCarouselItem() { ImageName = "image4.png" });
            items.Add(new SfCarouselItem() { ImageName = "image5.png" });
            items.Add(new SfCarouselItem() { ImageName = "image6.png" });
            items.Add(new SfCarouselItem() { ImageName = "image7.png" });
            carousel.ItemsSource = items;
        }
    }
