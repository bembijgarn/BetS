$(document).ready(function ()
{
    ShowUserData();
})


function ShowUserData() {
    $.ajax({
        url: "/User/UserList",
        type: "GET",
        dataType: "json",
        contentType: "application/json;charset=utf-8;",
        success: function (result) {
            var object = "";
            $.each(result, function (index, item) {
                object += "<tr>";
                object += "<td>" + item.id + "</td>";
                object += "<td>" + item.name + "</td>"
                object += "<td>" + item.lastname + "</td>"
                object += "<td>" + item.email + "</td>"
                object += "<td>" + item.identityId + "</td>"
                object += "<td>" + item.username + "</td>"
                object += "<td>" + item.balance + "</td>"
                object += "<td>" + item.bankCard + "</td>"
                object += '<td><a href="#" class="btn btn-danger" onclick="Delete(' + item.id + ')">Delete</a></td>';
                object += "</tr>";
            });
            $("#table_data").html(object);
        },
        error: function () {
            alert("Data denied");
        }
    })
};

function Delete(id) {
    if (confirm("Are You Sure,You Want  to Delete This User?")) {
        $.ajax({
            url: "/User/Delete?id=" + id,
            success: function () {
                alert("Record Deleted!");
                ShowUserData();
            },
            error: function () {
                alert("Record can't be deleted");
            }



        });
    }
    
}