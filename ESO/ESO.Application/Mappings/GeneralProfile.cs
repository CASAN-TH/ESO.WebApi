using AutoMapper;
using ESO.Application.Features.Products.Commands.CreateProduct;
using ESO.Application.Features.Products.Queries.GetAllProducts;
using ESO.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ESO.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<Product, GetAllProductsViewModel>().ReverseMap();
            CreateMap<CreateProductCommand, Product>();
            CreateMap<GetAllProductsQuery, GetAllProductsParameter>();
        }
    }
}
