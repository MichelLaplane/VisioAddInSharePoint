namespace VisioAddInSharePoint
  {
  partial class FormCSOM
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
      this.edResponse = new System.Windows.Forms.TextBox();
      this.btnSharePointFolders = new System.Windows.Forms.Button();
      this.edRootFolder = new System.Windows.Forms.TextBox();
      this.labRootFolder = new System.Windows.Forms.Label();
      this.labClientApplicationID = new System.Windows.Forms.Label();
      this.edClientApplicationID = new System.Windows.Forms.TextBox();
      this.labSharePointTenantID = new System.Windows.Forms.Label();
      this.edSharePointTenantID = new System.Windows.Forms.TextBox();
      this.labSharePointSiteUrl = new System.Windows.Forms.Label();
      this.edSharePointSiteUrl = new System.Windows.Forms.TextBox();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.btnCreateFolder = new System.Windows.Forms.Button();
      this.edParentFolderName = new System.Windows.Forms.TextBox();
      this.labParentFolderName = new System.Windows.Forms.Label();
      this.edSharePointTenantUrl = new System.Windows.Forms.TextBox();
      this.labSharePointTenantUrl = new System.Windows.Forms.Label();
      this.edFolderToCreate = new System.Windows.Forms.TextBox();
      this.labFolderToCreate = new System.Windows.Forms.Label();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      // 
      // edResponse
      // 
      this.edResponse.Location = new System.Drawing.Point(12, 12);
      this.edResponse.Multiline = true;
      this.edResponse.Name = "edResponse";
      this.edResponse.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.edResponse.Size = new System.Drawing.Size(776, 318);
      this.edResponse.TabIndex = 1;
      // 
      // btnSharePointFolders
      // 
      this.btnSharePointFolders.Location = new System.Drawing.Point(406, 348);
      this.btnSharePointFolders.Name = "btnSharePointFolders";
      this.btnSharePointFolders.Size = new System.Drawing.Size(120, 23);
      this.btnSharePointFolders.TabIndex = 2;
      this.btnSharePointFolders.Text = "SharePoint Folders";
      this.btnSharePointFolders.UseVisualStyleBackColor = true;
      this.btnSharePointFolders.Click += new System.EventHandler(this.btnSharePointFolders_Click);
      // 
      // edRootFolder
      // 
      this.edRootFolder.Location = new System.Drawing.Point(634, 350);
      this.edRootFolder.Name = "edRootFolder";
      this.edRootFolder.Size = new System.Drawing.Size(152, 20);
      this.edRootFolder.TabIndex = 3;
      // 
      // labRootFolder
      // 
      this.labRootFolder.AutoSize = true;
      this.labRootFolder.Location = new System.Drawing.Point(532, 353);
      this.labRootFolder.Name = "labRootFolder";
      this.labRootFolder.Size = new System.Drawing.Size(62, 13);
      this.labRootFolder.TabIndex = 4;
      this.labRootFolder.Text = "Root folder:";
      // 
      // labClientApplicationID
      // 
      this.labClientApplicationID.AutoSize = true;
      this.labClientApplicationID.Location = new System.Drawing.Point(11, 18);
      this.labClientApplicationID.Name = "labClientApplicationID";
      this.labClientApplicationID.Size = new System.Drawing.Size(105, 13);
      this.labClientApplicationID.TabIndex = 5;
      this.labClientApplicationID.Text = "Client Application ID:";
      // 
      // edClientApplicationID
      // 
      this.edClientApplicationID.Location = new System.Drawing.Point(133, 15);
      this.edClientApplicationID.Name = "edClientApplicationID";
      this.edClientApplicationID.Size = new System.Drawing.Size(239, 20);
      this.edClientApplicationID.TabIndex = 6;
      // 
      // labSharePointTenantID
      // 
      this.labSharePointTenantID.AutoSize = true;
      this.labSharePointTenantID.Location = new System.Drawing.Point(10, 44);
      this.labSharePointTenantID.Name = "labSharePointTenantID";
      this.labSharePointTenantID.Size = new System.Drawing.Size(113, 13);
      this.labSharePointTenantID.TabIndex = 7;
      this.labSharePointTenantID.Text = "SharePoint Tenant ID:";
      // 
      // edSharePointTenantID
      // 
      this.edSharePointTenantID.Location = new System.Drawing.Point(133, 41);
      this.edSharePointTenantID.Name = "edSharePointTenantID";
      this.edSharePointTenantID.Size = new System.Drawing.Size(239, 20);
      this.edSharePointTenantID.TabIndex = 8;
      // 
      // labSharePointSiteUrl
      // 
      this.labSharePointSiteUrl.AutoSize = true;
      this.labSharePointSiteUrl.Location = new System.Drawing.Point(11, 96);
      this.labSharePointSiteUrl.Name = "labSharePointSiteUrl";
      this.labSharePointSiteUrl.Size = new System.Drawing.Size(99, 13);
      this.labSharePointSiteUrl.TabIndex = 9;
      this.labSharePointSiteUrl.Text = "SharePoint Site Url:";
      // 
      // edSharePointSiteUrl
      // 
      this.edSharePointSiteUrl.Location = new System.Drawing.Point(133, 93);
      this.edSharePointSiteUrl.Name = "edSharePointSiteUrl";
      this.edSharePointSiteUrl.Size = new System.Drawing.Size(239, 20);
      this.edSharePointSiteUrl.TabIndex = 10;
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.labSharePointTenantUrl);
      this.groupBox1.Controls.Add(this.edSharePointTenantUrl);
      this.groupBox1.Controls.Add(this.edSharePointTenantID);
      this.groupBox1.Controls.Add(this.edSharePointSiteUrl);
      this.groupBox1.Controls.Add(this.labClientApplicationID);
      this.groupBox1.Controls.Add(this.labSharePointSiteUrl);
      this.groupBox1.Controls.Add(this.edClientApplicationID);
      this.groupBox1.Controls.Add(this.labSharePointTenantID);
      this.groupBox1.Location = new System.Drawing.Point(12, 340);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(388, 122);
      this.groupBox1.TabIndex = 11;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Tenant and SharePoint site informations";
      // 
      // btnCreateFolder
      // 
      this.btnCreateFolder.Location = new System.Drawing.Point(406, 374);
      this.btnCreateFolder.Name = "btnCreateFolder";
      this.btnCreateFolder.Size = new System.Drawing.Size(120, 23);
      this.btnCreateFolder.TabIndex = 12;
      this.btnCreateFolder.Text = "Create folder";
      this.btnCreateFolder.UseVisualStyleBackColor = true;
      this.btnCreateFolder.Click += new System.EventHandler(this.btnCreateFolder_Click);
      // 
      // edParentFolderName
      // 
      this.edParentFolderName.Location = new System.Drawing.Point(636, 376);
      this.edParentFolderName.Name = "edParentFolderName";
      this.edParentFolderName.Size = new System.Drawing.Size(152, 20);
      this.edParentFolderName.TabIndex = 14;
      // 
      // labParentFolderName
      // 
      this.labParentFolderName.AutoSize = true;
      this.labParentFolderName.Location = new System.Drawing.Point(534, 379);
      this.labParentFolderName.Name = "labParentFolderName";
      this.labParentFolderName.Size = new System.Drawing.Size(96, 13);
      this.labParentFolderName.TabIndex = 15;
      this.labParentFolderName.Text = "Parent folder name";
      // 
      // edSharePointTenantUrl
      // 
      this.edSharePointTenantUrl.Location = new System.Drawing.Point(133, 67);
      this.edSharePointTenantUrl.Name = "edSharePointTenantUrl";
      this.edSharePointTenantUrl.Size = new System.Drawing.Size(239, 20);
      this.edSharePointTenantUrl.TabIndex = 12;
      // 
      // labSharePointTenantUrl
      // 
      this.labSharePointTenantUrl.AutoSize = true;
      this.labSharePointTenantUrl.Location = new System.Drawing.Point(10, 70);
      this.labSharePointTenantUrl.Name = "labSharePointTenantUrl";
      this.labSharePointTenantUrl.Size = new System.Drawing.Size(115, 13);
      this.labSharePointTenantUrl.TabIndex = 11;
      this.labSharePointTenantUrl.Text = "SharePoint Tenant Url:";
      // 
      // edFolderToCreate
      // 
      this.edFolderToCreate.Location = new System.Drawing.Point(636, 402);
      this.edFolderToCreate.Name = "edFolderToCreate";
      this.edFolderToCreate.Size = new System.Drawing.Size(152, 20);
      this.edFolderToCreate.TabIndex = 14;
      // 
      // labFolderToCreate
      // 
      this.labFolderToCreate.AutoSize = true;
      this.labFolderToCreate.Location = new System.Drawing.Point(534, 405);
      this.labFolderToCreate.Name = "labFolderToCreate";
      this.labFolderToCreate.Size = new System.Drawing.Size(65, 13);
      this.labFolderToCreate.TabIndex = 15;
      this.labFolderToCreate.Text = "Folder name";
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 474);
      this.Controls.Add(this.labFolderToCreate);
      this.Controls.Add(this.labParentFolderName);
      this.Controls.Add(this.edFolderToCreate);
      this.Controls.Add(this.edParentFolderName);
      this.Controls.Add(this.btnCreateFolder);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.labRootFolder);
      this.Controls.Add(this.edRootFolder);
      this.Controls.Add(this.btnSharePointFolders);
      this.Controls.Add(this.edResponse);
      this.Name = "Form1";
      this.Text = "VisualSharePointCSOMSample";
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

      }

    #endregion
    private System.Windows.Forms.TextBox edResponse;
    private System.Windows.Forms.Button btnSharePointFolders;
    private System.Windows.Forms.TextBox edRootFolder;
    private System.Windows.Forms.Label labRootFolder;
    private System.Windows.Forms.Label labClientApplicationID;
    private System.Windows.Forms.TextBox edClientApplicationID;
    private System.Windows.Forms.Label labSharePointTenantID;
    private System.Windows.Forms.TextBox edSharePointTenantID;
    private System.Windows.Forms.Label labSharePointSiteUrl;
    private System.Windows.Forms.TextBox edSharePointSiteUrl;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Button btnCreateFolder;
    private System.Windows.Forms.TextBox edParentFolderName;
    private System.Windows.Forms.Label labParentFolderName;
    private System.Windows.Forms.TextBox edSharePointTenantUrl;
    private System.Windows.Forms.Label labSharePointTenantUrl;
    private System.Windows.Forms.TextBox edFolderToCreate;
    private System.Windows.Forms.Label labFolderToCreate;
    }
  }

