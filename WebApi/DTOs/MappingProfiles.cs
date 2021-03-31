using AutoMapper;
using CoreData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.DTOs
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Producto, ProductoDto>()
                .ForMember(p => p.Categoria, x => x.MapFrom(a => a.CategoriaLink.NombreCategoria))
                .ForMember(p => p.Marca, x => x.MapFrom(a => a.MarcaLink.MarcaProducto));
        }
    }
}
