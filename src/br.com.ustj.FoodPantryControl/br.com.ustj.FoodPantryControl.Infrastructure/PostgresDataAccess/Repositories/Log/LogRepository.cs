using AutoMapper;
using br.com.ustj.FoodPantryControl.Application.Repositories;

namespace br.com.ustj.FoodPantryControl.Infrastructure.PostgresDataAccess.Repositories.Log
{
    public class LogRepository : ILogWriteOnlyRepository
    {
        private readonly IMapper mapper;

        public LogRepository(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public int Add(params Domain.Log.Log[] log)
        {
            using var context = new Context();
            context.AddRange(mapper.Map<Entities.Log.Log[]>(log));

            return context.SaveChanges();
        }
    }
}
