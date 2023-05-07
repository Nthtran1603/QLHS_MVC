using AutoMapper;
using Infrastructure.Entities;
using Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLHS_MVC.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace VegetableWebMVC.Controllers
{
	public class HocSinhController : Controller
	{
		private readonly IHocSinhService hocSinhService;
		readonly IMapper mapper;

		public HocSinhController(IHocSinhService hocSinhService, IMapper mapper)
		{
			this.hocSinhService = hocSinhService;
			this.mapper = mapper;
		}

		public IActionResult Index()
		{
			
			return View(hocSinhService.GetHocSinhs());
		}
		public IActionResult AddOrEdit(string id = "")
		{
			HocSinhViewModel data = new HocSinhViewModel();
			ViewBag.RenderedHtmlTitle = string.IsNullOrEmpty(id)  ? "THÊM MỚI HỌC SINH" : "CẬP NHẬT HỌC SINH";

			if (!string.IsNullOrEmpty(id))
			{
				HocSinh res = hocSinhService.GetHocSinh(id);
				data = mapper.Map<HocSinhViewModel>(res);
				if (data == null)
				{
					return NotFound();
				}
			}
			return View(data);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult AddOrEdit(string id, HocSinhViewModel data)
		{
			ViewBag.RenderedHtmlTitle = string.IsNullOrEmpty(id) ? "THÊM MỚI HỌC SINH" : "CẬP NHẬT HỌC SINH";

			if (ModelState.IsValid)
			{
				try
				{
					HocSinh res = mapper.Map<HocSinh>(data);
					if (!string.IsNullOrEmpty(id))
					{
						hocSinhService.UpdateHocSinh(res);
					}
					else
					{

                        hocSinhService.InsertHocSinh(res);

					}
				}
				catch (DbUpdateConcurrencyException)
				{
					return NotFound();
				}

				return RedirectToAction("Index", "HocSinh");
			}
            return View(data);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Delete(string id)
		{
			HocSinh res = hocSinhService.GetHocSinh(id);
			hocSinhService.DeleteHocSinh(res);

			return RedirectToAction("Index", "HocSinh");
		}
	}
}
