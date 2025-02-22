﻿using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		IProductService _productService;

		public ProductsController(IProductService productService)
		{
			_productService = productService;
		}

		[HttpGet("getall")]
		public IActionResult GetAll()
		{
			Thread.Sleep(5000);

			var result=_productService.GetAll();
			if(result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}
		[HttpGet("getbyid")]
		public IActionResult GetById(int id)
		{
			var result = _productService.GetById(id);
			if(result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}
		[HttpGet("getbycategory")]
		public IActionResult GetByCategory(int categoryid)
		{
			var result = _productService.GetAllByCategoryId(categoryid);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}
		[HttpPost("add")]
		public IActionResult Post(Product product)
		{
			var result = _productService.Add(product);
			if(result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}
	}
}
