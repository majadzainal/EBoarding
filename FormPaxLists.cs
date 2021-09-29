using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static EBoarding.FormHome;

namespace EBoarding
{
    public partial class FormPaxLists : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
            (
                int nLeft,
                int nTop,
                int nRight,
                int nBottom,
                int nWidthEllipse,
                int nHeightEllipse
            );

        PATH path = new PATH();
        WebServices apiServices = new WebServices();
        ValidResponse resData = new ValidResponse();
        List<PAX_DATA> paxDataList = new List<PAX_DATA>();
        List<TICKET_DATA> ticketDataList = new List<TICKET_DATA>();
        string base_url = string.Empty;
        string device_id = string.Empty;
        bool isCheckedAll = false;
        int counterPrint = 0;
        public FormPaxLists(ValidResponse resDataRec, string baseUrl, string deviceId, string counterPrintRec)
        {
            InitializeComponent();
            resData = resDataRec;
            base_url = baseUrl;
            device_id = deviceId;
            if (Int32.TryParse(counterPrintRec, out counterPrint))
            {
                counterPrint = Convert.ToInt32(counterPrintRec);
            }
            ShowFirstForm();
            InitData();
        }

        private void InitData()
        {
            paxDataList = new List<PAX_DATA>();
            int haveList = (resData.PAX_LIST.Length / 16) - 1;

            for (int i = 0; i <= haveList; i++)
            {
                PAX_DATA data = new PAX_DATA();

                data.arr0 = resData.PAX_LIST[i, 0];
                data.arr1 = resData.PAX_LIST[i, 1];
                data.arr2 = resData.PAX_LIST[i, 2];
                data.arr3 = resData.PAX_LIST[i, 3];
                data.arr4 = resData.PAX_LIST[i, 4];
                data.arr5 = resData.PAX_LIST[i, 5];
                data.arr6 = resData.PAX_LIST[i, 6];
                data.arr7 = resData.PAX_LIST[i, 7];
                data.arr8 = resData.PAX_LIST[i, 8];
                data.arr9 = resData.PAX_LIST[i, 9];
                data.arr10 = resData.PAX_LIST[i, 10];
                data.arr11 = resData.PAX_LIST[i, 11];
                data.arr12 = resData.PAX_LIST[i, 12];
                data.arr13 = resData.PAX_LIST[i, 13];
                data.arr14 = resData.PAX_LIST[i, 14];
                data.arr15 = resData.PAX_LIST[i, 15];
                data.arr16 = resData.PAX_LIST[i, 16];
                paxDataList.Add(data);
            }

            ticketDataList = new List<TICKET_DATA>();

            foreach (var item in paxDataList)
            {

                TICKET_DATA data = new TICKET_DATA();
                Task<HttpResponseMessage> task = apiServices.GetCheckIn(base_url, item.arr7, device_id);
                task.Wait();
                var response = task.Result; //break point here

                //HttpResponseMessage response = apiServices.GetCheckIn(base_url, item.arr7, device_id);

                if(Convert.ToInt32(response.StatusCode) == 200)
                    data = JustValidateResponse(response);

                ticketDataList.Add(data);
                var rowIndex = dgvPaxList.Rows.Add();
                JustFillToDataGrid(rowIndex, data);

                var numbering = rowIndex + 1;
                if (numbering % 2 != 1)
                    dgvPaxList.Rows[rowIndex].DefaultCellStyle.BackColor = Color.Khaki;
                else
                    dgvPaxList.Rows[rowIndex].DefaultCellStyle.BackColor = Color.Bisque;

            }
        }

        private TICKET_DATA JustValidateResponse(HttpResponseMessage response)
        {
            TICKET_DATA data = new TICKET_DATA();
            string result = response.Content.ReadAsStringAsync().Result;
            CheckServices check = JsonConvert.DeserializeObject<CheckServices>(result);

            if (check.error_code.ToUpper() == "0".ToUpper())
                data = JsonConvert.DeserializeObject<TICKET_DATA>(result);
            else
                JustConvertToInvalidData(result);


            return data;
        }

