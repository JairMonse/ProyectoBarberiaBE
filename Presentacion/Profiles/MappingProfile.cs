using AutoMapper;
using DTO.BarberoDTO;
using DTO.CarritoDTO;
using DTO.CitasDTO;
using DTO.ClienteDTO;
using DTO.InventarioDTO;
using DTO.VentasDTO;
using Models;
using Models.Módulo_Barbero;
using Models.Módulo_Carrito;
using Models.Módulo_Citas;
using Models.Módulo_Cliente;
using Models.Módulo_Inventario;
using Models.Módulo_Ventas;

namespace Presentacion.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<Especialidad, EspecialidadDTO>();

            CreateMap<Jornada, jornadasDTO>();

            CreateMap<Barbero, BarberoPageDTO>();

            CreateMap<Barbero, BarberoGetDTO>();

            CreateMap<BarberoPostDTO, Barbero>();

            CreateMap<ClienteDTO, Cliente>().ReverseMap();


            CreateMap<Citas, CitasDTO>();
            CreateMap<CitasDTO, Citas>();

            CreateMap<Inventario, InventarioDTO>();
            CreateMap<InventarioDTO, Inventario>();

            CreateMap<Ventas, VentasDTO>();
            CreateMap<VentasDTO, Ventas>();


            CreateMap<Carrito, CarritoDTO>();
            CreateMap<CarritoDTO, Carrito>();

        }
    }
}
