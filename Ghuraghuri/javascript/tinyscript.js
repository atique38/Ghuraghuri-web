
/*document.getElementById('submitButton').addEventListener('click', function () {
    var plainText = tinyMCE.activeEditor.getContent('myTextarea').replace(/<[^>]*>/g, "");
    //var content = tinymce.activeEditor.getContent('myTextarea');
    document.getElementById('hiddenField').value = plainText;
    //$("#data_container").html(content);
    console.log(plainText);
});*/

document.getElementById('Submit_btn').addEventListener('click', function () {
    //var plainText = tinyMCE.activeEditor.getContent('myTextarea').replace(/<[^>]*>/g, "");
    //var content = tinymce.activeEditor.getContent('tiny');
    //var content = tinymce.get("tiny").getContent();
    var myContent = tinymce.activeEditor.getContent();
    document.getElementById('hiddenField').value = myContent;
    //$("#data_container").html(content);
    console.log(myContent);
});


