using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WCF.Winforms {
	public partial class Form1 : Form {
		public Form1() {
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e) {
			WCFEmpresaService.EmpresaServiceClient wcf = new WCFEmpresaService.EmpresaServiceClient();
			wcf.ClientCredentials.UserName.UserName = txtUser.Text;
			wcf.ClientCredentials.UserName.Password = txtPsw.Text;

			try {
				dataGridView1.DataSource = wcf.GetEmpresas();
			} catch (Exception ex) {
				MessageBox.Show(ex.Message + System.Environment.NewLine + ex.InnerException.Message);
			} finally {
				if(wcf.State == System.ServiceModel.CommunicationState.Opened)
					wcf.Close();
			}
		}

		private void button2_Click(object sender, EventArgs e) {
			WCFEmpresaService.EmpresaServiceClient wcf = new WCFEmpresaService.EmpresaServiceClient();
			wcf.ClientCredentials.UserName.UserName = txtUser.Text;
			wcf.ClientCredentials.UserName.Password = txtPsw.Text;

			WCFEmpresaService.Empresa emp = wcf.GetEmpresaByID(Int32.Parse(textBox1.Text));

			if (emp != null)
				textBox2.Text = emp.Codigo + " - " + emp.Nome;
			else
				MessageBox.Show("Não encontrada");

			wcf.Close();
		}
	}
}
