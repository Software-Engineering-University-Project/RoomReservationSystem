﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoomReservationSystem.UserInterface
{
    public partial class FormLogIn : Form
    {
        public FormLogIn()
        {
            InitializeComponent();
            password.UseSystemPasswordChar = true;
            password.PasswordChar = '*';
        }

        //to delete
        private void FormLogIn_Load(object sender, EventArgs e)
        {

        }

        private void buttonLogIn_Click(object sender, EventArgs e)
        {
            //login
        }
    }
}