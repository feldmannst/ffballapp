$(document).ready(function () {
    $(function () {
        $("#playerList, #personalRank").sortable({
            connectWith: ".connectedSortable"
        }).disableSelection();
    });
});

$(document).ready(function () {
    $("#saveRanks").click(function () {
        var rankings = JSON.stringify({ rankings: $("#personalRank").sortable("toArray") });
        $.ajax({
            url: "/Ranking/UpdatePersonalRankings",
            type: "POST",
            cache: false,
            contentType: "application/json",
            data: rankings,
            success: function (result) {
            }
        });
    });
});