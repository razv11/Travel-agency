using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Agentie_turism.domain;
using Agentie_turism.service;

namespace Agentie_turism;

public partial class MainWindow : Form
{
    private IDictionary<string, string> _props;
    private string _username;
    private Service _service;
    
    public MainWindow(IDictionary<string, string> props, string uname)
    {
        _props = props;
        _username = uname;
        InitializeComponent();
    }

    public void SetService(Service serv)
    {
        _service = serv;
    }
    
    private void MainWindow_Load(object sender, EventArgs e)
    {
        nameLabel.Text = @"Welcome back, " + _username;
        Text = @"Travel Agency";
        
        startHourComboBox.Items.Clear();
        endHourComboBox.Items.Clear();

        for (int i = 0; i <= 23; ++i)
        {
            startHourComboBox.Items.Add(i);
            endHourComboBox.Items.Add(i);
        }

        startHourComboBox.SelectedIndex = 0;
        endHourComboBox.SelectedIndex = 0;

        InitalizeTripsDataGridView();
    }

    private void InitalizeTripsDataGridView()
    {
        tripsDataGridView.DataSource = _service.GetAllTrips();
        tripsDataGridView.Columns.Remove("Id");
        tripsDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        tripsDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
    }
    
    private void tripsDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if (tripsDataGridView.Columns[e.ColumnIndex].Name == "AvailableSeats")
        {
            if (Convert.ToInt32(e.Value) == 0)
            {
                tripsDataGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
                tripsDataGridView.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
            }
        }
    }

    private void ShowErrorMessageBox(string error)
    {
        MessageBox.Show(@"Error: " + error, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    private void reserveButton_Click(object sender, EventArgs e)
    {
        string clientName = clientNameTextBox.Text;
        string phoneNumber = phoneNumberTextBox.Text;
        int noSeats = (int)seatsUpDown.Value;

        if (clientName.Equals(""))
        { 
            ShowErrorMessageBox(@"Enter client name!");
            return;
        }

        if (phoneNumber.Equals(""))
        {
            ShowErrorMessageBox(@"Enter phone number!");
            return;
        }

        if (noSeats.Equals(0))
        { 
            ShowErrorMessageBox(@"Number of seats cannot be 0!");
            return;
        }

        if (tripsDataGridView.SelectedRows.Count == 0)
        {
            ShowErrorMessageBox(@"You must select a Trip!");
            return;
        }
        
        DataGridViewRow selectedRow = tripsDataGridView.SelectedRows[0];
        Trip selectedTrip = (Trip)selectedRow.DataBoundItem;

        if (noSeats > selectedTrip.AvailableSeats)
        {
            ShowErrorMessageBox(@"Insufficient number of seats available!");
            return;
        }
        
        DialogResult result = MessageBox.Show(@"Are you sure you want to reserve this book?", @"Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (result == DialogResult.Yes)
        {
            Reservation reservation =
                _service.SaveReservation(clientName, phoneNumber, noSeats, _username, selectedTrip);

            if (reservation is not null)
            {
                ShowErrorMessageBox(@"Error while trying to add the Resevation. \n Please try again");
                return;
            }

            MessageBox.Show(@"Confirmation: " + @" This book was successfully booked!", @"Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);

            clientNameTextBox.Clear();
            phoneNumberTextBox.Clear();
            seatsUpDown.Value = 0;

            InitalizeTripsDataGridView();
        }
    }

    private void searchButton_Click(object sender, EventArgs e)
    {
        string landmark = landmarkTextBox.Text;

        if (landmark.Equals(""))
        { 
            ShowErrorMessageBox(@"Enter the landmark!");
            return;
        }

        if (startHourComboBox.SelectedItem == null)
        {
            ShowErrorMessageBox(@"Select start hour!");
            return;
        }
        
        if (endHourComboBox.SelectedItem == null)
        {
            ShowErrorMessageBox(@"Select end hour!");
            return;
        }

        int startHour = (int)startHourComboBox.SelectedItem;
        int endHour = (int)endHourComboBox.SelectedItem;

        searchedTripsDataGridView.DataSource = _service.GetFilteredTrips(landmark, startHour, endHour);
        searchedTripsDataGridView.Columns.Remove("Id");
        searchedTripsDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        searchedTripsDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
    }

    private void logoutButton_Click(object sender, EventArgs e)
    {
        LoginForm loginForm = new LoginForm(_props);
        Close();
        loginForm.Show();
    }
}