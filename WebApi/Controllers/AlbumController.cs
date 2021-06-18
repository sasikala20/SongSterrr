using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public AlbumController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ??  throw new ArgumentNullException(nameof(unitOfWork));
        }

        [HttpGet]
        public IActionResult Search([FromQuery]string titleSearch)
        {
            try
            {
                var response = _unitOfWork.Albums.Get(titleSearch);
                return Ok(response);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
    }
}