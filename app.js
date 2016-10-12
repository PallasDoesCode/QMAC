var electron = require( "electron" );

// Module to control application life.
var app = electron.app;

// Module to create native browser window.
var BrowserWindow = electron.BrowserWindow;

var mainWindows = null;

app.on( "ready", function() {
    // Create the browser window
    mainWindow = new BrowserWindow( {
        width: 565,
        height: 600
    } );

    // and load the index.html of the app.
    mainWindow.loadURL( "file://" + __dirname + "/index.html" );
} );

app.on( "browser-window-created", function( e, window ) {
    window.setMenu( null );
});