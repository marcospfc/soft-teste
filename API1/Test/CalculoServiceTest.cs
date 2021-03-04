using Core.Interfaces;
using Core.Services;
using Core.Validation;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Test.Unit
{
    public class CalculoServiceTest
    {
        readonly Mock<INotification> _notificacaoMock;
        readonly Mock<IServicoJuro> _serviceTaxaJurMock;
        readonly ServiceCalculo _serviceCalculo;
        public CalculoServiceTest()
        {
            _notificacaoMock = new Mock<INotification>();
            _serviceTaxaJurMock = new Mock<IServicoJuro>();
            _serviceCalculo = new ServiceCalculo(_notificacaoMock.Object, _serviceTaxaJurMock.Object);
        }

        [Theory]
        [InlineData(100, 5, 105.10)]
        public async Task CalculoService_ComValoresValidos_RetornaValorEsperado(decimal valorInicial, int tempo, decimal resultado)
        {
            _notificacaoMock.Setup(x => x.IsValid()).Returns(true);

            var result = await _serviceCalculo.GetCalculoAsync(valorInicial, tempo);

            Assert.IsType<decimal>(result);

            Assert.Equal(resultado, result);
        }

        [Theory]
        [InlineData(-100, 5)]
        [InlineData(100,  5)]
        [InlineData(100, -5)]
        public async Task CalculoService_ComValoresNegativos_DeveRetornarZero(decimal valorInicial, int tempo)
        {            
            var result = await _serviceCalculo.GetCalculoAsync(valorInicial, tempo);

            _serviceTaxaJurMock.Verify(x => x.GetJuro(), Times.Once);

            Assert.Equal(0, result);
        }
    }
}