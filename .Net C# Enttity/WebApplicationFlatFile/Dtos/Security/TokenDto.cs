using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;

namespace WebApplicationFlatFile.Dtos.Security
{
    public class TokenDto
    {
        [JsonProperty(PropertyName = "auth_token")]
        public string Auth_token { get; set; }

        [JsonProperty(PropertyName = "expires_in")]
        public long Expires_In { get; set; }
    }
}
