﻿namespace RealEstateDapperUI.Dtos.PopulerLocationDTO
{
    public class ResultPopulerLocationDTO
    {
        public int LocationID { get; set; }
        public string? CityName { get; set; }
        public string? ImageUrl { get; set; }

        public int PropertyCount { get; set; }
    }
}
