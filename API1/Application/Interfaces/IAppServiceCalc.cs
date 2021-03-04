using Core.Validation;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IAppServiceCalc
    {
        Task<decimal> GetCalculoAsync(decimal valorInicial, int tempo);
        INotification GetNotification();
    }
}
