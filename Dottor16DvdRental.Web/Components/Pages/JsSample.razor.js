export function showMessage(message) {
    alert(message);
}

export function initTimer(dotNetCallback) {
    setTimeout(function () {
        dotNetCallback.invokeMethodAsync("SetText", "ciao da js")
    }, 5000)
}

export function showActor(actor) {
    alert(`Actor: ${actor.firstName} ${actor.lastName}`);
}