$(document).ready(function () {
    ShowUserData();
});


function ShowUserData() {
    $.ajax({
        url: "/Userdetails/MyDetails/?Id",
        type: "GET",
        dataType: "json",
        contentType: "application/json;charset=utf-8;",
        success: function (result) {
            var object = "";
            $.each(result, function (index, item) {
                object += "<tr>";
                object += "<td>" + item.name + "</td>"
                object += "<td>" + item.lastname + "</td>"
                object += "<td>" + item.email + "</td>"
                object += "<td>" + item.identityId + "</td>"
                object += "<td>" + item.username + "</td>"
                object += "<td>" + item.balance + "</td>"
                object += "<td>" + item.bankCard + "</td>"
                object += '<td><a href="#" class="btn btn-primary" onclick="Edit()">Edit</a></td>';
                object += "</tr>";
            });
            $("#table_data").html(object);
        },
        error: function () {
            alert("Data denied");
        }
    });
};

function Edit() {
    $.ajax({
        url: "/Userdetails/MyDetails/?Id",
        type: "Get",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (resp) {
            $("#Usermodal").modal("show");
            $("#Name").val(resp.name);
            $("#Lastname").val(resp.lastName);
            $("#Email").val(resp.email);
            $("#Username").val(resp.username);
            $("#Bankcard").val(resp.bankCard);
            $("#btnupdate").show();
        },
        error: function () {
            alert("update denied");
        }
    });
};

function UpdateUser() {
    var Odata = {
        Name: $("#Name").val(),
        Lastname: $("#Lastname").val(),
        Email: $("#Email").val(),
        Username: $("#Username").val(),
        Bankcard: $("#Bankcard").val()
    }
    $.ajax({
        url: "/Userdetails/Edituser/?Id",
        type: "Post",
        data: Odata,
        contentType: 'application/x-www-form-urlencoded;charset=utf-8',
        dataType: "json",
        success: function () {
            alert("Details Updated");
            Cleartextbox();
            ShowUserData();
            Hidepopup();
        },
        error: function () {
            alert("Invalid Update");
        }

    })
};

function Hidepopup() {
    $("#Usermodal").modal("hide");
}

function Cleartextbox() {
    $("#Name").val(""),
        $("#Lastname").val(""),
        $("#Email").val(""),
        $("#Username").val(""),
        $("#Bankcard").val("")
}

