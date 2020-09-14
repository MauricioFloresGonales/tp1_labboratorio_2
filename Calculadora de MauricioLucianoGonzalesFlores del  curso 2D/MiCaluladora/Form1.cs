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
        Numero operadorUno = new Numero();
        Numero operadorDos = new Numero();
        char operador;
        string resultdado;
        public MiCalculadora()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {

        }

        private void txtNumero1_TextChanged(object sender, EventArgs e)
        {
            string numero = this.txtNumero1.Text;
            operadorUno.SetNumero(numero);
        }

        private void txtNumero2_TextChanged(object sender, EventArgs e)
        {
            string numero = this.txtNumero2.Text;
            operadorUno.SetNumero(numero);
        }

        private void cmbOperador_SelectedIndexChanged(object sender, EventArgs e)
        {
            string resultado = this.cmbOperador.Text;
            operador = resultado[0];
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            resultdado = Calculadora.operar(operador, operadorUno, operadorDos);
            lblResultado_TextChanged(sender, e);
        }

        private void lblResultado_TextChanged(object sender, EventArgs e)
        {
            label1.Text = resultdado;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            string numeroUno = "0";
            string numeroDos = "0";
            operadorUno.SetNumero(numeroUno);
            operadorDos.SetNumero(numeroDos);
        }
    }
}
