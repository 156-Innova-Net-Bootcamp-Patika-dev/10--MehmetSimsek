using AutoMapper;
using Management.Application.Features.Commands.Authentications.SignUpUser;
using Management.Application.Features.Commands.Buildings.Apartments.AddApartment;
using Management.Application.Features.Commands.Buildings.Apartments.UpdateApartment;
using Management.Application.Features.Commands.Buildings.ApartmentTypes.AddApartmentType;
using Management.Application.Features.Commands.Buildings.Blocks.AddBlock;
using Management.Application.Features.Commands.Invoices.Bills.AddBill;
using Management.Application.Features.Commands.Messages.AddMessage;
using Management.Application.Features.Commands.Residents.AddResident;
using Management.Application.Features.Commands.Residents.UpdateResident;
using Management.Application.Models.Authentications;
using Management.Application.Models.Buildings;
using Management.Application.Models.Invoices;
using Management.Application.Models.Messages;
using Management.Application.Models.Residents;
using Management.Domain.Entites.Messages;
using Management.Domain.Entities.Authentications;
using Management.Domain.Entities.Buildings;
using Management.Domain.Entities.Residents;
using Management.Domain.Entites.Invoices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Management.Domain.Enums.Invoices;
using Management.Domain.Enums.Messages;
using Management.Application.Features.Commands.Invoices.Bills.AddPayment;
using Management.Domain.Entities.Invoices;

namespace Management.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Authentications
            CreateMap<User, SignUpUserCommand>().ReverseMap();
            CreateMap<User, UserModel>().ReverseMap();
            #endregion
            #region Residents
            CreateMap<Resident, AddResidentCommand>().ReverseMap();
            CreateMap<Resident, ResidentModel>()
                .ForMember(dest => dest.Email, mo => mo.MapFrom(src => src.User.Email))
                .ForMember(dest => dest.Name, mo => mo.MapFrom(src => src.User.FirstName))
                .ForMember(dest => dest.LastName, mo => mo.MapFrom(src => src.User.LastName))
                .ForMember(dest => dest.ApartmentNumber, mo => mo.MapFrom(src => src.Apartment.ApartmentNumber))
                .ForMember(dest => dest.FloorNumber, mo => mo.MapFrom(src => src.Apartment.FloorNumber))
                .ReverseMap();
                

            CreateMap<Resident, UpdateResidentCommand>().ReverseMap();
            #endregion
            #region Buildings
            CreateMap<Apartment, AddApartmentCommand>().ReverseMap();

            CreateMap<ApartmentType, AddApartmentTypeCommand>().ReverseMap();
            //To show Apartment type and block name instead of id.
            CreateMap<Apartment, ApartmentModel>()
             .ForMember(dest => dest.ApartmentTypeName, mo => mo.MapFrom(src => src.ApartmentType.Name))
             .ForMember(dest => dest.BlockName, mo => mo.MapFrom(src => src.Block.Name))
             .ReverseMap();
            CreateMap<ApartmentModel, Apartment>().ReverseMap();

            CreateMap<Apartment, UpdateApartmentCommand>().ReverseMap();

            CreateMap<ApartmentType, ApartmentTypeModel>().ReverseMap();

            CreateMap<Block, AddBlockCommand>().ReverseMap();
            CreateMap<Block, BlockModel>().ReverseMap();
            #endregion
            #region Invoices
            CreateMap<Bill, AddBillCommand>().ReverseMap();
            CreateMap<Bill, BillModel>()
                .ForMember(dest => dest.ApartmentNumber, mo => mo.MapFrom(src => src.Apartment.ApartmentNumber))
                .ReverseMap();
            CreateMap<Payment, AddPaymentCommand>().ReverseMap();
            CreateMap<Payment, PaymentModel>();





            #endregion

            #region Messages
            CreateMap<Message, AddMessageCommand>().ReverseMap();
            CreateMap<Message, MessageModel>()
                .ForMember(dest => dest.SenderName, mo => mo.MapFrom(src => src.MessageSender.FirstName + src.MessageSender.LastName))
                .ForMember(dest => dest.ReceiverName, mo => mo.MapFrom(src => src.MessageReciever.FirstName + src.MessageReciever.LastName))
                .ForMember(dest => dest.MessageInfo, mo => mo.MapFrom(src => src.MessageSeenInfoEnum.ToString()))
                .ReverseMap();
            #endregion

        }
    }
}
