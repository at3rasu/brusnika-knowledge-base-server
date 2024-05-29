using AutoMapper;
using BrusnikaKnowledgeBaseServer.Core.Models.DbModels;
using BrusnikaKnowledgeBaseServer.Core.Models.Dtos;
using System;

namespace BrusnikaKnowledgeBaseServer.Core.Models.MappingProfiles
{
    public class KnowledgeMappingProfile : Profile
    {
        public KnowledgeMappingProfile()
        {
            CreateMap<KnowledgeCreateDto, Knowledge>()
                .ForMember(dest => dest.FileName, opt => opt.MapFrom(src => src.Content.FileName))
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content));

            // Маппинг для получения
            CreateMap<Knowledge, KnowledgeDto>()
                .ForMember(dest => dest.FileName, opt => opt.MapFrom(src => src.FileName))
                .ForMember(dest => dest.Src, opt => opt.MapFrom(src => src.Src));


            /*
                        CreateMap<KnowledgeDto, Knowledge>()
                            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                            .ForMember(dest => dest.FileName, opt => opt.MapFrom(src => src.Content != null ? src.Content.FileName : string.Empty));*/

            /*CreateMap<KnowledgeDto, KnowledgeWithFileName>()
                .ForMember(dest => dest.FileName, opt => opt.MapFrom(src => src.Content != null ? src.Content.FileName : string.Empty));*/


        }
    }

}
