namespace BantayPilaApp
{
    partial class NurseDashboardUC
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
            this.dgvQueue = new System.Windows.Forms.DataGridView();
            this.txtSystem = new System.Windows.Forms.TextBox();
            this.btnSendToDoctor = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQueue)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvQueue
            // 
            this.dgvQueue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQueue.Location = new System.Drawing.Point(26, 135);
            this.dgvQueue.Name = "dgvQueue";
            this.dgvQueue.Size = new System.Drawing.Size(1078, 486);
            this.dgvQueue.TabIndex = 0;
            this.dgvQueue.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvQueue_CellContentClick);
            // 
            // txtSystem
            // 
            this.txtSystem.Location = new System.Drawing.Point(26, 72);
            this.txtSystem.Multiline = true;
            this.txtSystem.Name = "txtSystem";
            this.txtSystem.Size = new System.Drawing.Size(348, 44);
            this.txtSystem.TabIndex = 1;
            // 
            // btnSendToDoctor
            // 
            this.btnSendToDoctor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendToDoctor.Location = new System.Drawing.Point(953, 642);
            this.btnSendToDoctor.Name = "btnSendToDoctor";
            this.btnSendToDoctor.Size = new System.Drawing.Size(151, 33);
            this.btnSendToDoctor.TabIndex = 2;
            this.btnSendToDoctor.Text = "Send to Doctor";
            this.btnSendToDoctor.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(432, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(252, 33);
            this.label1.TabIndex = 3;
            this.label1.Text = "NurseDashBoard";
            // 
            // NurseDashboardUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSendToDoctor);
            this.Controls.Add(this.txtSystem);
            this.Controls.Add(this.dgvQueue);
            this.Name = "NurseDashboardUC";
            this.Size = new System.Drawing.Size(1144, 690);
            this.Load += new System.EventHandler(this.NurseDashboardUC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvQueue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvQueue;
        private System.Windows.Forms.TextBox txtSystem;
        private System.Windows.Forms.Button btnSendToDoctor;
        private System.Windows.Forms.Label label1;
    }
}
