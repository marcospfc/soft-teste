using Core.Interfaces;
using Core.Models.Calculo;
using Core.Validation;
using System;
using System.Threading.Tasks;

namespace Core.Services
{
    public class ServiceCalculo : IServiceCalculo
    {
        protected INotification Notification { get { return _Notification; } }
        protected INotification _Notification;
        protected IServicoJuro _ServicoJuro;        

        public ServiceCalculo(INotification notificacao, IServicoJuro servicoJuro)
        {
            _Notification = notificacao;
            _ServicoJuro = servicoJuro;
        }
        
       public async Task ValidarAsync(Calculo calculo)
       {
           var validacao = new CalculoValidation(calculo);

           foreach (var notificacao in validacao.Contract.Notifications)
               _Notification.Add(notificacao.Message);
       }
       public async Task<decimal> GetCalculoAsync(decimal valorInicial, int tempo)
       {
           decimal taxaJuro = 0;
           try
           {
               taxaJuro = _ServicoJuro.GetJuro().Taxa;
           }
           catch (Exception ex)
           {
               _Notification.Add("Erro ao buscar taxa de juros.");
               return 0;
           }

           var calculo = Calculo.Criar(taxaJuro, valorInicial, tempo);

           await ValidarAsync(calculo);

           if (_Notification.IsValid())
           {
               return await calculo.Calcular();
           }
           return 0;
       }       
 
        public INotification GetNotification()
        {
            return Notification;
        }
    }
}