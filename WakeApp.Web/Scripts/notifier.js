class Notifier {
    /**
     * Отображает обычное уведомление.
     * @param {string} message
     */
    info(message) {
        this._notify('alert', message);
    }

    /**
     * Отображает уведомление об успешном выполнении операции.
     * @param {string} message
     */
    success(message) {
        this._notify('success', message);
    }

    /**
     * Отображает уведомление об ошибке.
     * @param {string} message
     */
    error(message) {
        this._notify('error', message);
    }

    /**
     * 
     * @param {string} notificationType
     * @param {string} message
     */
    _notify(notificationType, message) {
        new Noty({
            theme: 'semanticui',
            type: notificationType,
            layout: 'bottomRight',
            progressBar: false,
            text: message,
            timeout: 3000
        }).show();
    }
}