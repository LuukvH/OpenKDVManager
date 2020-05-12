using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Grpc.Net.Client;
using GrpcUser;
using Grpc.Core;

namespace User.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        // GET: api/Users
        [HttpGet]
        public async Task<IEnumerable<string>> GetAsync()
        {
            // The port number(5001) must match the port of the gRPC server.
            using var channel = GrpcChannel.ForAddress("https://user.service");
            var client = new GrpcUser.User.UserClient(channel);
            var reply = await client.SayHelloAsync(
                              new UserRequest { Uuid = "GreeterClient" });

            return new string[] { reply.Name };
        }
    }
}
