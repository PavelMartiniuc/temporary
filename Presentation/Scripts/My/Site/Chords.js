var chordsHidden = false;
var chordPopup;
var pathToChords = "/Content/Images/Chords/";

$(document).ready(
    function()
    {

        /*
        $("#btShowHideChords").on("click", function () {

            
            if (chordsHidden) 
                $(this).val("Скрыть аккорды");
            else
                $(this).val("Показать аккорды");
            
            $(".chordsArticle b").toggleClass("hide");
            $(".SongChodrs").toggleClass("hide");
            chordsHidden = !chordsHidden;
            }
        );
        */
        $("pre").transpose();

        $("span.c").on("mouseover", showChord);
        $("span.c").on("mouseout", hideChord);

        chordPopup = $("#chordPreview");
        
    }
)

function showChord(e)
{
    var x = e.pageX + 10;
    var y = e.pageY + 10;

    var target = $(e.target);
    var chordName = target.text();

    
    chordPopup.css({ left: x, top: y });
    
    var chordUrl = pathToChords + chordName[0] + "/" + chordName.replace("#", "%23").replace("/", "slash") + ".jpg";
    
    chordPopup.find('img').attr("src", chordUrl);
    
    chordPopup.show();
    e.stopPropagation();
}

function hideChord(e) {
    chordPopup.hide();

}