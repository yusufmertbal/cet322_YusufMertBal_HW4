﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YusufMertBookStore.Data;

namespace YusufMertBookStore.ViewComponents
{
    public class CategoryMenuViewComponent:ViewComponent
    {
        private readonly ApplicationDbContext context;

        public CategoryMenuViewComponent(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync() 
        {
            var cats = await context.Categories.ToListAsync();
            return View(cats);
        }
    }
}
