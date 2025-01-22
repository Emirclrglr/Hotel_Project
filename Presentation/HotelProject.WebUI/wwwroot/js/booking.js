$(document).ready(function () {
    $('#bookingForm').submit(function (e) {
        e.preventDefault();

        var form = $(this);
        var actionUrl = form.attr('action'); 
        var formData = form.serialize(); 

        $.ajax({
            url: actionUrl,
            type: 'POST',
            data: formData,
            success: function (response) {
                Swal.fire({
                    icon: 'success',
                    title: 'Rezervasyon Başarılı!',
                    text: 'Rezervasyonunuz Başarılı Bir Şekilde Oluşturuldu.',
                    confirmButtonText: 'Tamam'
                });
            },
            error: function () {
                Swal.fire({
                    icon: 'error',
                    title: 'Bir hata oluştu!',
                    text: 'Lütfen tekrar deneyin.',
                    confirmButtonText: 'Tamam'
                });
            }
        });
    });
});