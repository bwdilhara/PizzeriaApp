using AutoMapper;
using CWRETAIL.Api.Orders.Db;
using CWRETAIL.Api.Orders.Interfaces;
using CWRETAIL.Api.Orders.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CWRETAIL.Api.Orders.Providers
{
    public class OrdersProvider : IOrdersProvider
    {
        private readonly OrdersDbContext _dbContext;
        private readonly ILogger<OrdersProvider> _logger;
        private readonly IMapper _mapper;

        public OrdersProvider(OrdersDbContext dbContext, ILogger<OrdersProvider> logger, IMapper mapper)
        {
            _dbContext = dbContext;
            _logger = logger;
            _mapper = mapper;
            SeedData();
        }
        private void SeedData()
        {
            if (!_dbContext.Orders.Any())
            {
                _dbContext.Orders.Add(new Db.Order()
                {
                    Id = 1,
                    CustomerId = 1,
                    OrderDate = DateTime.Now,
                    Items = new List<Db.OrderItem>()
                    {
                        new Db.OrderItem() { OrderId = 1, MenuId = 1, Quantity = 10, UnitPrice = 10 },
                        new Db.OrderItem() { OrderId = 1, MenuId = 2, Quantity = 10, UnitPrice = 10 },
                        new Db.OrderItem() { OrderId = 1, MenuId = 3, Quantity = 10, UnitPrice = 10 },
                        new Db.OrderItem() { OrderId = 2, MenuId = 2, Quantity = 10, UnitPrice = 10 },
                        new Db.OrderItem() { OrderId = 3, MenuId = 3, Quantity = 1, UnitPrice = 100 }
                    },
                    Total = 100
                });
                _dbContext.Orders.Add(new Db.Order()
                {
                    Id = 2,
                    CustomerId = 1,
                    OrderDate = DateTime.Now.AddDays(-1),
                    Items = new List<Db.OrderItem>()
                    {
                        new Db.OrderItem() { OrderId = 1, MenuId = 1, Quantity = 10, UnitPrice = 10 },
                        new Db.OrderItem() { OrderId = 1, MenuId = 2, Quantity = 10, UnitPrice = 10 },
                        new Db.OrderItem() { OrderId = 1, MenuId = 3, Quantity = 10, UnitPrice = 10 },
                        new Db.OrderItem() { OrderId = 2, MenuId = 2, Quantity = 10, UnitPrice = 10 },
                        new Db.OrderItem() { OrderId = 3, MenuId = 3, Quantity = 1, UnitPrice = 100 }
                    },
                    Total = 100
                });
                _dbContext.Orders.Add(new Db.Order()
                {
                    Id = 3,
                    CustomerId = 2,
                    OrderDate = DateTime.Now,
                    Items = new List<Db.OrderItem>()
                    {
                        new Db.OrderItem() { OrderId = 1, MenuId = 1, Quantity = 10, UnitPrice = 10 },
                        new Db.OrderItem() { OrderId = 2, MenuId = 2, Quantity = 10, UnitPrice = 10 },
                        new Db.OrderItem() { OrderId = 3, MenuId = 3, Quantity = 1, UnitPrice = 100 }
                    },
                    Total = 100
                });
                _dbContext.SaveChanges();
            }
        }

        public async Task<(bool isSuccess, IEnumerable<Models.Order> orders, string errorMessage)> GetOrdersAsync(int id)
        {
            try
            {
                _logger?.LogInformation($"Querying Orders");
                var Order = await _dbContext.Orders.ToListAsync();
                if (Order != null)
                {
                    _logger?.LogInformation("Order found");
                    var result = _mapper.Map<IEnumerable<Models.Order>>(Order);
                    return (true, result, null);
                }
                return (false, null, "Not found");
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool isSuccess, decimal totalAmount, string errorMessage)> CreateOrdersAsync(Models.Order order)
        {
            try
            {
                _logger?.LogInformation($"Creating Orders");               
                if (order != null && order.LocationId>0 && order.Items!=null)
                {
                    _logger?.LogInformation("Order found");
                    var result = _mapper.Map<Db.Order>(order);
                    result.Total= order.Items.Sum(i=> i.UnitPrice * i.Quantity);
                    if (result.Total > 0)
                    {
                        await _dbContext.Orders.AddAsync(result);
                        _dbContext.SaveChanges();
                    }

                    return (true, result.Total, null);
                }
                return (false, 0, "Not found");
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex.ToString());
                return (false, 0, ex.Message);
            }
        }
    }
}
