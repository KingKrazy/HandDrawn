function generateTip()
{
schedule( 7500, 0, "TipTextA" );
}

function TipTextA()
{
GameTips.setText($TIPLIST[getRandom(0,19)]);
TipText();
}

function TipText()
{

schedule( 7500, 0, "TipTextB" );

}

function TipTextB()
{
schedule( 7500, 0, "generateTip" );
}


$TIPLIST[0] = "<font:Arial:30>Surveying the map is a great way to get by a hard part!";
$TIPLIST[1] = "<font:Arial:30>Some enemies are silent. If you don't pay attention, they'll kill you before you can say pencil!";
$TIPLIST[3] = "<font:Arial:30>Choose the right weapons for the right enemies. For example, it's a bad idea to attack small enemies with large, inaccurate weapons like the Bomb.";
$TIPLIST[4] = "<font:Arial:30>If your hurt, you can't fire any weapons or pause the game until the red frame goes away.";
$TIPLIST[5] = "<font:Arial:30>Some levels are reverse levels. You have to switch to your reverse twin to see where you are.";
$TIPLIST[6] = "<font:Arial:30>IS THE MUSIC TOO LOUD OR TOO MONOTONOUS? Try turning it down through the options menu found in the pause window and menu.";
$TIPLIST[7] = "<font:Arial:30>HandDrawn has 0 cholesterol, fat, and calories and is organic!";
$TIPLIST[8] = "<font:Arial:30>No level is impossible. Try different tactics to try to beat the really hard ones!";
$TIPLIST[9] = "<font:Arial:30>Sometimes the ridiculous answer is the only answer!";
$TIPLIST[10] = "<font:Arial:30>Don't feed the blob monsters…With yourself.";
$TIPLIST[12] = "<font:Arial:30>Don't lean on parachuting all the time. There is a timeout on it restricting you from using it to much at a time.";
$TIPLIST[13] = "<font:Arial:30>Life has no nutritional value. Telling that to monsters will not stop them from eating you.";
$TIPLIST[14] = "<font:Arial:30>If you swim too deep, you'll die from water pressure.";
$TIPLIST[15] = "<font:Arial:30>Some of these tips really don't deserve that title.";
$TIPLIST[16] = "<font:Arial:30>If you don't beat yer level, you can't advance to the next one! How can you advance to the next one if you don't beat yer level?";
$TIPLIST[17] = "<font:Arial:30>The chances of getting two tips in a row is 361 to one.";
$TIPLIST[18] = "<font:Arial:30>Some levels may seem impossible. Well, that's a matter of opinion. All levels are certified 100 percent beatable.";
$TIPLIST[19] = "<font:Arial:30>In a beta test, some people complained that the game was infecting their cheese with strange black blobs. I removed that…I think.";