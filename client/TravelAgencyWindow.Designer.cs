using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace client
{
    partial class TravelAgencyWindow
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.userLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.reserveTripLabel = new System.Windows.Forms.Label();
            this.clientNameLabel = new System.Windows.Forms.Label();
            this.phoneNumberLabel = new System.Windows.Forms.Label();
            this.noSeatsLabel = new System.Windows.Forms.Label();
            this.clientNameTextBox = new System.Windows.Forms.TextBox();
            this.phoneNumberTextBox = new System.Windows.Forms.TextBox();
            this.noSeastaUpDown = new System.Windows.Forms.NumericUpDown();
            this.reserveButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.searchTripLabel = new System.Windows.Forms.Label();
            this.landmarkLabel = new System.Windows.Forms.Label();
            this.startHourLabel = new System.Windows.Forms.Label();
            this.endHourLabel = new System.Windows.Forms.Label();
            this.landmarkTextBox = new System.Windows.Forms.TextBox();
            this.startHourComboBox = new System.Windows.Forms.ComboBox();
            this.endHourComboBox = new System.Windows.Forms.ComboBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.logoutButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.tripLabel = new System.Windows.Forms.Label();
            this.dataGridViewTrips = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewSearchedTrips = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.noSeastaUpDown)).BeginInit();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTrips)).BeginInit();
            this.tableLayoutPanel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSearchedTrips)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(
                new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.ColumnStyles.Add(
                new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel5, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(
                new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1037, 686);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(
                new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(
                new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.userLabel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(6, 8);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(
                new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(
                new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel2.RowStyles.Add(
                new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel2.RowStyles.Add(
                new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(
                new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel2.RowStyles.Add(
                new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(350, 670);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // userLabel
            // 
            this.userLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userLabel.Font = new System.Drawing.Font("Bahnschrift Condensed", 15.75F,
                System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userLabel.Location = new System.Drawing.Point(8, 2);
            this.userLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.userLabel.Name = "userLabel";
            this.userLabel.Size = new System.Drawing.Size(334, 132);
            this.userLabel.TabIndex = 0;
            this.userLabel.Text = "Welcome back, you";
            this.userLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(
                new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(
                new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(
                new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(
                new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.reserveTripLabel, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.clientNameLabel, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.phoneNumberLabel, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.noSeatsLabel, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.clientNameTextBox, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.phoneNumberTextBox, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.noSeastaUpDown, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.reserveButton, 1, 4);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(8, 144);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 5;
            this.tableLayoutPanel3.RowStyles.Add(
                new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.RowStyles.Add(
                new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.RowStyles.Add(
                new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.RowStyles.Add(
                new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.RowStyles.Add(
                new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.RowStyles.Add(
                new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.RowStyles.Add(
                new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.RowStyles.Add(
                new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.RowStyles.Add(
                new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.RowStyles.Add(
                new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(334, 248);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // reserveTripLabel
            // 
            this.reserveTripLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reserveTripLabel.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold,
                System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reserveTripLabel.Location = new System.Drawing.Point(8, 2);
            this.reserveTripLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.reserveTripLabel.Name = "reserveTripLabel";
            this.reserveTripLabel.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.reserveTripLabel.Size = new System.Drawing.Size(152, 47);
            this.reserveTripLabel.TabIndex = 0;
            this.reserveTripLabel.Text = "Reserve trip";
            this.reserveTripLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // clientNameLabel
            // 
            this.clientNameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clientNameLabel.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clientNameLabel.Location = new System.Drawing.Point(8, 51);
            this.clientNameLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.clientNameLabel.Name = "clientNameLabel";
            this.clientNameLabel.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.clientNameLabel.Size = new System.Drawing.Size(152, 47);
            this.clientNameLabel.TabIndex = 1;
            this.clientNameLabel.Text = "Client name";
            this.clientNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // phoneNumberLabel
            // 
            this.phoneNumberLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.phoneNumberLabel.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phoneNumberLabel.Location = new System.Drawing.Point(6, 100);
            this.phoneNumberLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.phoneNumberLabel.Name = "phoneNumberLabel";
            this.phoneNumberLabel.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.phoneNumberLabel.Size = new System.Drawing.Size(156, 47);
            this.phoneNumberLabel.TabIndex = 2;
            this.phoneNumberLabel.Text = "Phone number";
            this.phoneNumberLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // noSeatsLabel
            // 
            this.noSeatsLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.noSeatsLabel.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noSeatsLabel.Location = new System.Drawing.Point(6, 149);
            this.noSeatsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.noSeatsLabel.Name = "noSeatsLabel";
            this.noSeatsLabel.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.noSeatsLabel.Size = new System.Drawing.Size(156, 47);
            this.noSeatsLabel.TabIndex = 3;
            this.noSeatsLabel.Text = "No seats";
            this.noSeatsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // clientNameTextBox
            // 
            this.clientNameTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.clientNameTextBox.Font = new System.Drawing.Font("Times New Roman", 9.75F,
                System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clientNameTextBox.Location = new System.Drawing.Point(172, 63);
            this.clientNameTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.clientNameTextBox.Name = "clientNameTextBox";
            this.clientNameTextBox.Size = new System.Drawing.Size(156, 22);
            this.clientNameTextBox.TabIndex = 4;
            // 
            // phoneNumberTextBox
            // 
            this.phoneNumberTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.phoneNumberTextBox.Font = new System.Drawing.Font("Times New Roman", 9.75F,
                System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phoneNumberTextBox.Location = new System.Drawing.Point(172, 112);
            this.phoneNumberTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.phoneNumberTextBox.Name = "phoneNumberTextBox";
            this.phoneNumberTextBox.Size = new System.Drawing.Size(156, 22);
            this.phoneNumberTextBox.TabIndex = 5;
            // 
            // noSeastaUpDown
            // 
            this.noSeastaUpDown.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.noSeastaUpDown.Location = new System.Drawing.Point(172, 159);
            this.noSeastaUpDown.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.noSeastaUpDown.Name = "noSeastaUpDown";
            this.noSeastaUpDown.Size = new System.Drawing.Size(156, 26);
            this.noSeastaUpDown.TabIndex = 6;
            // 
            // reserveButton
            // 
            this.reserveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom |
                                                                              System.Windows.Forms.AnchorStyles
                                                                                  .Right)));
            this.reserveButton.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold,
                System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reserveButton.Location = new System.Drawing.Point(230, 206);
            this.reserveButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.reserveButton.Name = "reserveButton";
            this.reserveButton.Size = new System.Drawing.Size(98, 35);
            this.reserveButton.TabIndex = 7;
            this.reserveButton.Text = "Reserve";
            this.reserveButton.UseVisualStyleBackColor = true;
            this.reserveButton.Click += new System.EventHandler(this.reserveButton_Click);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(
                new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(
                new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(
                new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(
                new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.searchTripLabel, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.landmarkLabel, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.startHourLabel, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.endHourLabel, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.landmarkTextBox, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.startHourComboBox, 1, 2);
            this.tableLayoutPanel4.Controls.Add(this.endHourComboBox, 1, 3);
            this.tableLayoutPanel4.Controls.Add(this.searchButton, 1, 4);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(6, 407);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 5;
            this.tableLayoutPanel4.RowStyles.Add(
                new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.RowStyles.Add(
                new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.RowStyles.Add(
                new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.RowStyles.Add(
                new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.RowStyles.Add(
                new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.RowStyles.Add(
                new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.RowStyles.Add(
                new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.RowStyles.Add(
                new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.RowStyles.Add(
                new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.RowStyles.Add(
                new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(338, 256);
            this.tableLayoutPanel4.TabIndex = 2;
            // 
            // searchTripLabel
            // 
            this.searchTripLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchTripLabel.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold,
                System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchTripLabel.Location = new System.Drawing.Point(6, 2);
            this.searchTripLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.searchTripLabel.Name = "searchTripLabel";
            this.searchTripLabel.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.searchTripLabel.Size = new System.Drawing.Size(158, 48);
            this.searchTripLabel.TabIndex = 0;
            this.searchTripLabel.Text = "Search trip";
            this.searchTripLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // landmarkLabel
            // 
            this.landmarkLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.landmarkLabel.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.landmarkLabel.Location = new System.Drawing.Point(6, 52);
            this.landmarkLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.landmarkLabel.Name = "landmarkLabel";
            this.landmarkLabel.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.landmarkLabel.Size = new System.Drawing.Size(158, 48);
            this.landmarkLabel.TabIndex = 1;
            this.landmarkLabel.Text = "Landmark";
            this.landmarkLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // startHourLabel
            // 
            this.startHourLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.startHourLabel.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startHourLabel.Location = new System.Drawing.Point(6, 102);
            this.startHourLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.startHourLabel.Name = "startHourLabel";
            this.startHourLabel.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.startHourLabel.Size = new System.Drawing.Size(158, 48);
            this.startHourLabel.TabIndex = 2;
            this.startHourLabel.Text = "Start hour";
            this.startHourLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // endHourLabel
            // 
            this.endHourLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.endHourLabel.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endHourLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.endHourLabel.Location = new System.Drawing.Point(6, 152);
            this.endHourLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.endHourLabel.Name = "endHourLabel";
            this.endHourLabel.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.endHourLabel.Size = new System.Drawing.Size(158, 48);
            this.endHourLabel.TabIndex = 3;
            this.endHourLabel.Text = "End hour";
            this.endHourLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // landmarkTextBox
            // 
            this.landmarkTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.landmarkTextBox.Font = new System.Drawing.Font("Times New Roman", 9.75F,
                System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.landmarkTextBox.Location = new System.Drawing.Point(174, 65);
            this.landmarkTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.landmarkTextBox.Name = "landmarkTextBox";
            this.landmarkTextBox.Size = new System.Drawing.Size(158, 22);
            this.landmarkTextBox.TabIndex = 4;
            // 
            // startHourComboBox
            // 
            this.startHourComboBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.startHourComboBox.Font = new System.Drawing.Font("Times New Roman", 9.75F,
                System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startHourComboBox.FormattingEnabled = true;
            this.startHourComboBox.Location = new System.Drawing.Point(174, 114);
            this.startHourComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.startHourComboBox.Name = "startHourComboBox";
            this.startHourComboBox.Size = new System.Drawing.Size(158, 23);
            this.startHourComboBox.TabIndex = 5;
            // 
            // endHourComboBox
            // 
            this.endHourComboBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.endHourComboBox.Font = new System.Drawing.Font("Times New Roman", 9.75F,
                System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endHourComboBox.FormattingEnabled = true;
            this.endHourComboBox.Location = new System.Drawing.Point(174, 164);
            this.endHourComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.endHourComboBox.Name = "endHourComboBox";
            this.endHourComboBox.Size = new System.Drawing.Size(158, 23);
            this.endHourComboBox.TabIndex = 6;
            // 
            // searchButton
            // 
            this.searchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom |
                                                                             System.Windows.Forms.AnchorStyles.Right)));
            this.searchButton.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold,
                System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchButton.Location = new System.Drawing.Point(220, 214);
            this.searchButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(112, 35);
            this.searchButton.TabIndex = 7;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(
                new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.ColumnStyles.Add(
                new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.logoutButton, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel6, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel7, 0, 2);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(366, 5);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 3;
            this.tableLayoutPanel5.RowStyles.Add(
                new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel5.RowStyles.Add(
                new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel5.RowStyles.Add(
                new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel5.RowStyles.Add(
                new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel5.RowStyles.Add(
                new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel5.RowStyles.Add(
                new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(667, 676);
            this.tableLayoutPanel5.TabIndex = 1;
            // 
            // logoutButton
            // 
            this.logoutButton.Anchor =
                ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top |
                                                      System.Windows.Forms.AnchorStyles.Right)));
            this.logoutButton.Font = new System.Drawing.Font("Bahnschrift", 14.25F, System.Drawing.FontStyle.Bold,
                System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logoutButton.Location = new System.Drawing.Point(583, 7);
            this.logoutButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(78, 38);
            this.logoutButton.TabIndex = 0;
            this.logoutButton.Text = "Logout";
            this.logoutButton.UseVisualStyleBackColor = true;
            this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(
                new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Controls.Add(this.tripLabel, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.dataGridViewTrips, 0, 1);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(6, 142);
            this.tableLayoutPanel6.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 2;
            this.tableLayoutPanel6.RowStyles.Add(
                new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel6.RowStyles.Add(
                new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(655, 257);
            this.tableLayoutPanel6.TabIndex = 1;
            // 
            // tripLabel
            // 
            this.tripLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tripLabel.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tripLabel.Location = new System.Drawing.Point(4, 0);
            this.tripLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.tripLabel.Name = "tripLabel";
            this.tripLabel.Size = new System.Drawing.Size(647, 51);
            this.tripLabel.TabIndex = 0;
            this.tripLabel.Text = "Trips";
            this.tripLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dataGridViewTrips
            // 
            this.dataGridViewTrips.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTrips.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewTrips.Location = new System.Drawing.Point(8, 59);
            this.dataGridViewTrips.Margin = new System.Windows.Forms.Padding(8);
            this.dataGridViewTrips.Name = "dataGridViewTrips";
            this.dataGridViewTrips.ReadOnly = true;
            this.dataGridViewTrips.Size = new System.Drawing.Size(639, 190);
            this.dataGridViewTrips.TabIndex = 1;
            dataGridViewTrips.CellFormatting += tripsDataGridView_CellFormatting;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 1;
            this.tableLayoutPanel7.ColumnStyles.Add(
                new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.dataGridViewSearchedTrips, 0, 1);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(6, 411);
            this.tableLayoutPanel7.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 2;
            this.tableLayoutPanel7.RowStyles.Add(
                new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel7.RowStyles.Add(
                new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(655, 258);
            this.tableLayoutPanel7.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(647, 51);
            this.label1.TabIndex = 0;
            this.label1.Text = "Searched trips";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dataGridViewSearchedTrips
            // 
            this.dataGridViewSearchedTrips.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSearchedTrips.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewSearchedTrips.Enabled = false;
            this.dataGridViewSearchedTrips.Location = new System.Drawing.Point(8, 59);
            this.dataGridViewSearchedTrips.Margin = new System.Windows.Forms.Padding(8);
            this.dataGridViewSearchedTrips.Name = "dataGridViewSearchedTrips";
            this.dataGridViewSearchedTrips.ReadOnly = true;
            this.dataGridViewSearchedTrips.Size = new System.Drawing.Size(639, 191);
            this.dataGridViewSearchedTrips.TabIndex = 1;
            dataGridViewTrips.CellFormatting += tripsDataGridView_CellFormatting;
            // 
            // TravelAgencyWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1037, 686);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Location = new System.Drawing.Point(15, 15);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "TravelAgencyWindow";
            this.Load += new System.EventHandler(this.TravelAgencyWindow_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.noSeastaUpDown)).EndInit();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTrips)).EndInit();
            this.tableLayoutPanel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSearchedTrips)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridView dataGridViewSearchedTrips;

        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;

        private System.Windows.Forms.DataGridView dataGridViewTrips;

        private System.Windows.Forms.Label tripLabel;

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;

        private System.Windows.Forms.Button logoutButton;

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;

        private System.Windows.Forms.Button searchButton;

        private System.Windows.Forms.ComboBox endHourComboBox;

        private System.Windows.Forms.ComboBox startHourComboBox;

        private System.Windows.Forms.TextBox landmarkTextBox;

        private System.Windows.Forms.Label endHourLabel;

        private System.Windows.Forms.Label startHourLabel;

        private System.Windows.Forms.Label landmarkLabel;

        private System.Windows.Forms.Label searchTripLabel;

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;

        private System.Windows.Forms.Button reserveButton;

        private System.Windows.Forms.NumericUpDown noSeastaUpDown;

        private System.Windows.Forms.TextBox phoneNumberTextBox;

        private System.Windows.Forms.TextBox clientNameTextBox;

        private System.Windows.Forms.Label noSeatsLabel;

        private System.Windows.Forms.Label phoneNumberLabel;

        private System.Windows.Forms.Label userLabel;

        private System.Windows.Forms.Label clientNameLabel;

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;

        private System.Windows.Forms.Label reserveTripLabel;

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;

        #endregion
    }
}