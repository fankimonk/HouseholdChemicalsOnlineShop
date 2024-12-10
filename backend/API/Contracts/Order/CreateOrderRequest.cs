using System.ComponentModel.DataAnnotations;

namespace API.Contracts.Order
{
    public record CreateOrderRequest
    (
        [Required]
        string ShippingAddress,

        [Required]
        [MinLength(1)]
        int[] ProductIds
    );
}
