function getLogin()
{
    $('#container').html(login());
}
function getChat(){
    console.log("f")
    $('#contatiner').html(`<div class="messaging">
          <div class="inbox_msg">
            <div class="mesgs">
              <div class="msg_history">
]
                
                <div class="outgoing_msg">
                  <div class="sent_msg">
                    <p>Apollo University, Delhi, India Test</p>
                    <span class="time_date"> 11:01 AM    |    Today</span> </div>
                </div>
                <div class="incoming_msg">
                  <div class="received_msg">
                    <div class="received_withd_msg">
                      <p>We work directly with our designers and suppliers,
                        and sell direct to you, which means quality, exclusive
                        products, at a price anyone can afford.</p>
                      <span class="time_date"> 11:01 AM    |    Today</span></div>
                  </div>
                </div>
              </div>
              <div class="type_msg">
                <div class="input_msg_write">
                  <input type="text" class="write_msg" placeholder="Type a message" />
                  <button class="msg_send_btn" type="button"><i class="fa fa-paper-plane-o" aria-hidden="true"></i></button>
                </div>
              </div>
            </div>
          </div>
          
          `);
}
function logOut()
{
    sessionStorage.clear();
    getProducts();
}
function getProducts()
{    
    $('#container').html(storeLayout());
    console.log(sessionStorage.getItem("AccessToken"))
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
    $('#content').html(createCategoryForm());
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