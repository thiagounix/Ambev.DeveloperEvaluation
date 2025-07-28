﻿namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{

    public class SaleItemRequest
    {
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
