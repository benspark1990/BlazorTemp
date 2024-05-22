using YumBlazor.Data;

namespace YumBlazor.ViewModels
{
	public class OrderVM
	{
        public OrderHeader OrderHeader { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
