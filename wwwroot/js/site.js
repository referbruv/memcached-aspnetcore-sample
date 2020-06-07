// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
   
    $("form")
        .submit(function (event) {
            debugger;
            event.preventDefault();
            
            // fetch the form object
            $f = $(event.currentTarget);

            // check if form is valid
            if ($f.valid()) {
                $("div.loader").show();
                // fetch the action and method
                var url = $f.attr("action");
                var method = $f.attr("method");

                if (method.toUpperCase() === "POST") {

                    // prepare the FORM data to POST
                    var data = new FormData(this);

                    // ajax POST
                    $.ajax({
                        url: url,
                        method: "POST",
                        data: data,
                        processData: false,
                        contentType: false,
                        success: handleResponse,
                        error: handleError,
                        complete: function (jqXHR, status) {
                            console.log(jqXHR);
                            console.log(status);
                            $f.trigger('reset');
                        }
                    });
                }
            }
        });

        function handleResponse(res) {
            debugger;
            $("div.loader").hide();

            // check if isSuccess from Response
            // is False or Not set
            if (!res.isSuccess) {
                debugger;
                // handle unsuccessful scenario
            } else {
                // handle successful scenario
            }
        }

        function handleError(err) {
            $("div.loader").hide();
            if (xhr.responseText)
                showErrorMessage(xhr.responseText);
            else
                showErrorMessage("Some unknown error has occured. Please try again later.");
        }

        function showErrorMessage(message) {
            // show a popup logic or an alert logic
        }
});