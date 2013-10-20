//-----------------------------------------------------------------------------
// LoadManager - LoadFileList
//-----------------------------------------------------------------------------

function LoadGui::onWake(%this)
{
NMButton.command = "canvas.popdialog(LoadGui);";

%pattern = "~/data/Saves/*.hdsdat";
   LoadFileList.entryCount = 0;
   LoadFileList.clear();
   for(%file = findFirstFile(%pattern); %file !$= ""; %file = findNextFile(%pattern))
   {
      LoadFileList.fileName[LoadFileList.entryCount] = %file;
      echo("SFL, FN[SFL.EC] - " @ LoadFileList.fileName[LoadFileList.entryCount]);
      %stuff = fileBase(%file);
      LoadFileList.addRow(LoadFileList.entryCount, %stuff);
      LoadFileList.entryCount++;
      echo("ForLoop 1 --" SPC %stuff);
   }
   LoadFileList.sortNumerical(1);
   for(%i = 0; %i < LoadFileList.entryCount; %i++)
   {
      %rowId = LoadFileList.getRowId(%i);
      %text = LoadFileList.getRowTextById(%rowId);
      %text = restWords(%text); 
      %text = %i + 1 @". "@ LoadFileList.getRowTextById(%rowId);
      LoadFileList.setRowById(%rowId, %text);
      warn("ForLoop 2!");
   }
   LoadFileList.setSelectedRow(0);

loadfilelist.schedule(500, CheckItems);
}

function LoadFileList::checkItems(%this)
{
if(%this.entryCount <= 0)
{
    MessageBoxOK("No saves!", "It doesn't seem like you've made any saves, yet. You have to make one before playing!", "canvas.popdialog(loadGui); canvas.pushdialog(saveGui); altSave();");
}

}

function altSave()
{
doneButton.command = "canvas.popdialog(SaveGui); canvas.pushdialog(loadGui);";
}

function normSave()
{
doneButton.command = "canvas.popdialog(saveGui);";
}

function LoadFileList::onSelect(%this, %row)
{
echo("Row... " @ %row);
echo("Row text thing... " @ %this.getRowText(%row));
echo("OnSelect = " @ %this.fileName[%row]);
$LoadFolder = fileBase(%this.fileName[%row]);
error("OnSelect stuff..." SPC $LoadFolder);
}

//-----------------------------------------------------------------------------
// SaveManager - SaveFileList
//-----------------------------------------------------------------------------

function SaveGui::onWake(%this)
{
%pattern = "~/data/Saves/*.hdsdat";
   SaveFileList.entryCount = 0;
   SaveFileList.clear();
   for(%file = findFirstFile(%pattern); %file !$= ""; %file = findNextFile(%pattern))
   {
      SaveFileList.fileName[SaveFileList.entryCount] = %file;
      echo("SFL, FN[SFL.EC] - " @ SaveFileList.fileName[SaveFileList.entryCount]);
      %stuff = fileBase(%file);
      SaveFileList.addRow(SaveFileList.entryCount, %stuff);
      SaveFileList.entryCount++;
      echo("ForLoop 1 --" SPC %stuff);
   }
   SaveFileList.sortNumerical(1);
   for(%i = 0; %i < SaveFileList.entryCount; %i++)
   {
      %rowId = SaveFileList.getRowId(%i);
      %text = SaveFileList.getRowTextById(%rowId);
      %text = restWords(%text); 
      %text = %i + 1 @". "@ SaveFileList.getRowTextById(%rowId);
      SaveFileList.setRowById(%rowId, %text);
      warn("ForLoop 2!");
   }
   SaveFileList.setSelectedRow(0);
}

function SaveFileList::onSelect(%this, %row)
{
echo("Row... " @ %row);
echo("Row text thing... " @ %this.getRowText(%row));
echo("OnSelect = " @ %this.fileName[%row]);
$SaveFolder = fileBase(%this.fileName[%row]);
error("OnSelect stuff..." SPC $SaveFolder);
folderfield.setText($saveFolder);
}