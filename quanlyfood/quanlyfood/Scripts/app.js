$(document).ready(function () {
    var startCamera = function () {
        $('#camera_wrap').camera({
            fx: 'scrollLeft',
            time: 2000,
            loader: 'none',
            playPause: false,
            navigation: true,
            height: '65%',
            pagination: true
        });
    }

    $('#list_photos').carouFredSel({
        responsive: true,
        width: '100%',
        scroll: 2,
        items: {
            width: 320,
            visible: {
                min: 2,
                max: 6
            }
        }
    });

    startCamera();

        var options = {
            autoResize: true,
            container: $('#gridArea'),
            offset: 10
        };
        
        var handler = $('#tiles li');
        
        handler.wookmark(options);
        $('#tiles li').each(function () { 
            var imgm = 0; 
            if($(this).find('img').length>0)imgm=parseInt($(this).find('img').not('p img').css('margin-bottom')); 
            var newHeight = $(this).find('img').height() + imgm + $(this).find('div').height() + $(this).find('h4').height() + $(this).find('p').not('blockquote p').height() + $(this).find('iframe').height() + $(this).find('blockquote').height() + 5;
            if($(this).find('iframe').height()) 
                newHeight = newHeight+15;
            
            $(this).css('height', newHeight + 'px');
        });

        handler.wookmark(options);
        handler.wookmark(options);
    
    
    $("a[rel^='prettyPhoto']").prettyPhoto({
        social_tools: false
    });

    $("a[rel^='prettyPhoto'] img").hover(function(){
        $(this).animate({
            opacity:0.7},300
        )},function(){
            $(this).animate({opacity:1},300)
    });
    
});