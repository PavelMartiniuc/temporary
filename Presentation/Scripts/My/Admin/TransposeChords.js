$(document).ready(
    function () {

        $("#btParseChords").click(transposeChords);
    }
)

function transposeChords() {
    $('.transpose-keys').remove();
    var $parsedChordsPre = $('#parsedChords');
    var $chordsKey = $('#chordsKey').val();
    $parsedChordsPre.html($('#Chords').val());
    $parsedChordsPre.attr('data-key', $chordsKey);
    $parsedChordsPre.transpose();
}