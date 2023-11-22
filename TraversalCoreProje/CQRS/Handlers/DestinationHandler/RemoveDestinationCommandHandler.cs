using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraversalCoreProje.CQRS.Commands.DestinationComment;

namespace TraversalCoreProje.CQRS.Handlers.DestinationHandler
{
    public class RemoveDestinationCommandHandler
    {
        private readonly Context _context;
        public RemoveDestinationCommandHandler(Context context)
        {
            _context = context;
        }

        public void Handle(RemoveDestinationCommand command)
        {
            var values = _context.Destinations.Find(command.Id);
            _context.Destinations.Remove(values);
            _context.SaveChanges();
        }
    }
}
