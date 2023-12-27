using Syncfusion.OCRProcessor;
using Syncfusion.OCRProcessor.Interop;
using Syncfusion.Pdf.Graphics.Images.Decoder;

namespace ImageTextRetrievalOCR
{
    public class ImageTextRetriever
    {
        //todo find path of tesseract? also move this to better area.
        string tesseractDataPath = "./tessdata";
        public string RetrieveTextFromImage(string imagePath)
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("TODO ADD API");
            using (OCRProcessor ocrProcessor = new OCRProcessor())
            {
                FileStream imageStream = new FileStream(imagePath, FileMode.Open);
                ocrProcessor.Settings.Language = Languages.English;
                
                string ocrText = ocrProcessor.PerformOCR(imageStream, tesseractDataPath);

                return ocrText;
            }
        }
    }
}
