using MediatR;

namespace ECommerceAPI.Application.Features.Commands.Product.UpdateProduct.UpdateStockQrCodeToProduct
{
    public class UpdateStockQrCodeToProductCommandRequest:IRequest<UpdateStockQrCodeToProductCommandResponse>
    {
        public string ProductId { get; set; }
        public int Stock { get; set; }
    }
}