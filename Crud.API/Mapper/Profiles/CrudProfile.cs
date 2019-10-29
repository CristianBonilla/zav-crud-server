using AutoMapper;
using Crud.Domain;

namespace Crud.API
{
    public class CrudProfile : Profile
    {
        public CrudProfile()
        {
            CreateMap<VisitaEntity, VisitaEntity>()
                // .IgnoreAllUnmapped()
                .ReverseMap();
            CreateMap<VisitaModel, VisitaEntity>()
                .ForMember(d => d.Id, m => m.Ignore())
                .ReverseMap();
        }
    }
}
