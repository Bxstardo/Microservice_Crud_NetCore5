using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DependecyInjection.Api.Models;
using MVCInjectionDependecy.Core.Models;

namespace DependecyInjection.Api.Mappings
{
    /// <summary>
    /// Mappings models
    /// </summary>
    /// <seealso cref="AutoMapper.Profile" />
    public class MappingProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MappingProfile"/> class.
        /// </summary>
        public MappingProfile()
        {
            GeneralMappings();
        }

        /// <summary>
        /// Generals the mappings.
        /// </summary>
        public void GeneralMappings()
        {
            CreateMap<Address, AddressModel>();
            CreateMap<AddressModel, Address>();
        }
    }
}
