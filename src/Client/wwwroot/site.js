getDocumentCookie = function () {
    return Promise.resolve(document.cookie);
};

showAlert = (message) => {
    alert(message);
}