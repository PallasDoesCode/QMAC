var os = require("os");
//var system = require("./lib/system");
var hostname = os.hostname();

var hostnameElement = document.getElementById("hostname");
var interfaceElement = document.getElementById("interfaces");


var GetNetworkInfo = function () {

    var interfaces = os.networkInterfaces(); // ["lo", "eth0"]
    var allAddresses = {};

    Object.keys(interfaces).forEach(function (nic) {
        var addresses = {};
        var hasAddresses = false;
        interfaces[nic].forEach(function (address) {
            if (!address.internal) {
                addresses[(address.family || "").toLowerCase()] = address.address;
                hasAddresses = true;
                if (address.mac) {
                    addresses.mac = address.mac;
                }
            }
        });

        if (hasAddresses) {
            allAddresses[nic] = addresses;
        }
    });

    return allAddresses;
}

var interfaceList = GetNetworkInfo();
console.log(JSON.stringify(GetNetworkInfo()));

hostnameElement.innerHTML += hostname;
interfaceElement.innerHTML = interfaceList.Ethernet.ipv4;
