using eCommerce.Utils;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Web.Areas.Api.Models.General
{
    public class PaginationResponse<T>
    {
        public PaginationResponse()
        {

        }

        public PaginationResponse(IList<T> lst, int pageItem, int pageIndex)
        {
            this.pageIndex = pageIndex;
            this.pageItem = pageItem;

            TotalRow = lst.Count();

            if (pageItem == 1)
            {
                TotalPage = TotalRow;
            }
            else if (TotalRow == pageItem)
            {
                TotalPage = 1;
            }
            else
            {
                if(TotalRow % pageItem == 0)
                {
                    TotalPage = TotalRow / pageItem;
                }
                else
                {
                    TotalPage = (TotalRow / pageItem) + 1;
                }
            }
            Data = lst.Pagging(pageItem, pageIndex).ToList();
        }

        private int pageIndex { get; set; }

        private int pageItem { get; set; }

        public int TotalPage { get; set; }

        public int TotalRow { get; set; }

        public List<T> Data { get; set; }
    }
    public class PaginationResponseIQuery<T>
    {
        public PaginationResponseIQuery()
        {

        }

        public PaginationResponseIQuery(IQueryable<T> lst, int pageItem, int pageIndex)
        {
            this.pageIndex = pageIndex;
            this.pageItem = pageItem;

            TotalRow = lst.Count();

            if (pageItem == 1)
            {
                TotalPage = TotalRow;
            }
            else if (TotalRow == pageItem)
            {
                TotalPage = 1;
            }
            else
            {
                if (TotalRow % pageItem == 0)
                {
                    TotalPage = TotalRow / pageItem;
                }
                else
                {
                    TotalPage = (TotalRow / pageItem) + 1;
                }
            }
            Data = lst.PaggingIQuery(pageItem, pageIndex).ToList();
        }

        private int pageIndex { get; set; }

        private int pageItem { get; set; }

        public int TotalPage { get; set; }

        public int TotalRow { get; set; }

        public List<T> Data { get; set; }
    }
}

