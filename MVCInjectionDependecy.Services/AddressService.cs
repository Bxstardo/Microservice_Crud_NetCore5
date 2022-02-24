using MVCInjectionDependecy.Core.Models;
using MVCInjectionDependecy.Core.Services;
using MVCInjectionDependecy.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MVCInjectionDependecy.Services
{
    public class AddressService : IAddressService
    {
        private readonly AdventureWorksLT2019Context _db;
        public AddressService(AdventureWorksLT2019Context db)
        {
            _db = db;
        }

        public async Task<GenericResult> Add(Address newAddress)
        {
            await _db.Addresses.AddAsync(newAddress);
            await _db.SaveChangesAsync();
            return GenericResult.Successful;
        }

        public async Task<GenericResult> Delete(int idAddress)
        {
            var address = await _db.Addresses.FindAsync(idAddress);
            if (address != null)
            {
                _db.Addresses.Remove(address);
                await _db.SaveChangesAsync();
                return GenericResult.Successful;
            }
            else
            {
                return GenericResult.NotFound;
            }
        }

        public async Task<IEnumerable<Address>> GetAll()
        {
            return await _db.Addresses.ToListAsync();
        }

        public async Task<Address> GetById(int idAddress)
        {
            return await _db.Addresses.FindAsync(idAddress);
        }

        public async Task<GenericResult> Update(Address newAddress, int idAddress)
        {
            var oldAddress = _db.Addresses.Find(idAddress);
            if (oldAddress != null)
            {
                oldAddress.AddressLine1 = newAddress.AddressLine1;
                oldAddress.AddressLine2 = newAddress.AddressLine2;
                oldAddress.City = newAddress.City;
                oldAddress.CountryRegion = newAddress.CountryRegion;
                oldAddress.CustomerAddresses = newAddress.CustomerAddresses;
                oldAddress.StateProvince= newAddress.StateProvince;
                await _db.SaveChangesAsync();
                return GenericResult.Successful;
            }
            else
            {
                return GenericResult.NotFound;
            }

        }
    }
}
