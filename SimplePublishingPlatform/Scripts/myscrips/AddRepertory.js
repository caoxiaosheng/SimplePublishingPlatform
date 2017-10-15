function addRepertory(btn) {
    var repertoryName = $.trim($('#repertoryName').val());
    if (repertoryName === "") {
        $('#addrepertoryreplay').text("请输入版本名称");
        return false;
    }
    $.ajax({
        type:"post",
        url: "/Publish/Add",
        data: { "repertoryName": repertoryName },
        beforeSend: function () {
            $(btn).attr('disabled', "true");
            $('#addRepertoryProgress').show();
        },
        success:function(result) {
            if (result.success === true) {
                $('#addrepertoryreplay').text("");
                window.location.href = "/Publish/Index?repertoryName=" + repertoryName;
            } else {
                $('#addrepertoryreplay').text("创建仓库时发生错误," + result.reason);
            }
        },
        error: function (xmlHttpRequest, textStatus, errorThrown) {
            $('#addrepertoryreplay').text("传输错误," + textStatus);
            $(btn).removeAttr('disabled');
        },
        complete:function() {
            $('#addRepertoryProgress').hide();
        }
    });
    return true;
}

function publishversion(btn) {
    var repertoryName = $.trim($('#usedrepertoryname').val());
    var description = $.trim($('#updateDescription').val());
    var detail = CKEDITOR.instances.publishckedit.getData();
    if (repertoryName == "") {
        alert("版本名称不能为空");
        return false;
    }
    if (description == "") {
        alert("更新内容描述不能为空");
        return false;
    }
    if (detail == "") {
        alert("更新内容描述不能为空");
        return false;
    }
    $.ajax({
        type: "post",
        url: "/Publish/PublishVersion",
        data: {
            "repertoryName": repertoryName ,
            "description": description,
            "detail": detail
        },
        beforeSend: function () {
            $(btn).attr('disabled', "true");
        },
        success: function (result) {
            if (result.success === true) {
                window.location.href = "/Home";
            } else {
                alert("创建仓库时发生错误," + result.reason);
            }
        },
        error: function (xmlHttpRequest, textStatus, errorThrown) {
            alert("传输错误," + textStatus);
            $(btn).removeAttr('disabled');
        }
    });
    return true;
}