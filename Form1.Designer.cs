namespace YahooMailOauth1
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
	    this.button1 = new System.Windows.Forms.Button();
	    this.textBox1 = new System.Windows.Forms.TextBox();
	    this.splitContainer1 = new System.Windows.Forms.SplitContainer();
	    this.button3 = new System.Windows.Forms.Button();
	    this.button2 = new System.Windows.Forms.Button();
	    this.txtVerifier = new System.Windows.Forms.TextBox();
	    this.label1 = new System.Windows.Forms.Label();
	    this.webBrowser1 = new System.Windows.Forms.WebBrowser();
	    ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
	    this.splitContainer1.Panel1.SuspendLayout();
	    this.splitContainer1.Panel2.SuspendLayout();
	    this.splitContainer1.SuspendLayout();
	    this.SuspendLayout();
	    // 
	    // button1
	    // 
	    this.button1.Location = new System.Drawing.Point(23, 12);
	    this.button1.Name = "button1";
	    this.button1.Size = new System.Drawing.Size(196, 25);
	    this.button1.TabIndex = 0;
	    this.button1.Text = "Step 1: Get A Request Token";
	    this.button1.UseVisualStyleBackColor = true;
	    this.button1.Click += new System.EventHandler(this.button1_Click);
	    // 
	    // textBox1
	    // 
	    this.textBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
	    this.textBox1.Location = new System.Drawing.Point(0, 248);
	    this.textBox1.Multiline = true;
	    this.textBox1.Name = "textBox1";
	    this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
	    this.textBox1.Size = new System.Drawing.Size(554, 406);
	    this.textBox1.TabIndex = 1;
	    // 
	    // splitContainer1
	    // 
	    this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
	    this.splitContainer1.Location = new System.Drawing.Point(0, 0);
	    this.splitContainer1.Name = "splitContainer1";
	    // 
	    // splitContainer1.Panel1
	    // 
	    this.splitContainer1.Panel1.Controls.Add(this.button3);
	    this.splitContainer1.Panel1.Controls.Add(this.button2);
	    this.splitContainer1.Panel1.Controls.Add(this.txtVerifier);
	    this.splitContainer1.Panel1.Controls.Add(this.label1);
	    this.splitContainer1.Panel1.Controls.Add(this.textBox1);
	    this.splitContainer1.Panel1.Controls.Add(this.button1);
	    // 
	    // splitContainer1.Panel2
	    // 
	    this.splitContainer1.Panel2.Controls.Add(this.webBrowser1);
	    this.splitContainer1.Size = new System.Drawing.Size(1226, 654);
	    this.splitContainer1.SplitterDistance = 554;
	    this.splitContainer1.TabIndex = 2;
	    // 
	    // button3
	    // 
	    this.button3.Location = new System.Drawing.Point(23, 133);
	    this.button3.Name = "button3";
	    this.button3.Size = new System.Drawing.Size(196, 47);
	    this.button3.TabIndex = 5;
	    this.button3.Text = "Step 4: Use Access Token with IMAP";
	    this.button3.UseVisualStyleBackColor = true;
	    this.button3.Click += new System.EventHandler(this.button3_Click);
	    // 
	    // button2
	    // 
	    this.button2.Location = new System.Drawing.Point(23, 99);
	    this.button2.Name = "button2";
	    this.button2.Size = new System.Drawing.Size(196, 28);
	    this.button2.TabIndex = 4;
	    this.button2.Text = "Step 3: Get the Access Token";
	    this.button2.UseVisualStyleBackColor = true;
	    this.button2.Click += new System.EventHandler(this.button2_Click);
	    // 
	    // txtVerifier
	    // 
	    this.txtVerifier.Location = new System.Drawing.Point(23, 64);
	    this.txtVerifier.Name = "txtVerifier";
	    this.txtVerifier.Size = new System.Drawing.Size(204, 20);
	    this.txtVerifier.TabIndex = 3;
	    // 
	    // label1
	    // 
	    this.label1.AutoSize = true;
	    this.label1.Location = new System.Drawing.Point(22, 48);
	    this.label1.Name = "label1";
	    this.label1.Size = new System.Drawing.Size(281, 13);
	    this.label1.TabIndex = 2;
	    this.label1.Text = "Step 2: Copy-and-Paste the Verifier from the Browser here:";
	    // 
	    // webBrowser1
	    // 
	    this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
	    this.webBrowser1.Location = new System.Drawing.Point(0, 0);
	    this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
	    this.webBrowser1.Name = "webBrowser1";
	    this.webBrowser1.Size = new System.Drawing.Size(668, 654);
	    this.webBrowser1.TabIndex = 0;
	    // 
	    // Form1
	    // 
	    this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
	    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
	    this.ClientSize = new System.Drawing.Size(1226, 654);
	    this.Controls.Add(this.splitContainer1);
	    this.Name = "Form1";
	    this.Text = "Yahoo Mail with OAuth";
	    this.Load += new System.EventHandler(this.Form1_Load);
	    this.splitContainer1.Panel1.ResumeLayout(false);
	    this.splitContainer1.Panel1.PerformLayout();
	    this.splitContainer1.Panel2.ResumeLayout(false);
	    ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
	    this.splitContainer1.ResumeLayout(false);
	    this.ResumeLayout(false);

	    }

	#endregion

	private System.Windows.Forms.Button button1;
	private System.Windows.Forms.TextBox textBox1;
	private System.Windows.Forms.SplitContainer splitContainer1;
	private System.Windows.Forms.WebBrowser webBrowser1;
	private System.Windows.Forms.Button button2;
	private System.Windows.Forms.TextBox txtVerifier;
	private System.Windows.Forms.Label label1;
	private System.Windows.Forms.Button button3;
	}
    }

