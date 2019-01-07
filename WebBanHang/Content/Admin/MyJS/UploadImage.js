$(document).ready(function () {
    //$("#password").change(function () { confirmPass(); })
    //$("#confirm_password").keyup(function () { confirmPass(); })
});
function PreviewImage(event) {
    var reader = new FileReader();
    reader.onload = function () {
        var output = document.getElementById("IIdAvatar");
        output.src = reader.result;
    }
    reader.readAsDataURL(event.target.files[0]);
}
//function confirmPass()
//{
//    var password = document.getElementById("password"), confirm_password = document.getElementById("confirm_password");
//    if(password.value!=confirm_password.value)
//    {
//        confirm_password.setCustomValidity("Mật khẩu không trùng khớp!");
//    }
//    else
//    {
//        confirm_password.setCustomValidity('');
//    }
//}

//var password = $("#password")
//  , confirm_password = $("#confirm_password");

//function validatePassword(){
//    if(password.value != confirm_password.value) {
//        confirm_password.setCustomValidity("Mật khẩu không trùng khớp!");
//    } else {
//        confirm_password.setCustomValidity('');
//    }
//}

//password.onchange = validatePassword();
//confirm_password.onkeyup = validatePassword();

//function validatePassword(event) {
//    var password = $("#password")
//  , confirm_password = $("#confirm_password");
//    if (password.value != confirm_password.value) {
//        event.target.setCustomValidity("Mật khẩu không trùng khớp!");
//    } else {
//        event.target.setCustomValidity("");
//    }
//}
//$("#password").change(function (event) { alert("A"); validatePassword(event); alert("AA"); })
//    $("#confirm_password").keyup(function (event) { validatePassword(event); })