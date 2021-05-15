namespace OnlineShop.Web.ViewModels.ShoppingCart
{
    using AutoMapper;
    using OnlineShop.Data.Models;
    using OnlineShop.Services.Mapping;

    public class OrderViewModel : IMapFrom<Order>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string ProductTitle { get; set; }

        public string ProductDescription { get; set; }

        public string ProductImagePath { get; set; }

        public decimal ProductPrice { get; set; }

        public decimal TotalProductPrice { get; set; }

        public int Quantity { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Order, OrderViewModel>()
                .ForMember(x => x.TotalProductPrice,
                    y => y.MapFrom(x => x.Product.Price * x.Quantity));
        }
    }
}
