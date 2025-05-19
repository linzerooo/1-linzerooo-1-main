using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finate.Application.Features.Commands.Card.Query
{
    public class ClearCartCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
