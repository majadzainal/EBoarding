using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EBoarding
{
    public partial class FormMenu : Form
    {
        string pin = string.Empty;
        string counterPrint = string.Empty;
        bool isPin = true;
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
        public FormMenu(string pinRec, string counterPrintRec)
        {
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;

            this.Location = new Point(w - (this.Width + 40), h - (this.Height + 80));
            pin = pinRec;
            counterPrint = counterPrintRec;
            InitializeComponent();
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {
            txtCounterPrint.Location = new Point(txtPin.Location.X, txtPin.Location.Y);
            lblPinCounter.Text = "Masukan PIN.";
            InitButton();
        }

        private void InitButton()
        {
            int border = 15;

            btn0.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn0.Width, btn0.Height, border, border));
            btn1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn1.Width, btn1.Height, border, border));
            btn2.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn2.Width, btn2.Height, border, border));
            btn3.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn3.Width, btn3.Height, border, border));
            btn4.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn4.Width, btn4.Height, border, border));
            btn5.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn5.Width, btn5.Height, border, border));
            btn6.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn6.Width, btn6.Height, border, border));
            btn7.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn7.Width, btn7.Height, border, border));
            btn8.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn8.Width, btn8.Height, border, border));
            btn9.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn9.Width, btn9.Height, border, border));
            btnDel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnDel.Width, btnDel.Height, border, border));
            btnBack.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnBack.Width, btnBack.Height, border, border));
            btnOk.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnOk.Width, btnOk.Height, border, border));
            txtPin.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, txtPin.Width, txtPin.Height, border, border));
            txtCounterPrint.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, txtCounterPrint.Width, txtCounterPrint.Height, border, border));
        }



        private void btnBack_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
            catch (Exception ex)
            {
                ShowCustomDialog(ex.Message);
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (isPin)
                {
                    var pinNew = txtPin.Text;
                    if (pin.ToUpper() == pinNew.ToUpper())
                    {
                        txtPin.Visible = false;
                        txtCounterPrint.Visible = true;
                        isPin = false;
                        lblPinCounter.Text = "Masukan Counter";
                    }
                    else
                    {
                        throw new Exception("PIN is invalid!");
                    }
                }
                else
                {
                    JustSaveCounterPrint();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                ShowCustomDialog(ex.Message);
            }
        }

        private void JustSaveCounterPrint()
        {
            var counterPrint = txtCounterPrint.Text;
            if (File.Exists(path.counterPrintPath))
                File.WriteAllText(path.counterPrintPath, (counterPrint).ToString());
        }

        private void ShowCustomDialog(string message)
        {
            CustomDialog dialog = new CustomDialog(message);
            dialog.ShowDialog();
            this.Show();
        }

        private void SetToTextPin(string text)
        {
            var textBefore = txtPin.Text;
            var textAfter = textBefore + text;
            txtPin.Text = textAfter;

            SetFocusedPin();
        }

        private void SetFocusedPin()
        {
            ActiveControl = txtPin;
            int lengthText = txtPin.TextLength;
            txtPin.SelectionStart = lengthText;
        }

        private void SetToPrintCounterText(string text)
        {
            var textBefore = txtCounterPrint.Text;
            var textAfter = textBefore + text;
            txtCounterPrint.Text = textAfter;

            SetFocusedCounterPrint();
        }

        private void SetFocusedCounterPrint()
        {
            ActiveControl = txtCounterPrint;
            int lengthText = txtCounterPrint.TextLength;
            txtCounterPrint.SelectionStart = lengthText;
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            try
            {
                var text = btn1.Text;

                if (isPin)
                    SetToTextPin(text);
                else
                    SetToPrintCounterText(text);
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

                if (isPin)
                    SetToTextPin(text);
                else
                    SetToPrintCounterText(text);
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

                if (isPin)
                    SetToTextPin(text);
                else
                    SetToPrintCounterText(text);
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

                if (isPin)
                    SetToTextPin(text);
                else
                    SetToPrintCounterText(text);
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

                if (isPin)
                    SetToTextPin(text);
                else
                    SetToPrintCounterText(text);
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

                if (isPin)
                    SetToTextPin(text);
                else
                    SetToPrintCounterText(text);
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

                if (isPin)
                    SetToTextPin(text);
                else
                    SetToPrintCounterText(text);
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

                if (isPin)
                    SetToTextPin(text);
                else
                    SetToPrintCounterText(text);
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

                if (isPin)
                    SetToTextPin(text);
                else
                    SetToPrintCounterText(text);
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

                if (isPin)
                    SetToTextPin(text);
                else
                    SetToPrintCounterText(text);
            }
            catch (Exception ex)
            {
                ShowCustomDialog(ex.Message);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (isPin)
                    txtPin.Text = "";
                else
                    txtCounterPrint.Text = "";
            }
            catch (Exception ex)
            {
                ShowCustomDialog(ex.Message);
            }
        }
    }
}
