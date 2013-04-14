function checkIfBrowserIsMozilla() {        var browserName = window.navigator.appCodeName;    var isMozilla = false;    if (browserName === "Mozilla") {
        isMozilla = true;
    }    if (isMozilla) {
        alert("Yes");
    }    else {
        alert("No");
    }
}