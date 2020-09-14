document.addEventListener('DOMContentLoaded', initialize);

function initialize() {
    let sendButton = document.getElementById('send');
    if (sendButton) {
        sendButton.addEventListener('click', async function (e) {
            e.preventDefault();
            let wolData = {
                macAddress: '74-D4-35-0F-03-DF',
                ipAddress: '192.168.3.131',
                subnetMask: '255.255.255.0'
            };
            let notifier = new Notifier();
            let client = new WolClient();
            try {
                await client.wakeUp(wolData);
                notifier.success('Пакет успешно отправлен.');
            }
            catch {
                notifier.error('Не удалось отправить пакет.');
            }
        });
    }
    else {
        console.error('Элемент "send" не найден.');
    }
}