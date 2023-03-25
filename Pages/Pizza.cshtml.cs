using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesPizza.Models;
using RazorPagesPizza.Services;


namespace RazorPagesPizza.Pages
{
    public class PizzaModel : PageModel
    {
        public List<Pizza> pizzas = new();

        // La clase PizzaModel necesita acceder al modelo Pizza. Validará y pasará las entradas Pizza del formulario Pizza. Para ello, usa el atributo [BindProperty]
        [BindProperty]
        public Pizza NewPizza { get; set; } = new();
        public void OnGet()
        {
            pizzas = PizzaService.GetAll();
        }
        public string GlutenFreeText(Pizza pizza)
        {
            return pizza.IsGlutenFree ? "Gluten Free" : "Not Gluten Free";
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            PizzaService.Add(NewPizza);
            return RedirectToAction("Get");
        }
        public IActionResult OnPostDelete(int id)
        {
            PizzaService.Delete(id);
            return RedirectToAction("Get");
        }

    }
}
