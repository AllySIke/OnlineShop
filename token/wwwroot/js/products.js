function getAllProductss()
{   
    $.ajax(
    {
        type: 'GET',
        url: 'http://localhost:5000/api/product',
        dataType : "json", 
        success: function (data, textStatus)
        { 
            let products = "";
            data.forEach(function(item)
            {
                products = products + product(item.picUrl, item.cost, item.name);
            });
            $('#content').html(products);
        } 
    });
};


function getProductsByCategory(id){
    $.ajax(
        {
            type: 'GET',
            url: `http://localhost:5000/api/product/findbycat/${id}`,
            dataType : "json", 
            success: function (data, textStatus)
            { 
                let products = ``;
            data.forEach(function(item)
            {
                products = products + product(item.picUrl, item.cost, item.name);
            });
            $('#content').html(products);
            } 
        });
};

function createProduct(){
    let e = document.getElementById("categoryselect");
    let result = e.options[e.selectedIndex].id;
    // var formData = new FormData();  
    // formData.append("pic", document.forms.createProductForm.pic.files[0])
    let url = `http://localhost:5000/api/product`;
    $.ajax(
    {
        type: 'POST',
        url: url,
        dataType : "json",
        contentType: 'multipart/form-data',
        data: `{"product": "{"Name": "${document.forms.createProductForm.title.value}",
        "Description": "${document.forms.createProductForm.description.value}",
        "Cost": ${document.forms.createProductForm.cost.value}, 
        "CategoryId": "${result}}"}`,
        beforeSend: function(request) { 
           request.setRequestHeader("Authorization", `Bearer ${sessionStorage.getItem("AccessToken")}`);
           request.setRequestHeader("grant-type", "refresh_token");
           request.setRequestHeader("refresh_token", `${sessionStorage.getItem("RefreshToken")}`)
        }, 
        success: function (data, textStatus)
        { 
            getAllCategories();
            getAllProductss();
        }      
    });
}

function editProduct(){
    let e = document.getElementById("categoryselect");
    let result = e.options[e.selectedIndex].id;
    var formData = new FormData();  
    formData.append("pic", document.forms.createProductForm.pic.files[0])

    let url = `http://localhost:5000/api/product/${document.forms.createProductForm.title.value}/${document.forms.createProductForm.description.value}/${document.forms.createProductForm.cost.value}/${result}`;
    $.ajax(
    {
        type: 'PUT',
        url: url,
        dataType : "json",
        contentType: 'multipart/form-data',
        data: `${formData}`,
        beforeSend: function(request) {
           request.setRequestHeader("Authorization", `Bearer ${sessionStorage.getItem("AccessToken")}`);
           request.setRequestHeader("grant-type", "refresh_token");
           request.setRequestHeader("refresh_token", `${sessionStorage.getItem("RefreshToken")}`)
        }, 
        success: function (data, textStatus)
        { 
            getAllCategories();
            getAllProductss();
        }      
    });
}