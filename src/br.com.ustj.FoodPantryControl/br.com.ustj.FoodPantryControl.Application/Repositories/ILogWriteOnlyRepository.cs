using br.com.ustj.FoodPantryControl.Domain.Log;

namespace br.com.ustj.FoodPantryControl.Application.Repositories
{
    public interface ILogWriteOnlyRepository
    {
        int Add(params Log[] log);
    }
}
