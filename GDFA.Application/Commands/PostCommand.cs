using Convey.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDFA.Application.Commands
{
    public class PostCommand : ICommand
    {
        public PostCommand()
        {
            Console.WriteLine("PostCommand");
        }
    }
}
