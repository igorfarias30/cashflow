using AutoMapper;
using Verity.CashFlow.Contracts.DTOs;
using Verity.CashFlow.Contracts.ViewModels;

namespace Verity.CashFlow.Infrastructure.Mappers;

internal class TransactionMapperConfig : Profile
{
    public TransactionMapperConfig()
    {
        CreateMap<Transaction, TransactionViewModel>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()));

        CreateMap<Transaction, TransactionDetailsDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()));

        CreateMap<TransactionDetailsDto, TransactionViewModel>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()));
    }
}
