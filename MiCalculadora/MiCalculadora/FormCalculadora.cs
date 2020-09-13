using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }
        private void Limpiar()
        {
            string empty = "";
            txtNumero1.Text = empty;
            txtNumero2.Text = empty;
            lblResultado.Text = empty;
        }

        private static double Operar(string numero1, string numero2, string operador)
        {
            Numero num1 = new Numero(numero1);
            Numero num2 = new Numero(numero2);

            return Calculadora.Operar(num1, num2, operador);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
            btnConvertirADecimal.Enabled = true;
            btnConvertirABinario.Enabled = true;
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            string num1 = this.txtNumero1.Text;
            string num2 = this.txtNumero2.Text;
            string operador = this.cmbOperador.Text;

            this.lblResultado.Text = Operar(num1, num2, operador).ToString();
            btnConvertirADecimal.Enabled = false;
            btnConvertirABinario.Enabled = true;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            string numeroConvertir = this.lblResultado.Text;
            this.lblResultado.Text = Numero.DecimalBinario(numeroConvertir);
            btnConvertirABinario.Enabled = false;
            btnConvertirADecimal.Enabled = true;
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            string numeroConvertir = this.lblResultado.Text;
            this.lblResultado.Text = Numero.BinarioDecimal(numeroConvertir);
            btnConvertirADecimal.Enabled = false;
            btnConvertirABinario.Enabled = true;
        }
    }
}
