$(document).ready(function () {
    disableProduct();
    unDisableProduct();
    shiftDeleteProduct();
})
function disableProduct() {
    $(".ICDeleteProduct").off('click').on('click', function (e) {
        var conf = confirm("Bạn có chắc chắn muốn xóa?");
        e.preventDefault();
        var obj = $(this);
        var id = obj.data('id');
        $.ajax(
            {
                url: '/Admin/Product/Disable/',
                data: { id: id, conf:conf },
                type: "POST",
                dataType: 'JSON',
                success: function (data) {
                    if(conf==true)
                    {
                        alert(data.ok);
                        $('#row_' + id + '').remove();
                    }                   
                },                
                error: function () {
                    alert("Xóa không thành công!");
                }
            });
    });
}
function unDisableProduct()
{
    $(".ICUnDeleteProduct").off('click').on('click', function (e) {
        var conf = confirm("Bạn có chắc chắn muốn phục hồi sản phẩm?");
        e.preventDefault();
        var obj = $(this);
        var id = obj.data('id');
        $.ajax(
            {
                url: '/Admin/Product/UnDisableProduct/',
                data: { id: id, conf: conf },
                type: "POST",
                dataType: 'JSON',
                success: function (data) {
                    if (conf == true) {
                        alert(data.ok);
                        $('#row_' + id + '').remove();
                    }
                },
                error: function () {
                    alert("Khôi phục không thành công!");
                }
            });
    });
}
function shiftDeleteProduct() {
    $(".ICShiftDeleteProduct").off('click').on('click', function (e) {
        var conf = confirm("Sản phẩm sẽ bị xóa vĩnh viễn?");
        e.preventDefault();
        var obj = $(this);
        var id = obj.data('id');
        if (conf == true)
        {
            $.ajax(
            {
                url: '/Admin/Product/DeleteProduct/',
                data: { id: id },
                type: "POST",
                dataType: 'JSON',
                success: function (data) {                   
                        alert(data.ok);
                        $('#row_' + id + '').remove();
                },
                error: function () {
                    alert("Xóa không thành công!");
                }
            });
        }
        
    });
}





