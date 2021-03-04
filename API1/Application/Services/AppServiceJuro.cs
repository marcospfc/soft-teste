using Application.Interfaces;
using AutoMapper;
using Core.Interfaces;
using Core.Models.Juro;
using Core.Validation;
using Core.ViewModels.Output;
using System.Threading.Tasks;

namespace Aplicacao.Services
{
    public class AppServiceJuro : IAppServiceJuro
    {
        private readonly IServicoJuro _servico;
        private readonly IMapper _mapper;

        public AppServiceJuro(IServicoJuro servico, IMapper mapper)
        {
            _servico = servico;
            _mapper = mapper;
        }
        public JuroOutputModel GetJuro()
        {
            var retorno = _mapper.Map<Juro, JuroOutputModel>(_servico.GetJuro());

            return retorno;
        }
    }
}
