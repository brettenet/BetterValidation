function remoteErrors(jForm, name, errors) {

    function inner_ServerErrors(name, elements) {
        var ToApply = function () {
            for (var i = 0; i < elements.length; i++) {
                var currElement = elements[i];
                var currDom = $('#' + name.split('.')[1]);
                if (currDom.length == 0) continue;
                var currForm = currDom.parents('form').first();
                if (currForm.length == 0) continue;

                if (!currDom.hasClass('input-validation-error'))
                    currDom.addClass('input-validation-error');
                var currDisplay = $(currForm).find("[data-valmsg-for='" + name.split('.')[1] + "']");
                if (currDisplay.length > 0) {
                    currDisplay.removeClass("field-validation-valid").addClass("field-validation-error");
                    if (currDisplay.attr("data-valmsg-replace") !== false) {
                        currDisplay.empty();
                        currDisplay.text(currElement);
                    }
                }
            }
        };
        setTimeout(ToApply, 0);
    }

    jForm.find('.input-validation-error').removeClass('input-validation-error');
    jForm.find('.field-validation-error').removeClass('field-validation-error').addClass('field-validation-valid');
    var container = jForm.find("[data-valmsg-summary=true]");
    list = container.find("ul");
    list.empty();
    if (errors && errors.length > 0) {
        $.each(errors, function (i, ival) {
            $("<li />").html(ival).appendTo(list);
        });
        container.addClass("validation-summary-errors").removeClass("validation-summary-valid");
        inner_ServerErrors(name, errors);
        setTimeout(function () { jForm.find('span.input-validation-error[data-element-type]').removeClass('input-validation-error') }, 0);
    }
    else {
        container.addClass("validation-summary-valid").removeClass("validation-summary-errors");
    }
}

function clearErrors(jForm) {
    remoteErrors(jForm, []);
}