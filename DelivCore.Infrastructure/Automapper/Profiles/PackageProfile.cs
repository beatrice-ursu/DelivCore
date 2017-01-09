using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DelivCore.DataLayer.Entities;
using DelivCore.Models.Orders;

namespace DelivCore.Infrastructure.Automapper.Profiles
{
    class PackageProfile: Profile
    {
        public PackageProfile()
        {
            CreateMap<Package, PackageModel>();
            CreateMap<PackageModel, Package>();
        }
    }
}
