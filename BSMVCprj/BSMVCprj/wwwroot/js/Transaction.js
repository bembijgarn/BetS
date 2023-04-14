function getdata() {
    let dataa = $("#formid").serialize();
    $.ajax({
        url: "/Transaction/gettransactions",
        type: "Post",
        data: dataa,
        dataType: "json",
        success: function (result) {
            Removebody();
            Showbody();
             var object = "";
             $.each(result, function (index, item) {
                 object += "<tr>"
                 object += "<td>" + (index + 1) + "</td>"
                 object += "<td>" + item.type + "</td>"
                 object += "<td>" + item.amount + "</td>"
                 object += "<td>" + item.currentBalance + "</td>"
                 object += "<td>" + item.datetime + "</td>"
                 object += "</tr>";
             })
            $("#bodd").html(object);
            $("#table1").dataTable();
            
        },
        error: function () {
            alert("Data denied");
        }

    });
    return false;
};



function clearheader() {
    $("#head").remove();;
}
function Removebody() {
    $("#bodd").remove();
}
function Showbody() {
    $("#table1").append('<tbody id="bodd"</tbody>');
};


