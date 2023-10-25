
namespace Core.Interface
{
    public interface IUser
    {
        Guid Id { get; set; }
        string? Name { get; set; }
        string? Email { get; set; }
        IAddress? Address { get; set; }
        int? AddressId { get; set; }
        int? Age { get; set; }
        DateTime? CreateDate { get; set; }
        string? Password { get; set; }
    }
}
