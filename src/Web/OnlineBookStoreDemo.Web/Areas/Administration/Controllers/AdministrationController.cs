﻿namespace OnlineBookStoreDemo.Web.Areas.Administration.Controllers
{
    using OnlineBookStoreDemo.Common;
    using OnlineBookStoreDemo.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}
