using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RPAftercare.Models;

namespace RPAftercare.Controllers
{
    public class ExpenseController : Controller
    {
        public ActionResult Add()
        {
            var exp = new tblExpense()
            {
                expDate = DateTime.Today
            };
            return View(exp);
        }

        [HttpPost]
        public ActionResult Add(tblExpense exp)
        {
            AftercareEntities expenses = new AftercareEntities();
            expenses.tblExpenses.Add(exp);
            expenses.SaveChanges();
            ModelState.Clear();
            exp = new tblExpense()
            {
                expDate = DateTime.Today
            };
            ViewBag.Message = "Expense added successfully.";
            return View(exp);
        }

        public ActionResult List()
        {
            AftercareEntities exp = new AftercareEntities();
            return View(exp.tblExpenses.OrderByDescending(t => t.expDate));
        }

        public ActionResult Delete(int UserID)
        {
            AftercareEntities exp = new AftercareEntities();
            var item = exp.tblExpenses.Where(e => e.UserID == UserID).SingleOrDefault();
            exp.tblExpenses.Remove(item);
            return RedirectToAction("Home", "Users");
        }
    }
}