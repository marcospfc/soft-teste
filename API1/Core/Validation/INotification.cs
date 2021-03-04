using System.Collections.Generic;

namespace Core.Validation
{
    public interface INotification
    {
        void Add(string mensagem);
        bool IsValid();
        List<string> returnError();
    }
}