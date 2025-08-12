using System;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace TCC___Gerenciamento_de_estoque
{
    public static class NotaFiscalSimuladaGenerator
    {
        public static string GerarNfcePdf(int produtoId, string clienteNome, string produtoNome, int quantidade, decimal precoUnitario)
        {
            string pastaNotas = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "NotasFiscaisFake");
            if (!Directory.Exists(pastaNotas)) Directory.CreateDirectory(pastaNotas);

            string nomeArquivo = $"NFCe_Fake_{produtoId}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
            string caminhoCompleto = Path.Combine(pastaNotas, nomeArquivo);

            using (FileStream fs = new FileStream(caminhoCompleto, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                Document doc = new Document(PageSize.A4);
                PdfWriter writer = PdfWriter.GetInstance(doc, fs);
                doc.Open();

                // Fonte básica
                var fontTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18);
                var fontNormal = FontFactory.GetFont(FontFactory.HELVETICA, 12);

                // Título
                doc.Add(new Paragraph("Nota Fiscal de Consumidor Eletrônica (NFC-e) - FAKE", fontTitulo));
                doc.Add(new Paragraph($"Emitida em: {DateTime.Now:dd/MM/yyyy HH:mm:ss}", fontNormal));
                doc.Add(new Paragraph(" "));

                // Dados cliente
                doc.Add(new Paragraph($"Cliente: {clienteNome}", fontNormal));
                doc.Add(new Paragraph(" "));

                // Tabela produto
                PdfPTable tabela = new PdfPTable(4);
                tabela.WidthPercentage = 100;
                tabela.SetWidths(new float[] { 60, 15, 15, 20 });

                tabela.AddCell(new Phrase("Produto", fontNormal));
                tabela.AddCell(new Phrase("Qtd.", fontNormal));
                tabela.AddCell(new Phrase("Preço Unit.", fontNormal));
                tabela.AddCell(new Phrase("Total", fontNormal));

                tabela.AddCell(new Phrase(produtoNome, fontNormal));
                tabela.AddCell(new Phrase(quantidade.ToString(), fontNormal));
                tabela.AddCell(new Phrase(precoUnitario.ToString("C"), fontNormal));
                tabela.AddCell(new Phrase((quantidade * precoUnitario).ToString("C"), fontNormal));

                doc.Add(tabela);

                doc.Add(new Paragraph(" "));
                doc.Add(new Paragraph($"Valor Total: {(quantidade * precoUnitario).ToString("C")}", fontNormal));

                doc.Close();
                writer.Close();
            }

            return caminhoCompleto;
        }
    }
}

