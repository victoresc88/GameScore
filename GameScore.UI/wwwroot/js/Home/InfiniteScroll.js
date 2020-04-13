var page = 0,
    inCallback = false,
    hasReachedEndOfInfiniteScroll = false;

var ulScrollHandler = function () {
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
                    $("div.infinite-scroll").append(data);
                }
                else {
                    page = -1;
                    showNoMoreRecords();
                }

                inCallback = false;
            }
        });
    }
}

function showNoMoreRecords() {
    hasReachedEndOfInfiniteScroll = true;
}