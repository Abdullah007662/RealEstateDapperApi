﻿namespace RealEstateDapperUI.Dtos.ProductDTO
{
    public class CreateProductDTO
    {
        public int EmployeeID { get; set; }
        public string? Title { get; set; }
        public int Price { get; set; }
        public string? City { get; set; }
        public string? Disrict { get; set; }
        public int ProductCategory { get; set; }
        public string? CoverImage { get; set; }
        public string? Description { get; set; }
        public bool ProductStatus { get; set; }
        public string? Type { get; set; }
        public string? Address { get; set; }
        public bool? DealOfTheDay { get; set; }
        public DateTime Adverstisement { get; set; }


    }
}
