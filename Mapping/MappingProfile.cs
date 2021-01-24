using System.Collections.Generic;
using System.Linq;
using aspnetcore_spa.Controllers.Resources;
using aspnetcore_spa.Models;
using AutoMapper;
namespace aspnetcore_spa.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Domain to Resource

            CreateMap<Make,MakeResource>();
            CreateMap<Model,KeyValuePairResource>();
            CreateMap<Feature,KeyValuePairResource>();

             CreateMap<Vehicle,SaveVehicleResource>()
              .ForMember(vr => vr.Contact, opt => opt.MapFrom(v => new ContactResource{ Name = v.ContactName , Email= v.ContactEmail , Phone = v.ContactPhone }))
              .ForMember (vr => vr.Features, opt => opt.MapFrom(v => v.Features.Select ( vf => vf.Id)));

             CreateMap<Vehicle,VehicleResource>()
              .ForMember(vr => vr.Make, opt => opt.MapFrom(v => new MakeResource{ Id = v.Model.Make.Id , Name = v.Model.Make.Name }))
              .ForMember(vr => vr.Contact, opt => opt.MapFrom(v => new ContactResource{ Name = v.ContactName , Email= v.ContactEmail , Phone = v.ContactPhone }))
               .ForMember (vr => vr.Features, opt => opt.MapFrom(v => v.Features.Select (vf => new KeyValuePairResource { Id = vf.Id , Name = vf.Name })));

            //Resource to Domain

            CreateMap<SaveVehicleResource,Vehicle>()
            //.ForMember(v => v.Id , opt => opt.MapFrom(vr => vr.Id))
            .ForMember(v => v.ContactName , opt => opt.MapFrom(vr => vr.Contact.Name))
            .ForMember(v => v.ContactEmail , opt => opt.MapFrom(vr => vr.Contact.Email))
            .ForMember(v => v.ContactPhone , opt => opt.MapFrom(vr => vr.Contact.Phone))
            .ForMember(v => v.Features, opt => opt​.Ignore())
            .AfterMap((vr , v) => {

               
                 // Remove unselected features
                
                var removedFeatures = new List<Feature>();
                removedFeatures = v.Features.Where(f => !vr.Features.Contains(f.Id)).ToList();
                
                foreach (var f in removedFeatures)
                {
                    v.Features.Remove(f);
                }

                //Add new features
                // foreach (var id in vr.Features)
                // {
                //     if(!v.Features.Any(f => f.Id == id))
                //         v.Features.Add(new Feature { Id = })
                // }

            });
            
        }
    }
}