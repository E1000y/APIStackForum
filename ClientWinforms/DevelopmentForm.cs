﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientWinforms
{
    public partial class DevelopmentForm : Form
    {

        string _jwt;
        public DevelopmentForm(string jwt)
        {
            _jwt = jwt;
            InitializeComponent();
        }

        private void DevelopmentForm_Load(object sender, EventArgs e)
        {
            TxtToken.Text = _jwt;
        }
    }
}