var addModeratorBtn = $("#add-moderator");
var addModeratorModal = $("#add-moderator-modal");
var copyBtn = addModeratorModal.find("#copy-btn");
var copyText = addModeratorModal.find("#url-text");

addModeratorBtn.click(function (e) {
    e.preventDefault();

    copyBtn.text("Копировать");
    copyBtn.removeClass("btn-outline-success").addClass("btn-primary");

    $.get({
        url: addModeratorBtn.attr("href"),
        success: function (data) {
            copyText.val(data)
        }
    });

    addModeratorModal.modal();
});

copyBtn.click(function () {
    copyText.focus();
    copyText.select();

    try {
        var successful = document.execCommand('copy');
        if (successful) {
            copyBtn.text("Скопировано");
            copyBtn.removeClass("btn-primary").addClass("btn-outline-success");
        }
    }
    catch (err) {
        console.log('Проблема при копировании текста' + err);
    }
});