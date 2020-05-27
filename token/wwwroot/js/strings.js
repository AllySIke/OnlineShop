function login(){
    return `<div class="row">
    <div class="col-sm-4 col-sm-offset-1">
        <div class="login-form"><!--login form-->
            <h2>Login to your account</h2>
            <form name="loginForm">
                <input required="required" type="email" id="email" name="email" placeholder="Email" />
                <input required="required" type="password" name="password" placeholder="Password" />
                <button id="login" type="button" class="btn btn-default">Login</button>
            </form>
        </div><!--/login form-->
    </div>
    <div class="col-sm-1">
        <h2 class="or">OR</h2>
    </div>
    <div class="col-sm-4">
        <div class="signup-form"><!--sign up form-->
            <h2>New User Signup!</h2>
            <form name="signUpForm">
                <input required="required" type="text" name="name" placeholder="Name"/>
                <input required="required" type="email" name="email" placeholder="Email Address"/>
                <input required="required" type="password" name="password" placeholder="Password"/>
                <button type="button" id="signin" class="btn-default">Signup</button>
            </form>
        </div><!--/sign up form-->
    </div>
</div>`
}

function storeLayout(){
    return `<div class="row">
    <div class="col-sm-3">
        <div class="left-sidebar" id="cat">
            <h2>Category</h2>
            <div class="panel-group category-products" id="accordian"><!--category-productsr-->
                
            </div><!--/category-products-->
        
            <div class="shipping text-center"><!--shipping-->
                <img width="inherit" src="../images/shipping.jpg" alt="" />
            </div><!--/shipping-->
        
        </div>
    </div>
    
    <div class="col-sm-9 padding-right">
        <div class="features_items"><!--features_items-->
            <h2 class="title text-center">Products</h2>
            <div id="content">
            <div>
            
        </div><!--features_items-->
    </div>
</div>`
}

function headerEditButtons(){
    return `<ul class="nav navbar-nav">
    <li onclick="getChat()"><a><i class="fa fa-pencil"></i> Support</a></li>
    <li onclick="logOut()"><a><i class="fa fa-lock"></i> Logout</a></li>
</ul>`;
}

function headerButtons(){
    return `<ul class="nav navbar-nav">
    <li onclick="getChat()"><a><i class="fa fa-pencil"></i> Support</a></li>
    <li onclick="getLogin()"><a><i class="fa fa-lock"></i> Login</a></li>
</ul>`;
}

function category(name, id){
    return`<div class="panel panel-default">
    <div id="cat" class="panel-heading">
        <h4 class="panel-title">
        <button type="button" id="${id}" class="btn btn-default ctg" name="${name}">${name}</button>
    </div>
</div>`;
}

function getButtons(name, id){
    return`<div class="panel panel-default">
    <div id="cat" class="panel-heading">
        <h4 class="panel-title">
        <button type="button" id="${id}" class="btn btn-default ctg" name="${name}">${name}</button>
        <button type="button" id="${id}" class="btn btn-default ctgedit right">&#9998</button>
        <button type="button" id="${id}" class="btn btn-default ctgdelete right">&#215</button></h4>        
    </div>
</div>`;
}

function createProductForm(list){
    return `<div class="col-12 text-center">
    <h5>Создать новый продукт</h5>
</div>
<div class="col-12">
<form name="createProductForm">
    <div class="form-group">
        <label>Название</label>
        <input required="required" class="form-control" name="title" />
        <label>Описание</label>
        <input required="required" class="form-control" name="description" />
        <label>Цена</label>
        <input required= type="number" class="form-control" name="cost" />
        <label>Категория</label>
        <select class="form-control" id="categoryselect">` + list + `</select>
        <!--label>Фото</label-->
        <!--input required="required" type="file" accept=".jpg, .jpeg, .png" class="form-control" name="pic" /-->
    </div>
</form>
<button type="button" class="btn btn-outline-success btn-block" id="createProduct">Добавить</button>
</div>`;
}

function createCategoryForm(){
    return `<div class="col-12 text-center">
    <h5>Создать новую категорию</h5>
</div>
<div class="col-12">
<form name="createCategoryForm">
    <div class="form-group">
        <label>Название</label>
        <input required="required" class="form-control" name="title" />
    </div>
</form>
<button type="button" class="btn btn-outline-success btn-block" id="createCategory">Добавить</button>
</div>`;
}
function editCategoryForm(title, id){
    return `<div class="col-12 text-center">
    <h5>Редактировать категорию</h5>
</div>
<div class="col-12">
<form name="editCategoryForm">
    <div class="form-group">
        <label>Название</label>
        <input required="required" class="form-control" name="title" id=${id} value="${title}"/>
    </div>
</form>
<button type="button" class="btn btn-outline-success btn-block" id="editCategory">Сохранить</button>
</div>`;
}

function product(src, price, name){
    return `<div class="col-sm-4">
    <div class="product-image-wrapper">
        <div class="single-products">
            <div class="productinfo text-center">
                <!--img src="${src}" alt="" /-->
                <h2>${price} ₽</h2>
                <p>${name}</p>
                <a href="#" class="btn btn-default add-to-cart"><i class="fa fa-shopping-cart"></i>Add to cart</a>
            </div>
            <div class="product-overlay">
                <div class="overlay-content">
                    <h2>${price} ₽</h2>
                    <p>${name}</p>
                    <a href="#" class="btn btn-default add-to-cart"><i class="fa fa-shopping-cart"></i>Edit</a>
                    <a href="#" class="btn btn-default add-to-cart"><i class="fa fa-shopping-cart"></i>Delete</a>
                </div>
            </div>
        </div>
    </div>
</div>`
}