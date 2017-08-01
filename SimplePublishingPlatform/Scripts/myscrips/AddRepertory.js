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
        success:function() {
            
        },
        error: function (xmlHttpRequest, textStatus, errorThrown) {
            alert("错误\r"+textStatus);
        },
        complete:function() {
            $('#addRepertoryProgress').hide();
        }
    });

}