using AutoMapper;
using vega2.Data;
using vega2.Models;
using System.Linq;
using System.Collections.Generic;

namespace vega2.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Domain to API Resource
            CreateMap<Make, MakeViewModel>();
            CreateMap<Model, ModelViewModel>();
            CreateMap<Feature, FeatureViewModel>();
            CreateMap<Vehicle, VehicleViewModel>()
                .ForMember(vr => vr.Contact, opt => opt.MapFrom(v => new ContactViewModel { Name = v.ContactName, Phone = v.ContactPhone, Email = v.ContactEmail }))
                .ForMember(vr => vr.Features, opt => opt.MapFrom(v => v.Features.Select(vf => vf.FeatureId)));

            //API Resource to Domain
            CreateMap<VehicleViewModel, Vehicle>()
            //Ignore, mapping Id
            .ForMember(v => v.Id, opt => opt.Ignore())
            //First parameter is the target model, opt is for operation, and parameter in opt is source object
            .ForMember(v => v.ContactName, opt => opt.MapFrom(vr => vr.Contact.Name))
            .ForMember(v => v.ContactEmail, opt => opt.MapFrom(vr => vr.Contact.Email))
            .ForMember(v => v.ContactPhone, opt => opt.MapFrom(vr => vr.Contact.Phone))
            //Bidejki vo source objektot imame integers, treba za sekoja vrednost da kreirame nov Feature objekt
            //This way we tell automapper where to find the value for this features property
            //.ForMember(v=>v.Features, opt=>opt.MapFrom(vr=>vr.Features.Select(id=>new VehicleFeature {FeatureId=id}))); 
            .ForMember(v => v.Features, opt => opt.Ignore())
            //After all the basic properties are set then we do some additional processing
            //This method takes lambda expression, Source object - VehicleViewModel model, Target - Vehicle model
            .AfterMap((vr, v) =>
            {
                //Remove unselected features
                //Because we can't remove Features from Vehicle object while iterating we're adding new list
                var removedFeatures=new List<VehicleFeature>();
                foreach (var f in v.Features)
                {
                    //If we don't have this feature in VehicleViewModel then remove from Features in Vehicle model
                    if (!vr.Features.Contains(f.FeatureId))
                        // v.Features.Remove(f);
                        removedFeatures.Add(f);
                }
                foreach(var f in removedFeatures)
                {
                    v.Features.Remove(f);
                }

                //Add new features
                foreach(var id in vr.Features)
                {
                    //If we don't have feature in Vehicle model, add to Features collection in Vehicle model
                    if(!v.Features.Any(f=>f.FeatureId==id))
                    v.Features.Add(new VehicleFeature{FeatureId=id});
                }
            });
        }
    }
}