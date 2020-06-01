using Newtonsoft.Json;

namespace br.com.ustj.FoodPantryControl.Infrastructure.Services.Entities.Repository.Request
{
    public class RepositoryRequestTypeRepositories
    {
        [JsonProperty("repository")]
        public RepositoryRequestTypeRepository Repository { get; set; }

        public RepositoryRequestTypeRepositories(RepositoryRequestTypeRepository repository)
        {
            Repository = repository;
        }
    }
}
