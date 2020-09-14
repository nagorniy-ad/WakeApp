class WolClient {
    async wakeUp(wolData) {
        let response = await fetch('/api/wol', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json;charset=utf-8'
            },
            body: JSON.stringify({
                macAddress: wolData.macAddress,
                ipAddress: wolData.ipAddress,
                subnetMask: wolData.subnetMask
            })
        });
        if (response.ok == false) {
            switch (response.status) {
                case 400:
                    throw new Error('Произошла ошибка валидации данных.');
                case 500:
                    throw new Error('Произошла внутренняя ошибка сервера.');
                default:
                    throw new Error('Произошла неизвестная ошибка.');
            }
        }
    }
}