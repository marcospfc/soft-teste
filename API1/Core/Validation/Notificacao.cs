using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Validation
{
    public class Notification : INotification
    {
        private List<string> _mensagem;

        public Notification()
        {
            _mensagem = new List<string>();
        }

        public void Add(string mensagem)
        {
            _mensagem.Add(mensagem);
        }

        public bool IsValid()
        {
            return (_mensagem.Count == 0);
        }

        public List<string> returnError()
        {
            return _mensagem;
        }
    }
}
