var os = require("os");
//var system = require("./lib/system");
var hostname = os.hostname();

var hostnameElement = document.getElementById("hostname");
var interfaceElement = document.getElementById("interfaces");


var GetNetworkInfo = function () {

    var interfaces = os.networkInterfaces(); // ["lo", "eth0"]
    var allAddresses = [];

    Object.keys(interfaces).forEach(function (nic) {
        var addresses = {};
        var hasAddresses = false;
        interfaces[nic].forEach(function (address) {
            if (!address.internal && address.family === "IPv4") {
                
                //console.log("nic:" + nic);
                //console.log("IPv4 address:" + JSON.stringify(address));

                addresses["address"] = address.address;
                hasAddresses = true;

                if (address.mac) {
                    addresses.mac = address.mac;
                }
            }
        });

        if (hasAddresses) {
            allAddresses.push(addresses);
        }
    });

    console.log(allAddresses);
    return allAddresses;
}

var interfaceList = GetNetworkInfo();
//console.log(JSON.stringify(GetNetworkInfo()));

hostnameElement.innerHTML += hostname;
interfaceElement.innerHTML = interfaceList[0].address;
