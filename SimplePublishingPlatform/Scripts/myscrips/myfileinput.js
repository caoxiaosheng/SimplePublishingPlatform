//初始化fileinput
var FileInput = function () {
    var oFile = new Object();

    //初始化fileinput控件（第一次初始化）
    oFile.Init = function (ctrlName, uploadUrl) {
        var control = $('#' + ctrlName);

        //初始化上传控件的样式
        control.fileinput({
            language: 'zh', //设置语言
            uploadUrl: uploadUrl, //上传的地址
            //allowedFileExtensions: ['jpg', 'gif', 'png'],//接收的文件后缀
            uploadAsync: false, //默认异步上传
            showUpload: false, //是否显示上传按钮
            showRemove: true,
            showCaption: true, //是否显示标题
            showPreview: true, //是否显示预览
            browseClass: "btn btn-primary", //按钮样式     
            dropZoneEnabled: false, //是否显示拖拽区域
            initialCaption: "请上传单个文件",
            autoReplace:true,
            //minImageWidth: 50, //图片的最小宽度
            //minImageHeight: 50,//图片的最小高度
            //maxImageWidth: 1000,//图片的最大宽度
            //maxImageHeight: 1000,//图片的最大高度
            maxFileSize: 0,//单位为kb，如果为0表示不限制文件大小
            minFileCount: 0,
            maxFileCount: 1, //表示允许同时上传的最大文件个数
            enctype: 'multipart/form-data',
            validateInitialCount: false,
            layoutTemplates: {
                actionUpload: "",
                actionDelete:""
            }
            //previewFileIcon: "<i class='glyphicon glyphicon-king'></i>",
            //msgFilesTooMany: "选择上传的文件数量({n}) 超过允许的最大数值{m}！",
        });

        //选择完成后直接上传
        control.on('filebatchselected',
            function (event, files) {
                $(this).fileinput('upload');
            });
        control.on('filebatchuploaderror', function (event, data, msg) {
            alert("上传错误\r" + msg);
            $(this).fileinput('clear');
        });
        ////导入文件上传完成之后的事件
        //control.on("filebatchuploadsuccess", function (event, data, previewId, index) {
            
        //});
    }
    return oFile;
};