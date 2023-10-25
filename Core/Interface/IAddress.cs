
namespace Core.Interface
{
    public interface IAddress
    {
        int Id { get; set; }
        string? City { get; set; }
        string? Country { get; set; }
        string? Street { get; set; }
        string? Index { get; set; }
    }
}
