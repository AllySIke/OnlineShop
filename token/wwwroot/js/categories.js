function createCategory(){
    $.ajax(
        {
            type: 'POST',
            url: 'https://84.201.131.165/api/category',
            dataType : "json",
            contentType: "application/json; charset=utf-8",
            data: `{ "title": "${document.forms.createCategoryForm.title.value}" }`,
            beforeSend: function(request) { 
               request.setRequestHeader("Authorization", `Bearer ${sessionStorage.getItem("AccessToken")}`);
               request.setRequestHeader("grant-type", "refresh_token");
               request.setRequestHeader("refresh_token", `${sessionStorage.getItem("RefreshToken")}`)
            }, 
            success: function (data, textStatus)
            { 
                getProducts()
            }      
        });
}

function editCategory(){
    $.ajax(
        {
            type: 'PUT',
            url: 'https://84.201.131.165/api/category',
            dataType : "json",
            contentType: "application/json; charset=utf-8",
            data: `{ "Title": "${document.forms.editCategoryForm.title.value}",
        "Id": "${document.forms.editCategoryForm.title.id}" }`,
        beforeSend: function(request) {
           request.setRequestHeader("Authorization", `Bearer ${sessionStorage.getItem("AccessToken")}`);
           request.setRequestHeader("grant-type", "refresh_token");
           request.setRequestHeader("refresh_token", `${sessionStorage.getItem("RefreshToken")}`)
        }, 
            success: function (data, textStatus)
            { 
                getProducts()
            }      
        });
}

function deleteCategory(id){
    $.ajax(
        {
            type: 'DELETE',
            dataType : "json",
            contentType: "application/json; charset=utf-8",
            url: `https://84.201.131.165/api/category/${id}`,
            beforeSend: function(request) { // в хедерах передаем токен
               request.setRequestHeader("Authorization", `Bearer ${sessionStorage.getItem("AccessToken")}`);
               request.setRequestHeader("grant-type", "refresh_token");
               request.setRequestHeader("refresh_token", `${sessionStorage.getItem("RefreshToken")}`)
            }, 
            success: function (data, textStatus)
            { 
                getProducts()
            }      
        });
}


function getAllCategories()
{   
    $.ajax(
    {
        type: 'GET',
        url: 'https://84.201.131.165/api/category',
        dataType : "json", 
        success: function (data, textStatus)
        { 
            let products = `<div class="panel panel-default">
            <div class="panel-heading">
                <h4 class="panel-title"><button class="all btn btn-default allCtg">All</button></h4>
            </div>
        </div>`;
            data.forEach(function(item)
            {
                products = products + category(item.title, item.id);
            });
            $('#accordian').html(products);
        } 
    });
};

function getAllCategoriesAdmin()
{   
    $.ajax(
    {
        type: 'GET',
        url: 'https://84.201.131.165/api/category',
        dataType : "json", 
        success: function (data, textStatus)
        { 
            let products = `<div class="panel panel-default">
            <div class="panel-heading">
                <h4 class="panel-title"><button class="all btn btn-default allCtg">All</button></h4>
            </div>
        </div>`;
            data.forEach(function(item)
            {
                products = products + getButtons(item.title, item.id);
            });
            products = products + `<div class="panel panel-default">
            <div class="panel-heading">
                <h4 class="panel-title"><button class="all btn btn-default newCtg">Новая категория</button></h4>
            </div>
        </div>
        <div class="panel panel-default">
            <div class="panel-heading">
                <h4 class="panel-title"><button class="all btn btn-default newProd">Новый продукт</button></h4>
            </div>
        </div>`;
            $('#accordian').html(products);
        } 
    });
};

function getCategoryList(){
    $.ajax(
        {
            type: 'GET',
            url: 'https://84.201.131.165/api/category',
            dataType : "json", 
            success: function (data, textStatus)
            { 
                let products = ``;                
                data.forEach(function(item)
                {
                    products = products + `<option id='${item.id}'>${item.title}</option>`                
                });
                $('#content').html(createProductForm(products));
            } 
        });
}