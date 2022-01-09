using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Api.SeedWork
{
    public class Pagination<T>
    {

        public int PageIndex { get; private set; }
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }
        public int TotalPages { get; private set; }
        public List<T> Data { get; private set; }
        private IQueryable<T> _source;
        public Pagination(IQueryable<T> source, int pageIndex, int pageSize)
        {
            _source =source;
            PageIndex = pageIndex;
            PageSize = pageSize;
        }

        public Pagination<T> ToList()
        {
            TotalCount = _source.Count();
            TotalPages = (int)Math.Ceiling(TotalCount / (double)PageSize);
            Data = _source.Skip(PageIndex * PageSize).Take(PageSize).ToList();
            return this;
        }
        public async Task<Pagination<T>> ToListAsync()
        {
            TotalCount = await _source.CountAsync();
            TotalPages = (int)Math.Ceiling(TotalCount / (double)PageSize);
            Data = await _source.Skip(PageIndex * PageSize).Take(PageSize).ToListAsync();
            return this;
        }

        public bool HasPreviousPage
        {
            get
            {
                return (PageIndex > 0);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return (PageIndex + 1 < TotalPages);
            }
        }

    }
}