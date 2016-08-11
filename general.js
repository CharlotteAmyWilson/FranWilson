$(window).load(function () {

    var menu = $('#menu');
    var pos = menu.offset();

    var nav = $('#navigation');


    $('.lightbox1').lightBox({ fixedNavigation: true, maxWidth: 900, maxHeight: 900 });
    $('.lightbox2').lightBox({ fixedNavigation: true, maxWidth: 900, maxHeight: 900 });
    $('.lightbox3').lightBox({ fixedNavigation: true, maxWidth: 900, maxHeight: 900 });
    $('.lightbox4').lightBox({ fixedNavigation: true, maxWidth: 900, maxHeight: 900 });
    $('.lightbox5').lightBox({ fixedNavigation: true, maxWidth: 900, maxHeight: 900 });
    $('.lightbox6').lightBox({ fixedNavigation: true, maxWidth: 900, maxHeight: 900 });
    $('.lightbox7').lightBox({ fixedNavigation: true, maxWidth: 900, maxHeight: 900 });


    //CW event to hanle the on click the top gallery links
    $(".jumptolink").on('click', function (event) {

        

        //CW: find the gallery name by getting the value from the hidden input
        var galleryidandname = $(this).parent().parent().attr('id');

        var galleryname = galleryidandname.substring(1, galleryidandname.length);

        //CW: get the galleries position from the top including scroll
        var posfromTop = $("div[id='" + galleryname + "']").offset().top;

        //CW: on the click on the gallery thumbnail at the top we want to animate the window to the the pos of this gallery
        $("html, body").stop(true, false).animate({ scrollTop: posfromTop }, 1000);

        //highlightJumpToItem(galleryidandname);

        return false;
    });

    //CW event to hanle the on click the top gallery links
    $(".gallerylink").on('click', function (event) {

        //CW: find the gallery name by getting the value from the hidden input
        var galleryname = $(this).children().first().val();

        //CW: get the galleries position from the top including scroll
        var posfromTop = $("div[id='" + galleryname + "']").offset().top;

        //CW: on the click on the gallery thumbnail at the top we want to animate the window to the the pos of this gallery
        $("html, body").animate({ scrollTop: posfromTop }, 1000);

        return false;
    });

    //get the galleries on the page and there position from the top
    var galleries = new Array();
    $('.main').each(function () {
        var gallery = new Object();
        gallery.name = this.id;
        gallery.topposition = $(this).position().top - $("#navigation").height();
        galleries[galleries.length] = gallery;

    });


    $(window).scroll(function () {

        // this is the position from the start of the div that holds the content site - so we know when to fade out the jump to nav 
        var startpos = $('.content').offset().top + $('.content').height();

        // get the position from the top including the scroll
        var scrollYpos = $(document).scrollTop();

        // if we are higher than the start of the content seciton of the site we want to fade out the jump to nav
        if (scrollYpos > startpos) {
            nav.fadeIn('slow');
        } else {
            nav.fadeOut('slow');
        }


        // loop through each gallery and find out if the scroll position is within a gallery, if so highlight the navigation item
        for (i = 0; i < galleries.length; i++) {

            var thisGallery = galleries[i];
            var nextGallery = galleries[i + 1];
            var galleryId = (i + 1) + thisGallery.name;

            // if the scroll pos is greater than the top of the gallery and less than the bottom of the gallery then highlight to jump to nav item

            //If this is not the last gallery
            if ((i + 1) < galleries.length) {

                // if the current scroll position is within this gallery and the next - hightlight this gallery in the jump to nav
                if (scrollYpos >= thisGallery.topposition && scrollYpos < nextGallery.topposition) {
                    highlightJumpToItem(galleryId);
                }

            } else {
                // if the current scroll position is past the last gallery - hightlight the last gallery in the jump to nav
                if (scrollYpos >= thisGallery.topposition) {
                    highlightJumpToItem(galleryId);
                }
            }

        }

        //        //find all the list items and remove the hightlight class
        //        nav.children().children().removeClass('highlight');
        //        var galleryid = nav.closest('.gallerycontent').id();
        //        //        nav.find('#' + galleryid).addClass('highlight').fadeIn('fast');



        //        if ($(this).scrollTop() > pos.top + menu.height() && !menu.hasClass('fixed')) {
        //            menu.fadeOut('fast', function () {
        //                $(this).removeClass('topNav').addClass('fixed').fadeIn('fast');
        //            });
        //        }
        //        else if ($(this).scrollTop() <= pos.top && menu.hasClass('fixed')) {
        //            menu.fadeOut('fast', function () {
        //                $(this).removeClass('fixed').addClass('topNav').fadeIn('fast');
        //            });
        //        }
    });

    $('.window').hover(function () {

        $(this).find('.overlay').stop().animate({
            top: '0'
        }, 300);

    }, function () {
        $(this).find('.overlay').stop().animate({
            top: '145px'
        }, 300);
    });


});

function highlightJumpToItem(item) {

    // unhighlight all of the navigation items
    $('#navigation').children().children().removeClass('underline', 200);
    $("#" + item).addClass('underline'), 200;
}

