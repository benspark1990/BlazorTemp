using YumBlazor.Data;
using YumBlazor.ViewModels;

namespace YumBlazor.Repository.IRepository
{
	public interface IOrderRepository
    {
		public Task<OrderHeader> CreateAsync(OrderHeader orderVM);
		public Task<OrderHeader> GetAsync(int id);
		public Task<IEnumerable<OrderHeader>> GetAllAsync();
	}
}
