
$(document).ready(function () {
    $('#coolMenu > li').hover(
            function()
            {
                var parentMenu = $(this);
                var subMenu = $("ul:first", this);
                var parentMenuWidth = parentMenu.width();
                var subMenuWidth = subMenu.width();
               
                subMenu.width(parentMenuWidth);
                subMenu.hide().slideDown("fast");
            },
            function () {
                $("ul:first", this).slideUp("fast");
            }
        );
}
);
