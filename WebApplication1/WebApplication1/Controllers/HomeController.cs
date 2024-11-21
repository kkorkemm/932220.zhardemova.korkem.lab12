using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    private readonly ICalculatorService _calculatorService;

    public HomeController(ICalculatorService calculatorService)
    {
        _calculatorService = calculatorService;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult ManualParsingSingleAction()
    {
        return View();
    }

    [HttpPost]
    public IActionResult ManualParsingSingleAction(IFormCollection form)
    {
        double num1 = Convert.ToDouble(form["Number1"]);
        double num2 = Convert.ToDouble(form["Number2"]);
        string operation = form["Operation"];

        try
        {
            double result = _calculatorService.Calculate(num1, num2, operation);
            ViewBag.Result = result;
        }
        catch (Exception ex)
        {
            ViewBag.Error = ex.Message;
        }

        return View("ManualParsingSingleActionResult");
    }

    public IActionResult ManualParsingSeparateActions()
    {
        return View();
    }

    [HttpPost]
    public IActionResult ManualParsingSeparateActions(double Number1, double Number2, string Operation)
    {
        try
        {
            double result = _calculatorService.Calculate(Number1, Number2, Operation);
            ViewBag.Result = result;
        }
        catch (Exception ex)
        {
            ViewBag.Error = ex.Message;
        }

        return View("ManualParsingSeparateActionsResult");
    }

    public IActionResult ModelBindingParameters()
    {
        return View();
    }

    [HttpPost]
    public IActionResult ModelBindingParameters(OperationModel model)
    {
        try
        {
            double result = _calculatorService.Calculate(model.Number1, model.Number2, model.Operation);
            ViewBag.Result = result;
        }
        catch (Exception ex)
        {
            ViewBag.Error = ex.Message;
        }

        return View("ModelBindingParametersResult");
    }

    public IActionResult ModelBindingSeparateModel()
    {
        return View();
    }

    [HttpPost]
    public IActionResult ModelBindingSeparateModel(OperationModel model)
    {
        try
        {
            double result = _calculatorService.Calculate(model.Number1, model.Number2, model.Operation);
            ViewBag.Result = result;
        }
        catch (Exception ex)
        {
            ViewBag.Error = ex.Message;
        }

        return View("ModelBindingSeparateModelResult");
    }
}