//-----------------------------------------------------------------------------
// HandDrawn Modification System 1.0
//This sets mods up real nice. :)
//-----------------------------------------------------------------------------

function InitializeMods()
{
    if ( !isFile( "~/Mods/Main.cs" ) )
    {
    WriteModFile();
    }
    
    exec(expandFilename("~/Mods"));
    
    toggleConsole(1);
    toggleConsole(1);
    
    if($ConsoleErrorCount > 0)
    {
    if($consoleErrorCount > 1)
    {
    %grammar = "these files";
    }
    else
    {
    %grammar = "this file";
    }

    $modError = getWord(ConsoleErrorDisplay.getText(), 0);

    MessageBoxOK("Mod Files are Messed Up!", "OUCH! ERRORS REALLY HURT! I've tracked one of the problems down to: " @ $ModError @ ". Did you modify this file? Is it a mod? Press \"OK\" to open the file! Please also take a look at your console log to find any other errors but also to figure out exactly where it went wrong!", "OpenErroredFile();");
    }
}

function openErroredFile()
{
//warn("Going to: file://" @ $modError);
gotoWebPage("file://" @ $modError);
}

