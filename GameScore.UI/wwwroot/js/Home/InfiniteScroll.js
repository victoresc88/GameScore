
var page = 0,
    inCallback = false,
    hasReachedEndOfInfiniteScroll = false;

var ulScrollHandler = function () {
    console.log("Document height: " + ($(document).height() - $(window).height()));
    console.log("Scroll top: " + $(window).scrollTop());

    if (hasReachedEndOfInfiniteScroll == false &&
        ($(window).scrollTop() + 2 >= $(document).height() - $(window).height())) {
        loadMoreToInfiniteScrollUl(moreRowsUrl);
    }
}

function loadMoreToInfiniteScrollUl(loadMoreRowsUrl) {
    if (page > -1 && !inCallback) {
        inCallback = true;
        page++;

        $.ajax({
            type: 'GET',
            url: loadMoreRowsUrl,
            data: "pageNum=" + page,
            success: function (data, textstatus) {
                if (data != '') {
                    $("ul.infinite-scroll").append(data);
                }
                else {
                    page = -1;
                }

                inCallback = false;
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
            }
        });
    }
}

function showNoMoreRecords() {
    hasReachedEndOfInfiniteScroll = true;
}