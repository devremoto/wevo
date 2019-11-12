using Api.Helpers.Image;
using Api.Helpers.Upload;
using Api.Models;
using Application.Interfaces;
using Application.ViewModels.Common;
using AutoMapper;
using CrossCutting.Extensions;
using CrossCutting.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Primitives;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Api.Controllers
{

    public class BaseController<TKey, TService, T, TViewModel> : Controller
        where T : class
        where TViewModel : class
        where TService : IBaseAppService<T>
    {
        protected string FilePath { get; set; }

        protected string modelName;
        protected string apiUrl;

        protected string WebRootPath { get; private set; }
        protected string ContentRootPath { get; private set; }

        private IBaseAppService<T> _service;
        protected readonly IMapper _mapper;
        private readonly IWebHostEnvironment _hostingEnvironment;
        protected AppModelConfiguration _settings;
        private string _imgFolder;

        public BaseController(IWebHostEnvironment hostingEnvironment, AppModelConfiguration settings, IBaseAppService<T> service, IMapper mapper)
        {
            _imgFolder = settings.ImgFolder;
            _hostingEnvironment = hostingEnvironment;
            _settings = settings;
            WebRootPath = _hostingEnvironment.WebRootPath;
            ContentRootPath = _hostingEnvironment.ContentRootPath;
            _service = service;
            this._mapper = mapper;
            FilePath = FilePath ?? $@"{ContentRootPath}{_imgFolder}";
            modelName = typeof(T).Name;

        }

        [Route("{id}")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetOne(TKey id)
        {
            try
            {
                var model = await Task.FromResult(_service.GetOne(id));
                if (model != null)
                    return NotFound();
                return Ok(model);
            }
            catch (Exception e)
            {
                return BadRequest($"Error while retieving {modelName} {e.Message}");
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var model = await Task.FromResult(_service.GetAll());
                return Ok(model);
            }
            catch (Exception e)
            {
                return BadRequest($"Error while retieving {modelName} {e.Message}");
            }
        }

        [Route("getAllPage")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> GetByAllPage([FromBody] PagingViewModel<TViewModel> page)
        {
            try
            {
                var entity = _mapper.Map<PagingViewModel<T>>(page);
                var model = await Task.FromResult(_service.GetByAllPage(entity));
                return Ok(model);
            }
            catch (Exception e)
            {
                return BadRequest($"Error while retieving {modelName} {e.Message}");
            }
        }


        [HttpDelete]
        public async Task<IActionResult> Remove([FromBody] TViewModel model)
        {
            try
            {
                var entity = _mapper.Map<T>(model);
                await Task.Run(() => _service.Remove(entity));
                return Ok();
            }
            catch
            {
                return BadRequest($"Error while deleting {modelName}");
            }
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> Remove(TKey id)
        {
            try
            {
                await Task.Run(() => _service.Remove(id));
                return Ok();
            }
            catch
            {
                return BadRequest($"Error while deleting {modelName}");
            }
        }

		[Route("{id}")]
		[HttpPut]
		public async Task<IActionResult> Update([FromBody] TViewModel model, TKey id)
		{
			try
			{
				var entity = _mapper.Map<T>(model);
				var result = await Task.FromResult(_service.Update(entity));
				return Ok(_mapper.Map<TViewModel>(result));
			}
			catch (Exception e)
			{
				return BadRequest($"Error while saving {modelName} {e.Message}");
			}
		}


    }




}