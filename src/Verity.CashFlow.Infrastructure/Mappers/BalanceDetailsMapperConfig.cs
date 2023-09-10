using AutoMapper;
using Verity.CashFlow.Contracts.DTOs;
using Verity.CashFlow.Contracts.ViewModels;

namespace Verity.CashFlow.Infrastructure.Mappers;

internal sealed class BalanceDetailsMapperProfile : Profile
{
    public BalanceDetailsMapperProfile()
    {
        Expression<Func<Cash, long>> _incomeRetrieve = balance => balance
            .Transactions
            .Where(x => x.Type == TransactionType.Income)
            .Select(x => x.AmountInCents)
            .Sum();

        Expression<Func<Cash, long>> _outcomeRetrieve = balance => balance
            .Transactions
            .Where(x => x.Type == TransactionType.Outcome)
            .Select(x => x.AmountInCents)
            .Sum();

        CreateMap<BalanceDetailsDto, BalanceDetailsViewModel>()
            .ForMember(dest => dest.IncomeInCents, opt => opt.MapFrom(src => src.IncomeInCents))
            .ForMember(dest => dest.OutcomeInCents, opt => opt.MapFrom(src => src.OutcomeInCents))
            .ForMember(dest => dest.BalanceInCents, opt => opt.MapFrom(src => src.IncomeInCents - src.OutcomeInCents))
            .ForMember(dest => dest.Transactions, opt => opt.MapFrom(src => src.Transactions));

        CreateMap<Cash, BalanceDetailsDto>()
            .ForMember(dest => dest.IncomeInCents, opt => opt.MapFrom(_incomeRetrieve))
            .ForMember(dest => dest.OutcomeInCents, opt => opt.MapFrom(_outcomeRetrieve))
            .ForMember(dest => dest.Transactions, opt => opt.MapFrom(src => src.Transactions));
    }
}
