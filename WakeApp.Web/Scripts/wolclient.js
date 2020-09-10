class WolClient {
    /**
     * 
     * @param {WolData} wolData
     */
    wakeUp(wolData) {

    }
}

class WolData {
    /**
     * 
     * @param {string} macAddress
     * @param {string} ipAddress
     * @param {string} subnetMask
     */
    constructor(macAddress, ipAddress, subnetMask) {
        this.macAddress = macAddress;
        this.ipAddress = ipAddress;
        this.subnetMask = subnetMask;
    }
}

class WolErrorResult {
    /**
     * 
     * @param {string} type
     * @param {string} title
     * @param {number} status
     * @param {string} traceId
     * @param {any} errors
     */
    constructor(type, title, status, traceId, errors) {
        this.type = type;
        this.title = title;
        this.status = status;
        this.traceId = traceId;
        this.errors = errors;
    }
}