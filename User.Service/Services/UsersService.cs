using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using GrpcUser;

namespace User.Service
{
    public class UsersService : GrpcUser.User.UserBase
    {
        private readonly ILogger<UsersService> _logger;
        public UsersService(ILogger<UsersService> logger)
        {
            _logger = logger;
        }

        public override Task<UserReply> SayHello(UserRequest request, ServerCallContext context)
        {
            return Task.FromResult(new UserReply
            {
                Name = "Hello "
            });
        }
    }
}
