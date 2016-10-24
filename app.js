const electron = require( "electron" );
require('electron-reload')(__dirname);

// Module to control application life.
const app = electron.app;

// Module to create native browser window.
const BrowserWindow = electron.BrowserWindow;

let mainWindow;

app.on( "ready", function() {
    // Create the browser window
    mainWindow = new BrowserWindow( {
        width: 565,
        height: 600
    } );

    // and load the index.html of the app.
    mainWindow.loadURL( "file://" + __dirname + "/index.html" );

    // Open Chrome DevTools
    mainWindow.openDevTools( { detach: true } );
} );

app.on( "browser-window-created", function( e, window ) {
    window.setMenu( null );
});