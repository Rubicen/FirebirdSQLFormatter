namespace FormatSQLFirebird
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.rtxtIn = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.rtxtOut = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnFormat = new System.Windows.Forms.Button();
            this.btnUndo = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtxtIn
            // 
            this.rtxtIn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxtIn.Location = new System.Drawing.Point(15, 46);
            this.rtxtIn.Name = "rtxtIn";
            this.rtxtIn.Size = new System.Drawing.Size(582, 586);
            this.rtxtIn.TabIndex = 0;
            this.rtxtIn.Text = resources.GetString("rtxtIn.Text");
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47F));
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.rtxtOut, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.rtxtIn, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(12, 12, 12, 12);
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 95F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1277, 647);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label3.Location = new System.Drawing.Point(687, 13);
            this.label3.Margin = new System.Windows.Forms.Padding(12, 1, 1, 1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(577, 29);
            this.label3.TabIndex = 5;
            this.label3.Text = "Formatted";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // rtxtOut
            // 
            this.rtxtOut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxtOut.Location = new System.Drawing.Point(678, 46);
            this.rtxtOut.Name = "rtxtOut";
            this.rtxtOut.Size = new System.Drawing.Size(584, 586);
            this.rtxtOut.TabIndex = 2;
            this.rtxtOut.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label1.Location = new System.Drawing.Point(24, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(12, 1, 1, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(575, 29);
            this.label1.TabIndex = 3;
            this.label1.Text = "Raw";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.btnFormat, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.btnUndo, 0, 3);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(603, 46);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(69, 586);
            this.tableLayoutPanel2.TabIndex = 6;
            // 
            // btnFormat
            // 
            this.btnFormat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFormat.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFormat.Location = new System.Drawing.Point(3, 178);
            this.btnFormat.Name = "btnFormat";
            this.btnFormat.Size = new System.Drawing.Size(63, 81);
            this.btnFormat.TabIndex = 0;
            this.btnFormat.Text = ">";
            this.btnFormat.UseVisualStyleBackColor = true;
            this.btnFormat.Click += new System.EventHandler(this.btnPlainToOstendo_Click);
            // 
            // btnUndo
            // 
            this.btnUndo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnUndo.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUndo.Location = new System.Drawing.Point(3, 323);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(63, 81);
            this.btnUndo.TabIndex = 1;
            this.btnUndo.Text = "<";
            this.btnUndo.UseVisualStyleBackColor = true;
            this.btnUndo.Click += new System.EventHandler(this.btnOstendoToPlain_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1277, 647);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Form1";
            this.Text = "Format SQL App";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtxtIn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox rtxtOut;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnFormat;
        private System.Windows.Forms.Button btnUndo;
    }
}

