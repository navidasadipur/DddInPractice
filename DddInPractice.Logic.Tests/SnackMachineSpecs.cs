using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

using static DddInPractice.Logic.Money;

namespace DddInPractice.Logic.Tests
{
    public class SnackMachineSpecs
    {
        [Fact]
        public void ReturnMoneyEmptiesMoneyInTransaction()
        {
            var snackMachine = new SnackMachine();
            snackMachine.InsertMoney(Dollar);

            snackMachine.ReturnMoney();

            snackMachine.MoneyInTransaction.Amount.Should().Be(0m);
        }

        [Fact]
        public void InsertedMoneyGoesToMoneyInTransaction()
        {
            var snackMachine = new SnackMachine();

            snackMachine.InsertMoney(Cent);
            snackMachine.InsertMoney(Dollar);

            snackMachine.MoneyInTransaction.Amount.Should().Be(1.01m);
        }

        [Fact]
        public void CannotInsertMoreThanOneCoinOrNoteAtATime()
        {
            var snackMachine = new SnackMachine();
            var twoCent = Cent + Cent;

            Action action = () => snackMachine.InsertMoney(twoCent);

            action.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void MoneyInTransactionGoToMoneyInsideAfterPurchase()
        {
            var snackMachine = new SnackMachine();
            snackMachine.InsertMoney(Dollar);
            snackMachine.InsertMoney(Dollar);

            snackMachine.BuySnack();

            snackMachine.MoneyInTransaction.Should().Be(None);
            snackMachine.MoneyInside.Amount.Should().Be(2m);
        }

        [Fact]
        public void NewCreateSnackMachineMustHaveNoMoneyInsideAndTransaction()
        {
            var snackMachine = new SnackMachine();

            snackMachine.MoneyInside.Amount.Should().Be(0);
            snackMachine.MoneyInTransaction.Amount.Should().Be(0);
        }
    }
}
