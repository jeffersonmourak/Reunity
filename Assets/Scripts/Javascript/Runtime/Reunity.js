
var GLOBAL = this;

function BuildBridge(bridgeObject) {
    var globalObject = {};

    for (var i = 0; i < bridgeObject.actions.Count; i++) {
        var bridgeItem = bridgeObject.actions[i];
        globalObject[bridgeItem.name] = bridgeItem.action;
    }

    GLOBAL[bridgeObject.name] = globalObject;
}

function DestroyBridge(bridgeName) {
    delete GLOBAL[bridgeName];
}