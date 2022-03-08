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

namespace NomorIdaman.Application.Features.ProviderCard.Queries.GetList {
    public class ProviderGetListQuery : PagedQuery, IRequest<PagedResponse<List<ProviderGetListViewModel>>> {
        /// <summary>
        /// search by name
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

    public class ProviderGetListQueryHandler : IRequestHandler<ProviderGetListQuery, PagedResponse<List<ProviderGetListViewModel>>> {
        private readonly IUnitOfWork _unitOfWork;

        public ProviderGetListQueryHandler(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }

        public async Task<PagedResponse<List<ProviderGetListViewModel>>> Handle(ProviderGetListQuery request, CancellationToken cancellationToken) {
            var (total, list) = await _unitOfWork.ProviderCards.GetListAsync(request);
            var result = new List<ProviderGetListViewModel>();

            foreach (var item in list) {
                var vm = new ProviderGetListViewModel() {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    IsActive = item.IsActive,
                    Image = item.Image
                };
                result.Add(vm);
            }

            return new PagedResponse<List<ProviderGetListViewModel>>(result, total, request.PageSize, request.PageNumber
                , "List of Provider Cards has been sent successfully.");
        }
    }
}
