using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraversalCoreProje.CQRS.Commands.DestinationComment;

namespace TraversalCoreProje.CQRS.Handlers.DestinationHandler
{
    public class CreateDestianationCommandHandler
    {
        private readonly Context _context;
        public CreateDestianationCommandHandler(Context context)
        {
            _context = context;
        }

        public void Handle(CreateDestinationCommand command)
        {
            _context.Destinations.Add(new Destination 
            {
                City= command.City,
                Price= command.Price,
                DayNight= command.DayNight,
                Capacity= command.Capacity,
                Status= true
            });
            _context.SaveChanges();
        }
    }
}
