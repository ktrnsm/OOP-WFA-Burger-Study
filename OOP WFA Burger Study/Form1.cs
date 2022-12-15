using OOP_WFA_Burger_Study.Enums;
using OOP_WFA_Burger_Study.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Menu = OOP_WFA_Burger_Study.Models.Menu;

namespace OOP_WFA_Burger_Study
{
    public partial class rdbGross : Form
    {
        public rdbGross()
        {
            InitializeComponent();
        }

        private void Form1_Load  (object sender, EventArgs e)
            {
            List<Menu> menus = new List<Menu>
            {
                new Menu{Name="Texas Smoke House",Price=40, Info="Lovely"},

                new Menu{Name="BBQ",Price=35, Info="Tasty"},

                new Menu{Name="Chicken",Price=25, Info="Good"},

                new Menu{Name="Steak House", Price=45,Info="Very Good"},

                new Menu{Name="Cripsy", Price=15, Info="Very Tasty"}

            };

            cmbMenu.DataSource = menus;
            cmbMenu.SelectedIndex = -1;
            }

        private void lblInfo_Click(object sender, EventArgs e)
        {

        }

        private void rdbGross_Load(object sender, EventArgs e)
        {

        }

        private void cmbMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMenu.SelectedIndex != null)
            {
                lblInfo.Text = (cmbMenu.SelectedItem as Menu).Info;
            }
            else
            {
                lblInfo.Text = "";
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Order o = new Order();
            o.Name = textBox1.Text;
            if(cmbMenu.SelectedItem==null)
            {
                MessageBox.Show("Select a Menu");
                return;
            }

            o.SelectedMenu = cmbMenu.SelectedItem as Menu;
            o.Quantity = Convert.ToInt16(numericUpDown1.Value);

            if (radioButton1.Checked) o.Greatness = PizzaSizes.Gross;

            else if (rbdMedium.Checked) o.Greatness = PizzaSizes.Medium;
            
            foreach(CheckBox item in groupBox1.Controls)
            {
                if(item.Checked)
                {
                    Extras ex = new Extras();
                    ex.Name = item.Text;
                    ex.Price = Convert.ToDecimal(item.Tag);
                }
            }

            o.CalculateSum();
            listBox1.Items.Add(o);
        }

        private void btnSum_Click(object sender, EventArgs e)
        {
            decimal totalSum = 0;
            foreach(Order item in listBox1.Items)
            {
                totalSum += item.Price;
            }
            MessageBox.Show(totalSum.ToString());
        }
    }
}
