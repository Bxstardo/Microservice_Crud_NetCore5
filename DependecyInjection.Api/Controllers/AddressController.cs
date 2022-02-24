using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MVCInjectionDependecy.Core.Models;
using MVCInjectionDependecy.Core.Services;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using DependecyInjection.Api.Models;
using MVCInjectionDependecy.Core.Enums;
using DependecyInjection.Api.Helpers;

namespace DependecyInjection.Api.Controllers
{
    /// <summary>
    /// Address Controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly ILogger<AddressController> _logger;
        private readonly IAddressService _addressService;
        private readonly IMapper _mapper;

        /// <summary>Initializes a new instance of the <see cref="AddressController" /> class.</summary>
        /// <param name="logger">The logger.</param>
        /// <param name="addressService">The address service.</param>
        /// <param name="mapper">The mapper.</param>
        public AddressController(
            ILogger<AddressController> logger,
            IAddressService addressService,
            IMapper mapper
        )
        {
            _logger = logger;
            _addressService = addressService;
            _mapper = mapper;
        }

        // GET: api/address/GetAllAddress
        /// <summary>Gets all address.</summary>
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllAddress()
        {
            var addresses = await _addressService.GetAll();
            if (addresses != null)
            {
                var result = _mapper.Map<IEnumerable<AddressModel>>(addresses);
                _logger.LogInformation("Processing Address List {@result}", result);
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        // GET : api/address/GetById
        /// <summary>
        /// Get address by identifier.
        /// </summary>
        /// <param name="idAddress">The identifier address.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]/{idAddress}")]
        public async Task<IActionResult> GetById(int idAddress)
        {
            var address = await _addressService.GetById(idAddress);
            if (address != null)
            {
                var result = _mapper.Map<AddressModel>(address);
                _logger.LogInformation("Processing Address Model {@result}", result);
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        // POST : api/address/Create
        /// <summary>
        /// Creates the specified new address.
        /// </summary>
        /// <param name="newAddress">The new address.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Create(AddressModel newAddress)
        {
            var result = await _addressService.Add(_mapper.Map<Address>(newAddress));
            switch (result)
            {
                case GenericResult.Successful:
                    return StatusCode(200);
                default:
                    return StatusCode(500);
            }
        }

        // PUT : api/address/Update
        /// <summary>
        /// Updates the specified new address.
        /// </summary>
        /// <param name="newAddress">The new address.</param>
        /// <param name="idAddress">The identifier address.</param>
        /// <returns></returns>
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> Update(AddressModel newAddress, int idAddress)
        {
            var result = await _addressService.Update(_mapper.Map<Address>(newAddress), idAddress);
            var error = new Error();
            var intResult = (int)result;
            switch (result)
            {
                case GenericResult.Successful:
                    return StatusCode(200);
                case GenericResult.NotFound:
                    error.Code = intResult.ToString();
                    error.Message = "No se pudo actualizar debido a que no se encuentra ningun dato con este id";
                    return StatusCode(404, error);
                default:
                    return StatusCode(500);
            }
        }

        // DELETE : api/address/Delete
        /// <summary>
        /// Deletes the specified identifier address.
        /// </summary>
        /// <param name="idAddress">The identifier address.</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("[action]")]
        public async Task<IActionResult> Delete(int idAddress)
        {
            var result = await _addressService.Delete(idAddress);
            var error = new Error();
            var intResult = (int)result;
            switch (result)
            {
                case GenericResult.Successful:
                    return StatusCode(200);
                case GenericResult.NotFound:
                    error.Code = intResult.ToString();
                    error.Message = "No se pudo eliminar debido a que no se encuentra ningun dato con este id";
                    return StatusCode(404, error);
                default:
                    return StatusCode(500);
            }
        }
    }
}
