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
    public class AssignmentsController : ControllerBase
    {
        IAssignmentService _assignmentService;

        public AssignmentsController(IAssignmentService assignmentService)
        {
            _assignmentService = assignmentService;
        }

        [HttpPost("add")]
        public IActionResult Add(Assignment assignment)
        {
            var result = _assignmentService.Add(assignment);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Assignment assignment)
        {
            var result = _assignmentService.Update(assignment);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Assignment assignment)
        {
            var result = _assignmentService.Delete(assignment);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _assignmentService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _assignmentService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getassignmentsdetails")]
        public IActionResult GetAssignmentsDetails()
        {
            var result = _assignmentService.GetAssignmentsDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getsponsorsbyuserid")]
        public IActionResult GetSponsorsByUserId(int userId)
        {
            var result = _assignmentService.GetSponsorsByUserId(userId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getsponsorsbyuseridandsponsorname")]
        public IActionResult GetSponsorsByUserIdAndSponsorName(int userId, string sponsorName)
        {
            var result = _assignmentService.GetStudiesByUserIdAndSponsorName(userId, sponsorName);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getsponsorsbyuseridandsponsornameandprotocolcode")]
        public IActionResult GetSitesByUserIdAndSponsorNameAndProtocolCode(int userId, string sponsorName, string protocolCode)
        {
            var result = _assignmentService.GetSitesByUserIdAndSponsorNameAndProtocolCode(userId, sponsorName, protocolCode);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
