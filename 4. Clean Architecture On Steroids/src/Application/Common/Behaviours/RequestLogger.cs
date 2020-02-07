namespace Blog.Application.Common.Behaviours
{
    using System.Threading;
    using System.Threading.Tasks;
    using Interfaces;
    using MediatR.Pipeline;
    using Microsoft.Extensions.Logging;

    public class RequestLogger<TRequest> : IRequestPreProcessor<TRequest>
    {
        private readonly ILogger logger;
        private readonly ICurrentUser currentUserService;
        private readonly IIdentity identityService;

        public RequestLogger(
            ILogger<TRequest> logger, 
            ICurrentUser currentUserService, 
            IIdentity identityService)
        {
            this.logger = logger;
            this.currentUserService = currentUserService;
            this.identityService = identityService;
        }

        public async Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var requestName = typeof(TRequest).Name;
            var userId = this.currentUserService.UserId;
            var userName = await this.identityService.GetUserName(userId);

            this.logger.LogInformation(
                "Blog Request: {Name} {@UserId} {@UserName} {@Request}",
                requestName,
                userId, 
                userName ?? "Anonymous",
                request);
        }
    }
}
