using ManagementSystem.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagementSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            txtPassword.PasswordChar = '*';
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "admin" && txtPassword.Text == "password")
            {
                labelError.Visible = false;
                Dashboard ds = new Dashboard();
                this.Hide();
                ds.Show();
            }
            else
            {
                labelError.Visible = true;
                txtUsername.Clear();
                txtPassword.Clear();
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            int formWidth = this.ClientSize.Width;
            int formHeight = this.ClientSize.Height;

            btnExit.Location = new Point(formWidth - 60, 12);
            btnExit.Size = new Size(45, 43);

            int middleY = (this.Height - (txtUsername.Height + txtPassword.Height + btnLogin.Height + 20 + 50 + 20)) / 2;

            int shiftRight = 30; 

            txtUsername.Location = new Point(formWidth - txtUsername.Width - 20 - shiftRight, middleY);
            txtUsername.Size = new Size(formWidth / 3, 50);

            txtPassword.Location = new Point(formWidth - txtPassword.Width - 20 - shiftRight, txtUsername.Bottom + 20);
            txtPassword.Size = new Size(formWidth / 3, 50);

            btnLogin.Location = new Point(formWidth - btnLogin.Width - 20 - shiftRight, txtPassword.Bottom + 20);
            btnLogin.Size = new Size(formWidth / 3, 50);

            int labelX = btnLogin.Location.X + (btnLogin.Width - labelError.Width) / 2;
            int labelY = btnLogin.Bottom + 20;

            labelError.Location = new Point(labelX, labelY);
        }



    }


    public class PlaceHolderTextBox : TextBox
    {

        bool isPlaceHolder = true;
        string _placeHolderText;
        public string PlaceHolderText
        {
            get { return _placeHolderText; }
            set
            {
                _placeHolderText = value;
                setPlaceholder();
            }
        }

        public new string Text
        {
            get => isPlaceHolder ? string.Empty : base.Text;
            set => base.Text = value;
        }

        private void setPlaceholder()
        {
            if (string.IsNullOrEmpty(base.Text))
            {
                base.Text = PlaceHolderText;
                this.ForeColor = Color.Gray;
                this.Font = new Font(this.Font, FontStyle.Italic);
                isPlaceHolder = true;
            }
        }

        private void removePlaceHolder()
        {

            if (isPlaceHolder)
            {
                base.Text = "";
                this.ForeColor = System.Drawing.SystemColors.WindowText;
                this.Font = new Font(this.Font, FontStyle.Regular);
                isPlaceHolder = false;
            }
        }
        public PlaceHolderTextBox()
        {
            GotFocus += removePlaceHolder;
            LostFocus += setPlaceholder;
        }

        private void setPlaceholder(object sender, EventArgs e)
        {
            setPlaceholder();
        }

        private void removePlaceHolder(object sender, EventArgs e)
        {
            removePlaceHolder();
        }
    }
}