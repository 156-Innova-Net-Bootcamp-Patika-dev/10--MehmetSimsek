using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Features.Commands.Buildings.Blocks.AddBlock
{
    public class AddBlockCommand : IRequest<int>
    {
        public string Name { get; set; }
    }
}
