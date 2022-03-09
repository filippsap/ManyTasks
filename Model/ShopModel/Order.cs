namespace ShopASPNet.Model.ShopModel
{
    public class Order
    {
        public int Id { get; set; }

        public Product[]? Products { get; set; }
    }
}
