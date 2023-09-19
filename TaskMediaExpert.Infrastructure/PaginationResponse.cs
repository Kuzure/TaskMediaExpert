using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TaskMediaExpert.Infrastructure
{
    public class PaginationResponse<T>
    {
        public PaginationResponse()
        {

        }

        public PaginationResponse(T result, int totalItem, int currentPage, int itemPerPage)
        {

            Result = result;
            Code = HttpStatusCode.OK;
            IsError = false;
            TotalCount = totalItem;
            CurrentPage = currentPage;
            TotalPages = (int)Math.Ceiling(TotalCount / (double)itemPerPage);
        }

        /// <summary>
        /// Response result
        /// </summary>
        public T? Result { get; set; }

        /// <summary>
        /// Http Status code
        /// </summary>
        public HttpStatusCode Code { get; set; }

        /// <summary>
        /// Optional message
        /// </summary>
        public string? Message { get; set; }

        /// <summary>
        /// Error flag
        /// </summary>
        public bool IsError { get; set; }

        public int CurrentPage { get; set; }

        public int TotalCount { get; set; }

        public int TotalPages { get; set; }

    }
}
