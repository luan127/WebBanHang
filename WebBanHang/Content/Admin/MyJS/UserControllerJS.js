$(document).ready(function () {
    DeleteUser();
    BlockUser();
})
function DeleteUser() {

    $(".DeleteIcon").off('click').on("click", function (e) {
        e.preventDefault();
        var conf=confirm("Bạn muốn xóa người dùng này!");
        var obj = $(this);
        var id = obj.data("id");
        $.ajax(
            {
                url: "/Admin/User/Delete/",
                data: { id: id, conf: conf },
                dataType: 'JSON',
                type: "POST",
                success: function (data) {
                if(conf==true)
                    {
                        alert(data.message);
                        if (data.status === 1) { $("#container_" + id + '').remove() };
                    }      
                },
                
                error: function () { alert("Xóa không thành công!"); }

            });
    })
}

function testAjax() {
    $("#test").off('click').on('click', function () {
        var mess = $(this).data("mess");
        $.ajax({
            url: "/Admin/Product/Ajax",
            data: { message: mess },
            type: "POST",
            dataType: 'JSON',
            beforeSend: function () {
                confirm("Ahiiii");
            },
            success: function (data) { alert(data.luan); }
        });
    })
};
function BlockUser() {

    $(".BlockIcon").off('click').on("click", function (e) {
        e.preventDefault();
        var obj = $(this);
        var id = obj.data("id");
        $.ajax(
            {
                url: "/Admin/User/Block/",
                data: { id: id },
                dataType: 'JSON',
                type: "POST",
                success: function (data) {
                    alert(data.message);
                    if (data.status == 1)
                    {
                        obj.attr({ src: "/Data/Admin/Image/Icon/LockImage.PNG", tite: "Khóa!" });                       
                    }
                    if (data.status == 0)
                    {
                        obj.attr({ src: "/Data/Admin/Image/Icon/UnLockImage.PNG", tite: "Cho phép!" });                       
                    }
                },
                beforeSend: function () {
                    confirm("Bạn muốn thay đổi trạng thái?");
                },
                error: function () { alert("Sai rồi!"); }

            });
    })
}
