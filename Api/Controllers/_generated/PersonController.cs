using Application.Interfaces;
using Application.ViewModels;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Api.Controllers
{
    public partial class PersonController 

    {
        
		private readonly IPersonAppService _service;




        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PersonViewModel model)
        {
            try
            {
				var entity = _mapper.Map<Person>(model);
				var result = await Task.FromResult(_service.Save(entity, false));
                return Created("",_mapper.Map<PersonViewModel>(result));
            }
            catch(Exception e)
            {
                return BadRequest($"Error while saving Person {e.Message}");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] PersonViewModel model)
        {
            try
            {
				var entity = _mapper.Map<Person>(model);
				var result = await Task.FromResult(_service.Save(entity, true));
                return Ok(_mapper.Map<PersonViewModel>(result));
            }
            catch(Exception e)
            {
                return BadRequest($"Error while saving Person {e.Message}");
            }
        }

		protected override void Dispose(bool disposing)
		{
			_service.Dispose();
			base.Dispose(disposing);
		}

    }
}

