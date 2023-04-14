



function Redirect() {
    let x = $("#amount").val();
   
    var Odata = {
        Amount: $("#amount").val(),
    }
    $.ajax({
        url: "/Banking/Deeposit",
        Type: "GET",
        data: Odata,
        contentType: 'application/x-www-form-urlencoded;charset=utf-8',
        dataType: "json",
        success: function (data) {
            var par = `?TransactionId=${data}&Amount=${x}`;
            window.location.replace(`https://localhost:44316/Deposit/Deposit/${par}`);
        },
        error: function () {
            alert("Payment denied");
        }
    })
    
}