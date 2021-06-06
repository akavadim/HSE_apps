var addAgentBtn = $("#add-agent");
var addAgentModal = $("#add-agent-modal");
var removeAgentBtn = $("[name='remove-agent-btn']");
var removeAgentModal = $("#remove-agent-modal");
var removeAgentModalBtn = $("#remove-agent");
var copyBtn = addAgentModal.find("#copy-btn");
var copyText = addAgentModal.find("#url-text");

$(document).ready(function () {
    removeAgentBtn.click(function (e) {
        e.preventDefault();
        removeAgentModalBtn.attr("href", this.href);
        removeAgentModal.modal();
    });

    addAgentBtn.click(function (e) {
        e.preventDefault();

        copyBtn.text("Копировать");
        copyBtn.removeClass("btn-outline-success").addClass("btn-primary");

        $.get({
            url: addAgentBtn.attr("href"),
            success: function (data) {
                copyText.val(data)
            }
        });

        addAgentModal.modal();
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
});