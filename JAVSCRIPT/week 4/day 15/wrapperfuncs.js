// JavaScript Document
window.addEventListener('DOMContentLoaded', function() {
var addedToDocument = false;
var wrapper = document.createElement("div");
wrapper.id = "slideInner";
var nodesToWrap = document.getElementsByClassName("slide");
for (var index = 0; index < nodesToWrap.length; index++) {
    var node = nodesToWrap[index];
    if (! addedToDocument) {
        node.parentNode.insertBefore(wrapper, node);
        addedToDocument = true;
    }
    node.parentNode.removeChild(node);
    wrapper.appendChild(node);
}
})