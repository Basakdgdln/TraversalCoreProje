using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraversalCoreProje.CQRS.Queries.DestinationQueries;
using TraversalCoreProje.CQRS.Results.DestinationResults;

namespace TraversalCoreProje.CQRS.Handlers.DestinationHandler
{
    public class GetDestinationByIdQueryHandler
    {
        private readonly Context _context;
        public GetDestinationByIdQueryHandler(Context context)
        {
            _context = context;
        }

        public GetDestinationByIdQueryResult Handle(GetDestinationByIdQuery query)
        {
            var values = _context.Destinations.Find(query.id);
            return new GetDestinationByIdQueryResult
            {
                DestinationId = values.DestinationID,
                City = values.City,
                DayNight = values.DayNight,
                Price= values.Price
            };
        }
    }
}
