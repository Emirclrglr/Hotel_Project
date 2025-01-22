function submitForm(event) {
    event.preventDefault(); 

    var formData = $('#contactForm').serialize(); 

    $.ajax({
        url: '/Contact/ContactForm',
        type: 'POST',
        data: formData,
        success: function (response) {
            Swal.fire({
                icon: 'success',
                title: 'Başarıyla Gönderildi!',
                text: 'Mesajınız başarıyla gönderildi. En kısa zamanda size dönüş yapacağız.',
                confirmButtonText: 'Tamam'
            });
            $('#contactForm')[0].reset(); 
        },
        error: function (xhr, status, error) {
            Swal.fire({
                icon: 'error',
                title: 'Bir Hata Oluştu!',
                text: 'Mesajınızı gönderirken bir hata oluştu. Lütfen tekrar deneyin.',
                confirmButtonText: 'Tamam'
            });
        }
    });
}