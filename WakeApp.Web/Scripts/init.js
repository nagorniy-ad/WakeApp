document.addEventListener('DOMContentLoaded', initialize);

function initialize() {
    let submitButton = document.getElementById('send');
    if (submitButton) {
        submitButton.addEventListener('click', function (e) {
            e.preventDefault();
        });
    }
    else {
        console.error('Элемент "send" не найден.');
    }
}