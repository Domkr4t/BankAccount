﻿using BankAccount.Backend.Domain.ViewModel;
using BankAccount.Backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace BankAccount.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBankService _bankService;
        
        public HomeController(IBankService bankService)
        {
            _bankService = bankService;
        }

        [Route("CreateLegalUser")]
        [HttpPost]
        public async Task<IActionResult> CreateLegalUser([FromBody]CreateLegalUserViewModel model) 
        { 
            var response = await _bankService.CreateLegalUser(model);

            if (response.StatusCode == Backend.Domain.Enum.StatusCode.Ok)
            {
                return Ok(new {description = response.Description});
            }
            return BadRequest(new {description = response.Description });
        }

        [Route("DeleteLegalUser")]
        [HttpPost]
        public async Task<IActionResult> DeleteLegalUser([FromQuery] int id) 
        {
            var response = await _bankService.DeleteLegalUser(id);

            if (response.StatusCode == Backend.Domain.Enum.StatusCode.Ok)
            {
                return Ok(new { description = response.Description });
            }
            return BadRequest(new { description = response.Description });
        }

        [Route("UpdateLegalUser")]
        [HttpPut]
        public async Task<IActionResult> UpdateLegalUser(UpdateLegalUserViewModel model)
        {
            var response = await _bankService.UpdateLegalUser(model);

            if (response.StatusCode == Backend.Domain.Enum.StatusCode.Ok)
            {
                return Ok(new { description = response.Description });
            }
            return BadRequest(new { description = response.Description });
        }

        [Route("GetAllLegalUsers")]
        [HttpGet]
        public async Task<IActionResult> GetAllLegalUsers()
        {
            var response = await _bankService.GetAllLegalUsers();
            return Json(new { data = response.Data});
        }

        [Route("PatchLegalUser")]
        [HttpPatch]
        public async Task<IActionResult> PatchLegalUser(UpdateLegalUserViewModel model)
        {
            var response = await _bankService.PatchLegalUser(model);

            if (response.StatusCode == Backend.Domain.Enum.StatusCode.Ok)
            {
                return Ok(new { description = response.Description });
            }
            return BadRequest(new { description = response.Description });
        }


        [Route("CreateAccount")]
        [HttpPost]
        public async Task<IActionResult> CreateAccount(CreateAccountViewModel model)
        {
            var response = await _bankService.CreateAccount(model);

            if (response.StatusCode == Backend.Domain.Enum.StatusCode.Ok)
            {
                return Ok(new { description = response.Description });
            }
            return BadRequest(new { description = response.Description });
        }

        [Route("DeleteAccount")]
        [HttpPost]
        public async Task<IActionResult> DeleteAccount([FromQuery] int id)
        {
            var response = await _bankService.DeleteAccount(id);

            if (response.StatusCode == Backend.Domain.Enum.StatusCode.Ok)
            {
                return Ok(new { description = response.Description });
            }
            return BadRequest(new { description = response.Description });
        }

        [Route("UpdateAccount")]
        [HttpPut]
        public async Task<IActionResult> UpdateAccount(UpdateAccountViewModel model)
        {
            var response = await _bankService.UpdateAccount(model);

            if (response.StatusCode == Backend.Domain.Enum.StatusCode.Ok)
            {
                return Ok(new { description = response.Description });
            }
            return BadRequest(new { description = response.Description });
        }

        [Route("GetAllAccounts")]
        [HttpGet]
        public async Task<IActionResult> GetAllAccount()
        {
            var response = await _bankService.GetAllAccount();
            return Json(new { data = response.Data });
        }

        [Route("PatchAccount")]
        [HttpPatch]
        public async Task<IActionResult> PatchAccount(UpdateAccountViewModel model)
        {
            var response = await _bankService.PatchAccount(model);

            if (response.StatusCode == Backend.Domain.Enum.StatusCode.Ok)
            {
                return Ok(new { description = response.Description });
            }
            return BadRequest(new { description = response.Description });
        }


        [Route("CreatePhisycalUser")]
        [HttpPost]
        public async Task<IActionResult> CreatePhisycalUser([FromBody] CreatePhisycalUserViewModel model)
        {
            var response = await _bankService.CreatePhisycalUser(model);

            if (response.StatusCode == Backend.Domain.Enum.StatusCode.Ok)
            {
                return Ok(new { description = response.Description });
            }
            return BadRequest(new { description = response.Description });
        }

        [Route("DeletePhisycalUser")]
        [HttpPost]
        public async Task<IActionResult> DeletePhisycalUser([FromQuery] int id)
        {
            var response = await _bankService.DeletePhisycalUser(id);

            if (response.StatusCode == Backend.Domain.Enum.StatusCode.Ok)
            {
                return Ok(new { description = response.Description });
            }
            return BadRequest(new { description = response.Description });
        }

        [Route("UpdatePhisycalUser")]
        [HttpPut]
        public async Task<IActionResult> UpdatePhisycalUser(UpdatePhisycalUserViewModel model)
        {
            var response = await _bankService.UpdatePhisycalUser(model);

            if (response.StatusCode == Backend.Domain.Enum.StatusCode.Ok)
            {
                return Ok(new { description = response.Description });
            }
            return BadRequest(new { description = response.Description });
        }

        [Route("GetAllPhisycalUsers")]
        [HttpGet]
        public async Task<IActionResult> GetAllPhisycalUsers()
        {
            var response = await _bankService.GetAllPhisycalUsers();
            return Json(new { data = response.Data });
        }

        [Route("PhisycalUser")]
        [HttpPatch]
        public async Task<IActionResult> PatchPhisycalUser(UpdatePhisycalUserViewModel model)
        {
            var response = await _bankService.PatchPhisycalUser(model);

            if (response.StatusCode == Backend.Domain.Enum.StatusCode.Ok)
            {
                return Ok(new { description = response.Description });
            }
            return BadRequest(new { description = response.Description });
        }


        [Route("GetOneClient")]
        [HttpGet]
        public async Task<IActionResult> GetOneClient([FromQuery] int id)
        {
            var response = await _bankService.GetOneClient(id);
            return Json(new { data = response.Data });
        }
    }
}