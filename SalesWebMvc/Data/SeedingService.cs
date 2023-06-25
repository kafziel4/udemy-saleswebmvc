using SalesWebMvc.Models;
using SalesWebMvc.Models.Enums;

namespace SalesWebMvc.Data
{
    public class SeedingService
    {
        private readonly SalesWebMvcContext _context;

        public SeedingService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Department.Any() ||
                _context.Seller.Any() ||
                _context.SalesRecord.Any())
                return;

            List<Department> departments = new() {
                new(1, "Computers"),
                new(2, "Electronics"),
                new(3, "Fashion"),
                new(4, "Books")
            };

            List<Seller> sellers = new() {
                new(1, "Bob Brown", "bob@gmail.com", new DateTime(1998, 4, 21), 1000.0, departments[0]),
                new(2, "Maria Green", "maria@gmail.com", new DateTime(1979, 12, 31), 3500.0, departments[1]),
                new(3, "Alex Grey", "alex@gmail.com", new DateTime(1988, 1, 15), 2200.0, departments[0]),
                new(4, "Martha Red", "martha@gmail.com", new DateTime(1993, 11, 30), 3000.0, departments[3]),
                new(5, "Donald Blue", "donald@gmail.com", new DateTime(2000, 1, 9), 4000.0, departments[2]),
                new(6, "Alex Pink", "bob@gmail.com", new DateTime(1997, 3, 4), 3000.0, departments[1])
            };

            List<SalesRecord> salesRecords = new() {
                new(1, new DateTime(2018, 09, 25), 11000.0, SaleStatus.Billed, sellers[0]),
                new(2, new DateTime(2018, 09, 4), 7000.0, SaleStatus.Billed, sellers[4]),
                new(3, new DateTime(2018, 09, 13), 4000.0, SaleStatus.Canceled, sellers[3]),
                new(4, new DateTime(2018, 09, 1), 8000.0, SaleStatus.Billed, sellers[0]),
                new(5, new DateTime(2018, 09, 21), 3000.0, SaleStatus.Billed, sellers[2]),
                new(6, new DateTime(2018, 09, 15), 2000.0, SaleStatus.Billed, sellers[0]),
                new(7, new DateTime(2018, 09, 28), 13000.0, SaleStatus.Billed, sellers[1]),
                new(8, new DateTime(2018, 09, 11), 4000.0, SaleStatus.Billed, sellers[3]),
                new(9, new DateTime(2018, 09, 14), 11000.0, SaleStatus.Pending, sellers[5]),
                new(10, new DateTime(2018, 09, 7), 9000.0, SaleStatus.Billed, sellers[5]),
                new(11, new DateTime(2018, 09, 13), 6000.0, SaleStatus.Billed, sellers[1]),
                new(12, new DateTime(2018, 09, 25), 7000.0, SaleStatus.Pending, sellers[2]),
                new(13, new DateTime(2018, 09, 29), 10000.0, SaleStatus.Billed, sellers[3]),
                new(14, new DateTime(2018, 09, 4), 3000.0, SaleStatus.Billed, sellers[4]),
                new(15, new DateTime(2018, 09, 12), 4000.0, SaleStatus.Billed, sellers[0]),
                new(16, new DateTime(2018, 10, 5), 2000.0, SaleStatus.Billed, sellers[3]),
                new(17, new DateTime(2018, 10, 1), 12000.0, SaleStatus.Billed, sellers[0]),
                new(18, new DateTime(2018, 10, 24), 6000.0, SaleStatus.Billed, sellers[2]),
                new(19, new DateTime(2018, 10, 22), 8000.0, SaleStatus.Billed, sellers[4]),
                new(20, new DateTime(2018, 10, 15), 8000.0, SaleStatus.Billed, sellers[5]),
                new(21, new DateTime(2018, 10, 17), 9000.0, SaleStatus.Billed, sellers[1]),
                new(22, new DateTime(2018, 10, 24), 4000.0, SaleStatus.Billed, sellers[3]),
                new(23, new DateTime(2018, 10, 19), 11000.0, SaleStatus.Canceled, sellers[1]),
                new(24, new DateTime(2018, 10, 12), 8000.0, SaleStatus.Billed, sellers[4]),
                new(25, new DateTime(2018, 10, 31), 7000.0, SaleStatus.Billed, sellers[2]),
                new(26, new DateTime(2018, 10, 6), 5000.0, SaleStatus.Billed, sellers[3]),
                new(27, new DateTime(2018, 10, 13), 9000.0, SaleStatus.Pending, sellers[0]),
                new(28, new DateTime(2018, 10, 7), 4000.0, SaleStatus.Billed, sellers[2]),
                new(29, new DateTime(2018, 10, 23), 12000.0, SaleStatus.Billed, sellers[4]),
                new(30, new DateTime(2018, 10, 12), 5000.0, SaleStatus.Billed, sellers[1])
            };

            _context.Department.AddRange(departments);
            _context.Seller.AddRange(sellers);
            _context.SalesRecord.AddRange(salesRecords);
            _context.SaveChanges();
        }
    }
}
