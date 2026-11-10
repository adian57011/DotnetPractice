
/* ==============================
   TaskFlow - Application Scripts
   ============================== */

"use strict";

/**
 * Ask the user to confirm a destructive action.
 *
 * Usage:
 * data-confirm="Are you sure?"
 */
document.addEventListener("DOMContentLoaded", function () {

    const confirmationElements =
        document.querySelectorAll("[data-confirm]");

    confirmationElements.forEach(function (element) {

        element.addEventListener("click", function (event) {

            const message =
                element.getAttribute("data-confirm");

            if (!confirm(message)) {
                event.preventDefault();
            }

        });

    });

});
