﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_g033.Models.Domain;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_g033.Controllers
{
    public class AccountController : Controller
    {
        private readonly Account _account;
        public AccountController(Account account)
        {
            this._account = account;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}