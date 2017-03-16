$(document).ready(function () {
    $('#privacyLink').click(function (event) {
        event.preventDefault();
        var url = $(this).attr('href');
        $('#privacyEdit').load(url);
    });
});

$(document).ready(function () {
    var url = $(this).attr('href')
    $('#privacyInfo').load(url)
})