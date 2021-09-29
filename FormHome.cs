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

namespace EBoarding
{
    public partial class FormHome : Form
    {
        string base_url = string.Empty;
        string rqid = string.Empty;
        string device_id = string.Empty;
        string pin = string.Empty;
        bool isExpired = false;
        WebServices apiServices = new WebServices();
        PATH path = new PATH();
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

        bool isShift = false;

        public class CheckServices
        {
            public string error_code = string.Empty;
        }
        public class ErrorResponse
        {
            public string error_code = string.Empty;
            public string error_message = string.Empty;
        }

        //public string[,] arrTest1 = {
        //                        { "ABNER P WORIASI", "9105011809900001", "A", "N/A", "N/A", "N/A", "M", "111563200002342", "N", "0", "774000", "0", "774000" },
        //                        { "ABNER P WORIASI", "9105011809900001", "A", "N/A", "N/A", "N/A", "M", "111563200002342", "N", "0", "774000", "0", "774000" },
        //                    };
        
        public FormHome()
        {
            InitializeComponent();
            ShowFirstForm();
        }

        private void ShowFirstForm()
        {
            try
            {
                int w = Screen.PrimaryScreen.Bounds.Width;
                int h = Screen.PrimaryScreen.Bounds.Height;
                this.Location = new Point(0, 0);
                this.Size = new Size(w, h);


                int x = (w / 2) - 170;
                int y = (h / 2) - 130;

                //txtBookingCode.Focus();
                ActiveControl = txtBookingCode;

                int panelKeyWidth = panelKeyboard.Width;
                int panelKeyHeigth = panelKeyboard.Height;
                int panelKeyX = 0;
                int panelKeyY = 0;

                int panelHeight = ((h / 2) + (h / 8)) - 100;
                int panelLeftWidth = (w / 2) - 40;
                int panelLeftHeigth = panelHeight;

                int panelRightWidth = (w / 2) - 40;
                int panelRightHeigth = panelHeight;
                int panelRightX = panelLeftWidth;

                panelKeyX = (w - panelKeyWidth) / 2;
                panelKeyY = h - panelKeyHeigth;

                panelKeyboard.Location = new Point(panelKeyX, panelKeyY);

                panelLeft.Size = new Size(panelLeftWidth, panelLeftHeigth);
                panelLeft.Location = new Point(20, 100);

                panelRight.Size = new Size(panelRightWidth + 20, panelRightHeigth);
                panelRight.Location = new Point(panelRightX + 60, 100);

                panelTime.Size = new Size((w/2) - 40, (h / 35));
                panelTime.Location = new Point(0, 0);

                panelTime1.Size = new Size((w / 2) - 40, (h / 35));
                panelTime1.Location = new Point(0, panelTime.Size.Height);

                panelBookingCode.Size = new Size(panelLeftWidth, panelBookingCode.Height);
                panelBookingCode.Location = new Point(0, ((panelLeftHeigth - panelBookingCode.Height) / 3));

                lblKodeBooking.Location = new Point((panelBookingCode.Width - lblKodeBooking.Width) / 2, 0);

                txtBookingCode.Size = new Size(panelBookingCode.Width / 2, txtBookingCode.Height);
                txtBookingCode.Location = new Point((panelBookingCode.Width - txtBookingCode.Width) / 2, (lblKodeBooking.Height + 20));
                btnSubmit.Location = new Point((panelBookingCode.Width - btnSubmit.Width) / 2, (panelBookingCode.Height - btnSubmit.Height));

                btnMenu.Location = new Point(w - 60, panelLeftHeigth + 5);

                InitButton();
                TimeSetup();
                timerTime_Tick(null, null);

            }
            catch (Exception ex)
            {
                ShowCustomDialog(ex.Message);
            }
        }
        private void FormHome_Load(object sender, EventArgs e)
        {
            try
            {
                DateTime now = DateTime.Now;
                DateTime validDate;
                if (DateTime.TryParseExact("01-11-2021",
                                            "dd-MM-yyyy",
                                            CultureInfo.InvariantCulture,
                                            DateTimeStyles.None,
                    out validDate))
                {
                    //valid date
                }
                else
                {
                    //invalid date
                }

                if (now >= validDate) 
                {
                    isExpired = true;
                    throw new Exception("Please contact your developer. (email : maja.dzainal@gmail.com)");
                }
                if (File.Exists(path.ConfigPath))
                {
                    using (StreamReader sr = new StreamReader(path.ConfigPath))
                    {
                        string[] line1 = sr.ReadLine().Split(' ');
                        string[] line2 = sr.ReadLine().Split(' ');
                        string[] line3 = sr.ReadLine().Split(' ');
                        string[] line4 = sr.ReadLine().Split(' ');
                        sr.Close();

                        base_url = line1[1];
                        rqid = line2[1];
                        device_id = line3[1];
                        pin = line4[1];
                    }
                }
                else
                    throw new Exception("File config.txt not found or format file is incorrect!");

                JustGetCounterPrint();
            }
            catch (Exception ex)
            {
                ShowCustomDialog(ex.Message);
                if (isExpired) {
                    this.Close();
                }
            }
        }

