using Core.Entities.Abstract;

namespace Entities.ViewModel
{
    public class UserForLoginViewModel : IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
