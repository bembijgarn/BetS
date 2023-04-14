function Slotmachine() {
    $.ajax({
        url: "/Gamble/Slot",
        type: "Get",
        success: function (result) {
            Slotrefresh();
            $("#firsttr").append(`<td><img src='${result.symbol1}' width='300' height='300' /></td>`);
            $("#firsttr").append(`<td><img src='${result.symbol2}' width='300' height='300' /></td>`);
            $("#firsttr").append(`<td><img src='${result.symbol3}' width='300' height='300' /></td>`);
        }
    })
}
function Slotrefresh() {
    $("#firsttr").remove();
    $("#bodd").append(`<tr id="firsttr"></tr>`);
}