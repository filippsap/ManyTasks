namespace ShopASPNet.Model.ShopModel
{
    public class Product
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public uint Price { get; set; }

        public int CategoryId { get; set; }
    }
}
