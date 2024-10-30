using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;

namespace XMLSigner.ui
{
    partial class frmPhanQuyen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null; 
        private string bMaNguoiDung;
        private System.Windows.Forms.ComboBox cbNguoiDung;
        private CheckBox chkAll;
        private Button CmdHuy;
        private Button CmdKetThuc;
        private Button CmdLuu;

        //private DataSet ds;
        //private DataSet dsGrid;
        private GridControl grid1;
        private GridColumn gridColumn1;
        private GridColumn gridColumn2;
        private GridColumn gridColumn3;
        private GridView gridView1;
        private Label label1;
        private RepositoryItemCheckEdit repositoryItemCheckEdit1;

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
            DevExpress.XtraGrid.GridFormatRule gridFormatRule1 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleExpression formatConditionRuleExpression1 = new DevExpress.XtraEditors.FormatConditionRuleExpression();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPhanQuyen));
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cbNguoiDung = new System.Windows.Forms.ComboBox();
            this.grid1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.CmdLuu = new System.Windows.Forms.Button();
            this.CmdHuy = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.CmdKetThuc = new System.Windows.Forms.Button();
            this.chkAll = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Mục";
            this.gridColumn1.FieldName = "Muc";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 78;
            // 
            // cbNguoiDung
            // 
            this.cbNguoiDung.FormattingEnabled = true;
            this.cbNguoiDung.Location = new System.Drawing.Point(121, 13);
            this.cbNguoiDung.Name = "cbNguoiDung";
            this.cbNguoiDung.Size = new System.Drawing.Size(313, 21);
            this.cbNguoiDung.TabIndex = 0;
            this.cbNguoiDung.SelectedIndexChanged += new System.EventHandler(this.cbNguoiDung_SelectedIndexChanged);
            // 
            // grid1
            // 
            this.grid1.Location = new System.Drawing.Point(26, 44);
            this.grid1.MainView = this.gridView1;
            this.grid1.Name = "grid1";
            this.grid1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.grid1.Size = new System.Drawing.Size(408, 378);
            this.grid1.TabIndex = 1;
            this.grid1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
            gridFormatRule1.ApplyToRow = true;
            gridFormatRule1.Column = this.gridColumn1;
            gridFormatRule1.ColumnApplyTo = this.gridColumn1;
            gridFormatRule1.Name = "Format0";
            formatConditionRuleExpression1.Appearance.ForeColor = System.Drawing.Color.Red;
            formatConditionRuleExpression1.Appearance.Options.UseForeColor = true;
            formatConditionRuleExpression1.Expression = "Contains([Muc], \'00\')";
            gridFormatRule1.Rule = formatConditionRuleExpression1;
            this.gridView1.FormatRules.Add(gridFormatRule1);
            this.gridView1.GridControl = this.grid1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Tên mục";
            this.gridColumn2.FieldName = "TenMuc";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 248;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Gán quyền";
            this.gridColumn3.ColumnEdit = this.repositoryItemCheckEdit1;
            this.gridColumn3.FieldName = "chon";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 64;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // CmdLuu
            // 
            this.CmdLuu.Location = new System.Drawing.Point(104, 457);
            this.CmdLuu.Name = "CmdLuu";
            this.CmdLuu.Size = new System.Drawing.Size(75, 23);
            this.CmdLuu.TabIndex = 3;
            this.CmdLuu.Text = "Lưu";
            this.CmdLuu.UseVisualStyleBackColor = true;
            this.CmdLuu.Click += new System.EventHandler(this.CmdLuu_Click);
            // 
            // CmdHuy
            // 
            this.CmdHuy.Location = new System.Drawing.Point(185, 457);
            this.CmdHuy.Name = "CmdHuy";
            this.CmdHuy.Size = new System.Drawing.Size(75, 23);
            this.CmdHuy.TabIndex = 4;
            this.CmdHuy.Text = "Bỏ qua";
            this.CmdHuy.UseVisualStyleBackColor = true;
            this.CmdHuy.Click += new System.EventHandler(this.CmdHuy_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Tên user";
            // 
            // CmdKetThuc
            // 
            this.CmdKetThuc.Location = new System.Drawing.Point(266, 457);
            this.CmdKetThuc.Name = "CmdKetThuc";
            this.CmdKetThuc.Size = new System.Drawing.Size(75, 23);
            this.CmdKetThuc.TabIndex = 7;
            this.CmdKetThuc.Text = "Kết thúc";
            this.CmdKetThuc.UseVisualStyleBackColor = true;
            this.CmdKetThuc.Click += new System.EventHandler(this.CmdKetThuc_Click);
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(26, 429);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(126, 17);
            this.chkAll.TabIndex = 8;
            this.chkAll.Text = "Chọn/Bỏ chọn tất cả";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // frmPhanQuyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 492);
            this.Controls.Add(this.chkAll);
            this.Controls.Add(this.CmdKetThuc);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CmdHuy);
            this.Controls.Add(this.CmdLuu);
            this.Controls.Add(this.grid1);
            this.Controls.Add(this.cbNguoiDung);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPhanQuyen";
            this.Text = "Phân quyền người dùng trên menu";
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}