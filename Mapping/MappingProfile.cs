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
            CreateMap<Model,ModelResource>();
            CreateMap<Feature,FeatureResource>();

             CreateMap<Vehicle,VehicleResource>()
              .ForMember(vr => vr.Contact, opt => opt.MapFrom(v => new ContactResource{ Name = v.ContactName , Email= v.ContactEmail , Phone = v.ContactPhone }))
              .ForMember (vr => vr.Features, opt => opt.MapFrom(v => v.Features.Select ( vf => vf.Id)));

            //Resource to Domain

            CreateMap<VehicleResource,Vehicle>()
            //.ForMember(v => v.Id , opt => opt.MapFrom(vr => vr.Id))
            .ForMember(v => v.ContactName , opt => opt.MapFrom(vr => vr.Contact.Name))
            .ForMember(v => v.ContactEmail , opt => opt.MapFrom(vr => vr.Contact.Email))
            .ForMember(v => v.ContactPhone , opt => opt.MapFrom(vr => vr.Contact.Phone))
            .ForMember(v => v.Features, opt => opt​.Ignore())
            .AfterMap((vr , v) => {

                // Remove unselected features
                var removedFeatures = new List<Feature>();
                foreach (var f in v.Features)
                {
                    if(!vr.Features.Contains(f.Id))
                        removedFeatures.Add(f);
                }

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
            
            //.ForMember(v => v.Features, opt => opt.MapFrom(vr => vr.Features.Select( id => new Feature { Id = id})));

        }
    }
}