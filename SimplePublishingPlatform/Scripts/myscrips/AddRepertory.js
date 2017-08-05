function addRepertory() {
    var repertoryName = $.trim($('#repertoryName').val());
    if (repertoryName === "") {
        alert("请输入版本名称");
        return false;
    }
    $.ajax({
        type:"post",
        url: "/Publish/Add",
        data: { "repertoryName": repertoryName },
        beforeSend:function() {
            $('#addRepertoryProgress').show();
        },
        success:function(result) {
            if (result.success === true) {
                window.location.href = "/Publish/Index?repertoryName=" + repertoryName;
            } else {
                alert("创建仓库时发生错误\r" + result.reason);
            }
        },
        error: function (xmlHttpRequest, textStatus, errorThrown) {
            alert("传输错误\r"+textStatus);
        },
        complete:function() {
            $('#addRepertoryProgress').hide();
        }
    });

}