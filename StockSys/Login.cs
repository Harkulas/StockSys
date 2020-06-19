using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockSys
{
    public partial class Login : Form
    {
        //This adds the event handler for the control
        private void AddDrag(Control Control) { Control.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Login_MouseDown); }
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        public Login()
        {
            InitializeComponent();
            AddDrag(panel1);
        }

        private void lgClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lgClose_MouseHover(object sender, EventArgs e)
        {
            lgClose.BackColor = Color.MediumVioletRed;
        }

        private void lgClose_MouseLeave(object sender, EventArgs e)
        {
            lgClose.BackColor = Color.Transparent;
        }

        private void txtLoginUsername_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter && txtLoginUsername.Text != "")
            //{
            //    e.Handled = true;
            //    e.SuppressKeyPress = true;
            //    txtLoginPassword.Focus();
            //}
            //else
            //{
            //    ShowErrorMessage("Please Enter Username");
            //}

            if (e.KeyCode == Keys.Enter)
            {
                if (txtLoginUsername.Text == "")
                {
                    ShowErrorMessage("Please Enter Username.");
                }
                else
                {
                    lblErrorMessage.Visible = false;
                    txtLoginPassword.Focus();
                }
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txtLoginPassword_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter && txtLoginPassword.Text != "")
            //{
            //    e.Handled = true;
            //    e.SuppressKeyPress = true;
            //    this.ActiveControl = btnLogin;
            //    btnLogin.Focus();
            //}

            if (e.KeyCode == Keys.Enter)
            {
                if (txtLoginPassword.Text == "")
                {
                    ShowErrorMessage("Please Enter Password.");
                }
                else
                {
                    lblErrorMessage.Visible = false;
                    this.ActiveControl = btnLogin;
                    btnLogin.Focus();
                }
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtLoginUsername.Text != "" && txtLoginPassword.Text != "")
            {
                UserLogin user = new UserLogin();
                var isValidUser = user.LoginUser(txtLoginUsername.Text, txtLoginPassword.Text);

                if (isValidUser)
                {
                    ShowErrorMessage("Congratulatons");
                    MainDashboard mainds = new MainDashboard();
                    mainds.Show();
                    mainds.FormClosed += Logout;
                    this.Hide();
                    //MessageBox.Show("Congratulatons");
                }
                else
                {
                    ShowErrorMessage("Please Enter Valid Username or Password !");
                    //MessageBox.Show("Please Enter Valid Username or Password !");
                    txtLoginPassword.Clear();
                    txtLoginUsername.Focus();
                }

            }
            else
            {
                ShowErrorMessage("Please Enter Username and Password !");
                //MessageBox.Show("Please Enter Username and Password !");
            }
        }

        private void ShowErrorMessage(string msg)
        {
            lblErrorMessage.Text = "      " + msg;
            lblErrorMessage.Visible = true;
            //MessageBox.Show("" + msg + "");
        }

        private void Login_MouseMove(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Left)
            //{
            //    Point mousePos = Control.MousePosition;
            //    mousePos.Offset(mouseLocation.X, mouseLocation.Y);
            //    Location = mousePos;
            //}
        }

        //public Point mouseLocation;
        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                // Checks if Y = 0, if so maximize the form
                if (this.Location.Y == 0) { this.WindowState = FormWindowState.Maximized; }
            }
            //mouseLocation = new Point(-e.X, -e.Y);
        }

        private void Logout(object sender,FormClosedEventArgs e)
        {
            txtLoginUsername.Clear();
            txtLoginPassword.Clear();
            lblErrorMessage.Visible = false;
            this.Show();
            txtLoginUsername.Focus();
        }
    }
}
