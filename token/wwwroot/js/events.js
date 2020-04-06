function getLogin()
{
    $('#container').html(login());
}
function logOut()
{
    sessionStorage.clear();
    getProducts();
}
function getProducts()
{    
    $('#container').html(storeLayout());
    if (sessionStorage.getItem("AccessToken") != null ||
    sessionStorage.getItem("RefreshToken") != null){
        editButtons();
         getAllCategoriesAdmin();
         getAllProductss();
    }
    else{
        buttons();
        getAllProductss();
        getAllCategories();
    }
}

function editButtons(){
    $('#headerbuttons').html(headerEditButtons());
}

function buttons(){
    $('#headerbuttons').html(headerButtons());
}
$('#container').delegate(".ctg", "click", function(e){
    getProductsByCategory(e.target.id);
})

$('#container').delegate(".ctgedit", "click", function(e){
    $('#content').html(editCategoryForm(document.getElementById(`${e.target.id}`).name, e.target.id));
})

$('#container').delegate(".ctgdelete", "click", function(e){
    deleteCategory(e.target.id)
})

$('#container').delegate(".allCtg", "click", function(e){
    getAllProductss();
})

$('#container').delegate(".newCtg", "click", function(e){
    getCategoryList();
})

$('#container').delegate(".newProd", "click", function(e){
    getCategoryList();
})

$('#container').delegate("#createCategory", "click", function(e){
    createCategory();
})

$('#container').delegate("#createProduct", "click", function(e){
    createProduct();
})

$('#container').delegate("#editCategory", "click", function(e){
    editCategory();
})

$('#container').delegate("#login", "click", function(e){
    loginUser()
})

$('#container').delegate("#signin", "click", function(e){
    registerUser();
})