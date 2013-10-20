// Get number of splash screens from splash.ini
function getSplashNumber()
{    
   %nReturn = false;
   
    %file = new FileObject();    
    if (%file.openForRead("./Settings/splash.ini"))
    {    
      while ( !%file.isEOF() )
      {
           $splash = %file.readLine();
      }
     
      %file.close();
      %nReturn = true;
    }
    
    return %nReturn;
}

// Load splash screen
function loadSplash()
{
    // Load game
    if ($splash == 0)
    {
        resetCanvas();
        startGame($defaultScene);
    }
   
    // Display splash screen
    else 
    {
        splashGUI.bitmap = "~/data/splash/logo1.png" @ $splash @ ".png";
        canvas.popDialog(splashGUI);
        canvas.pushDialog(splashGUI);
        schedule(100, 0, checkSplash);
        $splash--;
    }

}

// Check to see if splash screen should be loaded
function checkSplash()
{
   if (splashGUI.done)
      loadSplash();
    else
      schedule(100, 0, checkSplash);
}