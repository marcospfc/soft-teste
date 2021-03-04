using Application.Interfaces;
using Core.Interfaces;
using Core.Validation;
using System.Threading.Tasks;

namespace Aplicacao.Services
{
    public class AppServiceCalc : IAppServiceCalc
    {
        private readonly IServiceCalculo _servico;

        public AppServiceCalc(IServiceCalculo servico)
        {
            _servico = servico;
        }
        public async Task<decimal> GetCalculoAsync(decimal valorInicial, int tempo)
        {   
            return await _servico.GetCalculoAsync(valorInicial, tempo);
        }

        public INotification GetNotification()
        {
            return _servico.GetNotification();
        }
    }
}
