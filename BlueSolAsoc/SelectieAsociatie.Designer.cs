namespace BlueSolAsoc
{
    partial class SelectieAsociatie
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
            this.TablePanelSelectAsoc = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // TablePanelSelectAsoc
            // 
            this.TablePanelSelectAsoc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TablePanelSelectAsoc.ColumnCount = 2;
            this.TablePanelSelectAsoc.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TablePanelSelectAsoc.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TablePanelSelectAsoc.Location = new System.Drawing.Point(-2, 4);
            this.TablePanelSelectAsoc.Name = "TablePanelSelectAsoc";
            this.TablePanelSelectAsoc.RowCount = 2;
            this.TablePanelSelectAsoc.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TablePanelSelectAsoc.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TablePanelSelectAsoc.Size = new System.Drawing.Size(802, 445);
            this.TablePanelSelectAsoc.TabIndex = 0;
            // 
            // SelectieAsociatie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = true;
            this.Controls.Add(this.TablePanelSelectAsoc);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "SelectieAsociatie";
            this.Text = "SelectieAsociatie";
            this.Load += new System.EventHandler(this.SelectieAsociatie_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TablePanelSelectAsoc;
    }
}