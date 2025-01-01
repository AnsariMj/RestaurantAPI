namespace RestaurantAPI.Application.Handlers.Authentication.Register.Common
{
    public class RegisterResponse
    {

        public bool Success { get; set; }
        public string Message { get; set; }
        public Guid? UserId { get; set; }
    }
}
