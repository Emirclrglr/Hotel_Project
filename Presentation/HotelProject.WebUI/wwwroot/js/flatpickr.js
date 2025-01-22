document.addEventListener('DOMContentLoaded', function () {
    // Check-in tarihi için Flatpickr
    var checkinPicker = flatpickr("#checkin", {
        dateFormat: "Y-m-d",
        locale: "tr",
        minDate: "today",
        disableMobile: true,
        onChange: function (selectedDates, dateStr) {
            // Check-out tarihini güncelle
            if (dateStr) {
                checkoutPicker.set('minDate', dateStr);
            }
        }
    });

    // Check-out tarihi için Flatpickr
    var checkoutPicker = flatpickr("#checkout", {
        dateFormat: "Y-m-d",
        locale: "tr",
        minDate: "today",
        disableMobile: true,
    });
});