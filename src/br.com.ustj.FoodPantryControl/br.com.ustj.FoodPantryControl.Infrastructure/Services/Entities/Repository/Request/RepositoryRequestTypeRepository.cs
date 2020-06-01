using Newtonsoft.Json;

namespace br.com.ustj.FoodPantryControl.Infrastructure.Services.Entities.Repository.Request
{
    public class RepositoryRequestTypeRepository
    {
        [JsonProperty("repositoryId")]
        public string RepositoryId { get; set; }

        [JsonProperty("repositoryType")]
        public string RepositoryType { get; set; }

        [JsonProperty("customerAccount")]
        public RepositoryCustomerAccount CustomerAccount { get; set; }

        [JsonProperty("agreement")]
        public RepositoryAgreement Agreement { get; set; }

        public RepositoryRequestTypeRepository(string repositoryId, string repositoryType, RepositoryCustomerAccount customerAccount, RepositoryAgreement agreement)
        {
            RepositoryId = repositoryId;
            RepositoryType = repositoryType;
            CustomerAccount = customerAccount;
            Agreement = agreement;
        }
    }
}
