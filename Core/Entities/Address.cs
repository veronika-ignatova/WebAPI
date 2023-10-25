using Core.Interface;

namespace Core.Entities
{
    public class Address : IAddress
    {
        public int Id { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? Street { get; set; }
        public string? Index { get; set; }
    }
}
