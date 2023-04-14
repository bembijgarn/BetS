function keyfunction()
{
    $("#search").on("keyup", function () {
        var search = $(this).val().toLowerCase();
        $("#table1 tr").each(function () {
            var data = $(this).text().toLowerCase();
            if (data.indexOf(search) === -1) {
                $(this).hide();
            } else {
                $(this).show();
            }
        });
    });
};


