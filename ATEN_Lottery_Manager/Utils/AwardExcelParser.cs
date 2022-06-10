using ATEN_Util;
using ATEN_Util.Model;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace ATEN_Lottery_Manager.Utils
{
    class AwardExcelParser
    {
        private const int NUM_OF_MIN_CELLS = 4;//欄位數
        private const int COL_IDX_Name = 0;
        private const int COL_IDX_Qty = 1;
        private const int COL_IDX_Seq = 2;
        //private const int COL_IDX_Status = 3;
        private const int COL_IDX_AwardGroup = 3;


        public List<AwardModel> ReadAwaedList(string path)
        {
            List<AwardModel> AeardList = new List<AwardModel>();
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                ISheet sheet = GetFirstSheet(fs, path);//取得頁籤
                IRow headerRow = GetHeaderRow(sheet);//取得欄位

                for (int i = 1; i <= sheet.LastRowNum; i++)
                {
                    IRow row = sheet.GetRow(i);
                    if (row != null)
                    {
                        int intN = 0;
                        AwardModel Award = new AwardModel();
                        string strName = row.GetCell(COL_IDX_Name) == null ? "" : row.GetCell(COL_IDX_Name).ToString().Trim();
                        string strQty = row.GetCell(COL_IDX_Qty) == null ? "" : row.GetCell(COL_IDX_Qty).ToString().Trim();
                        string strSeq = row.GetCell(COL_IDX_Seq) == null ? "" : row.GetCell(COL_IDX_Seq).ToString().Trim();
                        string strAwardGroup = row.GetCell(COL_IDX_AwardGroup) == null ? "" : row.GetCell(COL_IDX_AwardGroup).ToString().Trim().ToUpper();
                        if (string.IsNullOrEmpty(strName))//檢核獎項名稱是否空值
                        {
                            throw new Exception(string.Format("第 {0} 筆資料【獎項名稱】不可空值", i));
                        }
                        else
                        {
                            Award.name = strName;
                        }
                        if (string.IsNullOrEmpty(strQty))//檢核獎項名額是否空值
                        {
                            throw new Exception(string.Format("第 {0} 筆資料【獎項名額】不可空值", i));
                        }

                        if (string.IsNullOrEmpty(strSeq))//檢核獎項順序是否空值
                        {
                            throw new Exception(string.Format("第 {0} 筆資料【獎項順序】不可空值", i));
                        }

                        if (string.IsNullOrEmpty(strAwardGroup)) //獎項分類
                        {
                            throw new Exception(string.Format("第 {0} 筆資料【獎項分類】不可空值", i));
                        }
                        if (Int32.TryParse(strQty, out intN))//檢核獎項名額是否數字
                        {
                            Award.qty = strQty;
                        }
                        else
                        {
                            throw new Exception(string.Format("第 {0} 筆資料【獎項名額】需為數字", i));
                        }
                        if (Int32.TryParse(strSeq, out intN))//檢核獎項順序是否數字
                        {
                            Award.seq = strSeq;
                        }
                        else
                        {
                            throw new Exception(string.Format("第 {0} 筆資料【獎項順序】需為數字", i));
                        }
                        if (strAwardGroup.Length > 1)
                        {
                            throw new Exception(string.Format("第 {0} 筆資料【獎項分類】需為A~Z", i));
                        }
                        Regex eng = new Regex("^[A-Z]+$");
                        if (eng.IsMatch(strAwardGroup))//判別獎項分類是否為A~Z
                        {
                            Award.awardGroup = strAwardGroup;
                        }
                        else
                        {
                            throw new Exception(string.Format("第 {0} 筆資料【獎項分類】需為A~Z", i));
                        }
                        //檢核順序有無重複
                        int intSet = AeardList.IndexOf(AeardList.Find(x => x.seq == strSeq));
                        if (intSet > 0)
                        {
                            throw new Exception(string.Format("第 {0} 筆資料【獎項順序】與第 {1} 筆資料重複", i, intSet + 1));
                        }
                        AeardList.Add(Award);
                    }
                }
            }
            return AeardList;
        }

        /// <summary>
        /// 取得頁籤
        /// </summary>
        /// <param name="fs">檔名</param>
        /// <param name="path">路徑</param>
        /// <returns></returns>
        private ISheet GetFirstSheet(FileStream fs, string path)
        {
            ISheet sheet = new XSSFWorkbook(fs).GetSheetAt(0);

            if (sheet.LastRowNum < 2)
            {
                throw new Exception(string.Format("無法匯入空的 Excel: {0}", path));
            }

            return sheet;
        }

        /// <summary>
        /// 取得欄位
        /// </summary>
        /// <param name="sheet">頁籤</param>
        /// <returns></returns>
        private IRow GetHeaderRow(ISheet sheet)
        {
            IRow row = sheet.GetRow(0);

            if (row.LastCellNum != NUM_OF_MIN_CELLS)
            {
                throw new Exception(string.Format(
                    "標題欄位必需為 Name, Qty,  AwardGroup: 欄位數量={0}",
                    row.LastCellNum));
            }
            if (false == "Name".Equals(row.GetCell(COL_IDX_Name).ToString()))
            {
                throw new Exception(string.Format("標題第 {0} 欄不是 Name: {1}",
                    COL_IDX_Name, row.GetCell(COL_IDX_Name).ToString()));
            }
            if (false == "Qty".Equals(row.GetCell(COL_IDX_Qty).ToString()))
            {
                throw new Exception(string.Format("標題第 {0} 欄不是 Qty: {1}",
                    COL_IDX_Qty, row.GetCell(COL_IDX_Qty).ToString()));
            }
            if (false == "Seq".Equals(row.GetCell(COL_IDX_Seq).ToString()))
            {
                throw new Exception(string.Format("標題第 {0} 欄不是 Seq: {1}",
                    COL_IDX_Seq, row.GetCell(COL_IDX_Seq).ToString()));
            }

            if (false == "AwardGroup".Equals(row.GetCell(COL_IDX_AwardGroup).ToString()))
            {
                throw new Exception(string.Format("標題第 {0} 欄不是 AwardGroup: {1}",
                    COL_IDX_AwardGroup, row.GetCell(COL_IDX_AwardGroup).ToString()));
            }

            return row;
        }



    }
}
