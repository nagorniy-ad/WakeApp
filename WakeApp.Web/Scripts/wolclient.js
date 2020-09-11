class WolClient {
    async wakeUp(wolData) {
        let response = await fetch('/api/wol/wakeup', {
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
    }
}