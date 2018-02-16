
$(document).ready(
   function () {
       $('#removeProviderFooter').on("click", function () {$.cookie('footerRemoved', 'footerRemoved'); removeFooter();  });

       $('#showFooter').on("click", function () { $.cookie('footerRemoved', null); removeFooter(); location.reload(); });
       
       removeFooter();
   }
);

function removeFooter() {
    
     if ($.cookie('footerRemoved') != null) 
        $('footer').nextAll().remove();
}
