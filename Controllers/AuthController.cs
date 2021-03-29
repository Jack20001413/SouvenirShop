using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    public class AuthController : Controller
    {
        private readonly IEmployeeService employeeService;

        private AuthController(IEmployeeService employeeService) {
            this.employeeService = employeeService;
        }
    }
}