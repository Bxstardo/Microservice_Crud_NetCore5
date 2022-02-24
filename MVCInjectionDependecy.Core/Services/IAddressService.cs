using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCInjectionDependecy.Core.Enums;
using MVCInjectionDependecy.Core.Models;

namespace MVCInjectionDependecy.Core.Services
{
    public interface IAddressService
    {
        /// <summary>
        /// Get all address
        /// </summary>
        /// <returns>The <see cref="Task{IEnumerable{Address}}"/></returns>
        public Task<IEnumerable<Address>>GetAll();
        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="idAddress">The identifier address.</param>
        /// <returns></returns>
        public Task<Address> GetById(int idAddress);
        /// <summary>
        /// Adds the specified new address.
        /// </summary>
        /// <param name="newAddress">The new address.</param>
        /// <returns></returns>
        public Task<GenericResult> Add(Address newAddress);
        /// <summary>
        /// Updates the specified new address.
        /// </summary>
        /// <param name="newAddress">The new address.</param>
        /// <param name="idAddress">The identifier address.</param>
        /// <returns></returns>
        public Task<GenericResult> Update(Address newAddress, int idAddress);
        /// <summary>
        /// Deletes the specified identifier address.
        /// </summary>
        /// <param name="idAddress">The identifier address.</param>
        /// <returns></returns>
        public Task<GenericResult> Delete(int idAddress);

    }
}
