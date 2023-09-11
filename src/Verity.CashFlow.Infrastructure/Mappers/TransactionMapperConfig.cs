using Mapster;
using Verity.CashFlow.Contracts.DTOs;
using Verity.CashFlow.Contracts.ViewModels;

namespace Verity.CashFlow.Infrastructure.Mappers;

internal class TransactionMapperConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Transaction, TransactionViewModel>()
            .Map(dest => dest.Id, src => src.Id);

        config.NewConfig<Transaction, TransactionDetailsDto>()
           .Map(dest => dest.Id, src => src.Id);

        config.NewConfig<TransactionDetailsDto, TransactionViewModel>();
    }
}
