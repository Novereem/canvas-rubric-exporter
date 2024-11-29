using CanvasRubricExporter.Models;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace CanvasRubricExporter.Services.Static
{
    public static class ExcelExporter
    {
        public static void ExportRubricsToExcel(List<Rubric> rubrics, string baseUrl, string courseId, string filePath)
        {
            // Enable ExcelPackage to use non-commercial license
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Rubrics");

                // Set up headers
                worksheet.Cells[1, 1].Value = "Rubric Criteria Title";
                worksheet.Cells[1, 2].Value = "Assignment Link";

                // Format headers
                using (var range = worksheet.Cells[1, 1, 1, 2])
                {
                    range.Style.Font.Bold = true;
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                }

                int row = 2;

                foreach (var rubric in rubrics)
                {
                    // Build the assignment link
                    string assignmentLink = $"{baseUrl}/courses/{courseId}/assignments/{rubric.AssignmentId}";
                    if (!string.IsNullOrEmpty(rubric.ModuleItemId))
                    {
                        assignmentLink += $"?module_item_id={rubric.ModuleItemId}";
                    }
                    assignmentLink += $" ({rubric.AssignmentName})";

                    // Filter criteria based on your condition
                    var filteredCriteria = rubric.criteria
                        .Where(c => c.description != null && c.description.Contains("-") && c.description.Contains("."))
                        .ToList();

                    foreach (var criterion in filteredCriteria)
                    {
                        worksheet.Cells[row, 1].Value = criterion.description ?? "No Description";
                        worksheet.Cells[row, 2].Value = assignmentLink;

                        worksheet.Cells[row, 2].Hyperlink = new Uri(assignmentLink);
                        worksheet.Cells[row, 2].Style.Font.Color.SetColor(Color.Blue);
                        worksheet.Cells[row, 2].Style.Font.UnderLine = true;

                        row++;
                    }
                }

                if (row == 2)
                {
                    // No criteria matched the filter
                    worksheet.Cells[2, 1].Value = "No matching criteria found.";
                    worksheet.Cells[2, 1, 2, 2].Merge = true;
                    worksheet.Cells[2, 1].Style.Font.Italic = true;
                }

                // Adjust column widths
                worksheet.Column(1).AutoFit();
                worksheet.Column(2).AutoFit();

                // Save the Excel file
                package.SaveAs(new FileInfo(filePath));
            }
        }
    }
}