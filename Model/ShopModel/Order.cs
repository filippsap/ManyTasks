﻿namespace ShopASPNet.Model.ShopModel
{
    public class Order
    {
        public int Id { get; set; }

        public Product[]? products { get; set; }
    }
}