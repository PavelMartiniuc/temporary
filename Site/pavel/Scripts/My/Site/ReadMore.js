$(document).ready
(
    function()
    {
        $('.readMore').readmore
            (
                {
                    speed: 75,
                    embedCSS: false,
                    heightMargin: 0,
                    collapsedHeight: 100,
                    lessLink: '<a href="#">Скрыть</a>',
                    moreLink: '<a href="#">Читать всё</a>'

                }
            );
    }

);
