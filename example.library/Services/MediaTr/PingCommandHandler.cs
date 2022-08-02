using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace example.library.Services.MediaTr
{
    public class Pong
    {
        public DateTime ResponseSendAt { get; }

        public Pong(DateTime responseSendAt)
        {
            this.ResponseSendAt = responseSendAt;
        }
    }

    public class PingCommand : IRequest<Pong> { } // Command

    public class PingCommandHandler : IRequestHandler<PingCommand, Pong>
    {        
        public async Task<Pong> Handle(PingCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(new Pong(DateTime.UtcNow)).ConfigureAwait(false);
        }
    }

}
