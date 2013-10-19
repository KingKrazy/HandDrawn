function initSaveManager()
{
$Filedisplay = "" @ $DispFolderName @ "/" @ $DispFolderName @ ".hdsave";
exec($fileDisplay);
}

function InitSaveGame(%folderName, %level, %inv, %misc, %quit)
{
%num1 = %foldername;
%num2 = %level;
%num3 = %inv;
%num4 = %misc;
%num5 = %quit;
$saveCallback = "";
$saveCallback = "saveGame(" @ %num1 @ ", " @ %num2 @ ", " @ %num3 @ ", " @ %num4 @ ", " @ %num5 @ ");";
    if(!isFile("~/data/saves/" @ %folderName @ ".hdsdat"))
    {
    MessageBoxYesNo("Make new game?", "It seems that this save file, \"" @ %folderName @ "\", doesn't already exist. Do you want to make a new save?", $SaveCallback);
    }
    else
    {
    MessageBoxYesNo("File exists already!", "It seems that this save file, \"" @ %folderName @ "\", already exists. Do you want to overwrite the existing one with the new progress?", $SaveCallback);
    }

echo(%foldername SPC %level SPC %inv SPC %misc SPC %quit);
}

function saveGame(%folderName, %level, %inv, %misc, %quit)
{
error(%foldername SPC %level SPC %inv SPC %misc SPC %quit);
    %file = new FileObject();

    if(%file.openForWrite("~/data/saves/" @ %folderName @ ".hdsdat"))
    {
    %file.writeLine("/" @ "/This is just a placeholder so you'll see the file's name in the save/load system's fileview. If you delete this, you'll no longer be able to access the save, so don't!");
    }
    else if(!%file.openForWrite("~/data/saves/" @ %folderName @ "/LevelData.hdsave"))
    {
    error("Couldn't write!");
    MessageBoxOK("Error", "An error occured when you tried to save the file's basic data. Please make sure the name does not contain non-numeric symbols, then try again.");

    }
    %file.close();
    %file.delete();
    
    

    %file1 = new FileObject();

    if(%file1.openForWrite("~/data/saves/" @ %folderName @ "/LevelData.hdsave") && %level)
    {

    //Not-dead-ness
    
    
    %file1.writeLine("$PlayerLevel = \"" @ $playerlevel @ "\";");
    
    echo("File Written");
    }
    else if(!%file1.openForWrite("~/data/saves/" @ %folderName @ "/LevelData.hdsave"))
    {
    error("Couldn't write!");
    MessageBoxOK("Error", "An error occured when you tried to save the level data. Please make sure the name does not contain non-numeric symbols, then try again.");
    }
    %file1.close();
    %file1.delete();

    %file2 = new FileObject();

    if(%file2.openForWrite("~/data/saves/" @ %folderName @ "/InventoryData.hdsave") && %inv)
    {
    
    
    
    %file2.writeLine("/" @ "/InventoryData");
    %file2.writeLine("$game::player.PineConeAmmo = \"" @ $game::player.BurningPineConeAmmo @ "\";");
    %file2.writeLine("$game::player.BurningPineConeAmmo = \"" @ $game::player.BurningPineConeAmmo @ "\";");
    %file2.writeLine("$game::player.FrozenPineConeAmmo = \"" @ $game::player.FrozenPineConeAmmo @ "\";");
    %file2.writeLine("$game::player.PoisonedPineConeAmmo = \"" @ $game::player.PoisonedPineConeAmmo @ "\";");
    %file2.writeLine("$game::player.MultiPineConeAmmo = \"" @ $game::player.MultiPineConeAmmo @ "\";");
    %file2.writeLine("$game::player.MultiBurningPineConeAmmo = \"" @ $game::player.MultiBurningPineConeAmmo @ "\";");
    %file2.writeLine("$game::player.MultiFrozenPineConeAmmo = \"" @ $game::player.MultiFrozenPineConeAmmo @ "\";");
    %file2.writeLine("$game::player.MultiPoisonedPineConeAmmo = \"" @ $game::player.MultiPoisonedPineConeAmmo @ "\";");
    %file2.writeLine("$game::player.setActiveWeapon(" @ $game::player.activeWeapon @ ");");
    
    
    
    
    
    if($game::player.temporarySwim = 0 && $game::player.canSwim = 1)
    {
    %file2.writeLine("$game::player.canSwim = \"1\"");
    }
    else if($game::player.temporarySwim = 0 && $game::player.canSwim = 0)
    {
    %file2.writeLine("$game::player.canSwim = \"0\"");
    }
    
    echo("File Written");
    }
    else if(!%file2.openForWrite("~/data/saves/" @ %folderName @ "/InventoryData.hdsave"))
    {
    error("Couldn't write!");
    MessageBoxOK("Error", "An error occured when you tried to save the inventory data. Please make sure the name does not contain non-numeric symbols, then try again.");
    }
    %file2.close();
    %file2.delete();


    %file3 = new FileObject();

    if(%file3.openForWrite("~/data/saves/" @ %folderName @ "/MiscData.hdsave") && %misc)
    {
    
    
    
    %file3.writeLine("/" @ "/MiscData");
    
    
    
    echo("File Written");
    }
    else if(!%file3.openForWrite("~/data/saves/" @ %folderName @ "/MiscData.hdsave"))
    {
    error("Couldn't write!");
    MessageBoxOK("Error", "An error occured when you tried to save the extra data (shop data, point data, et cetera). Please make sure the filename does not contain non-numeric symbols, then try again.");
    }
    %file3.close();
    %file3.delete();

    if(%quit)
    {
    quit();
    }
}

