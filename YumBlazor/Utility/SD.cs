using YumBlazor.Data;

namespace YumBlazor.Utility
{
    public static class SD
    {
        public static string Role_Admin = "Admin";
        public static string Role_Customer = "Customer";
		public static string StatusPending = "Pending";
		public static string StatusApproved = "Approved";
		public static string StatusReadyForPickUp = "ReadyForPickUp";
		public static string StatusCompleted = "Completed";
		public static string StatusCancelled = "Cancelled";
		public static string StatusRefunded = "Refunded";

		//


		public static List<OrderDetail> ConvertShoppingCartListToOrderDetails(List<ShoppingCart> shoppingCarts)
		{
			List<OrderDetail> orderDetails = new List<OrderDetail>();

			foreach (var cart in shoppingCarts)
			{
				OrderDetail orderDetail = new OrderDetail
				{
					ProductId = cart.ProductId,
					Count=cart.Count,
					Price = Math.Round(cart.Product.Price, 2),
					ProductName = cart.Product.Name
				};

				orderDetails.Add(orderDetail);
			}

			return orderDetails;
		}
	}
}
