function loginUser(){
    $.ajax(
        {
            type: 'POST',
            url: 'https://84.201.131.165/api/auth/login',
            contentType: "application/json; charset=utf-8",
            data: `{ "Email": "${document.forms.loginForm.email.value}", "Password": "${document.forms.loginForm.password.value}"}`,
            success: function (data, textStatus) {
                sessionStorage.clear();
                sessionStorage.setItem("AccessToken", data.data.accessToken);
                sessionStorage.setItem("RefreshToken", data.data.refreshToken);
                getProducts();
                editButtons();
            }
        });
    }
function registerUser(){
    $.ajax(
        {
            type: 'POST',
            url: 'https://84.201.131.165/api/auth/register',
            contentType: "application/json; charset=utf-8",
            data: `{ "Email": "${document.forms.signUpForm.email.value}", "Password": "${document.forms.signUpForm.password.value}",
             "Name": "${document.forms.signUpForm.name.value}" }`,
            success: function (data, textStatus) {
                sessionStorage.clear();
                sessionStorage.setItem("AccessToken", data.data.accessToken);
                sessionStorage.setItem("RefreshToken", data.data.refreshToken);
                console.log(data.accessToken);
                getProducts();
                editButtons();
            }
        });
}