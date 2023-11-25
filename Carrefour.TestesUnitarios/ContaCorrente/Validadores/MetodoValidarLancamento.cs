using Carrefour.Dominio.ObjetosDeValor;
using Carrefour.Dominio.Servicos.Implementacao.Validadores;
using Carrefour.TestesUnitarios.ContaCorrente.DadosDeTeste;
using System;
using Xunit;

namespace Carrefour.TestesUnitarios.ContaCorrente.Validadores
{
    public partial class ValidadoresLancamento
    {
        public class MetodoValidarLancamento
        {
            [Fact]
            public void QuandoTodosOsAtributosForamInformadosCorretamente_Credito()
            {
                //Arrange
                var lancamentoOV = new LancamentoOV()
                {
                    DataEfetiva = DateTime.Now,
                    Valor = 1
                };

                // Act
                var resultado = ValidarLancamento.Validar(lancamentoOV);

                // Assert
                Assert.True(resultado);
            }

            [Fact]
            public void QuandoTodosOsAtributosForamInformadosCorretamente_Debito()
            {
                //Arrange
                var lancamentoOV = new LancamentoOV()
                {
                    DataEfetiva = DateTime.Now,
                    Valor = -1
                };

                // Act
                var resultado = ValidarLancamento.Validar(lancamentoOV);

                // Assert
                Assert.True(resultado);
            }

            [Theory]
            [ClassData(typeof(LancamentoOVDadosDeTeste))]
            public void QuandoAlgumAtributoNaoForInformadoCorretamenteRetornaFalse(LancamentoOV lancamentoOV)
            {
                // Act
                var resultado = ValidarLancamento.Validar(lancamentoOV);

                // Assert
                Assert.False(resultado);
            }
        }
    }
}
