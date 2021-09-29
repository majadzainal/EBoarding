namespace EBoarding
{
    partial class FormPaxLists
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPaxLists));
            this.printDocument = new System.Drawing.Printing.PrintDocument();
            this.panelPaxList = new System.Windows.Forms.Panel();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUP = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnTandai = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.dgvPaxList = new System.Windows.Forms.DataGridView();
            this.dgi_number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgi_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgi_no_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgi_category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgi_seat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgi_print = new System.Windows.Forms.DataGridViewImageColumn();
            this.dgi_isPrint = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.BOOK_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TICKET_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID_NUMBER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PAX_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PAX_TYPE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SHIP_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SUBCLASS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DEP_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ORG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DES = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRINT_BY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SHIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DECK_CABIN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.panelPaxList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaxList)).BeginInit();
            this.SuspendLayout();
            // 
            // printDocument
            // 
            this.printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument_PrintPage);
            // 
            // panelPaxList
            // 
            this.panelPaxList.BackColor = System.Drawing.Color.PaleTurquoise;
            this.panelPaxList.BackgroundImage = global::EBoarding.Properties.Resources.PRINT_BACK;
            this.panelPaxList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelPaxList.Controls.Add(this.btnDown);
            this.panelPaxList.Controls.Add(this.btnUP);
            this.panelPaxList.Controls.Add(this.btnPrint);
            this.panelPaxList.Controls.Add(this.btnTandai);
            this.panelPaxList.Controls.Add(this.btnCancel);
            this.panelPaxList.Controls.Add(this.dgvPaxList);
            this.panelPaxList.Location = new System.Drawing.Point(3, 2);
            this.panelPaxList.Name = "panelPaxList";
            this.panelPaxList.Size = new System.Drawing.Size(1042, 554);
            this.panelPaxList.TabIndex = 1;
            // 
            // btnDown
            // 
            this.btnDown.BackColor = System.Drawing.Color.Transparent;
            this.btnDown.BackgroundImage = global::EBoarding.Properties.Resources.DOWN;
            this.btnDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDown.FlatAppearance.BorderSize = 0;
            this.btnDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDown.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDown.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnDown.Location = new System.Drawing.Point(1007, 410);
            this.btnDown.Margin = new System.Windows.Forms.Padding(4);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(35, 35);
            this.btnDown.TabIndex = 159;
            this.btnDown.UseVisualStyleBackColor = false;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnUP
            // 
            this.btnUP.BackColor = System.Drawing.Color.Transparent;
            this.btnUP.BackgroundImage = global::EBoarding.Properties.Resources.UP;
            this.btnUP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUP.FlatAppearance.BorderSize = 0;
            this.btnUP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUP.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUP.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnUP.Location = new System.Drawing.Point(1007, 126);
            this.btnUP.Margin = new System.Windows.Forms.Padding(4);
            this.btnUP.Name = "btnUP";
            this.btnUP.Size = new System.Drawing.Size(35, 35);
            this.btnUP.TabIndex = 158;
            this.btnUP.UseVisualStyleBackColor = false;
            this.btnUP.Click += new System.EventHandler(this.btnUP_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.ForeColor = System.Drawing.Color.Linen;
            this.btnPrint.Location = new System.Drawing.Point(720, 485);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(302, 52);
            this.btnPrint.TabIndex = 157;
            this.btnPrint.Text = "PRINT";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnTandai
            // 
            this.btnTandai.BackColor = System.Drawing.Color.LimeGreen;
            this.btnTandai.FlatAppearance.BorderSize = 0;
            this.btnTandai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTandai.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTandai.ForeColor = System.Drawing.Color.Linen;
            this.btnTandai.Location = new System.Drawing.Point(374, 485);
            this.btnTandai.Margin = new System.Windows.Forms.Padding(4);
            this.btnTandai.Name = "btnTandai";
            this.btnTandai.Size = new System.Drawing.Size(302, 52);
            this.btnTandai.TabIndex = 156;
            this.btnTandai.Text = "TANDAI SEMUA";
            this.btnTandai.UseVisualStyleBackColor = false;
            this.btnTandai.Click += new System.EventHandler(this.btnTandai_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Red;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.Linen;
            this.btnCancel.Location = new System.Drawing.Point(16, 485);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(302, 52);
            this.btnCancel.TabIndex = 155;
            this.btnCancel.Text = "BATAL";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // dgvPaxList
            // 
            this.dgvPaxList.AllowUserToAddRows = false;
            this.dgvPaxList.AllowUserToDeleteRows = false;
            this.dgvPaxList.AllowUserToResizeColumns = false;
            this.dgvPaxList.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvPaxList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPaxList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dgvPaxList.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvPaxList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPaxList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.OrangeRed;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPaxList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPaxList.ColumnHeadersHeight = 40;
            this.dgvPaxList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgi_number,
            this.dgi_name,
            this.dgi_no_id,
            this.dgi_category,
            this.dgi_seat,
            this.dgi_print,
            this.dgi_isPrint,
            this.BOOK_CODE,
            this.TICKET_NO,
            this.ID_NUMBER,
            this.PAX_NAME,
            this.PAX_TYPE,
            this.SHIP_NO,
            this.SUBCLASS,
            this.DEP_DATE,
            this.ORG,
            this.DES,
            this.PRINT_BY,
            this.SHIP,
            this.DECK_CABIN});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Emoji", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPaxList.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPaxList.EnableHeadersVisualStyles = false;
            this.dgvPaxList.Location = new System.Drawing.Point(47, 103);
            this.dgvPaxList.MultiSelect = false;
            this.dgvPaxList.Name = "dgvPaxList";
            this.dgvPaxList.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.OrangeRed;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe MDL2 Assets", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPaxList.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvPaxList.RowHeadersVisible = false;
            this.dgvPaxList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvPaxList.Size = new System.Drawing.Size(947, 327);
            this.dgvPaxList.TabIndex = 1;
            this.dgvPaxList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPaxList_CellClick);
            // 
            // dgi_number
            // 
            this.dgi_number.HeaderText = "No.";
            this.dgi_number.Name = "dgi_number";
            this.dgi_number.ReadOnly = true;
            this.dgi_number.Width = 30;
            // 
            // dgi_name
            // 
            this.dgi_name.HeaderText = "Nama";
            this.dgi_name.Name = "dgi_name";
            this.dgi_name.ReadOnly = true;
            this.dgi_name.Width = 360;
            // 
            // dgi_no_id
            // 
            this.dgi_no_id.HeaderText = "No.Id";
            this.dgi_no_id.Name = "dgi_no_id";
            this.dgi_no_id.ReadOnly = true;
            this.dgi_no_id.Width = 220;
            // 
            // dgi_category
            // 
            this.dgi_category.HeaderText = "Kategori";
            this.dgi_category.Name = "dgi_category";
            this.dgi_category.ReadOnly = true;
            this.dgi_category.Width = 110;
            // 
            // dgi_seat
            // 
            this.dgi_seat.HeaderText = "Seat";
            this.dgi_seat.Name = "dgi_seat";
            this.dgi_seat.ReadOnly = true;
            this.dgi_seat.Width = 150;
            // 
            // dgi_print
            // 
            this.dgi_print.HeaderText = "Print";
            this.dgi_print.Image = global::EBoarding.Properties.Resources.UNCHECKED2_5;
            this.dgi_print.Name = "dgi_print";
            this.dgi_print.ReadOnly = true;
            this.dgi_print.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgi_print.Width = 60;
            // 
            // dgi_isPrint
            // 
            this.dgi_isPrint.HeaderText = "IsPirnt";
            this.dgi_isPrint.Name = "dgi_isPrint";
            this.dgi_isPrint.ReadOnly = true;
            this.dgi_isPrint.Visible = false;
            // 
            // BOOK_CODE
            // 
            this.BOOK_CODE.HeaderText = "BOOK_CODE";
            this.BOOK_CODE.Name = "BOOK_CODE";
            this.BOOK_CODE.ReadOnly = true;
            this.BOOK_CODE.Visible = false;
            // 
            // TICKET_NO
            // 
            this.TICKET_NO.HeaderText = "TICKET_NO";
            this.TICKET_NO.Name = "TICKET_NO";
            this.TICKET_NO.ReadOnly = true;
            this.TICKET_NO.Visible = false;
            // 
            // ID_NUMBER
            // 
            this.ID_NUMBER.HeaderText = "ID_NUMBER";
            this.ID_NUMBER.Name = "ID_NUMBER";
            this.ID_NUMBER.ReadOnly = true;
            this.ID_NUMBER.Visible = false;
            // 
            // PAX_NAME
            // 
            this.PAX_NAME.HeaderText = "PAX_NAME";
            this.PAX_NAME.Name = "PAX_NAME";
            this.PAX_NAME.ReadOnly = true;
            this.PAX_NAME.Visible = false;
            // 
            // PAX_TYPE
            // 
            this.PAX_TYPE.HeaderText = "PAX_TYPE";
            this.PAX_TYPE.Name = "PAX_TYPE";
            this.PAX_TYPE.ReadOnly = true;
            this.PAX_TYPE.Visible = false;
            // 
            // SHIP_NO
            // 
            this.SHIP_NO.HeaderText = "SHIP_NO";
            this.SHIP_NO.Name = "SHIP_NO";
            this.SHIP_NO.ReadOnly = true;
            this.SHIP_NO.Visible = false;
            // 
            // SUBCLASS
            // 
            this.SUBCLASS.HeaderText = "SUBCLASS";
            this.SUBCLASS.Name = "SUBCLASS";
            this.SUBCLASS.ReadOnly = true;
            this.SUBCLASS.Visible = false;
            // 
            // DEP_DATE
            // 
            this.DEP_DATE.HeaderText = "DEP_DATE";
            this.DEP_DATE.Name = "DEP_DATE";
            this.DEP_DATE.ReadOnly = true;
            this.DEP_DATE.Visible = false;
            // 
            // ORG
            // 
            this.ORG.HeaderText = "ORG";
            this.ORG.Name = "ORG";
            this.ORG.ReadOnly = true;
            this.ORG.Visible = false;
            // 
            // DES
            // 
            this.DES.HeaderText = "DES";
            this.DES.Name = "DES";
            this.DES.ReadOnly = true;
            this.DES.Visible = false;
            // 
            // PRINT_BY
            // 
            this.PRINT_BY.HeaderText = "PRINT_BY";
            this.PRINT_BY.Name = "PRINT_BY";
            this.PRINT_BY.ReadOnly = true;
            this.PRINT_BY.Visible = false;
            // 
            // SHIP
            // 
            this.SHIP.HeaderText = "SHIP";
            this.SHIP.Name = "SHIP";
            this.SHIP.ReadOnly = true;
            this.SHIP.Visible = false;
            // 
            // DECK_CABIN
            // 
            this.DECK_CABIN.HeaderText = "DECK_CABIN";
            this.DECK_CABIN.Name = "DECK_CABIN";
            this.DECK_CABIN.ReadOnly = true;
            this.DECK_CABIN.Visible = false;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "Print";
            this.dataGridViewImageColumn1.Image = global::EBoarding.Properties.Resources.CHECKED;
            this.dataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn1.Width = 50;
            // 
            // FormPaxLists
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(1048, 559);
            this.Controls.Add(this.panelPaxList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormPaxLists";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormPaxLists";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panelPaxList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaxList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelPaxList;
        private System.Windows.Forms.DataGridView dgvPaxList;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnTandai;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnUP;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Drawing.Printing.PrintDocument printDocument;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgi_number;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgi_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgi_no_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgi_category;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgi_seat;
        private System.Windows.Forms.DataGridViewImageColumn dgi_print;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgi_isPrint;
        private System.Windows.Forms.DataGridViewTextBoxColumn BOOK_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn TICKET_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_NUMBER;
        private System.Windows.Forms.DataGridViewTextBoxColumn PAX_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn PAX_TYPE;
        private System.Windows.Forms.DataGridViewTextBoxColumn SHIP_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn SUBCLASS;
        private System.Windows.Forms.DataGridViewTextBoxColumn DEP_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn ORG;
        private System.Windows.Forms.DataGridViewTextBoxColumn DES;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRINT_BY;
        private System.Windows.Forms.DataGridViewTextBoxColumn SHIP;
        private System.Windows.Forms.DataGridViewTextBoxColumn DECK_CABIN;
    }
}