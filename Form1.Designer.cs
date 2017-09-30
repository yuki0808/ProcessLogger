using System.Drawing;
using System.Windows.Forms;
namespace ProcessLogger
{
  partial class Form1
  {
    /// <summary>
    /// 必要なデザイナー変数です。
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// 使用中のリソースをすべてクリーンアップします。
    /// </summary>
    /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows フォーム デザイナーで生成されたコード

    /// <summary>
    /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
    /// コード エディターで変更しないでください。
    /// </summary>
    private void InitializeComponent()
    {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
      this.button1 = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.refreshB = new System.Windows.Forms.Button();
      this.stopB = new System.Windows.Forms.Button();
      this.textBox1 = new System.Windows.Forms.TextBox();
      this.secLB = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.processDGV = new System.Windows.Forms.DataGridView();
      this.dgvCB = new System.Windows.Forms.DataGridViewCheckBoxColumn();
      this.dgvPID = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dgvPName = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dgvUsrName = new System.Windows.Forms.DataGridViewTextBoxColumn();
      ((System.ComponentModel.ISupportInitialize)(this.processDGV)).BeginInit();
      this.SuspendLayout();
      // 
      // button1
      // 
      this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.button1.Location = new System.Drawing.Point(37, 479);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(117, 23);
      this.button1.TabIndex = 0;
      this.button1.Text = "開始";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
      this.label1.Location = new System.Drawing.Point(17, 16);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(74, 24);
      this.label1.TabIndex = 2;
      this.label1.Text = "プロセス一覧";
      // 
      // refreshB
      // 
      this.refreshB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.refreshB.Location = new System.Drawing.Point(344, 16);
      this.refreshB.Name = "refreshB";
      this.refreshB.Size = new System.Drawing.Size(56, 23);
      this.refreshB.TabIndex = 0;
      this.refreshB.Text = "更新";
      this.refreshB.UseVisualStyleBackColor = true;
      this.refreshB.Click += new System.EventHandler(this.refreshB_Click);
      // 
      // stopB
      // 
      this.stopB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.stopB.Enabled = false;
      this.stopB.Location = new System.Drawing.Point(263, 479);
      this.stopB.Name = "stopB";
      this.stopB.Size = new System.Drawing.Size(117, 23);
      this.stopB.TabIndex = 0;
      this.stopB.Text = "停止";
      this.stopB.UseVisualStyleBackColor = true;
      this.stopB.Click += new System.EventHandler(this.stopB_Click);
      // 
      // textBox1
      // 
      this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.textBox1.Location = new System.Drawing.Point(329, 445);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new System.Drawing.Size(51, 19);
      this.textBox1.TabIndex = 4;
      this.textBox1.Text = "3";
      this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.textBox1.Enter += new System.EventHandler(this.textBox1_Enter);
      this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
      this.textBox1.Leave += new System.EventHandler(this.textBox1_Leave);
      // 
      // secLB
      // 
      this.secLB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.secLB.AutoSize = true;
      this.secLB.Location = new System.Drawing.Point(264, 448);
      this.secLB.Name = "secLB";
      this.secLB.Size = new System.Drawing.Size(59, 12);
      this.secLB.TabIndex = 2;
      this.secLB.Text = "出力間隔：";
      // 
      // label2
      // 
      this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(386, 448);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(17, 12);
      this.label2.TabIndex = 2;
      this.label2.Text = "秒";
      // 
      // processDGV
      // 
      this.processDGV.AllowUserToAddRows = false;
      this.processDGV.AllowUserToDeleteRows = false;
      this.processDGV.AllowUserToResizeRows = false;
      this.processDGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.processDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.processDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvCB,
            this.dgvPID,
            this.dgvPName,
            this.dgvUsrName});
      this.processDGV.Location = new System.Drawing.Point(21, 47);
      this.processDGV.Name = "processDGV";
      this.processDGV.RowHeadersVisible = false;
      this.processDGV.RowTemplate.Height = 21;
      this.processDGV.Size = new System.Drawing.Size(379, 392);
      this.processDGV.TabIndex = 5;
      // 
      // dgvCB
      // 
      this.dgvCB.HeaderText = "";
      //this.dgvCB.Name = "";
      this.dgvCB.Resizable = System.Windows.Forms.DataGridViewTriState.False;
      this.dgvCB.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
      this.dgvCB.Width = 30;
      // 
      // dgvPID
      // 
      this.dgvPID.HeaderText = "PID";
      this.dgvPID.Name = "dgvPID";
      this.dgvPID.ReadOnly = true;
      this.dgvPID.Width = 80;
      // 
      // dgvPName
      // 
      this.dgvPName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      this.dgvPName.HeaderText = "プロセス名";
      this.dgvPName.Name = "dgvPName";
      this.dgvPName.ReadOnly = true;
      // 
      // dgvUsrName
      // 
      this.dgvUsrName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      this.dgvUsrName.HeaderText = "ユーザー名";
      this.dgvUsrName.Name = "dgvUsrName";
      this.dgvUsrName.ReadOnly = true;
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(417, 514);
      this.Controls.Add(this.processDGV);
      this.Controls.Add(this.textBox1);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.secLB);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.refreshB);
      this.Controls.Add(this.stopB);
      this.Controls.Add(this.button1);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "Form1";
      this.Text = "ProcessLogger Ver.1.0";
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
      ((System.ComponentModel.ISupportInitialize)(this.processDGV)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button refreshB;
    private System.Windows.Forms.Button stopB;
    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.Label secLB;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.DataGridView processDGV;
    private DataGridViewCheckBoxColumn dgvCB;
    private DataGridViewTextBoxColumn dgvPID;
    private DataGridViewTextBoxColumn dgvPName;
    private DataGridViewTextBoxColumn dgvUsrName;

  }
}