        private void JustConvertToInvalidData(string result)
        {
            ErrorResponse errData = new ErrorResponse();
            errData = JsonConvert.DeserializeObject<ErrorResponse>(result);
            JustCreateLog(errData.error_code, errData.error_message);

            throw new Exception(errData.error_message);
        }

        private void JustCreateLog(string status_code, string message)
        {
            var today = DateTime.Today;
            string logName = "LOG_" + today.ToString("yyyy") + today.ToString("MM") + today.ToString("dd");
            var logPath = Environment.CurrentDirectory + "/log/" + logName + ".txt";

            if (!File.Exists(logPath))
            {
                File.CreateText(logPath).Close();
            }

            string logDevId = "Device ID : " + device_id.ToString();
            string logTime = "Time : " + DateTime.Now.ToString("HH:mm:ss");
            string logErrCode = "Code : " + status_code;
            string logMessage = "Message : " + message;

            using (StreamWriter sw = new StreamWriter(logPath, true))
            {
                sw.WriteLine(logDevId + " | " + logTime + " | " + logErrCode + " | " + logMessage);
                sw.Flush();
                sw.Close();
            }
        }

        private void JustFillToDataGrid(int rowIndex, TICKET_DATA data)
        {
            var seat = "";
            PAX_DATA paxData = paxDataList.Find(a => a.arr7.ToUpper() == data.TICKET_NO.ToUpper());
            seat = paxData.arr3 + "/" + paxData.arr4 + "+" + paxData.arr5;
            if (data.DECK_CABIN.ToUpper() == "NON SEAT".ToUpper())
                seat = data.DECK_CABIN;

            dgvPaxList[dgi_number.Index, rowIndex].Value = (Convert.ToInt32(rowIndex) + 1).ToString();
            dgvPaxList[dgi_name.Index, rowIndex].Value = data.PAX_NAME.ToString().ToUpper();
            dgvPaxList[dgi_no_id.Index, rowIndex].Value = data.TICKET_NO.ToUpper();
            dgvPaxList[dgi_category.Index, rowIndex].Value = data.SUBCLASS.ToUpper();
            dgvPaxList[dgi_seat.Index, rowIndex].Value = (seat).ToString().ToUpper();
            dgvPaxList[dgi_isPrint.Index, rowIndex].Value = false;

            dgvPaxList[BOOK_CODE.Index, rowIndex].Value = data.BOOK_CODE.ToUpper();
            dgvPaxList[TICKET_NO.Index, rowIndex].Value = data.TICKET_NO.ToUpper();
            dgvPaxList[ID_NUMBER.Index, rowIndex].Value = data.ID_NUMBER.ToUpper();
            dgvPaxList[PAX_NAME.Index, rowIndex].Value = data.PAX_NAME.ToUpper();
            dgvPaxList[PAX_TYPE.Index, rowIndex].Value = data.PAX_TYPE.ToUpper();
            dgvPaxList[SHIP_NO.Index, rowIndex].Value = data.SHIP_NO.ToUpper();
            dgvPaxList[SUBCLASS.Index, rowIndex].Value = data.SUBCLASS.ToUpper();
            dgvPaxList[DEP_DATE.Index, rowIndex].Value = data.DEP_DATE.ToUpper();
            dgvPaxList[ORG.Index, rowIndex].Value = data.ORG.ToUpper();
            dgvPaxList[DES.Index, rowIndex].Value = data.DES.ToUpper();
            dgvPaxList[PRINT_BY.Index, rowIndex].Value = data.PRINT_BY.ToUpper();
            dgvPaxList[SHIP.Index, rowIndex].Value = data.SHIP.ToUpper();
            dgvPaxList[DECK_CABIN.Index, rowIndex].Value = data.DECK_CABIN.ToUpper();
        }

