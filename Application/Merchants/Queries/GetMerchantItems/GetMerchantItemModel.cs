﻿using Application.Common.Mappings;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Merchants.Queries.GetMerchantItems
{
    public class GetMerchantItemModel : IMapFrom<Item>
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public int ItemTypeID { get; set; }
        public string ItemTypeName { get; set; }
        public string UnitTypeName { get; set; }
        public string UnitTypePerUnit { get; set; }
        public bool PriceTypeIsVariableCost { get; set; }
        public decimal? Price { get; set; }
        public string DisplayPrice
        {
            get
            {
                //TODO: Calculate variable cost with extension method
                //Value objects?
                if (Price == null || PriceTypeIsVariableCost) return string.Empty;

                var displayPrice = Price.Value.ToString("C");

                if (!string.IsNullOrEmpty(UnitTypePerUnit))
                {
                    displayPrice = $"{displayPrice} {UnitTypePerUnit.ToLower()}";
                }

                return displayPrice;
            }
        }

        public string DisplayMaxAllowed => MaxAllowed != null 
            ? MaxAllowed.ToString() 
            : "N/A";
        public int? MaxAllowed { get; set; }
        public string DefaultImageUrl { get; set; }
    }
}
