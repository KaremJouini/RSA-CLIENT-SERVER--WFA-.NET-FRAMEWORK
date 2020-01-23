namespace ServerDash
{
    partial class ServerDash
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.logs_list = new System.Windows.Forms.ListView();
            this.connected_clients_list = new System.Windows.Forms.ListView();
            this.connect_button = new System.Windows.Forms.Button();
            this.disconnect_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(382, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Logs";
            this.label1.UseWaitCursor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Connected Clients";
            this.label2.UseWaitCursor = true;
            // 
            // logs_list
            // 
            this.logs_list.AccessibleName = "";
            this.logs_list.HideSelection = false;
            this.logs_list.Location = new System.Drawing.Point(385, 25);
            this.logs_list.Name = "logs_list";
            this.logs_list.Size = new System.Drawing.Size(369, 195);
            this.logs_list.TabIndex = 3;
            this.logs_list.UseCompatibleStateImageBehavior = false;
            // 
            // connected_clients_list
            // 
            this.connected_clients_list.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.connected_clients_list.HideSelection = false;
            this.connected_clients_list.Location = new System.Drawing.Point(15, 25);
            this.connected_clients_list.Name = "connected_clients_list";
            this.connected_clients_list.Size = new System.Drawing.Size(347, 195);
            this.connected_clients_list.TabIndex = 4;
            this.connected_clients_list.UseCompatibleStateImageBehavior = false;
            this.connected_clients_list.UseWaitCursor = true;
            // 
            // connect_button
            // 
            this.connect_button.Location = new System.Drawing.Point(25, 351);
            this.connect_button.Name = "connect_button";
            this.connect_button.Size = new System.Drawing.Size(114, 23);
            this.connect_button.TabIndex = 5;
            this.connect_button.Text = "Connect";
            this.connect_button.UseVisualStyleBackColor = true;
            this.connect_button.Click += new System.EventHandler(this.connect_button_clicked);
            // 
            // disconnect_button
            // 
            this.disconnect_button.Location = new System.Drawing.Point(385, 351);
            this.disconnect_button.Name = "disconnect_button";
            this.disconnect_button.Size = new System.Drawing.Size(81, 23);
            this.disconnect_button.TabIndex = 6;
            this.disconnect_button.Text = "Disconnect";
            this.disconnect_button.UseVisualStyleBackColor = true;
            this.disconnect_button.UseWaitCursor = true;
            this.disconnect_button.Click += new System.EventHandler(this.disconnect_button_clicked);
            // 
            // ServerDash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 450);
            this.Controls.Add(this.disconnect_button);
            this.Controls.Add(this.connect_button);
            this.Controls.Add(this.connected_clients_list);
            this.Controls.Add(this.logs_list);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "ServerDash";
            this.Text = "ServerDash";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ServerDash_Closing);
            this.Load += new System.EventHandler(this.ServerDash_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView logs_list;
        private System.Windows.Forms.ListView connected_clients_list;
        private System.Windows.Forms.Button connect_button;
        private System.Windows.Forms.Button disconnect_button;
    }
}

