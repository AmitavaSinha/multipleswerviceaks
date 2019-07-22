using eFormProcessingService.Repositories;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace eFormProcessingService.Controllers
{
    [Route("api/[controller]/[action]")]
    [EnableCors("projectAllowSpecificOrigins")]
    public class EFormController : Controller
    {
        private readonly IEFormRepository _Repository;
        public EFormController(IEFormRepository eFormRepository)
        {
            _Repository = eFormRepository;
        }

        [HttpGet]
        [EnableCors("projectAllowSpecificOrigins")]
        public async Task<IActionResult> GetDocumentType(CancellationToken ct = default(CancellationToken))
        {
            try
            {
                return new ObjectResult(await _Repository.GetDocumentType(ct));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
        [HttpGet]
        [EnableCors("projectAllowSpecificOrigins")]
        public async Task<IActionResult> GetIdentityType(CancellationToken ct = default(CancellationToken))
        {
            try
            {
                return new ObjectResult(await _Repository.GetIdentityType(ct));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet]
        [EnableCors("projectAllowSpecificOrigins")]
        public async Task<IActionResult> GetPostalCode(CancellationToken ct = default(CancellationToken))
        {
            try
            {
                return new ObjectResult(await _Repository.GetPostalCode(ct));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
        [HttpGet]
        [EnableCors("projectAllowSpecificOrigins")]
        public async Task<IActionResult> GetPostalCodeByID(string id,CancellationToken ct = default(CancellationToken))
        {
            try
            {
                return new ObjectResult(await _Repository.GetPostalCodeByID(id,ct));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet]
        [EnableCors("projectAllowSpecificOrigins")]
        public async Task<IActionResult> GetPropertyType(CancellationToken ct = default(CancellationToken))
        {
            try
            {
                return new ObjectResult(await _Repository.GetPropertyType(ct));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet]
        [EnableCors("projectAllowSpecificOrigins")]
        public async Task<IActionResult> GetProfile(CancellationToken ct = default(CancellationToken))
        {
            try
            {
                return new ObjectResult(await _Repository.GetProfile(ct));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}