$(document).ready(function(){
    
    const MainColours=['colour-Red','colour-Blue','colour-Green','colour-Yellow'];
    let currentColourSquare=[];

    function OnInit(){
        CreateButtons();
        CreateSquares();
    }

    function CreateSquares(){
        for(i=1;i<11;i++){
            $('#TenSquaresContainer').append('<div class="square" id="square'+i+'"></div>');
        }
        InitSquareColour();
    }

    function CreateButtons(){
        for(i=1;i<5;i++){
            $('#MainContainer').append('<button type="button" id="btn'+i+'" class="button"></button>');
        }
        $(".button").click(function (){
            updateColourSquare($(this).attr('class').match (/(^|\s)colour-\S+/g));
        });
        UpdateBtnColour();    
    }

    function updateColourSquare(NewColour){
        RemoveColorClass();
        UpdateColourSquareList(NewColour);
        ApplyColourToSquares();
    }

    function ApplyColourToSquares(){
        let i=0;
        $('#TenSquaresContainer .square').each(function(){
            $(this).addClass(currentColourSquare[i]);
            i++;
        });  
    }

    function UpdateColourSquareList(NewColour){
        currentColourSquare.unshift(NewColour);
        if(currentColourSquare.length>11){
            currentColourSquare = currentColourSquare.slice(0,10);
        }
        sessionStorage.setItem('currentColourSquare',JSON.stringify(currentColourSquare));
    }

    function RemoveColorClass(){
        $(".square").removeClass (function (index, className) {
            return (className.match (/(^|\s)colour-\S+/g) || []).join(' ');
        });
    }

    function UpdateBtnColour(){
        let i=0;
        $('#MainContainer .button').each(function(){
            $(this).addClass(MainColours[i]);
            i++;
        });       
    }

    function InitSquareColour(){
        currentColourSquare= JSON.parse(sessionStorage.getItem('currentColourSquare'));
        if(currentColourSquare== null)
            currentColourSquare=[];
        ApplyColourToSquares();
    }

    OnInit();
});