using DddInPractice.Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace DddInPractice.UI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly SnackMachine _snackMachine;

        public string MoneyInTransaction => _snackMachine.MoneyInTransaction.ToString();
        public Money MoneyInside => _snackMachine.MoneyInside + _snackMachine.MoneyInTransaction;

        private string _message;

        public string Message
        {
            get { return _message; }
            private set { _message = value; }
        }

        public IndexModel(ILogger<IndexModel> logger, SnackMachine snackMachine)
        {
            _logger = logger;
            _snackMachine = snackMachine;
        }

        public void OnGet()
        {

        }

        public void OnPostInsertCent()
        {
            _snackMachine.InsertMoney(Money.Cent);
            CreateMessage(Money.Cent);
        }
        public void OnPostInsertTenCent()
        {
            _snackMachine.InsertMoney(Money.TenCent);
            CreateMessage(Money.TenCent);
        }
        public void OnPostInsertQuarter()
        {
            _snackMachine.InsertMoney(Money.Quarter);
            CreateMessage(Money.Quarter);
        }
        public void OnPostInsertDollar()
        {
            _snackMachine.InsertMoney(Money.Dollar);
            CreateMessage(Money.Dollar);
        }
        public void OnPostInsertFiveDollar()
        {
            _snackMachine.InsertMoney(Money.FiveDollar);
            CreateMessage(Money.FiveDollar);
        }
        public void OnPostInsertTwentyDollar()
        {
            _snackMachine.InsertMoney(Money.TwentyDollar);
            CreateMessage(Money.TwentyDollar);
        }

        public void OnPostReturnMoney()
        {
            _snackMachine.ReturnMoney();
            Message = "Money was returned";
        }

        public void OnPostBuySnack()
        {
            _snackMachine.BuySnack();
            Message = "You have bought a snack";
        }

        private void CreateMessage(Money money)
        {
            Message = "You have inserted: " + money.ToString();
        }
    }
}
