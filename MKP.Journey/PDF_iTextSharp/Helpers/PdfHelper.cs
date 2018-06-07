using iTextSharp.text;
using iTextSharp.text.pdf;
using Journey.Controllers;
using MKP.Journey.Controllers;
using MKP.Journey.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace MKP.Journey.Helpers
{
    public class PdfHelper
    {
        public static string GetVehicleTripsPdfUrl(DownloadModel downloadModel)
        {
            var tripsController = new TripsController();
            var vehicleController = new VehicleController();

            var vehicleTrips = tripsController.GetTripsByVehicleId(downloadModel.VehicleId);
            var vehicle = vehicleController.GetVehicle().FirstOrDefault(x => x.Id == downloadModel.VehicleId);

            var url = BuildPdfAndReturnUrl(vehicleTrips, vehicle, downloadModel.FromDate, downloadModel.ToDate);

            return url;
        }

        private static string BuildPdfAndReturnUrl(List<Trip> vehicleTrips, Vehicle vehicle, string fromDate, string toDate)
        {
            var destination = @"/pdfDocuments"; // Sets the destination of the PDF-document.
            var fileSuffix = string.Format("/{0}_Tripinformation.pdf", vehicle.RegNumber);

            //Creats the destination folder if it doesn't exist:
            if (!Directory.Exists(HttpContext.Current.Server.MapPath(destination)))
                Directory.CreateDirectory(destination);

            using (Document document = new Document(PageSize.A4))
            {
                var internalPath = @"C:\Temp";

                using (PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(internalPath + destination + fileSuffix, FileMode.Create)))
                {
                    document.Open(); // Opens the PDF-document.

                    BaseFont baseHelvetica = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
                    var color = BaseColor.BLACK;
                    Font helvetica = new Font(baseHelvetica, 20, Font.BOLD, color);
                    var para = new Paragraph("Rapport för: " + vehicle.RegNumber, helvetica);
                    para.Alignment = 1;
                    para.SpacingAfter = 20;
                    document.Add(para);

                    // A loop that builds a row for each trip with the selected vehicle:
                    foreach (var trip in vehicleTrips)
                    {
                        PdfPTable table = new PdfPTable(2); // Sets the value for total columns.
                        PdfPCell cell = new PdfPCell(new Phrase("Trip-ID: " + trip.Id));
                        cell.Colspan = 2;
                        cell.BackgroundColor = BaseColor.WHITE;

                        cell.HorizontalAlignment = 1;
                        cell.Padding = 5;
                        table.AddCell(cell);

                        table.AddCell("Datum:");
                        table.AddCell(trip.Date.ToString());

                        table.AddCell("Startadress:");
                        table.AddCell(trip.StartAddress);

                        table.AddCell("Destination:");
                        table.AddCell(trip.StopDestination);

                        table.AddCell("Totalt antal km:");
                        table.AddCell(((trip.KmStop) - (trip.KmStart)).ToString());

                        table.AddCell("Ärende:");
                        table.AddCell(trip.Arrend);

                        table.AddCell("Anteckningar:");
                        table.AddCell(trip.Notes);

                        table.PaddingTop = 10;
                        table.SpacingAfter = 10;
                        document.Add(table);
                    }
                    document.Close(); // Closes the PDF-document when finished.
                }
            }
            // return a downloadable path to the generated pdf.
            return string.Format("{0}{1}", destination, fileSuffix);
        }
    }
}