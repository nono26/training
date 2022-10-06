using Xunit;
using VolleyBall.Core;
namespace VolletBall.Tests;

public class ScoreTest
{
    private Score _sut;
    private List<Team> _teams;

    public ScoreTest(){
        _teams= new List<Team>();
        _teams.Add(new Team("A",50));
        _teams.Add(new Team("B",50));
        _sut= new Score(_teams);
    }

    [Fact]
    public void IsSetFinished()
    {
        //Arrange
        _sut.GetSets().Add(new Set(_teams.First().GetId(), _teams));
        for(int i =0; i<25;i++)
            _sut.AddPoint(_teams.First());

        //Act
        var isSetContinue= _sut.IsSetCarryOn();

        //Assert

        Assert.False(isSetContinue);
    }

    [Fact]
    public void IsSetFinished_With2pointsDiff_true()
    {
        //Arrange   
        _sut.GetSets().Add(new Set(_teams.First().GetId(), _teams));

        for(int i =0; i<27;i++)
            _sut.AddPoint(_teams.First());    

        _sut.GetSets().Add(new Set(_teams[1].GetId(),_teams));
        for(int i =0; i<25;i++)
            _sut.AddPoint(_teams[1]);       
            
         //Act
        var isSetContinue=  _sut.IsSetCarryOn();

        //Assert

        Assert.False(isSetContinue);
    }  

    [Fact]
    public void IsSetNotFinished_Less2PointDiff()
    {
        //Arrange

        _sut.GetSets().Add(new Set(_teams.First().GetId(),_teams));

        for(int i =0; i<25;i++)
            _sut.AddPoint(_teams.First());    

        _sut.GetSets().Add(new Set(_teams[1].GetId(),_teams));

        for(int i =0; i<24;i++)
            _sut.AddPoint(_teams[1]);       

        //Act
        var isSetContinue=  _sut.IsSetCarryOn();

        //Assert

        Assert.True(isSetContinue);
    }

    [Fact]
    public void MatchFinishedOnFifthSet_With2PointDiff()
    {
        //Arrange
        
        _sut.GetSets().Add(new Set(_teams.First().GetId(),_teams));
        for(int i =0; i<25;i++)
            _sut.AddPoint(_teams.First());    

        _sut.GetSets().Add(new Set(_teams.First().GetId(),_teams));
        for(int i =0; i<25;i++)
            _sut.AddPoint(_teams.First());    

        _sut.GetSets().Add(new Set(_teams[1].GetId(),_teams));
        for(int i =0; i<25;i++)
            _sut.AddPoint(_teams[1]);       

        _sut.GetSets().Add(new Set(_teams[1].GetId(),_teams));
        for(int i =0; i<25;i++)
            _sut.AddPoint(_teams[1]);       

        _sut.GetSets().Add(new Set(_teams[1].GetId(),_teams,true));
        for(int i =0; i<15;i++)
            _sut.AddPoint(_teams.First());    

        for(int i =0; i<13;i++)
            _sut.AddPoint(_teams[1]);       

        //Act
        var isSetContinue= _sut.IsSetCarryOn();
        var isMatchNotFinished= _sut.IsMatchNotFinished();
        //Assert
        Assert.False(isSetContinue);
        Assert.True(isMatchNotFinished);
    }

    [Fact]
    public void IsSetNotFinishedOnFifthSet_WithLess2PointDiff()
    {
        //Arrange
        
        _sut.GetSets().Add(new Set(_teams.First().GetId(),_teams));
        for(int i =0; i<25;i++)
            _sut.AddPoint(_teams.First());    

        _sut.GetSets().Add(new Set(_teams.First().GetId(),_teams));
        for(int i =0; i<25;i++)
            _sut.AddPoint(_teams.First());    

        _sut.GetSets().Add(new Set(_teams[1].GetId(),_teams));
        for(int i =0; i<25;i++)
            _sut.AddPoint(_teams[1]);       

        _sut.GetSets().Add(new Set(_teams[1].GetId(),_teams));
        for(int i =0; i<25;i++)
            _sut.AddPoint(_teams[1]);       

        _sut.GetSets().Add(new Set(_teams[1].GetId(),_teams,true));
        for(int i =0; i<35;i++)
            _sut.AddPoint(_teams.First());    

        for(int i =0; i<36;i++)
            _sut.AddPoint(_teams[1]);       

        //Act
        var isSetContinue= _sut.IsSetCarryOn();
        var isMatchNotFinished= _sut.IsMatchNotFinished();
        //Assert
        Assert.True(isSetContinue);
        Assert.True(isMatchNotFinished);
    }

    [Fact]
    public void MatchNotFinishedWith0Sets()
    {

        //Act
        var matchNotFinished= _sut.IsMatchNotFinished();

        //Assert

        Assert.True(matchNotFinished);
    }
    

}