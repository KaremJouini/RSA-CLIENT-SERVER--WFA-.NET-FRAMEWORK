namespace ClientDash
{
    partial class ClientDash
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
            this.msg = new System.Windows.Forms.TextBox();
            this.partners_list = new System.Windows.Forms.ListBox();
            this.chat_log = new System.Windows.Forms.ListView();
            this.send_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chat_name = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // msg
            // 
            this.msg.Location = new System.Drawing.Point(12, 408);
            this.msg.Name = "msg";
            this.msg.Size = new System.Drawing.Size(408, 20);
            this.msg.TabIndex = 0;
            this.msg.Text = "Enter your msg here !";
            // 
            // partners_list
            // 
            this.partners_list.FormattingEnabled = true;
            this.partners_list.Location = new System.Drawing.Point(12, 40);
            this.partners_list.Name = "partners_list";
            this.partners_list.Size = new System.Drawing.Size(149, 316);
            this.partners_list.TabIndex = 1;
            this.partners_list.SelectedIndexChanged += new System.EventHandler(this.partners_list_SelectedIndexChanged);
            // 
            // chat_log
            // 
            this.chat_log.HideSelection = false;
            this.chat_log.Location = new System.Drawing.Point(239, 40);
            this.chat_log.Name = "chat_log";
            this.chat_log.Size = new System.Drawing.Size(265, 316);
            this.chat_log.TabIndex = 2;
            this.chat_log.UseCompatibleStateImageBehavior = false;
            // 
            // send_button
            // 
            this.send_button.Location = new System.Drawing.Point(429, 405);
            this.send_button.Name = "send_button";
            this.send_button.Size = new System.Drawing.Size(75, 23);
            this.send_button.TabIndex = 3;
            this.send_button.Text = "Send";
            this.send_button.UseVisualStyleBackColor = true;
            this.send_button.Click += new System.EventHandler(this.send_button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Available Partners";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(239, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Chat !";
            // 
            // chat_name
            // 
            this.chat_name.Location = new System.Drawing.Point(12, 362);
            this.chat_name.Name = "chat_name";
            this.chat_name.Size = new System.Drawing.Size(131, 20);
            this.chat_name.TabIndex = 6;
            this.chat_name.Text = "Type Your chat name!";
            this.chat_name.TextChanged += new System.EventHandler(this.chat_name_TextChanged);
            // 
            // ClientDash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 450);
            this.Controls.Add(this.chat_name);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.send_button);
            this.Controls.Add(this.chat_log);
            this.Controls.Add(this.partners_list);
            this.Controls.Add(this.msg);
            this.Name = "ClientDash";
            this.Text = "ChatRoom";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ClientDash_Closed);
            this.Load += new System.EventHandler(this.ClientDash_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox msg;
        private System.Windows.Forms.ListBox partners_list;
        private System.Windows.Forms.ListView chat_log;
        private System.Windows.Forms.Button send_button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox chat_name;
    }
}

