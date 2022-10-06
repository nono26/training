using myBankAccount.Core.BankAccountAggregate;
using Xunit;
namespace myBankAccount.UnitTests.Core
{
    public class BankAccountTest
    {
        private BankAccount _sut;


        public BankAccountTest(){

            _sut= new BankAccount("Arnaud",1000);
        }

        [Fact]
        public void  Deposit_100_Success(){

            //Arrange
            BankOperation myOp= new BankOperation{
                Type="Deposit",
                AmountInCent=100
            };

            //Act
            _sut.Operation(myOp);
            
            //Assert
            Assert.Equal(1, _sut.BankOperations.Count());
            Assert.Equal(1100, _sut.BalanceInCent);
            Assert.True(_sut.BankOperations.ToList()[0].OperationSuccess);     
        }

        [Fact]
        public void  Withdrawal_100_Success(){

            //Arrange
            BankOperation myOp= new BankOperation{
                Type="Withdrawal",
                AmountInCent=100
            };

            //Act
            _sut.Operation(myOp);
            
            //Assert
            Assert.Equal(1, _sut.BankOperations.Count());
            Assert.Equal(900, _sut.BalanceInCent);   
            Assert.True(_sut.BankOperations.ToList()[0].OperationSuccess);     
        }

        [Fact]
        public void  Withdrawal_2000_Fail(){

            //Arrange
            BankOperation myOp= new BankOperation{
                Type="Withdrawal",
                AmountInCent=2000
            };

            //Act
            _sut.Operation(myOp);
            
            //Assert
            Assert.Equal(1, _sut.BankOperations.Count());
            Assert.False(_sut.BankOperations.ToList()[0].OperationSuccess);
            Assert.Equal(1000, _sut.BalanceInCent);            
        }

        [Fact]
        public void  Deposit_Minus2000_Fail(){

            //Arrange
            BankOperation myOp= new BankOperation{
                Type="Deposit",
                AmountInCent=-2000
            };

            //Act
            _sut.Operation(myOp);
            
            //Assert
            Assert.Equal(1, _sut.BankOperations.Count());
            Assert.False(_sut.BankOperations.ToList()[0].OperationSuccess);
            Assert.Equal(1000, _sut.BalanceInCent);            
        }

    }
}