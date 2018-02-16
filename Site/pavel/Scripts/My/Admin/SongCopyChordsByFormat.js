var selection='';
var chordsString = '';
var chordsArrray;
var backupChords = null;
var TextSelecting = false;
// Флаги для определения браузеров
var uagent = navigator.userAgent.toLowerCase();
var is_safari = ((uagent.indexOf('safari') != -1) || (navigator.vendor == "Apple Computer, Inc."));
var is_ie = ((uagent.indexOf('msie') != -1) && (!is_opera) && (!is_safari) && (!is_webtv));
var is_ie4 = ((is_ie) && (uagent.indexOf("msie 4.") != -1));
var is_moz = (navigator.product == 'Gecko');
var is_ns = ((uagent.indexOf('compatible') == -1) && (uagent.indexOf('mozilla') != -1) && (!is_opera) && (!is_webtv) && (!is_safari));
var is_ns4 = ((is_ns) && (parseInt(navigator.appVersion) == 4));
var is_opera = (uagent.indexOf('opera') != -1);
var is_kon = (uagent.indexOf('konqueror') != -1);
var is_webtv = (uagent.indexOf('webtv') != -1);

var is_win = ((uagent.indexOf("win") != -1) || (uagent.indexOf("16bit") != -1));
var is_mac = ((uagent.indexOf("mac") != -1) || (navigator.vendor == "Apple Computer, Inc."));
var ua_vers = parseInt(navigator.appVersion);

$().ready(
    function (){
    
        
        
        $('#Chords').on('mouseup', checkCopyAviable);
        $('#Chords').on('keyup', checkCopyAviable);
        
        $('#Chords').on('mousleave', checkCopyAviable);
        $('#Chords').on('blur', function (e) {
            checkCopyAviable();
        });

        checkCopyAviable();
        $("#btCopySelection").on("click", copySelection);
        $("#btPasteChords").on("click", pasteChords);
        backupChords = $('#Chords').text();
        $("#btCancelFormat").on("click", cancelFormat);
        $("#btCancelFormat").attr("disabled", "disabled");
                
    }
)

function checkCopyAviable(e)
{
  //  if (e)
  //  alert(e.type);

    var selection = getSelection(document.getElementById('Chords'))
    if (selection = null || selection == "") {
        $("#btCopySelection").attr("disabled", "disabled");
        $("#btPasteChords").attr("disabled", "disabled");
    }
    else {
        $("#btCopySelection").removeAttr("disabled");
        if (chordsString == "")
            $("#btPasteChords").attr("disabled", "disabled");
        else
            $("#btPasteChords").removeAttr("disabled");
    }
        
}



function cancelFormat()
{
    $('#Chords').val(backupChords);
    backupChords = null;
    $("#btCancelFormat").attr("disabled", "disabled");
}



    function copySelection()
    {
        backupChords = $("#Chords").val();
        
        selection = getSelection(document.getElementById('Chords'));
        if (selection == null || selection == "") return;
        getChordsFromSelection();
        $("#copiedChords").text(chordsString);
      
    }

    function pasteChords()
    {
        
        var destSelection = getSelection(document.getElementById('Chords'));
        if (destSelection == null || destSelection == "" || chordsArrray.length == 0) return;
        var resultStringChords = '';
        var chordsLinePosition=0
        var selectionArray = destSelection.split('\n');
        var chordsLen = chordsArrray.length;
        for (i = 0; i < selectionArray.length; i++)
        {
            if (chordsLinePosition < chordsLen) {
                resultStringChords += chordsArrray[i] + '\n';
                resultStringChords += selectionArray[i] + '\n';
            }
            else
                resultStringChords += selectionArray[i];
        }

        var resultString = '';
        var $chordsTextArea = $("#Chords");
        var chordsTextArea = $chordsTextArea[0];
        
        var originalChordsText = $chordsTextArea.val();

        var selectionStart = chordsTextArea.selectionStart;
        var selectionEnd = chordsTextArea.selectionEnd;

        resultString = originalChordsText.substr(0, selectionStart) + resultStringChords + originalChordsText.substr(selectionEnd);

        $chordsTextArea.val(resultString);
        $("#btCancelFormat").removeAttr("disabled");
    }
    function getChordsFromSelection()
    {
        chordsString = "";
        chordsArrray = [];
        var chords = [];
        var chordsAndLiricsArray = selection.split('\n');
        var chords = [];
        for (i = 0; i < chordsAndLiricsArray.length; i=i+2)
            chords.push(chordsAndLiricsArray[i]);
        for (i = 0; i < chords.length; i++) {
            chordsArrray.push(chords[i]);
            chordsString+=chords[i]+'\n';
        }
        chordsString.trim();
    }

     

    function getSelection(textarea) {
        var selection = null;
        if ((ua_vers >= 4) && is_ie && is_win) {
            if (textarea.isTextEdit) {
                textarea.focus();
                var sel = document.selection;
                var rng = sel.createRange();
                rng.collapse;
                if ((sel.type == "Text" || sel.type == "None") && rng != null)
                    selection = rng.text;
            }
        } else if (typeof (textarea.selectionEnd) != "undefined") {
            selection = (textarea.value).substring(textarea.selectionStart, textarea.selectionEnd);
        }
        return selection;
    }

