using Carrefour.Dominio.Servicos.Implementacao.Validadores;
using Xunit;

namespace Carrefour.TestesUnitarios.ContaCorrente.Validadores
{
    public partial class ValidadoresRelatorio
    {
        public class MetodoValidarRelatorioSaldo
        {
            [InlineData(null, null)]
            [InlineData("", "")]
            [InlineData("2022-11-16", null)]
            [InlineData("2022-11-16", "")]
            [InlineData("2022-11-16", "2022-11-16")]
            [InlineData("2022-11-16", "2022-11-17")]
            [Theory]
            public void QuandoTodosOsAtributosForamInformadosCorretamente(string dataInicial, string dataFinal)
            {
                // Act
                var resultado = ValidarRelatorioSaldo.Validar(dataInicial, dataFinal);

                // Assert
                Assert.True(resultado);
            }

            [InlineData(null, "2022-11-16")]
            [InlineData("", "2022-11-16")]
            [InlineData("2030-10-16", "")]
            [InlineData("2022-11-16", "2022-11-15")]
            [Theory]
            public void QuandoAlgumAtributoNaoForInformadoCorretamenteRetornaFalse(string dataInicial, string dataFinal)
            {
                // Act
                var resultado = ValidarRelatorioSaldo.Validar(dataInicial, dataFinal);

                // Assert
                Assert.False(resultado);
            }
        }
    }
}
