﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.DAL.Context;
using WebStore.Domain.Identity;
using WebStore.Interfaces;

namespace WebStore.ServiceHosting.Controllers.Identity
{
    [Route(WebAPI.Identity.User)]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserStore<User, Role, WebStoreDB> _UserStore;
        public UsersController(WebStoreDB db)
        {
            _UserStore = new UserStore<User, Role, WebStoreDB>(db);
        }
    }
}