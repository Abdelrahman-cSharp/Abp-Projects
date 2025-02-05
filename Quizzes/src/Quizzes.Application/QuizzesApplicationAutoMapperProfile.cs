using AutoMapper;
using Quizzes.Questions;
using System.Collections.Generic;

namespace Quizzes;

public class QuizzesApplicationAutoMapperProfile : Profile
{
    public QuizzesApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<Quiz, QuizDto>()
            .ForMember(dest => dest.MCQs, opt => opt.MapFrom(src => src.MCQs != null ? src.MCQs : new List<MCQ>()))
            .ForMember(dest => dest.TFs, opt => opt.MapFrom(src => src.TFs != null ? src.TFs : new List<TF>()))
            .ReverseMap();
        CreateMap<QuizDto, CreateUpdateQuizDto>()
            .ReverseMap();
        CreateMap<CreateUpdateQuizDto, Quiz>()
            .ReverseMap();


        CreateMap<MCQ, MCQDto>()
            .ReverseMap();
        CreateMap<CreateUpdateMCQDto, MCQ>()
            .ReverseMap();
        CreateMap<MCQDto, CreateUpdateMCQDto>()
            .ReverseMap();


        CreateMap<TF, TFDto>()
            .ReverseMap();
        CreateMap<CreateUpdateTFDto, TF>()
            .ReverseMap();
        CreateMap<TFDto, CreateUpdateTFDto>()
            .ReverseMap();



    }
}
