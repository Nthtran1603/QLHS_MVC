using AutoMapper;
using Infrastructure.Entities;
using QLHS_MVC.Models;

namespace QLHS_MVC
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            // Add as many of these lines as you need to map your objects

            CreateMap<HocSinh,HocSinhViewModel>();
            CreateMap<HocSinhViewModel,HocSinh>();
        }
    }
}
