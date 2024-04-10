using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Agentie_turism.repository.reservationRepo;
using Agentie_turism.repository.tripRepo;
using Agentie_turism.repository.userRepo;
using Agentie_turism.service;

namespace Agentie_turism
{
    public partial class LoginForm : Form
    {
        private IDictionary<string, string> _props;
        private Service _service;
        private IUserRepository _userRepository;
        private ITripRepository _tripRepository;
        private IReservationRepository _reservationRepository;
        public LoginForm(IDictionary<string, string> props)
        {
            _props = props;
            _userRepository = new UserDbRepository(_props);
            _tripRepository = new TripDbRepository(_props);
            _reservationRepository = new ReservationDbRepository(_props);
            
            _service = new Service(_userRepository, _tripRepository, _reservationRepository);
            // _service.AddUser("razvan", "razv");
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            Text = @"Travel Agency";
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;

            if (username.Equals(""))
            {
                MessageBox.Show(@"Username field is empty!");
                return;
            }

            if (password.Equals(""))
            {
                MessageBox.Show(@"Password field is empty!");
                return;
            }

            if (_service.TryLogin(username, password))
            {
                MainWindow mainWindow = new MainWindow(_props, username);
                mainWindow.SetService(_service);
                mainWindow.Show();
                Hide();
                return;
            }

            MessageBox.Show(@"Invalid username or password!");
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}