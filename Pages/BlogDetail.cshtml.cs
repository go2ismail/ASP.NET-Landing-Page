using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Indotalent.Pages
{
    public class BlogDetailModel : PageModel
    {
        public void OnGet()
        {
            this.SetupViewDataTitleFromUrl();
        }
    }
}
