namespace CleanArchitecture.Application.UseCases.Users.CreateUser
{
    public sealed record CreateUserResponse
    {
        public Guid Id { get; init; }
        public string Email { get; init; } = string.Empty;
        public string Name { get; init; } = string.Empty;
        public bool IsActive { get; init; }
    }
}