namespace FreeGaming.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using static Common.WebConstants.Roles;

    [Area("Admin")]
    [Authorize(Roles = Administrator)]
    public class AdminBaseController : Controller { }
}
