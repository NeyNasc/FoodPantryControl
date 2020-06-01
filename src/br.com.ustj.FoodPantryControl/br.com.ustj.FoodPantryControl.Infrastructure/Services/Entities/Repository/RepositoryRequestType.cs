using br.com.ustj.FoodPantryControl.Infrastructure.Services.Entities.Repository.Request;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace br.com.ustj.FoodPantryControl.Infrastructure.Services.Entities.Repository
{
    public class RepositoryRequestType
    {
        [JsonProperty("repositories")]
        public List<RepositoryRequestTypeRepositories> RequestTypeRepositories { get; set; }

        public RepositoryRequestType(List<RepositoryRequestTypeRepositories> requestTypeRepositories)
        {
            RequestTypeRepositories = requestTypeRepositories;
        }
    }
}
