using CanvasRubricExporter.Models;
using iText.Html2pdf;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using System.Collections.Generic;

namespace CanvasRubricExporter.Services.Static
{
    public static class PdfExporter
    {
        public static void ExportRubricsToPdf(List<Rubric> rubrics, string baseUrl, string courseId, string filePath)
        {
            try
            {
                using (var pdfWriter = new PdfWriter(filePath))
                using (var pdfDocument = new PdfDocument(pdfWriter))
                using (var document = new Document(pdfDocument))
                {
                    foreach (var rubric in rubrics)
                    {
                        document.Add(new Paragraph($"Rubric: {rubric.title ?? "Unknown Title"}")
                            .SetFontSize(14));

                        if (rubric.criteria != null && rubric.criteria.Count > 0)
                        {
                            foreach (var criterion in rubric.criteria)
                            {
                                var description = criterion.description ?? "No Description";
                                var longDescription = criterion.long_description ?? "No Long Description";

                                document.Add(new Paragraph($"- {description}").SetFontSize(12));

                                // Render the HTML content
                                var elements = HtmlConverter.ConvertToElements(longDescription);

                                foreach (IElement element in elements)
                                {
                                    // Check the type of element and add accordingly
                                    if (element is IBlockElement blockElement)
                                    {
                                        document.Add(blockElement);
                                    }
                                    else if (element is ILeafElement leafElement)
                                    {
                                        Paragraph paragraph = new Paragraph();
                                        paragraph.Add(leafElement);
                                        document.Add(paragraph);
                                    }
                                    else if (element is AreaBreak areaBreak)
                                    {
                                        document.Add(areaBreak);
                                    }
                                    else
                                    {
                                        // For other types, you can handle them accordingly or log a warning
                                        Console.WriteLine($"Unhandled element type: {element.GetType()}");
                                    }
                                }

                                if (criterion.ratings != null && criterion.ratings.Count > 0)
                                {
                                    foreach (var rating in criterion.ratings)
                                    {
                                        var points = rating.points;
                                        var ratingDescription = rating.description ?? "No Description";

                                        document.Add(new Paragraph($"    {points} pts: {ratingDescription}").SetFontSize(10));
                                    }
                                }
                            }
                        }
                        else
                        {
                            document.Add(new Paragraph("No criteria available.").SetFontSize(12));
                        }

                        document.Add(new Paragraph("\n"));
                    }
                }
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                throw new Exception($"PDF Export Error: {ex.Message}", ex);
            }
        }
    }
}
