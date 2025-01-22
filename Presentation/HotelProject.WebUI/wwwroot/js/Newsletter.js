// Partial view'deki işlemleri başlatan fonksiyon
function initializeSubscribeForm() {
    $(document).on('submit', '#subscribeForm', function (e) {
        e.preventDefault();

        var form = $(this);
        var actionUrl = form.attr('action');
        var formData = form.serialize();

        if (!actionUrl) {
            console.error('Form action URL bulunamadı.');
            Swal.fire({
                icon: 'error',
                title: 'Hata!',
                text: 'Formun hedef URL\'si bulunamadı. Lütfen geliştiriciyle iletişime geçin.',
                confirmButtonText: 'Tamam'
            });
            return;
        }

        $.ajax({
            url: actionUrl,
            type: 'POST',
            data: formData,
            success: function (response) {
                var successMessage = response.message || 'Mail bültenimize başarıyla abone oldunuz.';
                var successTitle = response.title || 'Başarıyla Abone Oldunuz!';

                Swal.fire({
                    icon: 'success',
                    title: successTitle,
                    text: successMessage,
                    confirmButtonText: 'Tamam'
                });

                form[0].reset();
            },
            error: function (jqXHR, textStatus, errorThrown) {
                var errorMessage = jqXHR.responseJSON?.message || 'Lütfen tekrar deneyin.';
                console.error('AJAX Hatası:', textStatus, errorThrown);

                Swal.fire({
                    icon: 'error',
                    title: 'Bir Hata Oluştu!',
                    text: errorMessage,
                    confirmButtonText: 'Tamam'
                });
            }
        });
    });
}

// Sayfa yüklendiğinde veya partial view yüklendiğinde çağrılır
$(document).ready(function () {
    // initializeSubscribeForm fonksiyonunu burada çağırıyoruz
    initializeSubscribeForm();

    // Eğer dinamik içerik yüklenecekse (örn. AJAX ile yeni partial view ekleniyorsa)
    $(document).on('partialViewLoaded', function () {
        initializeSubscribeForm();  // Partial view yüklenirse tekrar çağır
    });
});

$(document).trigger('partialViewLoaded');