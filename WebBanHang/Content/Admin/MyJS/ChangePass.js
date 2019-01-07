$(document).ready(function () {
    Changepass();
    resetModel();
})

function resetModel() {
    $('#tbnMenuChange').off('click').on('click', function (e){
        e.preventDefault();
        $("#oldPass").val("");
        $("#newPass").val("");
        $("#confirmPass").val("");
}
    
}
function Changepass() {
    $("#submitPass").off('click').on('click', function (e) {
        e.preventDefault();
        var id = $("#oldPass").data('id');
        var oldPass = $("#oldPass").val().toString().trim(" ");
        var newPass = $("#newPass").val().toString().trim(" ");
        var confirmPass = $("#confirmPass").val().toString().trim(" ");
        if (newPass == confirmPass) {
            $.ajax({
                url: "/Admin/User/ChangePassword/",
                data: { id: id, oldPassword: oldPass, newPassword: newPass },
                datatype: "JSON",
                type: "POST",
                success: function (data) {
                    if (data.result == true)
                    {
                        Lobibox.alert('success', {
                            size: 'mini',
                            rounded: true,
                            sound: false,
                            delayIndicator: false,
                            msg: 'Thay đổi mật khẩu thành công!'
                        });
                        $("#closeModel").click();
                     }
                    if (data.result == false)
                    {
                        //alert(data.status.toString()+"111");
                        Lobibox.alert('error', {
                            size: 'mini',
                            rounded: true,
                            sound: false,
                            delayIndicator: false,
                            msg: 'Mật khẩu cũ không đúng!'
                        });
                    }
                },
                error: function () {
                    Lobibox.alert('error', {
                        size: 'mini',
                        rounded: true,
                        sound: false,
                        delayIndicator: false,
                        msg: 'Thay đổi mật khẩu không thành công!'
                    });
                }
            });
        }
        else {
            Lobibox.alert('error', {
                size: 'mini',
                rounded: true,
                sound: false,
                delayIndicator: false,
                msg: 'Mật khẩu không trùng khớp!'
            });
        }
    });
}