        private void JustGetCounterPrint()
        {
            if (File.Exists(path.counterPrintPath))
            {
                using (StreamReader sr = new StreamReader(path.counterPrintPath))
                {
                    string line1 = sr.ReadLine();
                    sr.Close();
                    lblPaperCount.Text = line1;
                }
            }
            else
                throw new Exception("File printCounter.txt not found or format file is incorrect!");
        }

        private void InitButton()
        {
            int border = 15;

            btnMenu.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnMenu.Width, btnMenu.Height, 35, 35));
            btnSubmit.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnSubmit.Width, btnSubmit.Height, border, border));
            txtBookingCode.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, txtBookingCode.Width, txtBookingCode.Height, border, border));

            btn1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn1.Width, btn1.Height, border, border));
            btn2.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn2.Width, btn2.Height, border, border));
            btn3.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn3.Width, btn3.Height, border, border));
            btn4.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn4.Width, btn4.Height, border, border));
            btn5.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn5.Width, btn5.Height, border, border));
            btn6.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn6.Width, btn6.Height, border, border));
            btn7.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn7.Width, btn7.Height, border, border));
            btn8.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn8.Width, btn8.Height, border, border));
            btn9.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn9.Width, btn9.Height, border, border));
            btn0.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn0.Width, btn0.Height, border, border));
            btnQ.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnQ.Width, btnQ.Height, border, border));
            btnW.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnW.Width, btnW.Height, border, border));
            btnE.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnE.Width, btnE.Height, border, border));
            btnR.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnR.Width, btnR.Height, border, border));
            btnT.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnT.Width, btnT.Height, border, border));
            btnY.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnY.Width, btnY.Height, border, border));
            btnU.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnU.Width, btnU.Height, border, border));
            btnI.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnI.Width, btnI.Height, border, border));
            btnO.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnO.Width, btnO.Height, border, border));
            btnP.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnP.Width, btnP.Height, border, border));
            btnA.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnA.Width, btnA.Height, border, border));
            btnS.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnS.Width, btnS.Height, border, border));
            btnD.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnD.Width, btnD.Height, border, border));
            btnF.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnF.Width, btnF.Height, border, border));
            btnG.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnG.Width, btnG.Height, border, border));
            btnH.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnH.Width, btnH.Height, border, border));
            btnJ.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnJ.Width, btnJ.Height, border, border));
            btnK.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnK.Width, btnK.Height, border, border));
            btnL.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnL.Width, btnL.Height, border, border));
            btnZ.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnZ.Width, btnZ.Height, border, border));
            btnX.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnX.Width, btnX.Height, border, border));
            btnC.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnC.Width, btnC.Height, border, border));
            btnV.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnV.Width, btnV.Height, border, border));
            btnB.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnB.Width, btnB.Height, border, border));
            btnN.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnN.Width, btnN.Height, border, border));
            btnM.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnM.Width, btnM.Height, border, border));
            btnTitikKoma.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnTitikKoma.Width, btnTitikKoma.Height, border, border));
            btnKoma.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnKoma.Width, btnKoma.Height, border, border));
            btnTitik.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnTitik.Width, btnTitik.Height, border, border));
            btnSlash.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnSlash.Width, btnSlash.Height, border, border));

            btnHapus.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnHapus.Width, btnHapus.Height, border, border));
            btnHapusSemua.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnHapusSemua.Width, btnHapusSemua.Height, border, border));
            btnShift.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnShift.Width, btnShift.Height, border, border));
            btnSpasi.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnSpasi.Width, btnSpasi.Height, border, border));
        }

        private void TimeSetup()
        {
            var dtmDate = DateTime.Today;
            lblDate.Text = dtmDate.ToLongDateString();
        }

        private void timerTime_Tick(object sender, EventArgs e)
        {
            try
            {
                lblTime.Text = DateTime.Now.ToString("HH:mm:ss");
                var paperCount = lblPaperCount.Text;
                var notInt = 0;
                if (Int32.TryParse(paperCount, out notInt)) 
                {
                    if (Convert.ToInt32(paperCount) < 30)
                        lblWarning.Visible = true;
                    else
                        lblWarning.Visible = false;
                }
                
            }
            catch (Exception ex)
            {
                DialogResult dr = MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                                           MessageBoxIcon.Error);
                this.Show();
            }
        }


        private void SetTextToSubmitText(string text)
        {
            var textBefore = txtBookingCode.Text;
            if (textBefore.Length >= 6)
            {
                return;
            }
            else {
                var textAfter = textBefore + text;
                txtBookingCode.Text = textAfter;
            }
            
            SetFocusedBookingCode();
        }

        private void SetFocusedBookingCode()
        {
            ActiveControl = txtBookingCode;
            int lengthText = txtBookingCode.TextLength;
            txtBookingCode.SelectionStart = lengthText;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string bookingCode = string.Empty;
                bookingCode = txtBookingCode.Text;
                if (bookingCode != string.Empty)
                {
                    Task<HttpResponseMessage> task = apiServices.CheckBookingCode(base_url, rqid, bookingCode, device_id);
                    task.Wait();
                    var response = task.Result; //break point here
                   
                    if (Convert.ToInt32(response.StatusCode) == 200)
                        JustValidateResponse(response);
                    else
                    {
                        JustCreateLog(response.StatusCode.ToString(), response.ReasonPhrase);
                        throw new Exception(Convert.ToInt32(response.StatusCode) + "\n" + "Message : " + response.ReasonPhrase);
                    }


                }
                else
                    throw new Exception("Tolong masukan kode booking !");
            }
            catch (Exception ex)
            {
                JustCreateLog("000", ex.Message);
                ShowCustomDialog(ex.Message);
            }
        }

        private void JustValidateResponse(HttpResponseMessage response)
        {
            string result = response.Content.ReadAsStringAsync().Result;
            CheckServices check = JsonConvert.DeserializeObject<CheckServices>(result);
            ValidResponse data = new ValidResponse();
            data.error_code = "0";
            var test1 = JsonConvert.SerializeObject(data);

            //JustConvertToValidateData(result);

            if (check.error_code.ToUpper() == "0".ToUpper())
                JustConvertToValidateData(result);
            else
                JustConvertToInvalidData(result);
        }

        private void JustConvertToInvalidData(string result)
        {
            ErrorResponse errData = new ErrorResponse();
            errData = JsonConvert.DeserializeObject<ErrorResponse>(result);
            JustCreateLog(errData.error_code, errData.error_message);

            throw new Exception(errData.error_message);
        }

        private void JustConvertToValidateData(string result)
        {
            ValidResponse resData = new ValidResponse();
            resData = JsonConvert.DeserializeObject<ValidResponse>(result);
            string message = "Request Success. Booking code : " + resData.BOOK_CODE + " Number Code: " + resData.NUM_CODE;
            JustCreateLog(resData.error_code, message);

            var counterPrint = lblPaperCount.Text;
            FormPaxLists dialogPrint = new FormPaxLists(resData, base_url, device_id, counterPrint);

            var resultDialog = dialogPrint.ShowDialog();
            if (resultDialog == DialogResult.OK)
            {
                JustGetCounterPrint();
                btnHapusSemua_Click(null, null);
            }
            else
            {
                JustGetCounterPrint();
                dialogPrint.Close();
                btnHapusSemua_Click(null, null);
            }

        }

        public void JustCreateLog(string status_code, string message)
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
        private void ShowCustomDialog(string message)
        {
            CustomDialog dialog = new CustomDialog(message);
            dialog.ShowDialog();
            this.Show();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            try
            {
                var counterPrint = lblPaperCount.Text;
                FormMenu dialog = new FormMenu(pin, counterPrint);
                dialog.ShowDialog();
                this.Show();

                if (dialog.DialogResult == DialogResult.OK)
                {
                    JustGetCounterPrint();
                }
                else
                    return;

            }
            catch (Exception ex)
            {
                ShowCustomDialog(ex.Message);
            }
        }


        #region KEYBOARD FITUR
        private void btnHapus_Click(object sender, EventArgs e)
        {
            try
            {
                var textBefore = txtBookingCode.Text;
                if (textBefore.Length > 0)
                {
                    var textAfter = textBefore.Remove(textBefore.Length - 1);
                    txtBookingCode.Text = textAfter;
                    SetFocusedBookingCode();
                }
                else
                    return;


            }
            catch (Exception ex)
            {
                ShowCustomDialog(ex.Message);
            }
        }

        private void btnHapusSemua_Click(object sender, EventArgs e)
        {
            try
            {
                txtBookingCode.Text = "";
                SetFocusedBookingCode();
            }
            catch (Exception ex)
            {
                ShowCustomDialog(ex.Message);
            }
        }
        private void btnSpasi_Click(object sender, EventArgs e)
        {
            try
            {
                var textBefore = txtBookingCode.Text;
                var textAfter = textBefore + " ";
                txtBookingCode.Text = textAfter;
                SetFocusedBookingCode();

            }
            catch (Exception ex)
            {
                ShowCustomDialog(ex.Message);
            }
        }


        private void btnShift_Click(object sender, EventArgs e)
        {
            try
            {
                isShift = !isShift;
                SetTextButtonShift();
                SetFocusedBookingCode();
            }
            catch (Exception ex)
            {
                ShowCustomDialog(ex.Message);
            }
        }

        private void SetTextButtonShift()
        {
            if (isShift)
                SetToLower();
            else
                SetToUpper();

        }

        private void SetToUpper()
        {
            btnShift.BackColor = Color.DodgerBlue;
            btn1.Text = btn1.Text.ToUpper();
            btn2.Text = btn2.Text.ToUpper();
            btn3.Text = btn3.Text.ToUpper();
            btn4.Text = btn4.Text.ToUpper();
            btn5.Text = btn5.Text.ToUpper();
            btn6.Text = btn6.Text.ToUpper();
            btn7.Text = btn7.Text.ToUpper();
            btn8.Text = btn8.Text.ToUpper();
            btn9.Text = btn9.Text.ToUpper();
            btn0.Text = btn0.Text.ToUpper();
            btnQ.Text = btnQ.Text.ToUpper();
            btnW.Text = btnW.Text.ToUpper();
            btnE.Text = btnE.Text.ToUpper();
            btnR.Text = btnR.Text.ToUpper();
            btnT.Text = btnT.Text.ToUpper();
            btnY.Text = btnY.Text.ToUpper();
            btnU.Text = btnU.Text.ToUpper();
            btnI.Text = btnI.Text.ToUpper();
            btnO.Text = btnO.Text.ToUpper();
            btnP.Text = btnP.Text.ToUpper();
            btnA.Text = btnA.Text.ToUpper();
            btnS.Text = btnS.Text.ToUpper();
            btnD.Text = btnD.Text.ToUpper();
            btnF.Text = btnF.Text.ToUpper();
            btnG.Text = btnG.Text.ToUpper();
            btnH.Text = btnH.Text.ToUpper();
            btnJ.Text = btnJ.Text.ToUpper();
            btnK.Text = btnK.Text.ToUpper();
            btnL.Text = btnL.Text.ToUpper();
            btnZ.Text = btnZ.Text.ToUpper();
            btnX.Text = btnX.Text.ToUpper();
            btnC.Text = btnC.Text.ToUpper();
            btnV.Text = btnV.Text.ToUpper();
            btnB.Text = btnB.Text.ToUpper();
            btnN.Text = btnN.Text.ToUpper();
            btnM.Text = btnM.Text.ToUpper();
            btnTitikKoma.Text = ";";
            btnKoma.Text = ",";
            btnTitik.Text = ".";
            btnSlash.Text = "/";
        }

        private void SetToLower()
        {
            btnShift.BackColor = Color.Red;
            btn1.Text = btn1.Text.ToLower();
            btn2.Text = btn2.Text.ToLower();
            btn3.Text = btn3.Text.ToLower();
            btn4.Text = btn4.Text.ToLower();
            btn5.Text = btn5.Text.ToLower();
            btn6.Text = btn6.Text.ToLower();
            btn7.Text = btn7.Text.ToLower();
            btn8.Text = btn8.Text.ToLower();
            btn9.Text = btn9.Text.ToLower();
            btn0.Text = btn0.Text.ToLower();
            btnQ.Text = btnQ.Text.ToLower();
            btnW.Text = btnW.Text.ToLower();
            btnE.Text = btnE.Text.ToLower();
            btnR.Text = btnR.Text.ToLower();
            btnT.Text = btnT.Text.ToLower();
            btnY.Text = btnY.Text.ToLower();
            btnU.Text = btnU.Text.ToLower();
            btnI.Text = btnI.Text.ToLower();
            btnO.Text = btnO.Text.ToLower();
            btnP.Text = btnP.Text.ToLower();
            btnA.Text = btnA.Text.ToLower();
            btnS.Text = btnS.Text.ToLower();
            btnD.Text = btnD.Text.ToLower();
            btnF.Text = btnF.Text.ToLower();
            btnG.Text = btnG.Text.ToLower();
            btnH.Text = btnH.Text.ToLower();
            btnJ.Text = btnJ.Text.ToLower();
            btnK.Text = btnK.Text.ToLower();
            btnL.Text = btnL.Text.ToLower();
            btnZ.Text = btnZ.Text.ToLower();
            btnX.Text = btnX.Text.ToLower();
            btnC.Text = btnC.Text.ToLower();
            btnV.Text = btnV.Text.ToLower();
            btnB.Text = btnB.Text.ToLower();
            btnN.Text = btnN.Text.ToLower();
            btnM.Text = btnM.Text.ToLower();
            btnTitikKoma.Text = ":";
            btnKoma.Text = "<";
            btnTitik.Text = ">";
            btnSlash.Text = "?";
        }
        #endregion KEYBOARD FITUR

        #region KEYBOARD EVENT
        private void btn1_Click(object sender, EventArgs e)
        {
            try
            {
                var text = btn1.Text;
                SetTextToSubmitText(text);
            }
            catch (Exception ex)
            {
                ShowCustomDialog(ex.Message);
            }
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            try
            {
                var text = btn2.Text;
                SetTextToSubmitText(text);
            }
            catch (Exception ex)
            {
                ShowCustomDialog(ex.Message);
            }
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            try
            {
                var text = btn3.Text;
                SetTextToSubmitText(text);
            }
            catch (Exception ex)
            {
                ShowCustomDialog(ex.Message);
            }
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            try
            {
                var text = btn4.Text;
                SetTextToSubmitText(text);
            }
            catch (Exception ex)
            {
                ShowCustomDialog(ex.Message);
            }
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            try
            {
                var text = btn5.Text;
                SetTextToSubmitText(text);
            }
            catch (Exception ex)
            {
                ShowCustomDialog(ex.Message);
            }
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            try
            {
                var text = btn6.Text;
                SetTextToSubmitText(text);
            }
            catch (Exception ex)
            {
                ShowCustomDialog(ex.Message);
            }
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            try
            {
                var text = btn7.Text;
                SetTextToSubmitText(text);
            }
            catch (Exception ex)
            {
                ShowCustomDialog(ex.Message);
            }
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            try
            {
                var text = btn8.Text;
                SetTextToSubmitText(text);
            }
            catch (Exception ex)
            {
                ShowCustomDialog(ex.Message);
            }
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            try
            {
                var text = btn9.Text;
                SetTextToSubmitText(text);
            }
            catch (Exception ex)
            {
                ShowCustomDialog(ex.Message);
            }
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            try
            {
                var text = btn0.Text;
                SetTextToSubmitText(text);
            }
            catch (Exception ex)
            {
                ShowCustomDialog(ex.Message);
            }
        }

        private void btnQ_Click(object sender, EventArgs e)
        {
            try
            {
                var text = btnQ.Text;
                SetTextToSubmitText(text);
            }
            catch (Exception ex)
            {
                ShowCustomDialog(ex.Message);
            }
        }

        private void btnW_Click(object sender, EventArgs e)
        {
            try
            {
                var text = btnW.Text;
                SetTextToSubmitText(text);
            }
            catch (Exception ex)
            {
                ShowCustomDialog(ex.Message);
            }
        }

        private void btnE_Click(object sender, EventArgs e)
        {
            try
            {
                var text = btnE.Text;
                SetTextToSubmitText(text);
            }
            catch (Exception ex)
            {
                ShowCustomDialog(ex.Message);
            }
        }

        private void btnR_Click(object sender, EventArgs e)
        {
            try
            {
                var text = btnR.Text;
                SetTextToSubmitText(text);
            }
            catch (Exception ex)
            {
                ShowCustomDialog(ex.Message);
            }
        }

        private void btnT_Click(object sender, EventArgs e)
        {
            try
            {
                var text = btnT.Text;
                SetTextToSubmitText(text);
            }
            catch (Exception ex)
            {
                ShowCustomDialog(ex.Message);
            }
        }

        private void btnY_Click(object sender, EventArgs e)
        {
            try
            {
                var text = btnY.Text;
                SetTextToSubmitText(text);
            }
            catch (Exception ex)
            {
                ShowCustomDialog(ex.Message);
            }
        }

        private void btnU_Click(object sender, EventArgs e)
        {
            try
            {
                var text = btnU.Text;
                SetTextToSubmitText(text);
            }
            catch (Exception ex)
            {
                ShowCustomDialog(ex.Message);
            }
        }

        private void btnI_Click(object sender, EventArgs e)
        {
            try
            {
                var text = btnI.Text;
                SetTextToSubmitText(text);
            }
            catch (Exception ex)
            {
                ShowCustomDialog(ex.Message);
            }
        }

        private void btnO_Click(object sender, EventArgs e)
        {
            try
            {
                var text = btnO.Text;
                SetTextToSubmitText(text);
            }
            catch (Exception ex)
            {
                ShowCustomDialog(ex.Message);
            }
        }

        private void btnP_Click(object sender, EventArgs e)
        {
            try
            {
                var text = btnP.Text;
                SetTextToSubmitText(text);
            }
            catch (Exception ex)
            {
                ShowCustomDialog(ex.Message);
            }
        }

        private void btnA_Click(object sender, EventArgs e)
        {
            try
            {
                var text = btnA.Text;
                SetTextToSubmitText(text);
            }
            catch (Exception ex)
            {
                ShowCustomDialog(ex.Message);
            }
        }

        private void btnS_Click(object sender, EventArgs e)
        {
            try
            {
                var text = btnS.Text;
                SetTextToSubmitText(text);
            }
            catch (Exception ex)
            {
                ShowCustomDialog(ex.Message);
            }
        }

        private void btnD_Click(object sender, EventArgs e)
        {
            try
            {
                var text = btnD.Text;
                SetTextToSubmitText(text);
            }
            catch (Exception ex)
            {
                ShowCustomDialog(ex.Message);
            }
        }

        private void btnF_Click(object sender, EventArgs e)
        {
            try
            {
                var text = btnF.Text;
                SetTextToSubmitText(text);
            }
            catch (Exception ex)
            {
                ShowCustomDialog(ex.Message);
            }
        }

        private void btnG_Click(object sender, EventArgs e)
        {
            try
            {
                var text = btnG.Text;
                SetTextToSubmitText(text);
            }
            catch (Exception ex)
            {
                ShowCustomDialog(ex.Message);
            }
        }

        private void btnH_Click(object sender, EventArgs e)
        {
            try
            {
                var text = btnH.Text;
                SetTextToSubmitText(text);
            }
            catch (Exception ex)
            {
                ShowCustomDialog(ex.Message);
            }
        }

        private void btnJ_Click(object sender, EventArgs e)
        {
            try
            {
                var text = btnJ.Text;
                SetTextToSubmitText(text);
            }
            catch (Exception ex)
            {
                ShowCustomDialog(ex.Message);
            }
        }

        private void btnK_Click(object sender, EventArgs e)
        {
            try
            {
                var text = btnK.Text;
                SetTextToSubmitText(text);
            }
            catch (Exception ex)
            {
                ShowCustomDialog(ex.Message);
            }
        }

        private void btnL_Click(object sender, EventArgs e)
        {
            try
            {
                var text = btnL.Text;
                SetTextToSubmitText(text);
            }
            catch (Exception ex)
            {
                ShowCustomDialog(ex.Message);
            }
        }

        private void btnTitikKoma_Click(object sender, EventArgs e)
        {
            try
            {
                var text = btnTitikKoma.Text;
                SetTextToSubmitText(text);
            }
            catch (Exception ex)
            {
                ShowCustomDialog(ex.Message);
            }
        }

        private void btnZ_Click(object sender, EventArgs e)
        {
            try
            {
                var text = btnZ.Text;
                SetTextToSubmitText(text);
            }
            catch (Exception ex)
            {
                ShowCustomDialog(ex.Message);
            }
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            try
            {
                var text = btnX.Text;
                SetTextToSubmitText(text);
            }
            catch (Exception ex)
            {
                ShowCustomDialog(ex.Message);
            }
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            try
            {
                var text = btnC.Text;
                SetTextToSubmitText(text);
            }
            catch (Exception ex)
            {
                ShowCustomDialog(ex.Message);
            }
        }

        private void btnV_Click(object sender, EventArgs e)
        {
            try
            {
                var text = btnV.Text;
                SetTextToSubmitText(text);
            }
            catch (Exception ex)
            {
                ShowCustomDialog(ex.Message);
            }
        }

        private void btnB_Click(object sender, EventArgs e)
        {
            try
            {
                var text = btnB.Text;
                SetTextToSubmitText(text);
            }
            catch (Exception ex)
            {
                ShowCustomDialog(ex.Message);
            }
        }

        private void btnN_Click(object sender, EventArgs e)
        {
            try
            {
                var text = btnN.Text;
                SetTextToSubmitText(text);
            }
            catch (Exception ex)
            {
                ShowCustomDialog(ex.Message);
            }
        }

        private void btnM_Click(object sender, EventArgs e)
        {
            try
            {
                var text = btnM.Text;
                SetTextToSubmitText(text);
            }
            catch (Exception ex)
            {
                ShowCustomDialog(ex.Message);
            }
        }

        private void btnKoma_Click(object sender, EventArgs e)
        {
            try
            {
                var text = btnKoma.Text;
                SetTextToSubmitText(text);
            }
            catch (Exception ex)
            {
                ShowCustomDialog(ex.Message);
            }
        }

        private void btnTitik_Click(object sender, EventArgs e)
        {
            try
            {
                var text = btnTitik.Text;
                SetTextToSubmitText(text);
            }
            catch (Exception ex)
            {
                ShowCustomDialog(ex.Message);
            }
        }

        private void btnSlash_Click(object sender, EventArgs e)
        {
            try
            {
                var text = btnSlash.Text;
                SetTextToSubmitText(text);
            }
            catch (Exception ex)
            {
                ShowCustomDialog(ex.Message);
            }
        }


        #endregion KEYBOARD EVENT
    }                   
}
