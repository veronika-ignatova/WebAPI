using Core.Interface;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class UserApiModel
    {
        [Required]
        public Guid Id { get; set; }
        
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string? Name { get; set; }
        
        public AddressApiModel? Address { get; set; }
                
        [Required]
        [Range(18, 99)]
        public int? Age { get; set; }
                
        [Required]
        [StringLength(16, MinimumLength = 8)]
        public string? Password { get; set; }
    }

    public class AddressApiModel
    {
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string? City { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string? Country { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string? Street { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string? Index { get; set; }
    }
}
