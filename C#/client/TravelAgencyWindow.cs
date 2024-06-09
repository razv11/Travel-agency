using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using model;

namespace client
{
    public partial class TravelAgencyWindow : Form
    {
        private TravelAgencyClientController _controller;
        private List<model.Trip> _trips;
        private model.User _currentUser;
        public TravelAgencyWindow(TravelAgencyClientController ctrl, model.User user)
        {
            Console.WriteLine(@"Initializing window for user: {0}", user.Username);
            _controller = ctrl;
            _currentUser = user;
            InitializeComponent();
            _trips = new List<model.Trip>(_controller.GetAllTrips());
            _controller.UpdateEvent += UserUpdate;
        }
        
        private void tripsDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridViewTrips.Columns[e.ColumnIndex].Name == "AvailableSeats")
            {
                if (Convert.ToInt32(e.Value) == 0)
                {
                    dataGridViewTrips.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
                    dataGridViewTrips.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
                }
            }
        }

        private void InitializeDataGridViewForTrips()
        {
            dataGridViewTrips.DataSource = _trips;
            dataGridViewTrips.Columns["Id"].Visible = false;
            dataGridViewTrips.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewTrips.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void InitDataGridViewForSearchedTrips(model.Trip[] searchedTrips)
        {
            dataGridViewSearchedTrips.DataSource = searchedTrips;
            dataGridViewSearchedTrips.Columns["Id"].Visible = false;
            dataGridViewSearchedTrips.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewSearchedTrips.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void TravelAgencyWindow_Load(object sender, EventArgs e)
        {
            Text = @"Travel Agency App";
            userLabel.Text = @"Welcome back, " + _currentUser.Username;
            
            startHourComboBox.Items.Clear();
            endHourComboBox.Items.Clear();

            for (int i = 0; i <= 23; ++i)
            {
                startHourComboBox.Items.Add(i);
                endHourComboBox.Items.Add(i);
            }

            startHourComboBox.SelectedIndex = 0;
            endHourComboBox.SelectedIndex = 0;
            
            InitializeDataGridViewForTrips();
        }

        public void UserUpdate(object sender, TravelAgencyUserEventArgs e)
        {
            if (e.EventType == TravelAgencyUserEvent.TripReserved)
            {
                foreach(model.Trip trip in _trips)
                {
                    model.Reservation reservation = (model.Reservation)e.Data;
                    if (trip.Id == reservation.CurrentTrip.Id)
                    {
                        trip.AvailableSeats = reservation.CurrentTrip.AvailableSeats;
                        break;
                    }
                }
                
                Console.WriteLine(@"Trip reserved by user: {0}", _currentUser.Username);
                dataGridViewTrips.BeginInvoke(new UpdataDataGridViewTripsCallback(this.UpdateDataGridViewTrips), new Object[] {dataGridViewSearchedTrips, _trips});
            }
        }

        private void UpdateDataGridViewTrips(DataGridView dataGridView, List<model.Trip> newData)
        {
            dataGridViewTrips.DataSource = null;
            dataGridViewTrips.DataSource = newData;
            dataGridViewTrips.Columns["Id"].Visible = false;
        }

        public delegate void UpdataDataGridViewTripsCallback(DataGridView dataGridView, List<model.Trip> trips);

        private void ShowErrorMessage(string error)
        {
            MessageBox.Show(null, error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        
        private void reserveButton_Click(object sender, EventArgs e)
        {
            string clientName = clientNameTextBox.Text;
            if (clientName == "")
            {
                ShowErrorMessage("Client name must be not null!");
                return;
            }

            string phoneNumberS = phoneNumberTextBox.Text;
            if (phoneNumberS == "")
            {
                ShowErrorMessage("Phone number must be not null!");
                return;
            }

            try
            {
                int.Parse(phoneNumberS);
            }
            catch (Exception ex)
            {
                ShowErrorMessage("Phone number must be numeric!");
                return;
            }

            int noSeats = (int)noSeastaUpDown.Value;
            if (noSeats <= 0)
            {
                ShowErrorMessage("Number of seats must be greater than 0!");
                return;
            }

            if (dataGridViewTrips.SelectedRows.Count == 0)
            {
                ShowErrorMessage("You must select a Trip!");
                return; 
            }
            
            DataGridViewRow selectedRow = dataGridViewTrips.SelectedRows[0];
            model.Trip selectedTrip = (model.Trip)selectedRow.DataBoundItem;

            if (noSeats > selectedTrip.AvailableSeats)
            {
                ShowErrorMessage("Insufficient number of seats available!");
                return;
            }
            
            DialogResult result = MessageBox.Show(@"Are you sure you want to reserve this book?", @"Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    _controller.ReserveTrip(clientName, phoneNumberS, noSeats, _currentUser, selectedTrip);
                    MessageBox.Show(@"Trip successfully reserved!");
                    clientNameTextBox.Clear();
                    phoneNumberTextBox.Clear();
                    noSeastaUpDown.Value = 0;
                }
                catch (Exception ex)
                {
                    ShowErrorMessage(ex.Message);
                }
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            string landmark = landmarkTextBox.Text;
            if (landmark == "")
            {
                ShowErrorMessage("Landmark must be not null!");
                return;
            }

            if (startHourComboBox.SelectedItem == null)
            {
                ShowErrorMessage("Select start hour!");
                return;
            }

            if (endHourComboBox.SelectedItem == null)
            {
                ShowErrorMessage("Select end hour");
                return;
            }

            int startHour = (int)startHourComboBox.SelectedItem;
            int endHour = (int)endHourComboBox.SelectedItem;

            InitDataGridViewForSearchedTrips(_controller.GetSearchedTrips(landmark, startHour, endHour));
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            try
            {
                _controller.Logout();
                _controller.UpdateEvent -= UserUpdate;
                Application.Exit();
            }
            catch (Exception ex)
            {
                ShowErrorMessage("Logout error: " + ex.Message);
            }
        }
    }
}