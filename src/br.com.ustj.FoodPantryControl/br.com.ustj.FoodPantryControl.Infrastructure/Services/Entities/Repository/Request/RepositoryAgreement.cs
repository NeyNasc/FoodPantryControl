using Newtonsoft.Json;

namespace br.com.ustj.FoodPantryControl.Infrastructure.Services.Entities.Repository.Request
{
    public class RepositoryAgreement
    {
        [JsonProperty("agreementDocumentNumber")]
        public string AgreementDocumentNumber { get; set; }

        public RepositoryAgreement(string agreementDocumentNumber)
        {
            AgreementDocumentNumber = agreementDocumentNumber;
        }
    }
}
