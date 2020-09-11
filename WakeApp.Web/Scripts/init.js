document.addEventListener('DOMContentLoaded', initialize);

function initialize() {
    let sendButton = document.getElementById('send');
    if (sendButton) {
        sendButton.addEventListener('click', async function (e) {
            e.preventDefault();
            let client = new WolClient();
            await client.wakeUp({
                macAddress: '74-D4-35-0F-03-DF',
                ipAddress: '192.168.3.131',
                subnetMask: '255.255.255.0'
            });
        });
    }
    else {
        console.error('Элемент "send" не найден.');
    }
}