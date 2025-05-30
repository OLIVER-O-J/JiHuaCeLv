using Aspose.CAD;
using Aspose.CAD.ImageOptions;
using System.IO;
using Aspose.CAD.FileFormats.Cad;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas;


namespace JiHuaCeLv.DWG_exchange_PDF
{
    public class CAD_method
    {
        /// <summary>
        /// PDF文件后缀名
        /// </summary>
        public string pdfExtensions = ".pdf";
        /// <summary>
        /// 将DWG文件转换为PDF文件
        /// </summary>
        /// <param name="文件名"></param>
        /// <param name="pdfFilePath"></param>
        public void ConverDwgToPdf(string dwgFilePath, string pdfFilePath)
        {
            using (var image = Image.Load(dwgFilePath))
            {
                MemoryStream ms = new MemoryStream();
                RasterizationQuality rasterizationQuality = new RasterizationQuality()
                {
                    Arc = RasterizationQualityValue.Medium,
                    Hatch = RasterizationQualityValue.Medium,
                    Text = RasterizationQualityValue.Medium,
                    Ole = RasterizationQualityValue.Medium,
                    ObjectsPrecision = RasterizationQualityValue.Medium,
                    TextThicknessNormalization = true,
                };
                var rasterizationOptions = new CadRasterizationOptions()
                {
                    BackgroundColor = Color.White,
                    PageWidth = image.Width,
                    PageHeight = image.Height,
                    UnitType = image.UnitType,
                    AutomaticLayoutsScaling = false,
                    NoScaling = false,
                    Quality = rasterizationQuality,
                    DrawType = CadDrawTypeMode.UseObjectColor,
                    ExportAllLayoutContent = true,
                    VisibilityMode = VisibilityMode.AsScreen
                };
                var pdfOptions = new PdfOptions()
                {
                    VectorRasterizationOptions = rasterizationOptions,
                };
                image.Save(pdfFilePath, pdfOptions);
            }
        }

        
    }
}

