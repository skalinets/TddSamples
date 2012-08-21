namespace Client
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label numbersLabel;
            System.Windows.Forms.Label resultLabel;
            this.numbersTextBox = new System.Windows.Forms.TextBox();
            this.resultTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.viewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            numbersLabel = new System.Windows.Forms.Label();
            resultLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.viewModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // numbersLabel
            // 
            numbersLabel.AutoSize = true;
            numbersLabel.Location = new System.Drawing.Point(42, 54);
            numbersLabel.Name = "numbersLabel";
            numbersLabel.Size = new System.Drawing.Size(52, 13);
            numbersLabel.TabIndex = 1;
            numbersLabel.Text = "Numbers:";
            // 
            // resultLabel
            // 
            resultLabel.AutoSize = true;
            resultLabel.Location = new System.Drawing.Point(42, 80);
            resultLabel.Name = "resultLabel";
            resultLabel.Size = new System.Drawing.Size(40, 13);
            resultLabel.TabIndex = 3;
            resultLabel.Text = "Result:";
            // 
            // numbersTextBox
            // 
            this.numbersTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.viewModelBindingSource, "Numbers", true));
            this.numbersTextBox.Location = new System.Drawing.Point(100, 51);
            this.numbersTextBox.Name = "numbersTextBox";
            this.numbersTextBox.Size = new System.Drawing.Size(100, 20);
            this.numbersTextBox.TabIndex = 2;
            // 
            // resultTextBox
            // 
            this.resultTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.viewModelBindingSource, "Result", true));
            this.resultTextBox.Location = new System.Drawing.Point(100, 77);
            this.resultTextBox.Name = "resultTextBox";
            this.resultTextBox.Size = new System.Drawing.Size(100, 20);
            this.resultTextBox.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(125, 114);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // viewModelBindingSource
            // 
            this.viewModelBindingSource.DataSource = typeof(Client.ViewModel);
            this.viewModelBindingSource.CurrentChanged += new System.EventHandler(this.viewModelBindingSource_CurrentChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 382);
            this.Controls.Add(this.button1);
            this.Controls.Add(numbersLabel);
            this.Controls.Add(this.numbersTextBox);
            this.Controls.Add(resultLabel);
            this.Controls.Add(this.resultTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.viewModelBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource viewModelBindingSource;
        private System.Windows.Forms.TextBox numbersTextBox;
        private System.Windows.Forms.TextBox resultTextBox;
        private System.Windows.Forms.Button button1;
    }
}

