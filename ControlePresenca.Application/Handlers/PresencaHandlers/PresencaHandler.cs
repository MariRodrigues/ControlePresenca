using AutoMapper;
using ControlePresenca.Application.Commands.Presenca;
using ControlePresenca.Application.Response;
using ControlePresenca.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ControlePresenca.Application.Handlers.PresencaHandlers
{
    public class PresencaHandler : IPresencaHandler
    {
        private readonly IMapper _mapper;
        private readonly IClasseRepository _classeRepository;
        private readonly IRelatorioRepository _relatorioRepository;
        private readonly IPresencaRepository _presencaRepository;

        public PresencaHandler(IMapper mapper, IClasseRepository classeRepository, IRelatorioRepository relatorioRepository, IPresencaRepository presencaRepository)
        {
            _mapper = mapper;
            _classeRepository = classeRepository;
            _relatorioRepository = relatorioRepository;
            _presencaRepository = presencaRepository;
        }

        public Task<ResponseApi> Handle(CreatePresencaCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
