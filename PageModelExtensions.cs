using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Indotalent
{
    public static class PageModelExtensions
    {
        public static void SetupViewDataTitleFromUrl(this PageModel pageModel)
        {
            var currentUrl = pageModel.HttpContext.GetCurrentUrl();
            var currentCshtml = currentUrl.ToCshtmlName();
            var currentTitle = currentCshtml.ToTitle();
            pageModel.ViewData["Title"] = currentTitle;

            var currentPageName = currentUrl.ToPageFolderName();
            if (currentPageName.EndsWith("y"))
            {
                currentPageName = currentPageName.Substring(0, currentPageName.Length - 1) + "ies";
            }
            pageModel.ViewData["PageFolderName"] = currentPageName;
            pageModel.ViewData["CshtmlName"] = currentCshtml;
        }
    }
}
