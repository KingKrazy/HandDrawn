function FinishGui::onWake(%this)
{
loadFinishText();
}

function loadFinishText()
{
finishText.setText(%finishText);
}

%finishText = "<just:center><font:Bank Gothic Medium:40>MISSION COMPLETE!<font:OCR A Std:16><just:center>You have succesfuly completed this mission. You can save or quit. Please note that saving will overwrite any previous progress. You cannot undo this action. If you quit, you will lose all unsaved progress.";