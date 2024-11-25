using ControlePresenca.Infra.Query;
using OfficeOpenXml;
using System.Threading.Tasks;

namespace ControlePresenca.Application.Services;

public interface IDocumentServices
{
    Task<byte[]> GenerateRelatorioExcel();
}

public class DocumentServices(IRelatorioQueries relatorioQueries) : IDocumentServices
{
    public async Task<byte[]> GenerateRelatorioExcel()
    {
        var relatorios = await relatorioQueries.GetGeneralRelatorio();

        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

        using var package = new ExcelPackage();
        var worksheet = package.Workbook.Worksheets.Add("Relatório Geral");

        worksheet.Cells[1, 1].Value = "IdRelatorio";
        worksheet.Cells[1, 2].Value = "DataRelatorio";
        worksheet.Cells[1, 3].Value = "ObservacaoRelatorio";
        worksheet.Cells[1, 4].Value = "Nome_Aluno";
        worksheet.Cells[1, 5].Value = "Nome_Professor";
        worksheet.Cells[1, 6].Value = "Presença";
        worksheet.Cells[1, 7].Value = "Turma";

        int row = 2;
        foreach (var relatorio in relatorios)
        {
            worksheet.Cells[row, 1].Value = relatorio.RelatorioId;
            worksheet.Cells[row, 2].Value = relatorio.Data.ToString("yyyy-MM-dd");
            worksheet.Cells[row, 3].Value = relatorio.Observacao;
            worksheet.Cells[row, 4].Value = relatorio.NomeAluno;
            worksheet.Cells[row, 5].Value = relatorio.NomeProfessor;
            worksheet.Cells[row, 6].Value = relatorio.Presenca;
            worksheet.Cells[row, 7].Value = relatorio.Turma;
            row++;
        }

        worksheet.Cells.AutoFitColumns();

        return package.GetAsByteArray();
    }
}
