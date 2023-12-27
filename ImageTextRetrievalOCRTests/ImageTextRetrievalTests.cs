using ImageTextRetrievalOCR;
using FluentAssertions;

namespace ImageTextRetrievalOCRTests
{
    public class ImageTextRetrievalOCRTests
    {
        [Fact]
        public void OCR_WhenCalled_RetrievesSuccessfulResult()
        {
            //string imagePath = "phototest.tif";
            string imagePath = "rdi.jpg";

            var imageTextRetreiver = new ImageTextRetriever();

            var result = imageTextRetreiver.RetrieveTextFromImage(imagePath);

            result.Should().NotBeNullOrEmpty();
        }
    }
}