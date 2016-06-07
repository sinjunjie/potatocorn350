namespace SWEN_Delonix_Regia_HMS
{
    partial class Useraccount_and_login_data
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
            this.components = new System.ComponentModel.Container();
            this.junjieDBDataSet = new SWEN_Delonix_Regia_HMS.JunjieDBDataSet();
            this.junjieDBDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.junjieDBDataSet2 = new SWEN_Delonix_Regia_HMS.JunjieDBDataSet2();
            this.accountBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.accountTableAdapter = new SWEN_Delonix_Regia_HMS.JunjieDBDataSet2TableAdapters.AccountTableAdapter();
            this.accountIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usernameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.passwordDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isAdminDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.junjieDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.junjieDBDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.junjieDBDataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // junjieDBDataSet
            // 
            this.junjieDBDataSet.DataSetName = "JunjieDBDataSet";
            this.junjieDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // junjieDBDataSetBindingSource
            // 
            this.junjieDBDataSetBindingSource.DataSource = this.junjieDBDataSet;
            this.junjieDBDataSetBindingSource.Position = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.accountIdDataGridViewTextBoxColumn,
            this.usernameDataGridViewTextBoxColumn,
            this.passwordDataGridViewTextBoxColumn,
            this.isAdminDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.accountBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(0, 1);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(808, 232);
            this.dataGridView1.TabIndex = 0;
            // 
            // junjieDBDataSet2
            // 
            this.junjieDBDataSet2.DataSetName = "JunjieDBDataSet2";
            this.junjieDBDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // accountBindingSource
            // 
            this.accountBindingSource.DataMember = "Account";
            this.accountBindingSource.DataSource = this.junjieDBDataSet2;
            // 
            // accountTableAdapter
            // 
            this.accountTableAdapter.ClearBeforeFill = true;
            // 
            // accountIdDataGridViewTextBoxColumn
            // 
            this.accountIdDataGridViewTextBoxColumn.DataPropertyName = "accountId";
            this.accountIdDataGridViewTextBoxColumn.HeaderText = "accountId";
            this.accountIdDataGridViewTextBoxColumn.Name = "accountIdDataGridViewTextBoxColumn";
            this.accountIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // usernameDataGridViewTextBoxColumn
            // 
            this.usernameDataGridViewTextBoxColumn.DataPropertyName = "username";
            this.usernameDataGridViewTextBoxColumn.HeaderText = "username";
            this.usernameDataGridViewTextBoxColumn.Name = "usernameDataGridViewTextBoxColumn";
            // 
            // passwordDataGridViewTextBoxColumn
            // 
            this.passwordDataGridViewTextBoxColumn.DataPropertyName = "password";
            this.passwordDataGridViewTextBoxColumn.HeaderText = "password";
            this.passwordDataGridViewTextBoxColumn.Name = "passwordDataGridViewTextBoxColumn";
            // 
            // isAdminDataGridViewTextBoxColumn
            // 
            this.isAdminDataGridViewTextBoxColumn.DataPropertyName = "isAdmin";
            this.isAdminDataGridViewTextBoxColumn.HeaderText = "isAdmin";
            this.isAdminDataGridViewTextBoxColumn.Name = "isAdminDataGridViewTextBoxColumn";
            // 
            // Useraccount_and_login_data
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 245);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Useraccount_and_login_data";
            this.Text = "Useraccount_and_login_data";
            this.Load += new System.EventHandler(this.Useraccount_and_login_data_Load);
            ((System.ComponentModel.ISupportInitialize)(this.junjieDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.junjieDBDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.junjieDBDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private JunjieDBDataSet junjieDBDataSet;
        private System.Windows.Forms.BindingSource junjieDBDataSetBindingSource;
        private System.Windows.Forms.DataGridView dataGridView1;
        private JunjieDBDataSet2 junjieDBDataSet2;
        private System.Windows.Forms.BindingSource accountBindingSource;
        private JunjieDBDataSet2TableAdapters.AccountTableAdapter accountTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn accountIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usernameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn passwordDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn isAdminDataGridViewTextBoxColumn;

    }
}