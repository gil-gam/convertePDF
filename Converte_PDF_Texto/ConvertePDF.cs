using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System.IO;
using System.Text;

namespace Converte_PDF_Texto
{
    public class ConvertePDF
    {

        public string ExtrairTexto_PDF(string caminho)
        {

            //if (File.Exists(caminho))
            //{
            using (PdfReader leitor = new PdfReader(caminho))
            {
                StringBuilder texto = new StringBuilder();

                // no pdf com 4 colunas, captura da quarta para a primeira coluna (ou seja, da direita p/ esquerda);
                for (int page = 1; page <= leitor.NumberOfPages; page++)
                {
                    ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
                    string currentText = PdfTextExtractor.GetTextFromPage(leitor, page, strategy);

                    currentText = Encoding.UTF8.GetString(ASCIIEncoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(currentText)));
                    texto.Append(currentText);
                }
                //texto.Close();
                return texto.ToString();
            }
            //}

        }


        //public string ExtrairTexto_PDF(string caminho)
        //{
        //    using (PdfReader leitor = new PdfReader(caminho))
        //    {
        //        StringBuilder texto = new StringBuilder();

        //        for (int i = 1; i <= leitor.NumberOfPages; i++)
        //        {
        //            texto.Append(PdfTextExtractor.GetTextFromPage(leitor, i));
        //        }
        //        return texto.ToString();
        //    }
        //}
    }
}
