using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.eShopWeb.ApplicationCore.Constants;
using Microsoft.eShopWeb.Web.ViewModels;

namespace Microsoft.eShopWeb.Web.Pages.Admin
{
    [Authorize(Roles = AuthorizationConstants.Roles.ADMINISTRATORS)]
    public class CreateProductItemModel : PageModel
    {
        [BindProperty]
        public CatalogCreateViewModel CatalogCreateModel { get; set; } = new CatalogCreateViewModel();
        public void OnGet()
        {

        }
    }
}