using Xunit;
using BankAccountAPI.Business;
using BankAccountAPI.PrimaryPort;
using BankAccountAPI.PrimaryPort.Models;
using BankAccountAPI.SecondaryPort;
using Moq;
using System.Linq;
using System.Collections.Generic;
namespace BankAccountAPI.Tests;

public class BusinessTests
{
    private IBankOperation _sut;
    private Mock<IBankBalance> _gateway;

    public BusinessTests(){

        _gateway= new Mock<IBankBalance>();
        _gateway.Setup(g=> g.GetBalance()).Returns(10);
        _sut= new BankOperation(_gateway.Object);
    }

    [Fact]
    public async void GetSuccess_When_do_deposit()
    {
        //Arrange
        int Amount= 10;
        string actionType= OperationType.Deposit.ToString();

        //Act
        var result= await _sut.Operation(Amount,actionType);

        //Assert
        Assert.True(result);
    }

    [Fact]
    public async void GetSuccess_When_do_withdrawal()
    {
        //Arrange
        int Amount= 10;
        string actionType= OperationType.Withdraw.ToString();

        //Act
        var result= await _sut.Operation(Amount,actionType);

        //Assert
        Assert.True(result);
    }

    [Fact]
    public async void GetFail_When_do_withdrawal_unsuffisantMoney()
    {
        //Arrange
        int AmountToWithdraw= 100;
        int currentBalance= 10;
        string actionType= OperationType.Withdraw.ToString();
        _gateway.Setup(g=> g.GetBalance()).Returns(currentBalance);

        //Act
        var result= await _sut.Operation(AmountToWithdraw,actionType);

        //Assert
        Assert.False(result);
    }

    [Fact]
    public async void GetSucces_When_GetStatement(){

        //Arrange
        List<BankStatement> statements=  new List<PrimaryPort.Models.BankStatement>();
        
        statements.Add(
                new PrimaryPort.Models.BankStatement{
                    OperationAmount=10,
                    OperationType=OperationType.Deposit
                }
            );
        statements.Add(
                new PrimaryPort.Models.BankStatement{
                    OperationAmount=5,
                    OperationType= OperationType.Withdraw
                }
            );

        _gateway.Setup(g=> g.GetBankStatements()).Returns(statements);

        //Act
        var result= await _sut.GetBankStatements();
        
        //Assert
        Assert.NotNull(result);

        Assert.Equal(2, result.ToList().Count());
        Assert.Equal("Deposit", result.ToList()[0].OperationType.ToString());
        Assert.Equal("Withdraw", result.ToList()[1].OperationType.ToString());       
    }
}