namespace BantayPilaApp
{
    partial class DoctorDashboardUC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvDoctorQueue = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDoctorQueue = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnComplete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoctorQueue)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDoctorQueue
            // 
            this.dgvDoctorQueue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDoctorQueue.Location = new System.Drawing.Point(20, 98);
            this.dgvDoctorQueue.Name = "dgvDoctorQueue";
            this.dgvDoctorQueue.Size = new System.Drawing.Size(376, 459);
            this.dgvDoctorQueue.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(338, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(261, 33);
            this.label1.TabIndex = 4;
            this.label1.Text = "DoctorDashBoard";
            // 
            // txtDoctorQueue
            // 
            this.txtDoctorQueue.Location = new System.Drawing.Point(540, 134);
            this.txtDoctorQueue.Multiline = true;
            this.txtDoctorQueue.Name = "txtDoctorQueue";
            this.txtDoctorQueue.Size = new System.Drawing.Size(262, 290);
            this.txtDoctorQueue.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(536, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(266, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Doctor\'s Diagnoses and Prescription";
            // 
            // btnComplete
            // 
            this.btnComplete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnComplete.Location = new System.Drawing.Point(733, 444);
            this.btnComplete.Name = "btnComplete";
            this.btnComplete.Size = new System.Drawing.Size(110, 34);
            this.btnComplete.TabIndex = 7;
            this.btnComplete.Text = "Complete Visit";
            this.btnComplete.UseVisualStyleBackColor = true;
            // 
            // DoctorDashboardUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnComplete);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDoctorQueue);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvDoctorQueue);
            this.Name = "DoctorDashboardUC";
            this.Size = new System.Drawing.Size(953, 628);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoctorQueue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDoctorQueue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDoctorQueue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnComplete;
    }
}