//------------------------------------------------------------------------------
// Load Function
//------------------------------------------------------------------------------


function loadGame(%folderName, %level, %inv, %misc, %close)
{

echo("Foldername is... " @ %foldername);
%file1 = new FileObject();
%file2 = new FileObject();
%file3 = new FileObject();

    if(%file1.openForRead("~/data/saves/" @ %folderName @ "/LevelData.hdsave"))
    {
    if(%level)
    {
    exec("~/data/saves/" @ %folderName @ "/LevelData.hdsave");
    }
    }
    else
    {
    error("Failed to load the level data!");
    }

    if(%file2.openForRead("~/data/saves/" @ %folderName @ "/InventoryData.hdsave"))
    {
    if(%inv)
    {
    exec("~/data/saves/" @ %folderName @ "/InventoryData.hdsave");
    }
    }
    else
    {
    error("Failed to load the inventory data!");
    }

    if(%file3.openForRead("~/data/saves/" @ %folderName @ "/MiscData.hdsave"))
    {
    if(%misc)
    {
    exec("~/data/saves/" @ %folderName @ "/MiscData.hdsave");
    }
    }
    else
    {
    error("Failed to load the misc data!");
    }

    %file1.close();
    %file1.delete();

    if(%close)
    {
    canvas.popDialog(LoadGui);
    }
    levelButtonClass::SetUpLS();
}

function deleteGameInt(%folderName, %level, %inv, %misc, %close)
{
    $DeleteCallback = "deleteGame(" @ %folderName @ ", " @ %level @ ", " @ %inv @ ", " @ %misc @ ", " @ %close @ ");";

    MessageBoxYesNo("Delete this saved file?", "You're about to delete the file, \"" @ %folderName @ "\". Once it's deleted, I can't recover it for you again. Do you really want to do this?", $deleteCallback);
}

function deleteGame(%folderName, %level, %inv, %misc, %close)
{

echo("Foldername is... " @ %foldername);
%file = new FileObject();
%file1 = new FileObject();
%file2 = new FileObject();
%file3 = new FileObject();

    if(%file.openForRead("~/data/saves/" @ %folderName @ ".hdsdat"))
    {
    if(%level)
    {
    fileDelete(expandFilename("~/data/saves/" @ %folderName @ ".hdsdat"));
    echo(fileDelete(expandFilename("~/data/saves/" @ %folderName @ ".hdsdat")));
    fileDelete(%file);
    }
    }
    else
    {
    error("Failed to delete the level data!");
    }

    if(%file1.openForRead("~/data/saves/" @ %folderName @ "/LevelData.hdsave"))
    {
    if(%level)
    {
    fileDelete(expandFilename("~/data/saves/" @ %folderName @ "/LevelData.hdsave"));
    fileDelete(%file1);
    }
    }
    else
    {
    error("Failed to delete the level data!");
    }

    if(%file2.openForRead("~/data/saves/" @ %folderName @ "/InventoryData.hdsave"))
    {
    if(%inv)
    {
    fileDelete(expandFilename("~/data/saves/" @ %folderName @ "/InventoryData.hdsave"));
    fileDelete(%file2);
    }
    }
    else
    {
    error("Failed to delete the inventory data!");
    }

    if(%file3.openForRead("~/data/saves/" @ %folderName @ "/MiscData.hdsave"))
    {
    if(%misc)
    {
    fileDelete(expandFilename("~/data/saves/" @ %folderName @ "/MiscData.hdsave"));
    //fileDelete(%file3);
    }
    }
    else
    {
    error("Failed to delete the misc data!");
    }

    %file1.close();
    %file1.delete();

    if(%close)
    {
    canvas.popDialog(LoadGui);
    }
    else
    {
    canvas.popdialog(loadgui);
    canvas.schedule(32, "pushdialog", loadGui);
    }
}