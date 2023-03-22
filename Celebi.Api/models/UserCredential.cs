using System.ComponentModel.DataAnnotations;

namespace Celebi.Api.models
{
    public class UserCredential
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; } = "";
        public string Password { get; set; } = "";
    }
}
