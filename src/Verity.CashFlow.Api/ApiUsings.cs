global using Hangfire;
global using MediatR;
global using Microsoft.AspNetCore.Mvc;
global using OperationResult;
global using Verity.CashFlow.Contracts.ViewModels;
global using Serilog;
global using ILogger = Serilog.ILogger;

global using Verity.CashFlow.Application;
global using Verity.CashFlow.Application.Services;
global using Verity.CashFlow.Contracts.Requests.Commands;
global using Verity.CashFlow.Contracts.Requests.Queries;
global using Verity.CashFlow.Infrastructure;
global using Verity.CashFlow.Infrastructure.Convertes;
global using Verity.CashFlow.Infrastructure.Persistence;
