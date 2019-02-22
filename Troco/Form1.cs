using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Troco
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            decimal[] valor_moedas =
            {
                1.00m, 0.50m, 0.25m, 0.10m, 0.05m
            };
            int[] qtd_moedas_disp =
            {
                Convert.ToInt32(textBox1.Text.ToString()),
                Convert.ToInt32(textBox2.Text.ToString()),
                Convert.ToInt32(textBox3.Text.ToString()),
                Convert.ToInt32(textBox4.Text.ToString()),
                Convert.ToInt32(textBox5.Text.ToString())
            };
            int[] qtd_moedas_usadas =
            {
                0,0,0,0,0
            };

            decimal troco = Convert.ToDecimal(txtTroco.Text);
            decimal troco_temp = troco;
            decimal soma_no_caixa = 0;

            for (int j = 0; j < 5; j++)
            {
                soma_no_caixa += (qtd_moedas_disp[j] * valor_moedas[j]);
            }
            if (soma_no_caixa < troco)
            {
                MessageBox.Show("Impossivel dar o troco");
                return;
            }
            

            for (int i = 0; i < 5; i++)
            {
                troco = ProcessoTroco(i, qtd_moedas_disp, qtd_moedas_usadas, troco, troco_temp, valor_moedas);
                if (troco == 0)
                {
                    break;
                }
                troco_temp = troco;
            }

            textBox10.Text = Convert.ToString(qtd_moedas_usadas[0]);
            textBox9.Text = Convert.ToString(qtd_moedas_usadas[1]);
            textBox8.Text = Convert.ToString(qtd_moedas_usadas[2]);
            textBox7.Text = Convert.ToString(qtd_moedas_usadas[3]);
            textBox6.Text = Convert.ToString(qtd_moedas_usadas[4]);
                                                                
        }

        private decimal ProcessoTroco(int i, int[] qtd_moedas_disp, int[] qtd_moedas_usadas, decimal troco, decimal troco_temp, decimal[] valor_moedas)
        {
            do
            {
                troco -= valor_moedas[i];
                qtd_moedas_usadas[i]++;
                qtd_moedas_disp[i]--;
                if (qtd_moedas_disp[i] == -1) { break; }
            }
            while (troco >= 0);

            qtd_moedas_usadas[i]--;
            qtd_moedas_disp[i]++;

            troco = troco_temp - (qtd_moedas_usadas[i] * valor_moedas[i]);

            return troco;
        }
    }
}
