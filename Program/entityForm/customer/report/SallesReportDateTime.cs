using Program.entityForm.customer.report;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Program.entityForm.customer
{
    public partial class SallesReportDateTime : Form
    {
        public SallesReportDateTime()
        {
            InitializeComponent();
        }

        private void SallesReportDateTime_Load(object sender, EventArgs e)
        {

        }

        private void bShow_Click(object sender, EventArgs e)
        {
            SaleReport.from = mcFrom.Value;
            SaleReport.to = mcTo.Value;
            SaleReport sr = new SaleReport();
            sr.ShowDialog();
        }
    }
}
