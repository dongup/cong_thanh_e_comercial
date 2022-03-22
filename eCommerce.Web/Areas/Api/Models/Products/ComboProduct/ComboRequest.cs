using eCommerce.Web.Entities.Product.ComboProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Web.Areas.Api.Models.Products.ComboProduct
{
    public class ComboRequest : ComboResponse
    {
        public ComboRequest()
        {

        }

        public ComboEntity CopyTo(ComboEntity entity)
        {
            entity.Name = Name;
            entity.Note = Note;
            entity.Price = Price;
            entity.GurantyTime = GurantyTime;
            entity.FriendlyUrl = FriendlyUrl;
            entity.Description = Description;
            entity.PromoContent = PromoContent;
            entity.ComboProducts = ComboProduct.Select(x => new ComboProductEntity()
            {
                ProductId = x.ProductId,
                Quantity = x.Quantity
            }).ToList();

            entity.ComboImages = ImageIds.Select(x => new ComboImagesEntity()
            {
                ImageId = x
            }).ToList();



            return entity;
        }

        public List<ComboProductRequest> ComboProduct { get; set; }
        public List<int> ImageIds { get; set; }


        //public virtual ICollection<ComboProductEntity> ComboProducts { get; set; }
    }
    public class ComboProductRequest
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
