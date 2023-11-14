namespace DataBaseKursRabota.Views.Tables
{
    partial class PlotView
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
            this.queryPlotView = new OxyPlot.WindowsForms.PlotView();
            this.SuspendLayout();
            // 
            // queryPlotView
            // 
            this.queryPlotView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.queryPlotView.Location = new System.Drawing.Point(0, 0);
            this.queryPlotView.Name = "queryPlotView";
            this.queryPlotView.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.queryPlotView.Size = new System.Drawing.Size(702, 693);
            this.queryPlotView.TabIndex = 0;
            this.queryPlotView.Text = "plotView1";
            this.queryPlotView.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.queryPlotView.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.queryPlotView.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // PlotView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 693);
            this.Controls.Add(this.queryPlotView);
            this.Name = "PlotView";
            this.Text = "PlotView";
            this.ResumeLayout(false);

        }

        #endregion

        private OxyPlot.WindowsForms.PlotView queryPlotView;
    }
}