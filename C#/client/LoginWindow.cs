using System;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;
using model;

namespace client
{
    public partial class LoginWindow : Form
    {
        private TravelAgencyClientController _controller;
        public LoginWindow(TravelAgencyClientController ctrl)
        {
            InitializeComponent();
            _controller = ctrl;
        }

        private void LoginWindow_Load(object sender, EventArgs e)
        {
            Text = @"Travel agency - Login";
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;
            try
            {
                _controller.Login(username, password);
                TravelAgencyWindow mainWindow = new TravelAgencyWindow(_controller, new model.User(username, password));
                mainWindow.Show();
                Hide();
                
                usernameTextBox.Clear();
                passwordTextBox.Clear();
            }
            catch (Exception ex)
            {
                string error = "Login error: " + ex.Message;
                MessageBox.Show(null, error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}