        private void ShowFirstForm()
        {
            int border = 20;
            int btnBorder = 15;
            this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Width, this.Height, border, border));
            panelPaxList.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panelPaxList.Width, panelPaxList.Height, border, border));

            btnCancel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnCancel.Width, btnCancel.Height, btnBorder, btnBorder));
            btnTandai.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnTandai.Width, btnTandai.Height, btnBorder, btnBorder));
            btnPrint.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnPrint.Width, btnPrint.Height, btnBorder, btnBorder));
            
            btnUP.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnUP.Width, btnUP.Height, btnBorder, btnBorder));
            btnDown.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnDown.Width, btnDown.Height, btnBorder, btnBorder));


            dgvPaxList.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                ShowCustomDialog(ex.Message);
            }
        }

        private void ShowCustomDialog(string message)
        {
            CustomDialog dialog = new CustomDialog(message);
            dialog.ShowDialog();
            this.Show();
        }

        private void dgvPaxList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var isPrint = Convert.ToBoolean(dgvPaxList[dgi_isPrint.Index, e.RowIndex].Value);
                isPrint = !isPrint;

                if (isPrint)
                {
                    dgvPaxList[dgi_print.Index, e.RowIndex].Value = Properties.Resources.CHECKED2_5;
                    dgvPaxList[dgi_isPrint.Index, e.RowIndex].Value = isPrint;
                }

                else
                {
                    dgvPaxList[dgi_print.Index, e.RowIndex].Value = Properties.Resources.UNCHECKED2_5;
                    dgvPaxList[dgi_isPrint.Index, e.RowIndex].Value = isPrint;
                }
            }   
            catch (Exception ex)
            {
                ShowCustomDialog(ex.Message);
            }
        }

        private void btnTandai_Click(object sender, EventArgs e)
        {
            try
            {
                isCheckedAll = !isCheckedAll;
                if (isCheckedAll) {
                    btnTandai.Text = "HAPUS TANDA";
                    foreach (DataGridViewRow row in dgvPaxList.Rows)
                    {
                        dgvPaxList[dgi_print.Index, row.Index].Value = Properties.Resources.CHECKED2_5;
                        dgvPaxList[dgi_isPrint.Index, row.Index].Value = true;
                    }
                }
                else {
                    btnTandai.Text = "TANDAI SEMUA";
                    foreach (DataGridViewRow row in dgvPaxList.Rows)
                    {
                        dgvPaxList[dgi_print.Index, row.Index].Value = Properties.Resources.UNCHECKED2_5;
                        dgvPaxList[dgi_isPrint.Index, row.Index].Value = false;
                    }
                }
                   
                
            }
            catch (Exception ex)
            {
                ShowCustomDialog(ex.Message);
            }
        }

        private int _Line = 0;
        private int _Line_Before = 0;
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                _Line = 0;
                printDocument.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("custom", 800, 300);
                printDocument.Print();
            }
            catch (Exception ex)
            {
                ShowCustomDialog(ex.Message);
            }
        }

        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                List<TICKET_DATA> dataPrintList = new List<TICKET_DATA>();
                dataPrintList = GetDataFromGrid();

                var font24 = new Font("Microsoft Sans Serif", 24, FontStyle.Bold, GraphicsUnit.Point);
                var font16 = new Font("Microsoft Sans Serif", 16, FontStyle.Bold, GraphicsUnit.Point);
                var font14 = new Font("Microsoft Sans Serif", 14, FontStyle.Bold, GraphicsUnit.Point);
                var font13 = new Font("Microsoft Sans Serif", 13, FontStyle.Bold, GraphicsUnit.Point);
                var font13Cal = new Font("Calibri", 13, FontStyle.Bold, GraphicsUnit.Point);
                var font12 = new Font("Microsoft Sans Serif", 12, FontStyle.Bold, GraphicsUnit.Point);
                var font10 = new Font("Microsoft Sans Serif", 10, FontStyle.Bold, GraphicsUnit.Point);
                var font9 = new Font("Microsoft Sans Serif", 9, FontStyle.Bold, GraphicsUnit.Point);
                var font8 = new Font("Microsoft Sans Serif", 8, FontStyle.Regular, GraphicsUnit.Point);
                var font7 = new Font("Microsoft Sans Serif", 7, FontStyle.Regular, GraphicsUnit.Point);
                var font7Bold = new Font("Microsoft Sans Serif", 7, FontStyle.Bold, GraphicsUnit.Point);
                var font6 = new Font("Microsoft Sans Serif", 6, FontStyle.Regular, GraphicsUnit.Point);
                var font5 = new Font("Microsoft Sans Serif", 5, FontStyle.Regular, GraphicsUnit.Point);

                int x = 20;
                int y = 20;
                int col2 = 350;
                int col3 = 440;
                int col4 = 600;
                _Line_Before = _Line;

                if (dataPrintList.Count() >= 1)
                {
                    for (; _Line < dataPrintList.Count(); _Line++)
                    {
                        if (_Line > _Line_Before) {
                            e.HasMorePages = true;
                            return;
                        }
                        TICKET_DATA item = dataPrintList[_Line];
                        PAX_DATA paxData = paxDataList.Find(a => a.arr7.ToUpper() == item.TICKET_NO.ToUpper());
                        string tglSale = "";
                        var year = resData.TRANSACTION_DATE.Substring(0, 4);
                        var month = resData.TRANSACTION_DATE.Substring(4, 2);
                        var day = resData.TRANSACTION_DATE.Substring(6, 2);

                        tglSale = day + "/" + month + "/" + year;


                        DateTime dt;
                        if (DateTime.TryParseExact(item.DEP_DATE,
                                                    "dd-MM-yyyy HH:mm",
                                                    CultureInfo.InvariantCulture,
                                                    DateTimeStyles.None,
                            out dt))
                        {
                            //valid date
                        }
                        else
                        {
                            //invalid date
                        }

                        Bitmap dataBitmap = JustCreateBitmapBarcode(item.TICKET_NO);

                        Pen nPen = new Pen(Color.Black, 1);
                        //e.Graphics.DrawRectangle(nPen, 0, 0, 800, 300);  //COL 1

                        //LINE 1
                        e.Graphics.DrawString("Ship Coupon", font7, Brushes.Black, x + col3, y);
                        e.Graphics.DrawString("Audit Coupon", font7, Brushes.Black, x + col4, y);

                        //LINE 2
                        e.Graphics.DrawString(item.TICKET_NO, font7, Brushes.Black, x + col2, y + 10);
                        e.Graphics.DrawString(item.TICKET_NO, font7, Brushes.Black, x + col3, y + 10);
                        e.Graphics.DrawString(item.TICKET_NO, font7, Brushes.Black, x + col4, y + 10);

                        //LINE 3
                        var orgDes = resData.ORG_NAME + " " + resData.ORG_CALL + " - " + resData.DES_NAME + " " + resData.DES_CALL;
                        var orgDesFix = orgDes.Length > 40 ? orgDes.Substring(0, 40) + "..." : orgDes;
                        e.Graphics.DrawString(orgDesFix.ToUpper(), font10, Brushes.Black, x, y + 20);
                        e.Graphics.DrawString(item.BOOK_CODE, font7, Brushes.Black, x + col2, y + 20);
                        e.Graphics.DrawString(item.BOOK_CODE, font7, Brushes.Black, x + col3, y + 20);
                        e.Graphics.DrawString(item.BOOK_CODE, font7, Brushes.Black, x + col4, y + 20);

                        //COL 1 LINE 4
                        e.Graphics.DrawString(("KELAS "+resData.CLASS+" - "+item.PAX_TYPE).ToUpper(), font10, Brushes.Black, x, y + 40);
                        //COL 1 LINE 5
                        e.Graphics.DrawString(dt.ToString("dd")+" "+ dt.ToString("MMM") + " " + dt.ToString("yyyy") + "/ "+ dt.ToString("HH") +"/ "+resData.SHIP_NAME+"/ VOY "+resData.VOYAGE_NO, font7, Brushes.Black, x, y + 60);

                        var paxNameLeft = item.PAX_NAME + "(" + item.PAX_TYPE + ")";
                        var paxNameLeftFix = paxNameLeft.Length > 30 ? paxNameLeft.Substring(0, 30) + "..." : paxNameLeft;
                        var arr13 = paxData.arr13 != "" ? paxData.arr13 : "-";
                        var arr14 = paxData.arr14 != "" ? paxData.arr14 : "-";
                        var arr15 = paxData.arr15 != "" ? paxData.arr15 : "-";
                        var arr13Fix = arr13.Length > 30 ? arr13.Substring(0, 30) + "..." : arr13;
                        var arr14Fix = arr14.Length > 30 ? arr14.Substring(0, 30) + "..." : arr14;
                        var arr15Fix = arr15.Length > 30 ? arr15.Substring(0, 30) + "..." : arr15;

                        var price = paxData.arr10 != "" ? paxData.arr10 : "0";
                        var admPrice = paxData.arr11 != "" ? paxData.arr11 : "0";
                        var netPrice = paxData.arr12 != "" ? paxData.arr12 : "0";

                        //COL 1 LINE 6
                        int finPrice = 0;
                        int finAdmPrice = 0;
                        int finNetPrice = 0;
                        if (Int32.TryParse(price, out finPrice))
                            finPrice = Convert.ToInt32(price);

                        if (Int32.TryParse(price, out finPrice))
                            finAdmPrice = Convert.ToInt32(admPrice);

                        if (Int32.TryParse(price, out finPrice))
                            finNetPrice = Convert.ToInt32(netPrice);


                        e.Graphics.DrawString(paxNameLeftFix.ToUpper(), font8, Brushes.Black, x, y + 90);
                        e.Graphics.DrawString("Rp."+ Convert.ToInt32(finPrice).ToString("N0") +" + ADM Rp. "+Convert.ToInt32(finAdmPrice).ToString("N0"), font8, Brushes.Black, x, y + 105);
                        e.Graphics.DrawString("NET Rp. " + Convert.ToInt32(finNetPrice).ToString("N0"), font8, Brushes.Black, x, y + 120);
                        e.Graphics.DrawString("DECK/CABIN : " + paxData.arr3 + "/" + paxData.arr4 + "-" + paxData.arr5, font8, Brushes.Black, x, y + 135);
                        e.Graphics.DrawString("Tempat & Tgl. Penjualan : "+ resData.LOCATION +", "+ tglSale, font8, Brushes.Black, x, y + 150);
                        e.Graphics.DrawString(arr13Fix, font8, Brushes.Black, x, y + 165);
                        e.Graphics.DrawString(arr14Fix, font8, Brushes.Black, x, y + 180);
                        e.Graphics.DrawString(arr15Fix, font8, Brushes.Black, x, y + 195);
                        e.Graphics.DrawString("PT. Pelayaran Nasional Indonesia (Persero)", font5, Brushes.Black, x, y + 235);


                        Point newPoint = new Point();
                        newPoint.X = x + 280;
                        newPoint.Y = y + 70;
                        e.Graphics.DrawImage(dataBitmap, newPoint);

                        var paxName = item.PAX_NAME + "(" + item.PAX_TYPE + ")";
                        var paxNameFix = paxName.Length > 21 ? paxName.Substring(0, 21) + "..." : paxName;

                        var kapal = resData.SHIP_NAME + "/VOY " + resData.VOYAGE_NO;
                        var kapalFix = kapal.Length > 23 ? kapal.Substring(0, 23) + "..." : kapal;

                        var fromTix = resData.ORG_NAME + " " + resData.ORG_CALL;
                        var fromTixFix = fromTix.Length > 25 ? fromTix.Substring(0, 25) + "..." : fromTix;

                        var toTix = resData.DES_NAME + " " + resData.DES_CALL;
                        var toTixFix = toTix.Length > 25 ? toTix.Substring(0, 25) + "..." : toTix;

                        //COL 3 LINE 5
                        e.Graphics.DrawString("Nama", font6, Brushes.Black, x + col3, y + 45);
                        e.Graphics.DrawString(paxNameFix.ToUpper(), font7, Brushes.Black, x + col3, y + 55);

                        e.Graphics.DrawString("Kelas - Kategori", font6, Brushes.Black, x + col3, y + 70);
                        e.Graphics.DrawString(("KELAS " + resData.CLASS + " - " + item.PAX_TYPE).ToUpper(), font7, Brushes.Black, x + col3, y + 80);

                        e.Graphics.DrawString("Kapal", font6, Brushes.Black, x + col3, y + 95);
                        e.Graphics.DrawString(kapalFix, font7, Brushes.Black, x + col3, y + 105);

                        e.Graphics.DrawString("Tgl/Jam", font6, Brushes.Black, x + col3, y + 120);
                        e.Graphics.DrawString(dt.ToString("dd") + " " + dt.ToString("MMM") + " " + dt.ToString("yyyy") + "/ " + dt.ToString("HH"), font7, Brushes.Black, x + col3, y + 130);

                        e.Graphics.DrawString("Dari - Ke", font6, Brushes.Black, x + col3, y + 145);
                        e.Graphics.DrawString(fromTixFix, font7, Brushes.Black, x + col3, y + 155);

                        e.Graphics.DrawString(toTixFix, font7, Brushes.Black, x + col3, y + 170);

                        e.Graphics.DrawString("Rp. "+ Convert.ToInt32(finPrice).ToString("N0") + " + Rp. "+ Convert.ToInt32(finAdmPrice).ToString("N0"), font7, Brushes.Black, x + col3, y + 185);

                        e.Graphics.DrawString("NET Rp. "+ Convert.ToInt32(finNetPrice).ToString("N0"), font7, Brushes.Black, x + col3, y + 200);

                        e.Graphics.DrawString("PT. Pelayaran Nasional Indonesia (Persero)", font5, Brushes.Black, x + col3, y + 235);


                        //COL 3 LINE 5
                        e.Graphics.DrawString("Nama", font6, Brushes.Black, x + col4, y + 45);
                        e.Graphics.DrawString(paxNameFix.ToUpper(), font7, Brushes.Black, x + col4, y + 55);

                        e.Graphics.DrawString("Kelas - Kategori", font6, Brushes.Black, x + col4, y + 70);
                        e.Graphics.DrawString(("KELAS " + resData.CLASS + " - " + item.PAX_TYPE).ToUpper(), font7, Brushes.Black, x + col4, y + 80);

                        e.Graphics.DrawString("Kapal", font6, Brushes.Black, x + col4, y + 95);
                        e.Graphics.DrawString(kapalFix, font7, Brushes.Black, x + col4, y + 105);

                        e.Graphics.DrawString("Tgl/Jam", font6, Brushes.Black, x + col4, y + 120);
                        e.Graphics.DrawString(dt.ToString("dd") + " " + dt.ToString("MMM") + " " + dt.ToString("yyyy") + "/ " + dt.ToString("HH"), font7, Brushes.Black, x + col4, y + 130);

                        e.Graphics.DrawString("Dari - Ke", font6, Brushes.Black, x + col4, y + 145);
                        e.Graphics.DrawString(fromTixFix, font7, Brushes.Black, x + col4, y + 155);

                        e.Graphics.DrawString(toTixFix, font7, Brushes.Black, x + col4, y + 170);

                        e.Graphics.DrawString("Rp. " + Convert.ToInt32(finPrice).ToString("N0") + " + Rp. " + Convert.ToInt32(finAdmPrice).ToString("N0"), font7, Brushes.Black, x + col4, y + 185);

                        e.Graphics.DrawString("NET Rp. " + Convert.ToInt32(finNetPrice).ToString("N0"), font7, Brushes.Black, x + col4, y + 200);

                        e.Graphics.DrawString("PT. Pelayaran Nasional Indonesia (Persero)", font5, Brushes.Black, x + col4, y + 235);


                    }
                }
                var tst = _Line;
                if (File.Exists(path.counterPrintPath))
                    File.WriteAllText(path.counterPrintPath, (counterPrint - _Line).ToString());

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                ShowCustomDialog(ex.Message);
            }
        }

        private List<TICKET_DATA> GetDataFromGrid()
        {
            List<TICKET_DATA> dataList = new List<TICKET_DATA>();

            foreach (DataGridViewRow row in dgvPaxList.Rows)
            {
                TICKET_DATA itemData = new TICKET_DATA();
                itemData = JustGetItemFromDataGrid(row);

                if(itemData.is_print)
                    dataList.Add(itemData);
            }

            return dataList;
        }

        private TICKET_DATA JustGetItemFromDataGrid(DataGridViewRow row)
        {
            TICKET_DATA data = new TICKET_DATA();
            string isChecked = GetStringValueFromRowCell(row, dgi_isPrint.Index);
            if (isChecked == string.Empty)
                isChecked = "false";

            data.is_print = Convert.ToBoolean(isChecked);
            data.BOOK_CODE = GetStringValueFromRowCell(row, BOOK_CODE.Index).ToString();
            data.TICKET_NO = GetStringValueFromRowCell(row, TICKET_NO.Index).ToString();
            data.ID_NUMBER = GetStringValueFromRowCell(row, ID_NUMBER.Index).ToString();
            data.PAX_NAME = GetStringValueFromRowCell(row, PAX_NAME.Index).ToString();
            data.PAX_TYPE = GetStringValueFromRowCell(row, PAX_TYPE.Index).ToString();
            data.SHIP_NO = GetStringValueFromRowCell(row, SHIP_NO.Index).ToString();
            data.SUBCLASS = GetStringValueFromRowCell(row, SUBCLASS.Index).ToString();
            data.DEP_DATE = GetStringValueFromRowCell(row, DEP_DATE.Index).ToString();
            data.ORG = GetStringValueFromRowCell(row, ORG.Index).ToString();
            data.DES = GetStringValueFromRowCell(row, DES.Index).ToString();
            data.PRINT_BY = GetStringValueFromRowCell(row, PRINT_BY.Index).ToString();
            data.SHIP = GetStringValueFromRowCell(row, SHIP.Index).ToString();
            data.DECK_CABIN = GetStringValueFromRowCell(row, DECK_CABIN.Index).ToString();

            return data;
        }

        private string GetStringValueFromRowCell(DataGridViewRow row, int index)
        {
            var value = row.Cells[index].Value;
            if (value == null)
                return string.Empty;

            return value.ToString();
        }

        private Bitmap JustCreateBitmapBarcode(string v)
        {
            QRCoder.QRCodeGenerator qrGenerator = new QRCoder.QRCodeGenerator();
            var qrData = qrGenerator.CreateQrCode(v, QRCoder.QRCodeGenerator.ECCLevel.H);
            var qrCode = new QRCoder.QRCode(qrData);
            Bitmap bmp = qrCode.GetGraphic(5);

            return bmp;
        }

        private void btnUP_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvPaxList.FirstDisplayedScrollingRowIndex == 0)
                    return;
                else
                    dgvPaxList.FirstDisplayedScrollingRowIndex = dgvPaxList.FirstDisplayedScrollingRowIndex - 1;
            }
            catch (Exception ex)
            {
                ShowCustomDialog(ex.Message);
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvPaxList.RowCount == dgvPaxList.FirstDisplayedScrollingRowIndex)
                    return;
                else
                    dgvPaxList.FirstDisplayedScrollingRowIndex = dgvPaxList.FirstDisplayedScrollingRowIndex + 1;

            }
            catch (Exception ex)
            {
                ShowCustomDialog(ex.Message);
            }
        }
    }
}
