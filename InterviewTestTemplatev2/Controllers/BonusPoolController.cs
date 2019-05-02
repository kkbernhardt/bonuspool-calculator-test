using InterviewTestTemplatev2.Models;
using InterviewTestTemplatev2.Services;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace InterviewTestTemplatev2.Controllers
{
    public class BonusPoolController : Controller
    {
        private readonly IBonusPoolCalculationService _bonusService;
        public BonusPoolController(IBonusPoolCalculationService bonusService)
        {
            _bonusService = bonusService;
        }

        // GET: BonusPool
        public ActionResult Index()
        {
            try
            {
                return View(_bonusService.AddEmployeesToResultModel());
            }
            catch (NullReferenceException ex)
            {
                return HttpNotFound(ex.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Calculate(BonusPoolCalculatorModel model)
        {
            try
            {
                var resultToDisplay = _bonusService.SetBonusPoolToEmployee(model.SelectedEmployeeId, model.BonusPoolAmount);
                return View(resultToDisplay);
            }
            catch (KeyNotFoundException e)
            {
                return View(Index());
            }   
        }
    }
}