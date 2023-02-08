const url = "http://localhost:58667/api/MusicProducts"

function loadingRecords() {
    $("table").find("tr:gt(0)").remove();
    $.get(url, (data) => {
        for (const value of data) {
            const row = `<tr><td>${value.ProductId}</td><td>${value.ProductName}</td><td><a href="#" onclick="onView(${value.ProductId})">ViewDeatails</a><br>
            <a href="#" onclick="onDelete(${value.ProductId})">Delete</a></tr>`;
            $("table").append(row);
        }
    })
}
function onDelete(id) {
    var tempurl = url + "/" + id;
    alert(id)
    $.ajax({
        'url': tempurl,
        'success': function () { loadingRecords(); },
        'method': 'DELETE'
    })

}
function onView(id) {
    //alert(id);
    var tempurl = url + "/" + id;
    $.get(tempurl, (data) => {
        $("#Iamge").attr("src", "http://localhost:58667/Images/" + data.ProductIamge);
        $("#txtId").val(data.ProductId);
        $("#txtName").val(data.ProductName);
        $("#txtPrice").val(data.ProductPrice);
        $("#txtQuantity").val(data.Quantity);
    })
}
function UpdateProduct() {
    let obj = {};
    obj.ProductId = $("#txtId").val()
    obj.ProductName = $("#txtName").val()
    obj.ProductPrice = $("#txtPrice").val()
    obj.Quantity = $("#txtQuantity").val()
    obj.ProductIamge = $("#Iamge").val()
    let src = $("#Iamge").attr("src")
    let modified = src.replace("http://localhost:58667/Images/", "");
    alert(modified);
    
    obj.ProductIamge = modified;
    $.ajax({
        'url': url,
        'data': obj,
        'success': function () { loadingRecords(); },
        'method':'PUT'
    })
}
function AddProduct() {
    let obj = {};
    ////obj.ProductId = $("#txtId").val()
    obj.ProductName = $("#txtName").val()
    obj.ProductPrice = $("#txtPrice").val()
    obj.Quantity = $("#txtQuantity").val()
    obj.ProductIamge = "Images\\gitar.jfif";

    //let src = $("#Iamge").attr("src")
    //let modified = src.replace("http://localhost:58667/", "");
    //alert(modified);
    
    //obj.ProductIamge = modified;
    $.ajax({
        url: url,
        data: obj,
        success: function () { loadingRecords(); },
        method:'POST'
    })
}
function init() {
    $("a:first").click(loadingRecords);
}