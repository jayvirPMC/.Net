using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EFCrudApp.Models.ViewModel;

namespace EFCrudApp.Pages.Employees
{
    public class AddModel : PageModel
    {
        public AddModel(RazorPagesDBContext dBContext)
        {
            DBContext = dBContext;
        }

        [BindProperty]
        public AddEmployeeViewModel AddEmployeeRequest { get; set; }
        public RazorPagesDBContext DBContext { get; }

        public void OnGet() {

        }

        public void OnPost() {
            
        }

    }
    
    
}