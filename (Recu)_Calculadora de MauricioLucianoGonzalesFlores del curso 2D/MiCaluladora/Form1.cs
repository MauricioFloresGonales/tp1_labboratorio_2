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

namespace MiCaluladora
{
    public partial class MiCalculadora : Form
    {
        Numero operadorUno;
        Numero operadorDos;
        char operador;
        string resultdado;
        public MiCalculadora()
        {
            InitializeComponent();
        }

        private void MiCalculadora_Load(object sender, EventArgs e)
        {
            operadorUno = new Numero();
            operadorDos = new Numero();
        }

        private void txtNumero1_TextChanged(object sender, EventArgs e)
        {
            operadorUno.SetNumero(operadorUno, txtNumero1.Text);
        }

        private void txtNumero2_TextChanged(object sender, EventArgs e)
        {
            operadorDos.SetNumero(operadorDos, txtNumero2.Text);
        }

        private void cmbOperador_SelectedIndexChanged(object sender, EventArgs e)
        {
            string resultado = this.cmbOperador.Text;
            operador = resultado[0];
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            resultdado = Calculadora.operar(operadorUno, operadorDos, operador);
            lblResultado.Text = resultdado;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNumero1.Text = "0";
            txtNumero2.Text = "0";
        }
        private void txtNumero1_ModifiedChanged(object sender, EventArgs e)
        {
            operadorUno.SetNumero(operadorUno, "0");
        }
        private void txtNumero2_ModifiedChanged_1(object sender, EventArgs e)
        {
            operadorDos.SetNumero(operadorDos, "0");
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            lblResultado.Text = Numero.DecimalBinario(double.Parse(resultdado));
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            lblResultado.Text = Numero.BinarioDecimal(double.Parse(resultdado));
        }
    }
}
