function createCategory(){
    $.ajax(
        {
            type: 'POST',
            url: 'http://localhost:5000/api/category',
            dataType : "json",
            contentType: "application/json; charset=utf-8",
            data: `{ "title": "${document.forms.createCategoryForm.title.value}" }`,
            success: function (data, textStatus)
            { 
                getAllCategories();
                getAllProductss();
            }      
        });
}

function editCategory(){
    $.ajax(
        {
            type: 'PUT',
            url: 'http://localhost:5000/api/category',
            dataType : "json",
            contentType: "application/json; charset=utf-8",
            data: `{ "Title": "${document.forms.editCategoryForm.title.value}",
        "Id": "${document.forms.editCategoryForm.title.id}" }`,
            success: function (data, textStatus)
            { 
                getAllCategories();
                getAllProductss();
            }      
        });
}

function deleteCategory(id){
    $.ajax(
        {
            type: 'DELETE',
            dataType : "json",
            contentType: "application/json; charset=utf-8",
            url: `http://localhost:5000/api/category/${id}`,
            success: function (data, textStatus)
            { 
                getAllCategories();
                getAllProductss();
            }      
        });
}


function getAllCategories()
{   
    $.ajax(
    {
        type: 'GET',
        url: 'http://localhost:5000/api/category',
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
        url: 'http://localhost:5000/api/category',
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
            url: 'http://localhost:5000/api/category',
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