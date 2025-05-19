using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finate.Application.Features.Queries.Shop.Commands
{
    public class DeleteProductCardCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
