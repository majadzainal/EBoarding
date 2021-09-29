using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EBoarding
{
    public partial class CustomDialog : Form
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
        public CustomDialog(string messageError)
        {
            InitializeComponent();
            richTextBoxMessage.Text = messageError;
            InitButton();
        }

        private void InitButton()
        {
            int border = 15;
            btnOke.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnOke.Width, btnOke.Height, border, border));


        }

        private void btnOke_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                DialogResult dr = MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                                          MessageBoxIcon.Error);
                this.Show();
            }
        }
    }
}
