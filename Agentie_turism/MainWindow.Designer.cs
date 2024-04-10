using System.ComponentModel;

namespace Agentie_turism;

partial class MainWindow
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

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
        this.reservePanel = new System.Windows.Forms.Panel();
        this.reserveButton = new System.Windows.Forms.Button();
        this.noSeatsLabel = new System.Windows.Forms.Label();
        this.seatsUpDown = new System.Windows.Forms.NumericUpDown();
        this.phoneNumberTextBox = new System.Windows.Forms.TextBox();
        this.phoneNumberLabel = new System.Windows.Forms.Label();
        this.clientNameTextBox = new System.Windows.Forms.TextBox();
        this.clientNameLabel = new System.Windows.Forms.Label();
        this.nameLabel = new System.Windows.Forms.Label();
        this.logoutButton = new System.Windows.Forms.Button();
        this.searchPanel = new System.Windows.Forms.Panel();
        this.searchButton = new System.Windows.Forms.Button();
        this.endHourLabel = new System.Windows.Forms.Label();
        this.endHourComboBox = new System.Windows.Forms.ComboBox();
        this.startHourLabel = new System.Windows.Forms.Label();
        this.startHourComboBox = new System.Windows.Forms.ComboBox();
        this.landmarkLabel = new System.Windows.Forms.Label();
        this.landmarkTextBox = new System.Windows.Forms.TextBox();
        this.panel3 = new System.Windows.Forms.Panel();
        this.tripsDataGridView = new System.Windows.Forms.DataGridView();
        this.tripLabel = new System.Windows.Forms.Label();
        this.panel4 = new System.Windows.Forms.Panel();
        this.searchedTripsDataGridView = new System.Windows.Forms.DataGridView();
        this.label1 = new System.Windows.Forms.Label();
        this.reservePanel.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.seatsUpDown)).BeginInit();
        this.searchPanel.SuspendLayout();
        this.panel3.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.tripsDataGridView)).BeginInit();
        this.panel4.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.searchedTripsDataGridView)).BeginInit();
        this.SuspendLayout();
        // 
        // reservePanel
        // 
        this.reservePanel.Controls.Add(this.reserveButton);
        this.reservePanel.Controls.Add(this.noSeatsLabel);
        this.reservePanel.Controls.Add(this.seatsUpDown);
        this.reservePanel.Controls.Add(this.phoneNumberTextBox);
        this.reservePanel.Controls.Add(this.phoneNumberLabel);
        this.reservePanel.Controls.Add(this.clientNameTextBox);
        this.reservePanel.Controls.Add(this.clientNameLabel);
        this.reservePanel.Location = new System.Drawing.Point(12, 69);
        this.reservePanel.Name = "reservePanel";
        this.reservePanel.Size = new System.Drawing.Size(324, 216);
        this.reservePanel.TabIndex = 0;
        // 
        // reserveButton
        // 
        this.reserveButton.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.reserveButton.Location = new System.Drawing.Point(220, 175);
        this.reserveButton.Name = "reserveButton";
        this.reserveButton.Size = new System.Drawing.Size(82, 27);
        this.reserveButton.TabIndex = 6;
        this.reserveButton.Text = "Reserve";
        this.reserveButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
        this.reserveButton.UseVisualStyleBackColor = true;
        this.reserveButton.Click += new System.EventHandler(this.reserveButton_Click);
        // 
        // noSeatsLabel
        // 
        this.noSeatsLabel.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.noSeatsLabel.Location = new System.Drawing.Point(12, 121);
        this.noSeatsLabel.Name = "noSeatsLabel";
        this.noSeatsLabel.Size = new System.Drawing.Size(129, 30);
        this.noSeatsLabel.TabIndex = 5;
        this.noSeatsLabel.Text = "No seats";
        this.noSeatsLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
        // 
        // seatsUpDown
        // 
        this.seatsUpDown.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.seatsUpDown.Location = new System.Drawing.Point(153, 121);
        this.seatsUpDown.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
        this.seatsUpDown.Name = "seatsUpDown";
        this.seatsUpDown.Size = new System.Drawing.Size(147, 30);
        this.seatsUpDown.TabIndex = 4;
        // 
        // phoneNumberTextBox
        // 
        this.phoneNumberTextBox.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.phoneNumberTextBox.Location = new System.Drawing.Point(153, 69);
        this.phoneNumberTextBox.Name = "phoneNumberTextBox";
        this.phoneNumberTextBox.Size = new System.Drawing.Size(148, 30);
        this.phoneNumberTextBox.TabIndex = 3;
        // 
        // phoneNumberLabel
        // 
        this.phoneNumberLabel.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.phoneNumberLabel.Location = new System.Drawing.Point(12, 69);
        this.phoneNumberLabel.Name = "phoneNumberLabel";
        this.phoneNumberLabel.Size = new System.Drawing.Size(130, 30);
        this.phoneNumberLabel.TabIndex = 2;
        this.phoneNumberLabel.Text = "Phone number";
        this.phoneNumberLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
        // 
        // clientNameTextBox
        // 
        this.clientNameTextBox.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.clientNameTextBox.Location = new System.Drawing.Point(153, 18);
        this.clientNameTextBox.Name = "clientNameTextBox";
        this.clientNameTextBox.Size = new System.Drawing.Size(149, 30);
        this.clientNameTextBox.TabIndex = 1;
        // 
        // clientNameLabel
        // 
        this.clientNameLabel.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.clientNameLabel.Location = new System.Drawing.Point(12, 18);
        this.clientNameLabel.Name = "clientNameLabel";
        this.clientNameLabel.Size = new System.Drawing.Size(130, 30);
        this.clientNameLabel.TabIndex = 0;
        this.clientNameLabel.Text = "Client name";
        this.clientNameLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
        // 
        // nameLabel
        // 
        this.nameLabel.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.nameLabel.Location = new System.Drawing.Point(12, 19);
        this.nameLabel.Name = "nameLabel";
        this.nameLabel.Size = new System.Drawing.Size(322, 30);
        this.nameLabel.TabIndex = 1;
        this.nameLabel.Text = "name";
        this.nameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // logoutButton
        // 
        this.logoutButton.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.logoutButton.Location = new System.Drawing.Point(921, 19);
        this.logoutButton.Name = "logoutButton";
        this.logoutButton.Size = new System.Drawing.Size(78, 30);
        this.logoutButton.TabIndex = 2;
        this.logoutButton.Text = "Logout";
        this.logoutButton.UseVisualStyleBackColor = true;
        this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);
        // 
        // searchPanel
        // 
        this.searchPanel.Controls.Add(this.searchButton);
        this.searchPanel.Controls.Add(this.endHourLabel);
        this.searchPanel.Controls.Add(this.endHourComboBox);
        this.searchPanel.Controls.Add(this.startHourLabel);
        this.searchPanel.Controls.Add(this.startHourComboBox);
        this.searchPanel.Controls.Add(this.landmarkLabel);
        this.searchPanel.Controls.Add(this.landmarkTextBox);
        this.searchPanel.Location = new System.Drawing.Point(12, 309);
        this.searchPanel.Name = "searchPanel";
        this.searchPanel.Size = new System.Drawing.Size(324, 215);
        this.searchPanel.TabIndex = 3;
        // 
        // searchButton
        // 
        this.searchButton.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.searchButton.Location = new System.Drawing.Point(220, 175);
        this.searchButton.Name = "searchButton";
        this.searchButton.Size = new System.Drawing.Size(80, 27);
        this.searchButton.TabIndex = 4;
        this.searchButton.Text = "Search";
        this.searchButton.UseVisualStyleBackColor = true;
        this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
        // 
        // endHourLabel
        // 
        this.endHourLabel.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.endHourLabel.Location = new System.Drawing.Point(12, 121);
        this.endHourLabel.Name = "endHourLabel";
        this.endHourLabel.Size = new System.Drawing.Size(128, 29);
        this.endHourLabel.TabIndex = 5;
        this.endHourLabel.Text = "End hour";
        this.endHourLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
        // 
        // endHourComboBox
        // 
        this.endHourComboBox.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.endHourComboBox.FormattingEnabled = true;
        this.endHourComboBox.IntegralHeight = false;
        this.endHourComboBox.Location = new System.Drawing.Point(153, 121);
        this.endHourComboBox.Name = "endHourComboBox";
        this.endHourComboBox.Size = new System.Drawing.Size(149, 30);
        this.endHourComboBox.TabIndex = 4;
        // 
        // startHourLabel
        // 
        this.startHourLabel.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.startHourLabel.Location = new System.Drawing.Point(12, 69);
        this.startHourLabel.Name = "startHourLabel";
        this.startHourLabel.Size = new System.Drawing.Size(129, 30);
        this.startHourLabel.TabIndex = 3;
        this.startHourLabel.Text = "Start hour";
        this.startHourLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
        // 
        // startHourComboBox
        // 
        this.startHourComboBox.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.startHourComboBox.FormattingEnabled = true;
        this.startHourComboBox.IntegralHeight = false;
        this.startHourComboBox.Location = new System.Drawing.Point(153, 69);
        this.startHourComboBox.Name = "startHourComboBox";
        this.startHourComboBox.Size = new System.Drawing.Size(148, 30);
        this.startHourComboBox.TabIndex = 2;
        // 
        // landmarkLabel
        // 
        this.landmarkLabel.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.landmarkLabel.Location = new System.Drawing.Point(12, 18);
        this.landmarkLabel.Name = "landmarkLabel";
        this.landmarkLabel.Size = new System.Drawing.Size(130, 30);
        this.landmarkLabel.TabIndex = 1;
        this.landmarkLabel.Text = "Landmark";
        this.landmarkLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
        // 
        // landmarkTextBox
        // 
        this.landmarkTextBox.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.landmarkTextBox.Location = new System.Drawing.Point(154, 18);
        this.landmarkTextBox.Name = "landmarkTextBox";
        this.landmarkTextBox.Size = new System.Drawing.Size(148, 30);
        this.landmarkTextBox.TabIndex = 0;
        // 
        // panel3
        // 
        this.panel3.Controls.Add(this.tripsDataGridView);
        this.panel3.Controls.Add(this.tripLabel);
        this.panel3.Location = new System.Drawing.Point(353, 69);
        this.panel3.Name = "panel3";
        this.panel3.Size = new System.Drawing.Size(646, 215);
        this.panel3.TabIndex = 4;
        // 
        // tripsDataGridView
        // 
        this.tripsDataGridView.AllowUserToAddRows = false;
        this.tripsDataGridView.AllowUserToDeleteRows = false;
        this.tripsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.tripsDataGridView.Location = new System.Drawing.Point(3, 37);
        this.tripsDataGridView.Name = "tripsDataGridView";
        this.tripsDataGridView.ReadOnly = true;
        this.tripsDataGridView.Size = new System.Drawing.Size(640, 175);
        this.tripsDataGridView.TabIndex = 1;
        this.tripsDataGridView.CellFormatting += tripsDataGridView_CellFormatting;
        // 
        // tripLabel
        // 
        this.tripLabel.Font = new System.Drawing.Font("Bahnschrift", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.tripLabel.Location = new System.Drawing.Point(12, 0);
        this.tripLabel.Name = "tripLabel";
        this.tripLabel.Size = new System.Drawing.Size(631, 34);
        this.tripLabel.TabIndex = 0;
        this.tripLabel.Text = "Trips";
        this.tripLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // panel4
        // 
        this.panel4.Controls.Add(this.searchedTripsDataGridView);
        this.panel4.Controls.Add(this.label1);
        this.panel4.Location = new System.Drawing.Point(353, 309);
        this.panel4.Name = "panel4";
        this.panel4.Size = new System.Drawing.Size(646, 215);
        this.panel4.TabIndex = 5;
        // 
        // searchedTripsDataGridView
        // 
        this.searchedTripsDataGridView.AllowUserToAddRows = false;
        this.searchedTripsDataGridView.AllowUserToDeleteRows = false;
        this.searchedTripsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.searchedTripsDataGridView.Location = new System.Drawing.Point(3, 33);
        this.searchedTripsDataGridView.Name = "searchedTripsDataGridView";
        this.searchedTripsDataGridView.ReadOnly = true;
        this.searchedTripsDataGridView.Size = new System.Drawing.Size(640, 179);
        this.searchedTripsDataGridView.TabIndex = 1;
        // 
        // label1
        // 
        this.label1.Font = new System.Drawing.Font("Bahnschrift", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.label1.Location = new System.Drawing.Point(13, 0);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(630, 30);
        this.label1.TabIndex = 0;
        this.label1.Text = "Searched Trips";
        this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // MainWindow
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(1014, 547);
        this.Controls.Add(this.panel4);
        this.Controls.Add(this.panel3);
        this.Controls.Add(this.searchPanel);
        this.Controls.Add(this.logoutButton);
        this.Controls.Add(this.nameLabel);
        this.Controls.Add(this.reservePanel);
        this.Name = "MainWindow";
        this.Text = "MainWindow";
        this.Load += new System.EventHandler(this.MainWindow_Load);
        this.reservePanel.ResumeLayout(false);
        this.reservePanel.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.seatsUpDown)).EndInit();
        this.searchPanel.ResumeLayout(false);
        this.searchPanel.PerformLayout();
        this.panel3.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.tripsDataGridView)).EndInit();
        this.panel4.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.searchedTripsDataGridView)).EndInit();
        this.ResumeLayout(false);
    }

    private System.Windows.Forms.DataGridView searchedTripsDataGridView;

    private System.Windows.Forms.Panel panel4;
    private System.Windows.Forms.Label label1;

    private System.Windows.Forms.DataGridView tripsDataGridView;

    private System.Windows.Forms.Panel panel3;
    private System.Windows.Forms.Label tripLabel;

    private System.Windows.Forms.Button searchButton;

    private System.Windows.Forms.Label endHourLabel;

    private System.Windows.Forms.ComboBox endHourComboBox;

    private System.Windows.Forms.Label startHourLabel;

    private System.Windows.Forms.ComboBox startHourComboBox;

    private System.Windows.Forms.Label landmarkLabel;

    private System.Windows.Forms.Panel searchPanel;
    private System.Windows.Forms.TextBox landmarkTextBox;

    private System.Windows.Forms.Button logoutButton;

    private System.Windows.Forms.Label nameLabel;

    private System.Windows.Forms.Label clientNameLabel;

    private System.Windows.Forms.Button reserveButton;

    private System.Windows.Forms.Label noSeatsLabel;

    private System.Windows.Forms.NumericUpDown seatsUpDown;

    private System.Windows.Forms.TextBox phoneNumberTextBox;

    private System.Windows.Forms.Panel reservePanel;
    private System.Windows.Forms.Label phoneNumberLabel;
    private System.Windows.Forms.TextBox clientNameTextBox;

    #endregion
}