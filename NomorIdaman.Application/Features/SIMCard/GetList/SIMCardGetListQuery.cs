using MediatR;
using NomorIdaman.Application.Common.Formatters;
using NomorIdaman.Application.Common.Models.Enums;
using NomorIdaman.Application.Common.Models.Responses;
using NomorIdaman.Application.Features.SIMCard.GetList;
using NomorIdaman.Application.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NomorIdaman.Application.Features.SIMCard.Queries.GetList {
    public class SIMCardGetListQuery : PagedQuery, IRequest<PagedResponse<List<SIMCardGetListViewModel>>> {

        /// <summary>
        /// search by shop code, provider name, card number
        /// </summary>
        public string Keyword { get; set; }

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

    public class SIMCardGetListQueryHandler : IRequestHandler<SIMCardGetListQuery, PagedResponse<List<SIMCardGetListViewModel>>> {
        private readonly IUnitOfWork _unitOfWork;

        public SIMCardGetListQueryHandler(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }

        public async Task<PagedResponse<List<SIMCardGetListViewModel>>> Handle(SIMCardGetListQuery request, CancellationToken cancellationToken) {
            var (total, list) = await _unitOfWork.SIMCards.GetListAsNotrackingAsync(request);
            var result = new List<SIMCardGetListViewModel>();

            foreach (var item in list) {
                var vm = new SIMCardGetListViewModel() {
                    CardNumber = item.CardNumber,
                    Price = NumberFormatters.Currency.Format(item.Price),
                    Description = item.Description,
                    IsActive = item.IsActive,
                    Image = item.Image,
                    ShopId = item.ShopId,
                    ShopCode = item.Shop.Code,
                    ProviderCardId = item.ProviderCardId,
                    ProviderCardName = item.ProviderCard.Name
                };
                result.Add(vm);
            }

            return new PagedResponse<List<SIMCardGetListViewModel>>(result, total, request.PageSize, request.PageNumber
                , "List of SIMCards has been sent successfully.");
        }
    }
}
