using CanvasRubricExporter.Services.Static;
using CanvasRubricExporter.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using CanvasRubricExporter.Models;
using System.IO;
using CanvasRubricExporter.Models.Display;

namespace CanvasRubricExporter
{
    public partial class MainForm : Form
    {
        private CanvasApiService _canvasApiService;

        public MainForm()
        {
            InitializeComponent();
        }

        private async void FetchAssignmentsButton_Click(object sender, EventArgs e)
        {
            if (ModulesComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a module first.");
                return;
            }

            var selectedModule = (ModuleDisplay)ModulesComboBox.SelectedItem;

            try
            {
                var items = await _canvasApiService.GetModuleItemsAsync(CourseIdTextBox.Text, selectedModule.Id);

                AssignmentsListBox.Items.Clear();

                foreach (var item in items)
                {
                    if (item.type == "Assignment")
                    {
                        AssignmentsListBox.Items.Add(new AssignmentDisplay
                        {
                            Name = item.title,
                            Id = item.content_id.ToString(),
                            ModuleItemId = item.id.ToString() // Capture module item ID
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private async void ExportToPdfButton_Click(object sender, EventArgs e)
        {
            if (AssignmentsListBox.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select at least one assignment to export.");
                return;
            }

            try
            {
                var selectedAssignments = AssignmentsListBox.SelectedItems.Cast<AssignmentDisplay>().ToList();
                var rubrics = new List<Rubric>();

                foreach (var assignment in selectedAssignments)
                {
                    var rubric = await _canvasApiService.GetRubricForAssignmentAsync(CourseIdTextBox.Text, assignment.Id);

                    if (rubric != null)
                    {
                        // Include assignment information in the rubric object
                        rubric.AssignmentId = assignment.Id;
                        rubric.AssignmentName = assignment.Name;
                        rubric.ModuleItemId = assignment.ModuleItemId; // Include module item ID
                        rubrics.Add(rubric);
                    }
                }

                if (rubrics.Count == 0)
                {
                    MessageBox.Show("No valid rubrics found for the selected assignments.");
                    return;
                }

                var baseUrl = BaseUrlTextBox.Text;
                var courseId = CourseIdTextBox.Text;

                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.InitialDirectory = KnownFolders.GetDownloadsFolderPath();
                    saveFileDialog.Filter = ShortTableCheckBox.Checked ? "Excel Files (*.xlsx)|*.xlsx" : "PDF Files (*.pdf)|*.pdf";
                    saveFileDialog.FileName = ShortTableCheckBox.Checked ? "rubrics.xlsx" : "rubrics.pdf";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = saveFileDialog.FileName;

                        if (ShortTableCheckBox.Checked)
                        {
                            ExcelExporter.ExportRubricsToExcel(rubrics, baseUrl, courseId, filePath);
                        }
                        else
                        {
                            PdfExporter.ExportRubricsToPdf(rubrics, baseUrl, courseId, filePath);
                        }

                        MessageBox.Show($"Rubrics exported to: {filePath}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}\n\n{ex}");
            }
        }

        private async void FetchModulesButton_Click(object sender, EventArgs e)
        {
            _canvasApiService = new CanvasApiService(BaseUrlTextBox.Text, ApiTokenTextBox.Text);

            try
            {
                var modules = await _canvasApiService.GetModulesAsync(CourseIdTextBox.Text);

                ModulesComboBox.Items.Clear();

                foreach (var module in modules)
                {
                    ModulesComboBox.Items.Add(new ModuleDisplay
                    {
                        Name = module.name,
                        Id = module.id.ToString()
                    });
                }

                if (ModulesComboBox.Items.Count > 0)
                {
                    ModulesComboBox.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}
