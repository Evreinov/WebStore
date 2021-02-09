﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Domain.Identity;

namespace WebStore.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _UserManager;
        private readonly RoleManager<Role> _RoleManager;
        public AccountController(UserManager<User> UserManager, RoleManager<Role> RoleManager)
        {
            _UserManager = UserManager;
            _RoleManager = RoleManager;
        }


    }
}