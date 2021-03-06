using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudiesController : ControllerBase
    {
        IStudyService _studyService;

        public StudiesController(IStudyService studyService)
        {
            _studyService = studyService;
        }

        [HttpPost("add")]
        public IActionResult Add(Study study)
        {
            var result = _studyService.Add(study);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Study study)
        {
            var result = _studyService.Update(study);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Study study)
        {
            var result = _studyService.Delete(study);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _studyService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyprotocolcode")]
        public IActionResult GetByProtocolCode(string protocolCode)
        {
            var result = _studyService.GetByProtocolCode(protocolCode);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _studyService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getstudiesbysponsorid")]
        public IActionResult GetStudiesBySponsorId(int id)
        {
            var result = _studyService.GetStudiesBySponsorId(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getstudiesdetails")]
        public IActionResult GetStudiesDetails()
        {
            var result = _studyService.GetStudiesDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
