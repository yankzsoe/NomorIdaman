using MediatR;
using NomorIdaman.Application.Common.Models.Enums;
using NomorIdaman.Application.Common.Models.Responses;
using NomorIdaman.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NomorIdaman.Application.Features.Shop.Queries.GetList {
    public class ShopGetListQuery : PagedQuery, IRequest<PagedResponse<List<ShopGetListViewModel>>> {
        /// <summary>
        /// search by name or code
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

    }

    public class ShopGetListQueryHandler : IRequestHandler<ShopGetListQuery, PagedResponse<List<ShopGetListViewModel>>> {
        private readonly IUnitOfWork _unitOfWork;

        public ShopGetListQueryHandler(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }

        public async Task<PagedResponse<List<ShopGetListViewModel>>> Handle(ShopGetListQuery request, CancellationToken cancellationToken) {
            var (total, list) = await _unitOfWork.Shops.GetListAsNotrackingAsync(request);
            var result = new List<ShopGetListViewModel>();

            foreach (var item in list) {
                var vm = new ShopGetListViewModel() {
                    Id = item.Id,
                    Code = item.Code,
                    Name = item.Name,
                    Description = item.Description,
                    IsActive = item.IsActive,
                    Image = item.Image
                };
                result.Add(vm);
            }

            return new PagedResponse<List<ShopGetListViewModel>>(result, total, request.PageSize, request.PageNumber
                , "List of Shops has been sent successfully.");
        }
    }
}
