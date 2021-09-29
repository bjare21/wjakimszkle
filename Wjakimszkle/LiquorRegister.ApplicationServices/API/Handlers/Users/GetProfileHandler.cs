using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wjakimszkle.ApplicationServices.API.Domain.Models;
using Wjakimszkle.ApplicationServices.API.Domain.Users;
using Wjakimszkle.DataAccess;
using Wjakimszkle.DataAccess.CQRS.Queries;

namespace Wjakimszkle.ApplicationServices.API.Handlers.Users
{
    //public class GetProfileHandler:IRequestHandler<GetProfileRequest, GetProfileResponse>
    //{
    //    private readonly IMapper mapper;
    //    private readonly IQueryExecutor queryExecutor;

    //    public GetProfileHandler(IMapper mapper, IQueryExecutor queryExecutor)
    //    {
    //        this.mapper = mapper;
    //        this.queryExecutor = queryExecutor;
    //    }

    //    public async Task<GetProfileResponse> Handle(GetProfileRequest request, CancellationToken cancellationToken)
    //    {
    //        int userId = int.Parse(request.AuthorizationClaim.Id);

    //        if (userId == null)
    //        {
    //            //brak zalogowania? możliwy?
    //        }
    //        var query = new GetProfileQuery()
    //        {
    //            Id = userId
    //        };

    //        var user = await this.queryExecutor.Execute(query);

    //        var response = new GetProfileResponse()
    //        {
    //            Data = this.mapper.Map<User>(user)
    //        };

    //        return response;
    //    }
    //}
}
