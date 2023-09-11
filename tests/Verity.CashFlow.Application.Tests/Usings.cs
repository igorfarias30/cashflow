global using FluentAssertions;
global using OperationResult;
global using Mapster;
global using MapsterMapper;
global using NSubstitute;
global using Xunit;
global using System.Linq.Expressions;
global using System.Text;

global using Verity.CashFlow.Application.Repositories;
global using Verity.CashFlow.Application.Services.Exporter;
global using Verity.CashFlow.Application.Services.Strategies;
global using Verity.CashFlow.Application.RequestHandlers.CommandHandlers;
global using Verity.CashFlow.Application.RequestHandlers.QueryHandlers;
global using Verity.CashFlow.Contracts.Requests.Commands;
global using Verity.CashFlow.Contracts.Requests.Queries;
global using Verity.CashFlow.Contracts.ViewModels;
global using Verity.CashFlow.Domain.Entities;
global using Verity.CashFlow.Domain.Enums;
