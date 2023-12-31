﻿using MapsterMapper;

namespace Verity.CashFlow.Application.RequestHandlers.QueryHandlers;

public class GetBalanceDetailsQueryHandler : BaseQueryHandler<GetBalanceDetailsQuery, Result<BalanceDetailsViewModel>>
{
    private readonly ITransactionRepository _transactionRepository;
    private readonly IMapper _mapper;

    public GetBalanceDetailsQueryHandler(ITransactionRepository transactionRepository, IMapper mapper)
    {
        _transactionRepository = transactionRepository;
        _mapper = mapper;
    }

    public override async Task<Result<BalanceDetailsViewModel>> Handle(GetBalanceDetailsQuery request, CancellationToken cancellationToken)
    {
        var balanceDetails = await _transactionRepository.GetBalanceDetailsByDate(request.DateOfCash);
        return Result.Success(_mapper.Map<BalanceDetailsViewModel>(balanceDetails!));
    }
}
