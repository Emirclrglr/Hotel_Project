﻿using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.Areas.Admin.ViewComponents.Admin
{
    public class _AdminSidebarPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
