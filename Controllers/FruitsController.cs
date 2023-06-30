using FruitsManagementAPI.Models;
using FruitsManagementAPI.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FruitsManagementAPI.Controllers
{
    [EnableCors("AllowOrigin")]
    [ApiController]
    public class FruitsController : ControllerBase
    {
        private readonly IAPIService _apiService;
        public FruitsController(IAPIService service) {
            _apiService = service;
                }


        [HttpGet("GetAllFruits")]
      
        public IActionResult GetAllFruits() 
        { 
        
            var response= _apiService.GetAllFruits();
            return Ok(response);
        }

        [HttpGet("GetFruitById")]

        public IActionResult GetFruitById(int id)
        {

            var response = _apiService.GetFruitById(id);

            if(response==null)
            {
                return NotFound("Fruit data not found");
            }
            return Ok(response);
        }

        [HttpPost("UpdateDescription")]

        public IActionResult UpdateDescription(int id, string desc)
        {

            var response = _apiService.UpdateDescription(id, desc);

            if (response == null)
            {
                return NotFound("Fruit data not found");
            }
            return Ok(response);
        }

        [HttpPost("AddBenefit")]
        public IActionResult AddBenefit(Benefits benefits)
        {

            var response = _apiService.AddBenefit( benefits);

          
            return Ok(response);
        }


        [HttpPost("GetBenefitsById")]
        public IActionResult GetBenefitsById(int id)
        {

            var response = _apiService.GetBenefitsById(id);


            return Ok(response);
        }


        [HttpPost("DeleteBenefitById")]
        public IActionResult DeleteBenefitById(int id)
        {

            var response = _apiService.DeleteBenefitById(id);


            return Ok(response);
        }

    }
}
