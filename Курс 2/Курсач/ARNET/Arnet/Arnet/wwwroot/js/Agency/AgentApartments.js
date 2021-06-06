$(document).ready(function () {

    var checkboxes = $(".select-apartment");
    var submitMove = $("#submit-move");

    CheckSubmitMove();

    checkboxes.click(function () {
        CheckSubmitMove();
    });

    function CheckSubmitMove() {
        if (checkboxes.filter(":checked").length > 0)
            submitMove.prop('disabled', false);
        else
            submitMove.prop('disabled', true);
    }
});