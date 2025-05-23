﻿using Pixly.Services.Helper;
using System.Text.Json;

namespace Pixly.API.Exstensions
{
    public static class PaginationExtension
    {
        public static void AddPaginationHeader(this HttpResponse response, int currentPage,
           int itemsPerPage, int totalItems, int totalPages)
        {
            var paginationHeader = new PaginationHeader(currentPage, itemsPerPage, totalItems, totalPages);

            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            response.Headers.Add("Pagination", JsonSerializer.Serialize(paginationHeader, options));
            response.Headers.Add("Access-Control-Expose-Headers", "Pagination");
        }
    }
}
