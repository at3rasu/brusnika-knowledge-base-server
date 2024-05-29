using AutoMapper;
using BrusnikaKnowledgeBaseServer.Core.Models.DbModels;
using BrusnikaKnowledgeBaseServer.Core.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrusnikaKnowledgeBaseServer.Core.Models.MappingProfiles
{
    public class FormuleMapping : Profile
    {
        public FormuleMapping()
        {
            CreateMap<Formule, FormuleDto>()
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            CreateMap<FormuleDto, Formule>()
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            CreateMap<FormuleResultDto, Formule>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Values, opt => opt.MapFrom(src => src.Values));

            CreateMap<Formule, FormuleResultDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Values, opt => opt.MapFrom(src => src.Values));
        }
    }
}
