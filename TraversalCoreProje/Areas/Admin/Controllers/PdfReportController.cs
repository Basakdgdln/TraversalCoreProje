using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PdfReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
  

        public IActionResult StaticCustomerPdfReport()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pdfreport/" + "dosya2.pdf");
            var stream = new FileStream(path, FileMode.Create);
            Document document = new Document(PageSize.A4);
            PdfWriter.GetInstance(document, stream);
            document.Open();

            PdfPTable pdfPTable = new PdfPTable(3);
            pdfPTable.AddCell("misafir adı");
            pdfPTable.AddCell("misafir soyadı");
            pdfPTable.AddCell("misafir tc");

            pdfPTable.AddCell("başak");
            pdfPTable.AddCell("dağdelen");
            pdfPTable.AddCell("11111111111");

            pdfPTable.AddCell("kemal");
            pdfPTable.AddCell("yıldırım");
            pdfPTable.AddCell("11111111111");

            pdfPTable.AddCell("mehmet");
            pdfPTable.AddCell("yücedağ");
            pdfPTable.AddCell("11111111111");

            document.Add(pdfPTable);
            document.Close();
            return File("/pdfreport/dosya2.pdf", "application/pdf", "dosya2.pdf");
        }
    }
}
