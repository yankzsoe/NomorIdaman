using MediatR;
using NomorIdaman.Application.Common.Formatters;
using NomorIdaman.Application.Common.Models.Enums;
using NomorIdaman.Application.Common.Models.Responses;
using NomorIdaman.Application.Features.SIMCard.GetList;
using NomorIdaman.Application.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NomorIdaman.Application.Features.SIMCard.Queries.GetListSummary {
    public class SIMCardGetListSummaryQuery : IRequest<Response<List<SIMCardGetListSummaryViewModel>>> { }

    public class SIMCardGetListSummaryQueryHandler : IRequestHandler<SIMCardGetListSummaryQuery, Response<List<SIMCardGetListSummaryViewModel>>> {
        private readonly IUnitOfWork _unitOfWork;

        public SIMCardGetListSummaryQueryHandler(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<List<SIMCardGetListSummaryViewModel>>> Handle(SIMCardGetListSummaryQuery request, CancellationToken cancellationToken) {
            var (total, list) = await _unitOfWork.SIMCards.GetListSIMCardSummary(request);
            var result = new List<SIMCardGetListSummaryViewModel>();

            foreach (var item in list) {
                var vm = new SIMCardGetListSummaryViewModel() {
                    CardName = item.CardName,
                    Count = item.Count
                };
                result.Add(vm);
            }

            return new Response<List<SIMCardGetListSummaryViewModel>>(result, "Summary of SIMCards has been sent successfully.");
        }
    }
}
