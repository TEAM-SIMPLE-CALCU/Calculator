using Microsoft.AspNetCore.Mvc;

namespace SimpleCalculator.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Result = "";

            return View();
        }

        [HttpPost]
        public IActionResult Calculate(double num1, double num2, string operation)
        {
            double result;
            switch (operation)
            {
                case "+":
                    result = num1 + num2;
                    break;
                case "-":
                    result = num1 - num2;
                    break;
                case "*":
                    result = num1 * num2;
                    break;
                case "/":
                    if (num2 == 0)
                    {
                        ViewBag.Result = "Error: Cannot divide by zero";
                        return View("Index");
                    }
                    result = num1 / num2;
                    break;
                default:
                    ViewBag.Result = "Invalid operation";
                    return View("Index");
            }

            ViewBag.Result = result;
            ViewBag.Num1 = num1;
            ViewBag.Operation = operation;
            ViewBag.Num2 = num2;
            return View("Index");
        }
    }
}
