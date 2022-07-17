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
    public class SIMCardGetListSummaryQuery : PagedQuery, IRequest<PagedResponse<List<SIMCardGetListSummaryViewModel>>> {

        /// <summary>
        /// search by shop code, provider name, card number
        /// </summary>
        public string Keyword { get; set; }

        /// <summary>
        /// default: all
        /// </summary>
        public int ShopId { get; set; }

        /// <summary>
        /// default: all
        /// </summary>
        public int ProviderId { get; set; } = 0;

        /// <summary>
        /// default: all
        /// </summary>
        public bool? IsActive { get; set; }

        /// <summary>
        /// default: ascending
        /// </summary>
        public new SortBy SortBy { get; set; } = SortBy.Asc;

        /// <summary>
        /// default: provider
        /// </summary>
        public SIMCardOrderBy OrderBy { get; set; } = SIMCardOrderBy.Provider;

    }

    public class SIMCardGetListSummaryQueryHandler : IRequestHandler<SIMCardGetListSummaryQuery, PagedResponse<List<SIMCardGetListSummaryViewModel>>> {
        private readonly IUnitOfWork _unitOfWork;

        public SIMCardGetListSummaryQueryHandler(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }

        public async Task<PagedResponse<List<SIMCardGetListSummaryViewModel>>> Handle(SIMCardGetListSummaryQuery request, CancellationToken cancellationToken) {
            var (total, list) = await _unitOfWork.SIMCards.GetListSIMCardSummary(request);
            var result = new List<SIMCardGetListSummaryViewModel>();

            foreach (var item in list) {
                var vm = new SIMCardGetListSummaryViewModel() {
                    CardName = item.CardName,
                    Count = item.Count
                };
                result.Add(vm);
            }

            return new PagedResponse<List<SIMCardGetListSummaryViewModel>>(result, total, request.PageSize, request.PageNumber
                , "Summary of SIMCards has been sent successfully.");
        }
    }
}
