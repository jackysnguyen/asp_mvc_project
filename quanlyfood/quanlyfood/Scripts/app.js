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
    
});