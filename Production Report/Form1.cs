using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Components;
using MetroFramework;
using MetroFramework.Forms;
using MetroFramework.Controls;
using System.IO;
using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace Production_Report
{
    public partial class Form1 : MetroForm
    {
        private Microsoft.Office.Interop.Excel.Application excelApp;
        private Microsoft.Office.Interop.Excel.Workbook excelWorkbook;
        private Microsoft.Office.Interop.Excel.Worksheet activeSheet;

        public Form1()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.FormClosing += Form1_FormClosing;
        }

        private void btnBrowseFldr_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    txtCsvFolder.Text = dialog.SelectedPath;
                    // Set the value of txtExcelFilePath.Text with the same path as txtFolder.Text but with .xlsx extension
                    txtExcelFilePath.Text = Path.Combine(dialog.SelectedPath, new DirectoryInfo(dialog.SelectedPath).Name + ".xlsx");
                }
            }
        }

        private void txtCsvFolder_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCsvFolder.Text))
            {
                // Clear the file path in txtExcelFilePath
                txtExcelFilePath.Text = string.Empty;
                // Display a message to prompt the user to select a CSV folder
                MessageBox.Show("Please select a CSV folder to continue.", "Folder Not Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Set the value of txtExcelFilePath.Text with the same path as txtFolder.Text but with .xlsx extension
                txtExcelFilePath.Text = Path.Combine(txtCsvFolder.Text, new DirectoryInfo(txtCsvFolder.Text).Name + ".xlsx");
                txtExcelFilePath01.Text = Path.Combine(txtCsvFolder.Text, new DirectoryInfo(txtCsvFolder.Text).Name + ".xlsx");
            }
        }

        private void btnGetReport_Click(object sender, EventArgs e)
        {
            // Create a new Excel application instance
            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
            excelApp.Visible = false;

            // Create a new Excel workbook
            Microsoft.Office.Interop.Excel.Workbook excelWorkbook = excelApp.Workbooks.Add();

            // Get the path of the directory containing the CSV files
            string csvFolderPath = txtCsvFolder.Text;

            // Check if csvFolderPath is blank
            if (string.IsNullOrEmpty(csvFolderPath))
            {
                MessageBox.Show("Please Select CSV Folder to Continue.", "Folder Not Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get the files with a .csv extension in the specified directory
            //var csvFiles = new DirectoryInfo(csvFolderPath).GetFiles("*.csv");
            var csvFiles = new DirectoryInfo(csvFolderPath).GetFiles("*.csv", SearchOption.AllDirectories);

            // Create a dictionary to store the desired headers' data
            Dictionary<string, List<string>> dataDictionary = new Dictionary<string, List<string>>();

            // Loop through each CSV file
            foreach (var csvFile in csvFiles)
            {
                // Extract the date from the CSV file name
                string fileName = Path.GetFileNameWithoutExtension(csvFile.Name);
                string[] fileNameParts = fileName.Split('-');
                string date = string.Join("-", fileNameParts.Take(3));

                // Read the contents of the CSV file
                var csvContents = File.ReadAllLines(csvFile.FullName);

                // Check if the CSV file has any data
                if (csvContents.Length > 0)
                {
                    // Find the indices of the desired headers
                    int userNameIndex = -1;
                    int partyCodeIndex = -1;
                    int weightRangeIndex = -1;
                    int resultIndex = -1;

                    // Split the first line of the CSV file to get the headers
                    var headers = csvContents[0].Split(',');

                    // Loop through the headers to find the indices of the desired headers
                    for (int i = 0; i < headers.Length; i++)
                    {
                        if (headers[i] == " UserName")
                        {
                            userNameIndex = i;
                        }
                        else if (headers[i] == " PartyCode")
                        {
                            partyCodeIndex = i;
                        }
                        else if (headers[i] == " WeightRange")
                        {
                            weightRangeIndex = i;
                        }
                        else if (headers[i] == " Result")
                        {
                            resultIndex = i;
                        }
                    }

                    // Check if all desired headers are found
                    if (userNameIndex == -1 || partyCodeIndex == -1 || weightRangeIndex == -1 || resultIndex == -1)
                    {
                        // Display a message indicating that one or more desired headers are missing
                        MessageBox.Show("One or more desired headers are missing in the CSV files.", "Headers Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Loop through the data rows
                    for (int row = 1; row < csvContents.Length; row++)
                    {
                        var data = csvContents[row].Split(',');

                        // Check if the data row has all the desired headers
                        if (data.Length > Math.Max(userNameIndex, Math.Max(partyCodeIndex, Math.Max(weightRangeIndex, resultIndex))))
                        {
                            string userName = data[userNameIndex].Trim();

                            // Check if the dictionary already contains the user
                            if (dataDictionary.ContainsKey(userName))
                            {
                                // Add the data entry to the existing user's list
                                dataDictionary[userName].Add($"{data[partyCodeIndex]},{data[weightRangeIndex]},{data[resultIndex]},{date}");
                            }
                            else
                            {
                                // Create a new list for the user and add the data entry
                                dataDictionary[userName] = new List<string> { $"{data[partyCodeIndex]},{data[weightRangeIndex]},{data[resultIndex]},{date}" };
                            }
                        }
                    }
                }
            }

            // Create a dictionary to store the desired data
            Dictionary<string, Dictionary<string, int[]>> partyCodeWeightRangeCounts = new Dictionary<string, Dictionary<string, int[]>>();

            // Loop through each entry in the dataDictionary
            foreach (var entry in dataDictionary)
            {
                string userName = entry.Key;
                List<string> userEntries = entry.Value;

                // Create a dictionary to store partyCode and weightRange counts for the current user
                Dictionary<string, int[]> counts = new Dictionary<string, int[]>();

                // Loop through the user entries and count partyCode and weightRange occurrences
                foreach (var userEntry in userEntries)
                {
                    var entryData = userEntry.Split(',');
                    string partyCode = entryData[0].Trim();
                    string weightRange = entryData[1].Trim();
                    string result = entryData[2].Trim();
                    string date = entryData[3].Trim();

                    // Create a unique key for the combination of partyCode and weightRange
                    string key = $"{partyCode},{weightRange},{date}";

                    // Check if the key already exists in counts dictionary
                    if (counts.ContainsKey(key))
                    {
                        if (result == "ok")
                        {
                            counts[key][0]++; // Increment the OK count
                        }
                        else
                        {
                            counts[key][1]++; // Increment the non-OK count
                        }
                    }
                    else
                    {
                        if (result == "ok")
                        {
                            counts[key] = new int[2] { 1, 0 }; // Initialize the count with 1 OK and 0 non-OK
                        }
                        else
                        {
                            counts[key] = new int[2] { 0, 1 }; // Initialize the count with 0 OK and 1 non-OK
                        }
                    }
                }

                // Add the counts dictionary to partyCodeWeightRangeCounts for the current user
                partyCodeWeightRangeCounts[userName] = counts;
            }
                        
            // Loop through each entry in partyCodeWeightRangeCounts
            foreach (var entry in partyCodeWeightRangeCounts)
            {
                string userName = entry.Key;
                Dictionary<string, int[]> counts = entry.Value;

                // Add a new worksheet for the current user
                Microsoft.Office.Interop.Excel.Worksheet userWorksheet = excelWorkbook.Sheets.Add();
                userWorksheet.Name = userName;

                // Write the headers to the user's worksheet
                userWorksheet.Cells[1, 1] = "SrNo";
                userWorksheet.Cells[1, 2] = "UserName";
                userWorksheet.Cells[1, 3] = "Date";
                userWorksheet.Cells[1, 4] = "PartyCode";
                userWorksheet.Cells[1, 5] = "WeightRange";
                userWorksheet.Cells[1, 6] = "Count";
                userWorksheet.Cells[1, 7] = "OK";
                userWorksheet.Cells[1, 8] = "PK";

                int currentRow = 2; // Start writing the data from the second row
                int serialNumber = 1; // Initialize the serial number

                // Create a dictionary to store the summed values per WeightRange
                Dictionary<string, int[]> weightRangeSummary = new Dictionary<string, int[]>();

                // Create a dictionary to store the summed values per PartyCode and WeightRange
                Dictionary<string, int[]> summaryData = new Dictionary<string, int[]>();

                foreach (var countEntry in counts)
                {
                    string[] keyData = countEntry.Key.Split(',');
                    string date = keyData[2];
                    string partyCode = keyData[0].Trim();
                    string weightRange = keyData[1].Trim();
                    int[] countValues = countEntry.Value;
                    int okCount = countValues[0]; // OK count
                    int pkCount = countValues[1]; // PK count
                    int totalCount = okCount + pkCount; // Total count (OK + PK)

                    // Write the data to the user's worksheet
                    userWorksheet.Cells[currentRow, 1] = serialNumber;
                    userWorksheet.Cells[currentRow, 2] = userName;
                    userWorksheet.Cells[currentRow, 3] = date;
                    userWorksheet.Cells[currentRow, 4] = partyCode;
                    userWorksheet.Cells[currentRow, 5] = weightRange;
                    userWorksheet.Cells[currentRow, 6] = totalCount;
                    userWorksheet.Cells[currentRow, 7] = okCount;
                    userWorksheet.Cells[currentRow, 8] = pkCount;

                    currentRow++; // Move to the next row
                    serialNumber++; // Increment the serial number

                    // Create the combined key for PartyCode and WeightRange
                    string combinedKey = partyCode + weightRange;

                    // Update the summaryData dictionary
                    if (summaryData.ContainsKey(combinedKey))
                    {
                        // Sum the values for the current combined key
                        summaryData[combinedKey][0] += totalCount;
                        summaryData[combinedKey][1] += okCount;
                        summaryData[combinedKey][2] += pkCount;
                    }
                    else
                    {
                        // Create a new entry for the current combined key
                        summaryData[combinedKey] = new int[] { totalCount, okCount, pkCount };
                    }
                }

                // Add a summary section in the user's worksheet
                int summaryRow = currentRow + 3;
                int headerRow = summaryRow + 1; // Save the header row number
                userWorksheet.Cells[summaryRow, 1] = "SrNo";
                userWorksheet.Cells[summaryRow, 2] = "UserName";
                userWorksheet.Cells[summaryRow, 3] = "PartyCode";
                userWorksheet.Cells[summaryRow, 4] = "WeightRange";
                userWorksheet.Cells[summaryRow, 5] = "Count";
                userWorksheet.Cells[summaryRow, 6] = "OK";
                userWorksheet.Cells[summaryRow, 7] = "PK";

                summaryRow++;

                int summarySerialNumber = 1;

                int totalCountSummary = 0;
                int totalOkCountSummary = 0;
                int totalPkCountSummary = 0;

                // Create a list to store the filtered party codes
                List<string> filteredPartyCodes = new List<string>();

                foreach (var summaryEntry in summaryData)
                {
                    string combinedKey = summaryEntry.Key;
                    string[] keyData = combinedKey.Split('[');
                    string partyCode = keyData[0];
                    string weightRange = keyData[1].Trim().TrimEnd(']'); // Trim the closing square bracket
                    int[] summaryValues = summaryEntry.Value;
                    int summaryTotalCount = summaryValues[0];
                    int summaryOkCount = summaryValues[1];
                    int summaryPkCount = summaryValues[2];

                    // Write the summary data to the user's worksheet
                    userWorksheet.Cells[summaryRow, 1] = summarySerialNumber.ToString(); // Convert to string to ensure consistent serial number format
                    userWorksheet.Cells[summaryRow, 2] = userName;
                    userWorksheet.Cells[summaryRow, 3] = partyCode;
                    userWorksheet.Cells[summaryRow, 4] = $"[{weightRange}]"; // Added closing square bracket
                    userWorksheet.Cells[summaryRow, 5] = summaryTotalCount;
                    userWorksheet.Cells[summaryRow, 6] = summaryOkCount;
                    userWorksheet.Cells[summaryRow, 7] = summaryPkCount;

                    totalCountSummary += summaryTotalCount; // Accumulate the total count
                    totalOkCountSummary += summaryOkCount; // Accumulate the total OK count
                    totalPkCountSummary += summaryPkCount; // Accumulate the total PK count

                    summaryRow++; // Move to the next row
                    summarySerialNumber++; // Increment the serial number
                }

                // Add the total count to partyCodeSummary
                userWorksheet.Cells[summaryRow + 1, 4] = "TOTAL";
                userWorksheet.Cells[summaryRow + 1, 5] = totalCountSummary;
                userWorksheet.Cells[summaryRow + 1, 6] = totalOkCountSummary;
                userWorksheet.Cells[summaryRow + 1, 7] = totalPkCountSummary;

                // Sort the PartyCode column in ascending order
                Microsoft.Office.Interop.Excel.Range sortRange = userWorksheet.Range[userWorksheet.Cells[headerRow, 1], userWorksheet.Cells[summaryRow, 7]]; // Use headerRow instead of summaryRow for the start cell
                sortRange.Sort(sortRange.Columns[3], Microsoft.Office.Interop.Excel.XlSortOrder.xlAscending); // Sort based on the PartyCode column (3rd column)

                // Auto-fit the columns for better visibility in the user's worksheet
                userWorksheet.Columns.AutoFit();
            }

            // Get the name of the current folder
            string folderName = new DirectoryInfo(csvFolderPath).Name;
            
            // Create a timestamp for the backup folder (e.g., current date)
            string backupFolderName = DateTime.Now.ToString("ddMMyyyy");

            // Path to the backup folder
            string backupFolderPath = Path.Combine("C:\\tempcsvbckup", backupFolderName);

            // Create the backup folder
            Directory.CreateDirectory(backupFolderPath);

            // Save the Excel workbook with the same name as the folder and replace if it exists
            string excelFilePath = Path.Combine(csvFolderPath, folderName + ".xlsx");

            if (File.Exists(excelFilePath))
            {
                File.Delete(excelFilePath); // Delete the existing file
            }

            excelWorkbook.SaveAs(excelFilePath); // Save the workbook

            // Close the Excel application and release resources
            excelWorkbook.Close();
            excelApp.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);

            // Define the path to the new folder
            string newFolderPath = Path.Combine(csvFolderPath, "Done Production Report");

            // Check if the folder already exists
            if (Directory.Exists(newFolderPath))
            {
                // If it exists, delete it and all its contents
                Directory.Delete(newFolderPath, true);
            }

            // Create the new folder
            Directory.CreateDirectory(newFolderPath);

            // Move all the CSV files to the new folder and backup folder
            if (chkMoveFiles.Checked)
            {
                foreach (var csvFile in csvFiles)
                {
                    string newFilePath = Path.Combine(newFolderPath, csvFile.Name);
                    string backupFilePath = Path.Combine(backupFolderPath, csvFile.Name);

                    if (File.Exists(backupFilePath))
                    {
                        File.Delete(backupFilePath); // Delete the existing file in the backup folder
                    }

                    File.Copy(csvFile.FullName, backupFilePath); // Copy to the backup folder
                    File.Move(csvFile.FullName, newFilePath); // Move to the new folder
                }
            }

            // Display a message to indicate that the data has been read and saved in the dictionary
            MessageBox.Show("CSV data has been read and saved calculation in the Excel Sheet.", "Data Read", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LoadExcelFile(string filePath)
        {
            // Create an instance of the Excel application
            excelApp = new Microsoft.Office.Interop.Excel.Application();

            // Open the workbook
            excelWorkbook = excelApp.Workbooks.Open(filePath);

            // Clear the existing data in the ComboBox
            comboBoxSheets.Items.Clear();

            // Add sheet names to the ComboBox
            foreach (Worksheet sheet in excelWorkbook.Sheets)
            {
                comboBoxSheets.Items.Add(sheet.Name);
            }

            // Detach event handlers
            comboBoxSheets.SelectedIndexChanged -= comboBoxSheets_SelectedIndexChanged;
            btnViewReport.Click -= btnViewReport_Click;

            // Set the selected item to the first sheet
            comboBoxSheets.SelectedIndex = 0;

            // Update the metroGrid1 with the selected sheet
            UpdateMetroGridWithSheet(comboBoxSheets.SelectedItem.ToString());

            // Attach event handlers
            comboBoxSheets.SelectedIndexChanged += comboBoxSheets_SelectedIndexChanged;
            btnViewReport.Click += btnViewReport_Click;
        }

        private void UpdateMetroGridWithSheet(string sheetName)
        {
            if (excelWorkbook != null)
            {
                // Get the specified sheet
                Worksheet sheet = excelWorkbook.Sheets[sheetName];

                // Clear the existing data in the metroGrid control
                metroGrid1.Rows.Clear();
                metroGrid1.Columns.Clear();

                // Get the range of used cells in the sheet
                Range usedRange = sheet.UsedRange;

                // Check if the used range has any data
                if (usedRange.Value != null)
                {
                    // Add columns to the metroGrid control
                    for (int col = 1; col <= usedRange.Columns.Count; col++)
                    {
                        var columnName = ((Range)usedRange.Cells[1, col]).Value;
                        metroGrid1.Columns.Add(columnName.ToString(), columnName.ToString());
                    }

                    // Add rows to the metroGrid control
                    for (int row = 2; row <= usedRange.Rows.Count; row++)
                    {
                        var rowData = new List<object>();
                        for (int col = 1; col <= usedRange.Columns.Count; col++)
                        {
                            var cellValue = ((Range)usedRange.Cells[row, col]).Value;
                            rowData.Add(cellValue);
                        }
                        metroGrid1.Rows.Add(rowData.ToArray());
                    }
                }
            }
        }

        private void btnViewReport_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtExcelFilePath01.Text))
            {
                string filePath = txtExcelFilePath01.Text;
                LoadExcelFile(filePath);
            }
            else
            {
                MessageBox.Show("Please select an Excel file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBoxSheets_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedSheet = comboBoxSheets.SelectedItem.ToString();
            UpdateMetroGridWithSheet(selectedSheet);
        }

        private void btnExcelBrowse(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files|*.xlsx;*.xls|All Files|*.*";
            openFileDialog.Title = "Select an Excel file";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtExcelFilePath01.Text = openFileDialog.FileName;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Clean up resources and close Excel application
            if (excelWorkbook != null)
            {
                try
                {
                    excelWorkbook.Close(false);
                }
                finally
                {
                    Marshal.ReleaseComObject(excelWorkbook);
                    excelWorkbook = null;
                }
            }

            if (excelApp != null)
            {
                try
                {
                    excelApp.Quit();
                    excelApp.Quit();
                }
                finally
                {
                    Marshal.ReleaseComObject(excelApp);
                    excelApp = null;
                }
            }
        }

        private void metroGrid1_SelectionChanged(object sender, EventArgs e)
        {
            CalculateSelectedCellsTotal();
        }

        private void CalculateSelectedCellsTotal()
        {
            int total = 0;

            // Iterate over the selected cells in metroGrid1
            foreach (DataGridViewCell cell in metroGrid1.SelectedCells)
            {
                // Check if the cell value is numeric
                if (cell.Value != null && int.TryParse(cell.Value.ToString(), out int cellValue))
                {
                    // Add the cell value to the total
                    total += cellValue;
                }
            }

            // Display the total in a label
            lblTotal.Text = "Total: " + total.ToString();
        }
    }
}
