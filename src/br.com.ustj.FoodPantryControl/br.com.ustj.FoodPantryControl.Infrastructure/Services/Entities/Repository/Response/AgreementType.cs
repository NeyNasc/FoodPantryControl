using Newtonsoft.Json;

namespace br.com.ustj.FoodPantryControl.Infrastructure.Services.Entities.Repository.Response
{
    public class AgreementType
    {
        [JsonProperty("agreementDocumentNumber")]
        public string AgreementDocumentNumber { get; set; }
    }
}
