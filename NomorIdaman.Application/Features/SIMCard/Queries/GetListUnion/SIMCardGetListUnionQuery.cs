using MediatR;
using NomorIdaman.Application.Common.Formatters;
using NomorIdaman.Application.Common.Models.Enums;
using NomorIdaman.Application.Common.Models.Responses;
using NomorIdaman.Application.Features.SIMCard.Queries.GetList;
using NomorIdaman.Application.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NomorIdaman.Application.Features.SIMCard.Queries.GetListUnion {
    public class SIMCardGetListUnionQuery : PagedQuery, IRequest<PagedResponse<List<SIMCardGetListUnionViewModel>>> {

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

    public class SIMCardGetListUnionQueryHandler : IRequestHandler<SIMCardGetListUnionQuery, PagedResponse<List<SIMCardGetListUnionViewModel>>> {
        private readonly IUnitOfWork _unitOfWork;

        public SIMCardGetListUnionQueryHandler(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }

        public async Task<PagedResponse<List<SIMCardGetListUnionViewModel>>> Handle(SIMCardGetListUnionQuery request, CancellationToken cancellationToken) {
            var (total, list) = await _unitOfWork.SIMCards.GetListUnionAsNotrackingAsync(request);
            var result = new List<SIMCardGetListUnionViewModel>();

            foreach (var item in list) {
                var vm = new SIMCardGetListUnionViewModel() {
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

            return new PagedResponse<List<SIMCardGetListUnionViewModel>>(result, total, request.PageSize, request.PageNumber
                , "List of SIMCards has been sent successfully.");
        }
    }
}
