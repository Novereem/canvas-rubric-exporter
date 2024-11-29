# Canvas Rubric Exporter

## Overview

The **Canvas Rubric Exporter** is a Windows Forms application that allows instructors and administrators to export rubrics from Canvas LMS into PDF or Excel formats. This tool simplifies the process of retrieving and organizing rubric criteria, enabling easy sharing and analysis outside of Canvas.

## Features

- **Export Rubrics to PDF**: Generate detailed PDF files containing rubric criteria, descriptions, and ratings.
- **Export Rubrics to Excel**: Create an Excel spreadsheet with filtered rubric criteria for streamlined analysis.
- **Module and Assignment Selection**: Fetch modules and assignments from a specific course to select rubrics for export.
- **Filtering Options**: Filter rubric criteria based on specific patterns in their titles.
- **User-Friendly Interface**: Simple and intuitive interface for easy navigation and operation.

## System Requirements

- **Operating System**: Windows 7 SP1 or later (Windows 10 or later recommended)
- **.NET Runtime**:
  - For .NET Framework applications: .NET Framework 4.7.2 or later
  - For .NET Core/5/6 applications: Appropriate .NET Desktop Runtime installed (e.g., .NET 6 Desktop Runtime)
- **Internet Connection**: Required for accessing Canvas API

## Installation

1. **Download the Application**:
   - Go to the [Releases](https://github.com/Novereem/CanvasRubricExporter/releases) page of this repository.
   - Download the latest version of the application.

2. **Extract the Zip File**:
   - Right-click on the downloaded zip file and select **"Extract All..."**.
   - Choose a destination folder and click **"Extract"**.

3. **Run the Application**:
   - Navigate to the extracted folder.
   - Double-click on `CanvasRubricExporter.exe` to launch the application.

## Usage

### 1. Obtain Canvas API Token

Before using the application, you need a valid Canvas API token:

- Log in to  Canvas account.
- Go to **Account** > **Settings**.
- Scroll down to **Approved Integrations** and click **"+ New Access Token"**.
- Enter a purpose and an expiration date.
- Click **"Generate Token"**.
- Copy the generated token (keep it secure).

### 2. Launch the Application

- Double-click `CanvasRubricExporter.exe` to open the application.

### 3. Enter Base URL

- In the **"Base URL"** field, enter the URL of  Canvas instance.
  - For example: `https://institution.instructure.com`

### 4. Enter API Token

- Paste  Canvas API token into the **"API Token"** field.

### 5. Enter Course ID

- Enter the Course ID from which you want to export rubrics.
  - The Course ID is the number in the URL when viewing the course in Canvas.
  - For example, in `https://institution.instructure.com/courses/12345`, the Course ID is `12345`.

### 6. Fetch Modules

- Click the **"Fetch Modules"** button.
- The **"Modules"** dropdown will populate with the list of modules from the course.

### 7. Select a Module

- Choose a module from the **"Modules"** dropdown.

### 8. Fetch Assignments

- Click the **"Fetch Assignments"** button.
- The **"Assignments"** list will populate with assignments from the selected module.

### 9. Select Assignments

- In the **"Assignments"** list, select one or more assignments whose rubrics you want to export.
  - Hold down `Ctrl` to select multiple assignments.

### 10. Choose Export Options

- **Export to Excel (Short Table)**:
  - Check the **"Export to Excel (Short Table)"** checkbox to export a filtered list of rubric criteria to an Excel file.
  - When checked, the application will export to Excel; when unchecked, it will export a detailed PDF.
- **Filter Criteria**:
  - The application filters rubric criteria that contain both a hyphen (`-`) and a dot (`.`) in their titles when exporting to Excel.

### 11. Export Rubrics

- Click the **"Export to File"** button.
- A **Save File Dialog** will appear:
  - Choose the location where you want to save the exported file (default is  Downloads folder).
  - Enter a file name.
  - Click **"Save"**.

### 12. View the Exported File

- Navigate to the location where you saved the file.
- Open the PDF or Excel file to view the exported rubrics.

## Export Options

### Export to PDF

- Generates a detailed PDF file containing:
  - Rubric titles.
  - Criteria descriptions and long descriptions.
  - Ratings with points and descriptions.
- HTML content in the rubric descriptions is rendered appropriately.
- Suitable for comprehensive review and printing.

### Export to Excel (Short Table)

- Creates an Excel spreadsheet with:
  - A table containing two columns:
    - **Rubric Criteria Title**: Titles of the rubric criteria that match the filter.
    - **Assignment Link**: Link to the assignment with the assignment name in parentheses.
- Filters criteria to include only those with both a hyphen (`-`) and a dot (`.`) in their titles.
- Useful for quick analysis and integration with other tools.

## Troubleshooting

- **No Modules or Assignments Loaded**:
  - Ensure that  API token is valid and has sufficient permissions.
  - Verify that the Course ID and Base URL are correct.
  - Check  internet connection.

- **Error Messages**:
  - Read the error message carefully; it may indicate missing information or invalid input.
  - Ensure all fields are filled out correctly before fetching modules or assignments.

- **Exported File Does Not Open**:
  - Confirm that you have the necessary software to open PDFs (e.g., Adobe Reader) or Excel files (e.g., Microsoft Excel, LibreOffice Calc).
  - Ensure the file was saved correctly and is not corrupted.

- **Application Crashes or Freezes**:
  - Try running the application as an administrator.
  - Make sure  system meets the requirements.
  - Contact support or check for updates.

## Dependencies and Credits

- **iText7**: Used for generating PDF files.
- **EPPlus**: Used for creating Excel files.
- **Newtonsoft.Json**: For JSON serialization and deserialization.
- **Canvas LMS API**: For accessing course, module, assignment, and rubric data.
