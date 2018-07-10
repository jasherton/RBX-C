namespace SharpUpdate
{
    partial class SharpUpdateInfoForm
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
            this.CloseOut = new System.Windows.Forms.Button();
            this.txtDescription = new System.Windows.Forms.Label();
            this.apply = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CloseOut
            // 
            this.CloseOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseOut.ForeColor = System.Drawing.Color.White;
            this.CloseOut.Location = new System.Drawing.Point(214, 0);
            this.CloseOut.Name = "CloseOut";
            this.CloseOut.Size = new System.Drawing.Size(46, 20);
            this.CloseOut.TabIndex = 4;
            this.CloseOut.Text = "X";
            this.CloseOut.UseVisualStyleBackColor = true;
            this.CloseOut.Click += new System.EventHandler(this.CloseOut_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.txtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.ForeColor = System.Drawing.Color.White;
            this.txtDescription.Location = new System.Drawing.Point(12, 84);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(236, 337);
            this.txtDescription.TabIndex = 5;
            this.txtDescription.Click += new System.EventHandler(this.txtDescription_Click);
            // 
            // apply
            // 
            this.apply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.apply.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.apply.ForeColor = System.Drawing.Color.White;
            this.apply.Location = new System.Drawing.Point(24, 45);
            this.apply.Name = "apply";
            this.apply.Size = new System.Drawing.Size(89, 26);
            this.apply.TabIndex = 7;
            this.apply.Text = "Apply Update";
            this.apply.UseVisualStyleBackColor = true;
            this.apply.Click += new System.EventHandler(this.apply_Click);
            // 
            // SharpUpdateInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.ClientSize = new System.Drawing.Size(260, 430);
            this.ControlBox = false;
            this.Controls.Add(this.apply);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.CloseOut);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SharpUpdateInfoForm";
            this.Text = "SharpUpdateInfoForm";
            this.Load += new System.EventHandler(this.SharpUpdateInfoForm_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SharpUpdateInfoForm_MouseDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CloseOut;
        private System.Windows.Forms.Label txtDescription;
        private System.Windows.Forms.Button apply;
    }
}