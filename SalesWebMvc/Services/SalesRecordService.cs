﻿using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Data;
using SalesWebMvc.Models;

namespace SalesWebMvc.Services
{
    public class SalesRecordService
    {
        private readonly SalesWebMvcContext _context;

        public SalesRecordService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public async Task<List<SalesRecord>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from salesRecords in _context.SalesRecord select salesRecords;

            if (minDate.HasValue)
                result = result.Where(s => s.Date >= minDate.Value);

            if (maxDate.HasValue)
                result = result.Where(s => s.Date <= maxDate.Value);

            return await result
                .Include(s => s.Seller)
                .Include(s => s.Seller.Department)
                .OrderByDescending(s => s.Date)
                .ToListAsync();
        }

        public async Task<List<IGrouping<Department?, SalesRecord>>> FindByDateGroupingAsync(
            DateTime? minDate, DateTime? maxDate)
        {
            var result = from salesRecords in _context.SalesRecord select salesRecords;

            if (minDate.HasValue)
                result = result.Where(s => s.Date >= minDate.Value);

            if (maxDate.HasValue)
                result = result.Where(s => s.Date <= maxDate.Value);

            return await result
                .Include(s => s.Seller)
                .Include(s => s.Seller.Department)
                .OrderByDescending(s => s.Date)
                .GroupBy(s => s.Seller.Department)
                .ToListAsync();
        }
    }
}
