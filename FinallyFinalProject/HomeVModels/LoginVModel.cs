using System.ComponentModel.DataAnnotations;

namespace FinallyFinalProject.HomeVModels
{
    public class LoginVModel
    {
        [Required, StringLength(30)]
        public string UserName { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }

    }
}
