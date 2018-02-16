var filterFormAction;
$().ready(
    function (){
    
        $("#ArtistId").on("change", FilterSongs);
        $("#ThemeId").on("change", FilterSongs);
        filterFormAction = $("#filterForm").attr("action");
       
   }
)

function FilterSongs()
{
    var artistId = $("#ArtistId").val();
    
    var themeId = $("#ThemeId").val();

    var url = filterFormAction + artistId + "/" + themeId;

    $(location).attr('href', url);

}