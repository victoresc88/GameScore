// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function SearchGame() {
    $.ajax({
        type: 'GET',
        url: '/Game/GetGameFromMemoryCache',
        data: "name=" + $("#searchBar").val(),
        success: function (data) {
            $("#esmegmer").html(data);
        }
    });
}