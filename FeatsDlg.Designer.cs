namespace CS_Editor
{
    partial class FeatsDlg
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
            label1 = new Label();
            lbFeats = new ListBox();
            btnRemove = new Button();
            label2 = new Label();
            cbAddFeat = new ComboBox();
            btnAdd = new Button();
            okBtn = new Button();
            cancelBtn = new Button();
            SuspendLayout();
            //
            // label1
            //
            label1.AutoSize = true;
            label1.Location = new Point(12, 12);
            label1.Name = "label1";
            label1.Size = new Size(85, 15);
            label1.TabIndex = 0;
            label1.Text = "Character &feats:";
            //
            // lbFeats
            //
            lbFeats.FormattingEnabled = true;
            lbFeats.ItemHeight = 15;
            lbFeats.Location = new Point(12, 30);
            lbFeats.Name = "lbFeats";
            lbFeats.Size = new Size(332, 184);
            lbFeats.TabIndex = 1;
            //
            // btnRemove
            //
            btnRemove.Location = new Point(350, 30);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(75, 23);
            btnRemove.TabIndex = 2;
            btnRemove.Text = "&Remove";
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += BtnRemove_Click;
            //
            // label2
            //
            label2.AutoSize = true;
            label2.Location = new Point(12, 224);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 3;
            label2.Text = "Add f&eat:";
            //
            // cbAddFeat
            //
            cbAddFeat.FormattingEnabled = true;
            cbAddFeat.Location = new Point(12, 242);
            cbAddFeat.MaxDropDownItems = 20;
            cbAddFeat.Name = "cbAddFeat";
            cbAddFeat.Size = new Size(332, 23);
            cbAddFeat.TabIndex = 4;
            //
            // btnAdd
            //
            btnAdd.Location = new Point(350, 242);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 5;
            btnAdd.Text = "&Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += BtnAdd_Click;
            //
            // okBtn
            //
            okBtn.DialogResult = DialogResult.OK;
            okBtn.Location = new Point(12, 282);
            okBtn.Name = "okBtn";
            okBtn.Size = new Size(75, 23);
            okBtn.TabIndex = 6;
            okBtn.Text = "&OK";
            okBtn.UseVisualStyleBackColor = true;
            //
            // cancelBtn
            //
            cancelBtn.DialogResult = DialogResult.Cancel;
            cancelBtn.Location = new Point(93, 282);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(75, 23);
            cancelBtn.TabIndex = 7;
            cancelBtn.Text = "&Cancel";
            cancelBtn.UseVisualStyleBackColor = true;
            //
            // FeatsDlg
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = cancelBtn;
            ClientSize = new Size(437, 317);
            Controls.Add(cancelBtn);
            Controls.Add(okBtn);
            Controls.Add(btnAdd);
            Controls.Add(cbAddFeat);
            Controls.Add(label2);
            Controls.Add(btnRemove);
            Controls.Add(lbFeats);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FeatsDlg";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Character Feats";
            Load += FeatsDlg_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ListBox lbFeats;
        private Button btnRemove;
        private Label label2;
        private ComboBox cbAddFeat;
        private Button btnAdd;
        private Button okBtn;
        private Button cancelBtn;
    }
}
