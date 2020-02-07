namespace Blog.Application.Common.Behaviours
{
    using System.Diagnostics;
    using System.Threading;
    using System.Threading.Tasks;
    using Interfaces;
    using MediatR;
    using Microsoft.Extensions.Logging;

    public class RequestPerformanceBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly Stopwatch timer;
        private readonly ILogger<TRequest> logger;
        private readonly ICurrentUser currentUserService;
        private readonly IIdentity identityService;

        public RequestPerformanceBehaviour(
            ILogger<TRequest> logger, 
            ICurrentUser currentUserService,
            IIdentity identityService)
        {
            this.timer = new Stopwatch();
            
            this.logger = logger;
            this.currentUserService = currentUserService;
            this.identityService = identityService;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            this.timer.Start();

            var response = await next();

            this.timer.Stop();

            var elapsedMilliseconds = this.timer.ElapsedMilliseconds;

            if (elapsedMilliseconds <= 500)
            {
                return response;
            }

            var requestName = typeof(TRequest).Name;
            var userId = this.currentUserService.UserId;
            var userName = await this.identityService.GetUserName(userId);

            this.logger.LogWarning(
                "Blog Long Running Request: {Name} ({ElapsedMilliseconds} milliseconds) {@UserId} {@Request}",
                requestName, 
                elapsedMilliseconds, 
                userId,
                userName ?? "Anonymous", 
                request);

            return response;
        }
    }
}
