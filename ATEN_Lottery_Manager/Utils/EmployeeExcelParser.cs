using ATEN_Util;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;

namespace ATEN_Lottery_Manager.Utils
{
    class EmployeeExcelParser
    {
        private const int NUM_OF_MIN_CELLS = 4;
        private const int COL_IDX_ID = 0;
        private const int COL_IDX_NAME = 1;
        private const int COL_IDX_DEPARTMENT = 2;
        private const int COL_IDX_JOB = 3;

        public List<EmployeeModel> ReadEmployeeList(string path)
        {
            List<EmployeeModel> employeeList = new List<EmployeeModel>();

            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                ISheet sheet = GetFirstSheet(fs, path);
                IRow headerRow = GetHeaderRow(sheet);

                Dictionary<int, string> labelDictionary = new Dictionary<int, string>();
                bool hasAwardGroupLabel = FillLabelGroup(headerRow, labelDictionary);

                // process data rows
                for (int i = 1; i <= sheet.LastRowNum; i++)
                {
                    IRow row = sheet.GetRow(i);

                    if (row != null)
                    {
                        EmployeeModel employeeModel = new EmployeeModel()
                        {
                            id = row.GetCell(COL_IDX_ID).ToString(),
                            name = row.GetCell(COL_IDX_NAME).ToString(),
                            department = row.GetCell(COL_IDX_DEPARTMENT).ToString(),
                            job = row.GetCell(COL_IDX_JOB).ToString(),
                            enable = "1",
                            updateTime = DateTime.Now.ToString("yyyyMMddHHmmss")
                        };

                        AssignLabel(row, employeeModel, labelDictionary, hasAwardGroupLabel);

                        employeeList.Add(employeeModel);
                    }
                }
            }

            return employeeList;
        }

        private ISheet GetFirstSheet(FileStream fs, string path)
        {
            ISheet sheet = new XSSFWorkbook(fs).GetSheetAt(0);

            if (sheet.LastRowNum < 2)
            {
                throw new Exception(string.Format("無法匯入空的 Excel: {0}", path));
            }

            return sheet;
        }

        private IRow GetHeaderRow(ISheet sheet)
        {
            IRow row = sheet.GetRow(0);

            if (row.LastCellNum < NUM_OF_MIN_CELLS)
            {
                throw new Exception(string.Format(
                    "標題欄位必需至少包含 ID, Name, Department, Job: 欄位數量={0}",
                    row.LastCellNum));
            }

            if (false == "ID".Equals(row.GetCell(COL_IDX_ID).ToString()))
            {
                throw new Exception(string.Format("標題第 {0} 欄不是 ID: {1}",
                    COL_IDX_ID, row.GetCell(COL_IDX_ID).ToString()));
            }

            if (false == "Name".Equals(row.GetCell(COL_IDX_NAME).ToString()))
            {
                throw new Exception(string.Format("標題第 {0} 欄不是 Name: {1}",
                    COL_IDX_NAME, row.GetCell(COL_IDX_NAME).ToString()));
            }

            if (false == "Department".Equals(row.GetCell(COL_IDX_DEPARTMENT).ToString()))
            {
                throw new Exception(string.Format("標題第 {0} 欄不是 Department: {1}",
                    COL_IDX_DEPARTMENT, row.GetCell(COL_IDX_DEPARTMENT).ToString()));
            }

            if (false == "Job".Equals(row.GetCell(COL_IDX_JOB).ToString()))
            {
                throw new Exception(string.Format("標題第 {0} 欄不是 Job: {1}",
                    COL_IDX_JOB, row.GetCell(COL_IDX_JOB).ToString()));
            }

            return row;
        }

        private bool FillLabelGroup(IRow headerRow, Dictionary<int, string> labelDictionary)
        {
            bool hasAwardGroupLabel = headerRow.LastCellNum > NUM_OF_MIN_CELLS;

            if (true == hasAwardGroupLabel)
            {
                for (int i = NUM_OF_MIN_CELLS; i < headerRow.LastCellNum; i++)
                {
                    string label = headerRow.GetCell(i).ToString();

                    if (label.Length != 1 || label[0] < 'A' || label[0] > 'Z')
                    {
                        throw new Exception(string.Format("群組必需為 A - Z: 目前字元={0}", label));
                    }

                    if (labelDictionary.ContainsValue(label))
                    {
                        throw new Exception(string.Format("群組重覆: 目前字元={0}", label));
                    }

                    labelDictionary.Add(i, label);
                }
            }

            return hasAwardGroupLabel;
        }

        private void AssignLabel(IRow row, EmployeeModel employeeModel,
            Dictionary<int, string> labelDictionary, bool hasAwardGroupLabel)
        {
            if (false == hasAwardGroupLabel)
            {
                employeeModel.awardGroups = "A";
            }
            else
            {
                employeeModel.awardGroups = "";

                foreach (int i in labelDictionary.Keys)
                {
                    ICell cell = row.GetCell(i);

                    if (null == cell)
                    {
                        throw new Exception(string.Format("群組只能為 Y 或 N: 員工編號={0}, 姓名={1}",
                            employeeModel.id, employeeModel.name));
                    }

                    string label = cell.ToString();

                    if (string.IsNullOrEmpty(label)
                        || (false == "Y".Equals(label) && false == "N".Equals(label)))
                    {
                        throw new Exception(string.Format("群組只能為 Y 或 N: 員工編號={0}, 姓名={1}",
                            employeeModel.id, employeeModel.name));
                    }

                    if ("Y".Equals(label))
                    {
                        employeeModel.awardGroups =
                            string.IsNullOrEmpty(employeeModel.awardGroups) ?
                            employeeModel.awardGroups = labelDictionary[i]:
                            employeeModel.awardGroups += "," + labelDictionary[i];
                    }
                }
            }
        }
    }
}
