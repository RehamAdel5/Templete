﻿using Domain.Abstractions;
using Domain.ViewModels;
using MediatR;

namespace Application.Handeler.Queries.Service.Queries
{
    public class GetServiceQueryHandler : IRequestHandler<GetServiceQuery, List<ServicesViewModel>>
    {
        private readonly IServicesRepository _servicesRepository; 
        public GetServiceQueryHandler(IServicesRepository servicesRepository)
        {
            _servicesRepository = servicesRepository;
        }
        public async Task<List<ServicesViewModel>> Handle(GetServiceQuery request, CancellationToken cancellationToken)
        {
            return await _servicesRepository.GetServicesAsync();
        }
    }
}
