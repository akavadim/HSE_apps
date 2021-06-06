var newAccountForm = $("#new-account-form");
var accountInfo = $("#account-info");
var companyInfo = $("#company-info");
var companyInfoContent = companyInfo.children();
var accountTypes = $(".account-type");
var newAccountBtn = $("#new-account-btn");

$(document).ready(function () {
    newAccountBtn.click(function () {
        if (!newAccountForm.valid())
            return;
        $.post({
            url: $(this).attr('href'),
            data: newAccountForm.serialize(),
            success: function (data) {
                if (data.invalidEmail) {
                    newAccountForm.validate().showErrors({ "AccountModel.Email": "Аккаунт с таким email уже зарегистрирован" });
                    return;
                }
                PhoneModal(data);
            }
        });
    });

    accountTypes.change(function () {
        var checked = accountTypes.filter(":checked");
        if (checked.val() !== "Agency")
            companyInfo.empty();
        else {
            companyInfo.show();
            companyInfo.append(companyInfoContent)
        };
    }).change();
});

function PhoneModal(data) {
    var phoneModal = $("#phone-modal");
    phoneModal.html(data);
    var phoneForm = phoneModal.find("#phone-form");
    var phoneCodeForm = phoneModal.find("#phone-code-form");
    var sendMessageBtn = phoneModal.find("#send-message-btn");
    var registrationBtn = phoneModal.find("#registration-btn");

    sendMessageBtn.click(function () {
        if (!phoneForm.valid())
            return
        $.post({
            url: sendMessageBtn.attr('href'),
            data: phoneForm.serialize(),
            success: function (data) {
                if (!data.isValid) {
                    phoneForm.validate().showErrors({ "Phone": "Аккаунт с таким номером уже зарегистрирован" })
                    return;
                }
                //TODO: заблокировать окно номера телефона
                phoneCodeForm.show();
                sendMessageBtn.hide();
                registrationBtn.show();
            }
        })
    });

    registrationBtn.click(function () {
        if (!phoneCodeForm.valid())
            return;
        $.post({
            url: registrationBtn.attr('href'),
            data: phoneCodeForm.serialize(),
            success: function (data) {
                if (data.invalidCode) {
                    phoneCodeForm.validate().showErrors({ "Code": "Неправильный код" })
                    return;
                }
                location.href = data;
            }
        });
        //TODO: отправка кода
    });

    phoneForm.removeData("validator")
        .removeData("unobtrusiveValidation");
    $.validator.unobtrusive.parse(phoneForm);

    phoneCodeForm.removeData("validator")
        .removeData("unobtrusiveValidation");
    $.validator.unobtrusive.parse(phoneCodeForm);

    phoneModal.modal();
};