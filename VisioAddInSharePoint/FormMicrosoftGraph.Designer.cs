namespace VisioAddInSharePoint
  {
  partial class FormMicrosoftGraph
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
      this.edResultText = new System.Windows.Forms.TextBox();
      this.edTokenInfoText = new System.Windows.Forms.TextBox();
      this.labResultText = new System.Windows.Forms.Label();
      this.labTokenInfoText = new System.Windows.Forms.Label();
      this.btnCallGraphButton = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // edResultText
      // 
      this.edResultText.Location = new System.Drawing.Point(12, 29);
      this.edResultText.Multiline = true;
      this.edResultText.Name = "edResultText";
      this.edResultText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.edResultText.Size = new System.Drawing.Size(693, 201);
      this.edResultText.TabIndex = 0;
      // 
      // edTokenInfoText
      // 
      this.edTokenInfoText.Location = new System.Drawing.Point(12, 253);
      this.edTokenInfoText.Multiline = true;
      this.edTokenInfoText.Name = "edTokenInfoText";
      this.edTokenInfoText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.edTokenInfoText.Size = new System.Drawing.Size(693, 156);
      this.edTokenInfoText.TabIndex = 1;
      // 
      // labResultText
      // 
      this.labResultText.AutoSize = true;
      this.labResultText.Location = new System.Drawing.Point(13, 13);
      this.labResultText.Name = "labResultText";
      this.labResultText.Size = new System.Drawing.Size(82, 13);
      this.labResultText.TabIndex = 2;
      this.labResultText.Text = "API Call Results";
      // 
      // labTokenInfoText
      // 
      this.labTokenInfoText.AutoSize = true;
      this.labTokenInfoText.Location = new System.Drawing.Point(12, 237);
      this.labTokenInfoText.Name = "labTokenInfoText";
      this.labTokenInfoText.Size = new System.Drawing.Size(59, 13);
      this.labTokenInfoText.TabIndex = 3;
      this.labTokenInfoText.Text = "Token Info";
      // 
      // btnCallGraphButton
      // 
      this.btnCallGraphButton.Location = new System.Drawing.Point(545, 415);
      this.btnCallGraphButton.Name = "btnCallGraphButton";
      this.btnCallGraphButton.Size = new System.Drawing.Size(160, 23);
      this.btnCallGraphButton.TabIndex = 4;
      this.btnCallGraphButton.Text = "Call Microsoft Graph API";
      this.btnCallGraphButton.UseVisualStyleBackColor = true;
      this.btnCallGraphButton.Click += new System.EventHandler(this.btnCallGraphButton_Click);
      // 
      // FormMicrosoftGraph
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(720, 450);
      this.Controls.Add(this.btnCallGraphButton);
      this.Controls.Add(this.labTokenInfoText);
      this.Controls.Add(this.labResultText);
      this.Controls.Add(this.edTokenInfoText);
      this.Controls.Add(this.edResultText);
      this.Name = "FormMicrosoftGraph";
      this.Text = "Form1";
      this.ResumeLayout(false);
      this.PerformLayout();

      }

    #endregion
    private System.Windows.Forms.TextBox edResultText;
    private System.Windows.Forms.TextBox edTokenInfoText;
    private System.Windows.Forms.Label labResultText;
    private System.Windows.Forms.Label labTokenInfoText;
    private System.Windows.Forms.Button btnCallGraphButton;
    }
  }

