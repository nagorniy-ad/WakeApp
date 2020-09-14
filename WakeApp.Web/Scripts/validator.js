class Validator {
    validate(wolData) {
        let errors = {
            macAddress: [],
            ipAddress: [],
            subnetMask: []
        };
        if (!wolData.macAddress) {
            errors.macAddress.push('MAC-адрес не задан.');
        }
        else {
            if (this._isValidMacAddress(wolData.macAddress) == false) {
                errors.macAddress.push('MAC-адрес некорректен.');
            }
        }
        if (wolData.ipAddress) {
            if (this._isValidIpAddress(wolData.ipAddress) == false) {
                errors.ipAddress.push('IP-адрес некорректен.');
            }
            if (!wolData.subnetMask) {
                errors.subnetMask.push('Маска подсети не задана.');
            }
            else {
                if (this._isValidIpAddress(wolData.subnetMask) == false) {
                    errors.subnetMask.push('Маска подсети некорректна.');
                }
            }
        }
        else {
            if (wolData.subnetMask) {
                errors.ipAddress.push('IP-адрес не задан.');
                if (this._isValidIpAddress(wolData.subnetMask) == false) {
                    errors.subnetMask.push('Маска подсети некорректна.');
                }
            }
        }
        let result = errors.macAddress.length == 0 &&
            errors.ipAddress.length == 0 &&
            errors.subnetMask.length == 0;
        return {
            success: result,
            errors: errors
        };
    }

    /**
     * 
     * @param {string} value
     */
    _isValidMacAddress(value) {
        return /^\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}$/.test(value);
    }

    /**
     * 
     * @param {string} value
     */
    _isValidIpAddress(value) {
        return /^[a-f0-9]{2}([:-])(?:[a-f0-9]{2}\1){4}[a-f0-9]{2}$/.test(value);
    }
}