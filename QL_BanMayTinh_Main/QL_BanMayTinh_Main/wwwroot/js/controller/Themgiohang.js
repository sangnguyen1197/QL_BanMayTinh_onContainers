function them(masp) {

    var myData = JSON.stringify(masp);

    $.ajax({
        type: "POST",
        url: "/Cart/AddItem",
        data: myData,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            if (response.status == "1") {
                alert("Đã thêm vào giỏ hàng");
            }
        },

        failure: function (response) {
            alert(response.responseText);
        },

        error: function (response) {
            alert(response.responseText);
        }
    });
}