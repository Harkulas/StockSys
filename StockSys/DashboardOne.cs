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
    public partial class DashboardOne : Form
    {
        public DashboardOne()
        {
            InitializeComponent();
            HideAllSubMenuPanels();
        }

        private void HideAllSubMenuPanels()
        {
            panelMastSubMenu.Visible = false;
            panelTransationSubMenu.Visible = false;
            panelReportsSubMenu.Visible = false;
        }

        private void HideAllSubMenu()
        {
            if (panelMastSubMenu.Visible == true)
            {
                panelMastSubMenu.Visible = false;
            }
            if (panelTransationSubMenu.Visible == true)
            {
                panelTransationSubMenu.Visible = false;
            }
            if (panelReportsSubMenu.Visible == true)
            {
                panelReportsSubMenu.Visible = false;
            }

        }

        private void ShowSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                HideAllSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }


        private void btnMastSetup_Click(object sender, EventArgs e)
        {
            ShowSubMenu(panelMastSubMenu);
        }

        #region MastSetup
        private void btnProduct_Click(object sender, EventArgs e)
        {
            //..
            //..
            HideAllSubMenu();
        }

        private void btnUnit_Click(object sender, EventArgs e)
        {
            //..
            //..
            HideAllSubMenu();
        }

        private void btnParty_Click(object sender, EventArgs e)
        {
            //..
            //..
            HideAllSubMenu();
        }
        #endregion

        private void btnTransaction_Click(object sender, EventArgs e)
        {
            ShowSubMenu(panelTransationSubMenu);
        }

        #region Transaction

        private void btnSales_Click(object sender, EventArgs e)
        {
            //..
            //..
            HideAllSubMenu();
        }

        private void btnPurchase_Click(object sender, EventArgs e)
        {
            //..
            //..
            HideAllSubMenu();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            //..
            //..
            HideAllSubMenu();
        }
        #endregion

        private void btnReports_Click(object sender, EventArgs e)
        {
            ShowSubMenu(panelReportsSubMenu);
        }

        #region Reports
        private void btnRptSales_Click(object sender, EventArgs e)
        {
            //..
            //..
            HideAllSubMenu();
        }

        private void btnRptPurchase_Click(object sender, EventArgs e)
        {
            //..
            //..
            HideAllSubMenu();
        }

        private void btnRptReturn_Click(object sender, EventArgs e)
        {
            //..
            //..
            HideAllSubMenu();
        }

        private void btnRptStock_Click(object sender, EventArgs e)
        {
            //..
            //..
            HideAllSubMenu();
        }
        #endregion

        private void btnSystemSetup_Click(object sender, EventArgs e)
        {
            //OpenChildForm(new UserEntry());
            //..
            //..
            HideAllSubMenu();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to log out?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Close();
            }
            //..
            //..
            HideAllSubMenu();
        }

        private Form activeForm = null;
        private void OpenChildForm(Form childFrom)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childFrom;
            childFrom.TopLevel = false;
            childFrom.FormBorderStyle = FormBorderStyle.None;
            childFrom.Dock = DockStyle.Fill;
            panelChildFormData.Controls.Add(childFrom);
            panelChildFormData.Tag = childFrom;
            childFrom.BringToFront();
            childFrom.Show();
        }
    }
}
