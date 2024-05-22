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

        public async Task<IEnumerable<OrderHeader>> GetAllAsync(string? userId=null)
        {
            if (!string.IsNullOrEmpty(userId))
            {
                return await _db.OrderHeader.Where(u=>u.UserId==userId).ToListAsync();
            }
            return await _db.OrderHeader.ToListAsync();
        }

        public async Task<OrderHeader> GetBySessionIdAsync(string sessionId)
        {
            return _db.OrderHeader.FirstOrDefault(u => u.SessionId == sessionId);
        }

        public async Task<OrderHeader> UpdateStatusAsync(int id, string orderStatus, string paymentIntentId)
        {
            var orderFromDb = _db.OrderHeader.FirstOrDefault(u => u.Id == id);
            if (orderFromDb != null)
            {
                orderFromDb.Status = orderStatus;
                if (!string.IsNullOrEmpty(paymentIntentId))
                {
                    orderFromDb.PaymentIntentId = paymentIntentId;
                }
            }
            await _db.SaveChangesAsync();
            return orderFromDb;
        }

    }
}
