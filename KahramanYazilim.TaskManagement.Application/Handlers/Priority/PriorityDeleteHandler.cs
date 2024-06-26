﻿using KahramanYazilim.TaskManagement.Application.Dtos;
using KahramanYazilim.TaskManagement.Application.Interfaces;
using KahramanYazilim.TaskManagement.Application.Requests;
using MediatR;

namespace KahramanYazilim.TaskManagement.Application.Handlers
{
    public class PriorityDeleteHandler : IRequestHandler<PriorityDeleteRequest, Result<NoData>>
    {
        private readonly IPriorityRepository repository;

        public PriorityDeleteHandler(IPriorityRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Result<NoData>> Handle(PriorityDeleteRequest request, CancellationToken cancellationToken)
        {
            var deletedEntity = await this.repository.GetByFilterAsync(x => x.Id == request.Id);
            if (deletedEntity != null)
            {
                await this.repository.DeleteAsync(deletedEntity);
                return new Result<NoData>(new NoData(), true, null, null);
            }
            return new Result<NoData>(new NoData(), false, "Silinecek aciliyet bulunamadı", null);
        }
    }
}
