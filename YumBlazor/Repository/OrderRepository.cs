using Microsoft.EntityFrameworkCore;
using YumBlazor.Data;
using YumBlazor.Repository.IRepository;

namespace YumBlazor.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _db;

        public OrderRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<OrderHeader> CreateAsync(OrderHeader orderHeader)
        {
            orderHeader.OrderDate = DateTime.Now;
            await _db.OrderHeader.AddAsync(orderHeader);
            await _db.SaveChangesAsync();
            return orderHeader;
        }

        public async Task<OrderHeader> GetAsync(int id)
        {
            return await _db.OrderHeader.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<IEnumerable<OrderHeader>> GetAllAsync()
        {
            return await _db.OrderHeader.ToListAsync();
        }
    }
}
