using YumBlazor.Data;
using YumBlazor.ViewModels;

namespace YumBlazor.Repository.IRepository
{
	public interface IOrderRepository
    {
		public Task<OrderHeader> CreateAsync(OrderHeader orderVM);
		public Task<OrderHeader> GetAsync(int id);
        public Task<OrderHeader> GetBySessionIdAsync(string sessionId);
        public Task<OrderHeader> UpdateStatusAsync(int id, string orderStatus, string paymentIntentId);
        public Task<IEnumerable<OrderHeader>> GetAllAsync();
	}
}
