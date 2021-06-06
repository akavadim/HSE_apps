$(document).ready(function () {
    var links = $(".async-link");
    links.click(function (e) {
        e.preventDefault();
        var link = $(this);
        RemoveById(link.attr("invite-id"), link.attr("href"));
    });
});

var lastChanged;
function CopyById(id)
{
    if (lastChangedBtn != null) {
        $(lastChangedBtn).removeClass("btn-outline-success").addClass("btn-primary");
        lastChangedBtn.innerText = "Копировать";
    }

    var inviteElement = document.getElementById("invite-" + id);
    lastChangedBtn = inviteElement.getElementsByTagName("button")[0];
    var input = inviteElement.getElementsByTagName("input")[0];
    input.focus();
    input.select();
    var successful = document.execCommand('copy');
    if (successful) {
        lastChangedBtn.innerText = "Скопировано";
        $(lastChangedBtn).removeClass("btn-primary").addClass("btn-outline-success");
    }
}

function RemoveById(id, url) {
    var inviteElement = document.getElementById("invite-" + id);
    inviteElement.remove();
    $.get(url);
}