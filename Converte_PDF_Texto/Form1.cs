using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Converte_PDF_Texto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnConvertePDF_Click(object sender, EventArgs e)
        {
            try
            {
                ConvertePDF pdftxt = new ConvertePDF();
                txtArquivoTexto.Text = pdftxt.ExtrairTexto_PDF(txtCaminoNomePDF.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnProcurar_Click(object sender, EventArgs e)
        {
            //define as propriedades do controle 
            //OpenFileDialog
            this.ofd1.Multiselect = false;
            this.ofd1.Title = "Selecionar PDF";
            ofd1.InitialDirectory = @"C:\dados";
            //filtra para exibir somente arquivos de imagens
            ofd1.Filter = "Files (*.PDF)|*.PDF|" + "All files (*.*)|*.*";
            ofd1.CheckFileExists = true;
            ofd1.CheckPathExists = true;
            ofd1.FilterIndex = 2;
            ofd1.RestoreDirectory = true;
            ofd1.ReadOnlyChecked = true;
            ofd1.ShowReadOnly = false;
            
            DialogResult dr = this.ofd1.ShowDialog();

            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                txtCaminoNomePDF.Text = ofd1.FileName;
            }
        }

        private void txtCaminoNomePDF_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
