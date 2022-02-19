using AutoMapper;
using Management.Application.Features.Commands.Buildings.Apartments.AddApartment;
using Management.Application.Features.Commands.Buildings.Apartments.UpdateApartment;
using Management.Application.Features.Commands.Buildings.ApartmentTypes.AddApartmentType;
using Management.Application.Features.Commands.Buildings.Blocks.AddBlock;
using Management.Application.Features.Commands.Residents.AddResident;
using Management.Application.Features.Commands.Residents.UpdateResident;
using Management.Application.Models.Buildings;
using Management.Application.Models.Residents;
using Management.Domain.Entities.Buildings;
using Management.Domain.Entities.Residents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Residents
            CreateMap<Resident, AddResidentCommand>().ReverseMap();
            CreateMap<Resident, ResidentModel>().ReverseMap();
            CreateMap<Resident, UpdateResidentCommand>().ReverseMap();
            #endregion
            #region Buildings
            CreateMap<Apartment, AddApartmentCommand>().ReverseMap();

            CreateMap<ApartmentType, AddApartmentTypeCommand>().ReverseMap();
            //To show Apartment type and block name instead of id.
            CreateMap<Apartment, ApartmentModel>()
             .ForMember(dest => dest.ApartmentType, mo => mo.MapFrom(src => src.ApartmentType.Name))
             .ForMember(dest => dest.BlockName, mo => mo.MapFrom(src => src.Block.Name))
             .ReverseMap();

            CreateMap<Apartment, UpdateApartmentCommand>().ReverseMap();

            CreateMap<ApartmentType, ApartmentTypeModel>().ReverseMap();


            CreateMap<Block, AddBlockCommand>().ReverseMap();
            CreateMap<Block, BlockModel>().ReverseMap();
            #endregion
        }
    }
}
