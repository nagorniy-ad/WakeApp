const MAC_ADDRESS_STORAGE_KEY = "macAddress";
const IP_ADDRESS_STORAGE_KEY = "ipAddress";
const SUBNET_MASK_STORAGE_KEY = "subnetMask";

let sendPacketButton;
let wolDataForm;
let macAddressInput;
let ipAddressInput;
let subnetMaskInput;

document.addEventListener('DOMContentLoaded', initialize);

function initialize() {
    sendPacketButton = document.getElementById('sendPacketButton');
    wolDataForm = document.getElementById('wolDataForm');
    macAddressInput = document.getElementById('macAddressInput');
    ipAddressInput = document.getElementById('ipAddressInput');
    subnetMaskInput = document.getElementById('subnetMaskInput');
    loadValuesFromStorage();
    if (sendPacketButton) {
        sendPacketButton.addEventListener('click', function (e) {
            e.preventDefault();
            sendPacket();
        });
    }
    if (macAddressInput) {
        macAddressInput.addEventListener('input', setMacAddressValidationRules);
    }
    if (ipAddressInput) {
        ipAddressInput.addEventListener('input', setIpAddressValidationRules);
    }
    if (subnetMaskInput) {
        subnetMaskInput.addEventListener('input', setSubnetMaskValidationRules);
    }
}

async function sendPacket() {
    if (wolDataForm.checkValidity() === true) {
        let wolData = {
            macAddress: macAddressInput.value,
            ipAddress: ipAddressInput.value,
            subnetMask: subnetMaskInput.value
        };
        let notifier = new Notifier();
        let client = new WolClient();
        try {
            await client.wakeUp(wolData);
            notifier.success('Пакет успешно отправлен.');
            localStorage.setItem(MAC_ADDRESS_STORAGE_KEY, wolData.macAddress);
            localStorage.setItem(IP_ADDRESS_STORAGE_KEY, wolData.ipAddress);
            localStorage.setItem(SUBNET_MASK_STORAGE_KEY, wolData.subnetMask);
        }
        catch {
            notifier.error('Не удалось отправить пакет.');
        }
        wolDataForm.classList.remove('was-validated');
    }
    else {
        wolDataForm.classList.add('was-validated');
    }
}

function setMacAddressValidationRules() {
    let invalidFeedback = macAddressInput.parentElement.querySelector('.invalid-feedback');
    if (macAddressInput.value) {
        invalidFeedback.textContent = 'MAC-адрес некорректен.';
    }
    else {
        invalidFeedback.textContent = 'MAC-адрес не задан.';
    }
}

function setIpAddressValidationRules() {
    let invalidFeedback = ipAddressInput.parentElement.querySelector('.invalid-feedback');
    if (ipAddressInput.value) {
        invalidFeedback.textContent = 'IP-адрес некорректен.';
        subnetMaskInput.required = true;
    }
    else {
        invalidFeedback.textContent = 'IP-адрес не задан.';
        subnetMaskInput.required = false;
    }
}

function setSubnetMaskValidationRules() {
    let invalidFeedback = subnetMaskInput.parentElement.querySelector('.invalid-feedback');
    if (subnetMaskInput.value) {
        invalidFeedback.textContent = 'Маска подсети некорректна.';
        ipAddressInput.required = true;
    }
    else {
        invalidFeedback.textContent = 'Маска подсети не задана.';
        ipAddressInput.required = false;
    }
}

function loadValuesFromStorage() {
    var macAddress = localStorage.getItem('macAddress');
    if (macAddress && macAddressInput) {
        macAddressInput.value = macAddress;
    }
    var ipAddress = localStorage.getItem('ipAddress');
    if (ipAddress && ipAddressInput) {
        ipAddressInput.value = ipAddress;
    }
    var subnetMask = localStorage.getItem('subnetMask');
    if (subnetMask && subnetMaskInput) {
        subnetMaskInput.value = subnetMask;
    }
}