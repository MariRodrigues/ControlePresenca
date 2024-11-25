using AutoMapper;
using ControlePresenca.Application.Commands.Relatorios;
using ControlePresenca.Domain.Entities;

namespace ControlePresenca.Application.Profiles
{
    public class RelatorioProfile : Profile
    {
        public RelatorioProfile()
        {
            CreateMap<CreateRelatorioCommand, Relatorio>();
            CreateMap<UpdateRelatorioCommand, Relatorio>();

        }
    }
}
