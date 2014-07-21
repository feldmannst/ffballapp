$(document).ready(function () {
    $("#rankingupdateform").submit(function (e) {
        e.preventDefault();
        var expert = $("#expertid").val();
        var pos = $("#positionid").val()
        $.ajax({
            url: "/Ranking/DisplayExpertRankings",
            type: "GET",
            data: { expertid: expert, positionid: pos },
            beforeSend: function() {
                $("#rankingtable").addClass("loading-table");
                $("#rankingtable").addClass("loading-gif");
            },
            success: function (data) {
                $("#rankingssection").hide().html(data).fadeIn();
            },
            complete: function () {
                $("#rankingtable").removeClass("loading-table");
                $("#rankingtable").removeClass("loading-gif");
            }
        });
    });
});