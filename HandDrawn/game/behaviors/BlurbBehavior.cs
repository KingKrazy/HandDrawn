//-----------------------------------------------------------------------------
//HandDrawn 1.0
// Blurbs
//-----------------------------------------------------------------------------
//By Robert V.

//First, let's start with creating a speech bubble.

if ( !isObject( SpeechDisplayBehavior ) )
{
    %template = new BehaviorTemplate( SpeechDisplayBehavior );

    %template.friendlyName = "Blurb Text";
    %template.behaviorType = "Miscellaneous";
    %template.description  = "Set this behavior to something so when the player interacts with them, they engage them in a conversation.";

   %template.addBehaviorField(Font, "The name of the font to use.", string, "Chalkboard");
   %template.addBehaviorField(BlendColor, "The text-color.", string, "0 0 0 1");
   %template.addBehaviorField(Size, "The text-size.", float, "84");
   %template.addBehaviorField(Spacing, "The character spacing.", float, "0");
   %template.addBehaviorField(LineY, "The line height.", float, "3");
   %template.addBehaviorField(Align, "Where to align the text.", string, "Left");

   %template.addBehaviorField(BlurbText, "What the person should say when they are collided with.", string, "");
   %template.addBehaviorField(BlurbText2, "What the person should say when they are collided with.", string, "");
   %template.addBehaviorField(BlurbText3, "What the person should say when they are collided with.", string, "");
   %template.addBehaviorField(BlurbText4, "What the person should say when they are collided with.", string, "");
   %template.addBehaviorField(BlurbText5, "What the person should say when they are collided with.", string, "");
   %template.addBehaviorField(BlurbText6, "What the person should say when they are collided with.", string, "");
   %template.addBehaviorField(BlurbText7, "What the person should say when they are collided with.", string, "");
   %template.addBehaviorField(BlurbText8, "What the person should say when they are collided with.", string, "");
   %template.addBehaviorField(BlurbText9, "What the person should say when they are collided with.", string, "");
   %template.addBehaviorField(BlurbText10, "What the person should say when they are collided with.", string, "");
   %template.addBehaviorField(BlurbText11, "What the person should say when they are collided with.", string, "");
   %template.addBehaviorField(BlurbText12, "What the person should say when they are collided with.", string, "");
   %template.addBehaviorField(BlurbText13, "What the person should say when they are collided with.", string, "");
   %template.addBehaviorField(BlurbText14, "What the person should say when they are collided with.", string, "");
   %template.addBehaviorField(BlurbText15, "What the person should say when they are collided with.", string, "");

//Alternates
   %template.addBehaviorField(APoint, "What line to open the options on. (-1 means don't do it ever!)", string, "-1");
   %template.addBehaviorField(ANumLines, "How many lines the alternate choice should have.", string, "");
   %template.addBehaviorField( ThreeOpts, "Collide with the player, not other actors",       BOOL,  true );

//A
   %template.addBehaviorField(AlternateA1, "What the person should say when they are collided with.", string, "");
   %template.addBehaviorField(AlternateA2, "What the person should say when they are collided with.", string, "");
   %template.addBehaviorField(AlternateA3, "What the person should say when they are collided with.", string, "");

//B
   %template.addBehaviorField(AlternateB1, "What the person should say when they are collided with.", string, "");
   %template.addBehaviorField(AlternateB2, "What the person should say when they are collided with.", string, "");
   %template.addBehaviorField(AlternateB3, "What the person should say when they are collided with.", string, "");

//C
   %template.addBehaviorField(AlternateC1, "What the person should say when they are collided with.", string, "");
   %template.addBehaviorField(AlternateC2, "What the person should say when they are collided with.", string, "");
   %template.addBehaviorField(AlternateC3, "What the person should say when they are collided with.", string, "");

   %template.addBehaviorField(Opt1Text, "What the person should say when they are collided with.", string, "Opt 1");
   %template.addBehaviorField(Opt2Text, "What the person should say when they are collided with.", string, "Opt 2");
   %template.addBehaviorField(Opt3Text, "What the person should say when they are collided with.", string, "Opt 3");
   %template.addBehaviorField(TalkSound, "The sound that they should make per every character rendering.", string, "Talk");
   %template.addBehaviorField(TalkDoneSound, "The sound that they should make per every character rendering.", string, "TalkDone");

   %template.addBehaviorField(DoneFunction, "Call a function at the end of the dialog.", string, "");


   %template.addBehaviorField(numLines, "How many lines? (Maximum: 20)", float, "1");


   %template.addBehaviorField(timer, "What the speed should be.", float, "20");
    %template.addBehaviorField( PlayerOnly, "Collide with the player, not other actors",       BOOL,  false );
    %template.addBehaviorField( isDestroyer, "Destroy a bubble, not make one.",       BOOL,  false );
   %template.addBehaviorField(targetSpeaker, "The person who's talking", object, "", t2dSceneObject);
   //%template.addBehaviorField(speechDest, "The person who's talking", object, "", t2dSceneObject);

}

function SpeechDisplayBehavior::BlurbSpawn(%this)  
{  

%blurbPositionX = %this.TargetSpeaker.Position.X;
%blurbPositionY = %this.TargetSpeaker.Position.Y - 30;
%blurbPosition = %blurbPositionX SPC %BlurbPositionY;

if( !isObject(%this.Blurb) )
{
    echo("Created bubble");
    %this.Blurb = new t2dStaticSprite()
    {
        SceneGraph    = Scenewindow2D.getSceneGraph();  
        imageMap = "SpeechBubbleImageMap";  
        frame = "0";  
        sourceRect = "0 0 0 0";  
        layer = "0";
        canSaveDynamicFields = "1";
        Position = %BlurbPosition;
        size = "50.000 20.000";
        mountID = "173";
      _behavior0 = "ScaleBehavior\txWidthMin\t0.001\tyWidthMin\t0.001\txWidthMax\t65\tyWidthMax\t30\tTime\t0.1\tgrow\t1";
    };
}
    %textPosX = getWord(%this.Blurb.getPosition(), 0);
    %textPosY = getWord(%this.Blurb.getPosition(), 1);
    %blurbSizeY = getWord(%this.Blurb.size, 1);

    %textPos = %textPosX SPC %textPosY - 3.5;

if( !isObject(%this.SpText) )
{
    echo("Created text object");
    %this.SpText = new t2dTextObject()
    {
        SceneGraph    = Scenewindow2D.getSceneGraph();  
        canSaveDynamicFields = "1";  
        Position = %textPos;
        SortPoint = "-0.161 -0.631";
        size = "48.000 3.000";  
        font = %this.Font;  
        text = "(Press \"C\" to hear the message again)";
        wordWrap = "1";  
        BlendColor = %this.blendColor;  
        hideOverflow = "0";  
        textAlign = %this.align;  
        lineHeight = %this.LineY;  
        aspectRatio = "1";  
        lineSpacing = "0";  
        characterSpacing = %this.Spacing;  
        autoSize = "0";  
        fontSizes = %this.size;  
        textColor = %this.blendColor;
        bilinearFilter = "0";  
        snapToInteger = "0";  
        noUnicode = "0";  
        hideOverlap = "0";  
        mountID = "174";  
      _behavior0 = "ScaleBehavior\txWidthMin\t0.001\tyWidthMin\t0.001\txWidthMax\t48\tyWidthMax\t3\tTime\t0.1\tgrow\t1";
    };
}

}

function SpeechDisplayBehavior::getSpeaker(%this)
{
%this.Speaker = $game::player.lastInteracted;
return %this.Speaker;
}

function SpeechBubble::onAddToScene(%this)   
{   
	%this.SpeechPos = SpeechDisplayBehavior.SpeechDest;   
}   

function SpeechText::onAddToScene(%this)   
{   
	%YPOS = speechDisplayBehavior.Speaker.Position.Y - 8;   
	speechDisplayBehavior.TextPos = speechDisplayBehavior.Speaker.position.X SPC %YPOS;   
}

function SpeechDisplayBehavior::onAddToScene( %this, %scenegraph )
{
%this.nextText[1] = %this.BlurbText;
%this.nextText[2] = %this.BlurbText2;
%this.nextText[3] = %this.BlurbText3;
%this.nextText[4] = %this.BlurbText4;
%this.nextText[5] = %this.BlurbText5;
%this.nextText[6] = %this.BlurbText6;
%this.nextText[7] = %this.BlurbText7;
%this.nextText[8] = %this.BlurbText8;
%this.nextText[9] = %this.BlurbText9;
%this.nextText[10] = %this.BlurbText10;
%this.nextText[11] = %this.BlurbText10;
%this.nextText[12] = %this.BlurbText10;
%this.nextText[13] = %this.BlurbText10;
%this.nextText[14] = %this.BlurbText10;
%this.nextText[15] = %this.BlurbText10;

%this.Alternate[A1] = %this.AlternateA1;
%this.Alternate[A2] = %this.AlternateA2;
%this.Alternate[A3] = %this.AlternateA3;

%this.Alternate[B1] = %this.AlternateB1;
%this.Alternate[B2] = %this.AlternateB2;
%this.Alternate[B3] = %this.AlternateB3;

%this.Alternate[C1] = %this.AlternateC1;
%this.Alternate[C2] = %this.AlternateC2;
%this.Alternate[C3] = %this.AlternateC3;


    if ( %this.PlayerOnly )
    {
        %this.Owner.setObjectType( "PlayerTrigger" );
        %this.Owner.setCollidesWith( "PlayerObject" );
    }
    else
    {
        %this.Owner.setObjectType( "ActorTrigger" );
        %this.Owner.setCollidesWith( "ActorObject" );
    }
}

function SpeechDisplayBehavior::SpeedUp(%this)
{
//%this.speedUp = 1;
}

function SpeechDisplayBehavior::onEnter( %this, %theirObject )
{
$game::player.insideTrigger = 1;

if(%this.CanTalk)
{
%this.canTalk = 0;
GlobalActionMap.unbindObj("keyboard", "T", %this);
%this.speedUp = 0;
%this.speechLine = 0;
echo("Speech line modified! - OnEnter <" @ %this.speechLine @ ">");
GlobalActionMap.bindObj("keyboard", "Shift", "SpeedUp", %this);

$isCanceled = 0;

echo("Entered Area...");
%theirObject.lastInteracted = %this.owner;
%this.getSpeaker();
%this.typewriterText();
%this.BlurbSpawn();


    if( !$game::player.FlipX )
    {
    %this.TargetSpeaker.FlipX = 1;
    }
    else
    {
    %this.TargetSpeaker.FlipX = 0;
    }

//%this.Owner.safeDelete();
if(%this.BlurbText $= "Hi!")
{
%this.SpeechLine = 1;
%this.NextLine();
}
}
else
{
GlobalActionMap.bindObj("keyboard", "T", "readyToTalk", %this);
}
}

function SpeechDisplayBehavior::readyToTalk(%this)
{
if($game::player.insideTrigger && !%this.isRenderingLine)
{
%this.canTalk = 1;
%this.onEnter();
}
}

function SpeechDisplayBehavior::typewriterText(%this)  
{  
	GlobalActionMap.unbindObj(keyboard, "C", %this);

$game::player.Controller.Direction = "0 0";
$Game::player.MoveSpeed = "0 0";
$game::player.setLinearVelocityX( 0 );
$game::player.setLinearVelocitY( 0 );
//Store speed

$game::player.maxMoveSpeed = 0;
moveMap.pop();



if(%this.numLines >= %this.SpeechLine)
{

    %len = strlen(%this.BlurbText);
    for (%i = 1; %i <= %len; %i++)  
    {
        if(!$isCanceled)
        {
        %tempStr = getSubStr(%this.BlurbText, 0, %i);
            
            //if(%this.SpeedUp = 1)
            //{
            //%num2 = %this.timer / 2;
            //%time = %i * %num2;
            //}
            //else
            //{
            %time = %i * %this.timer;
            //}

        %this.schedule(%time, "updateText", %tempStr);
        }
    }
%doneTime = %this.timer * strlen(%this.BlurbText);
%this.doneevent = %this.schedule(%Donetime, "TextDone");
}

}

function SpeechDisplayBehavior::updateText(%this, %string)  
{
if( isObject ( %this.Blurb ) )
{
    %this.isRenderingLine = 1;
    %bingSound = $bing[getRandom(1,7)];
    %this.SpText.text = %string;
    //echo(%this.SpText.text);
    playsound(%this.TalkSound);
}
}


function SpeechDisplayBehavior::onleave( %this, %theirObject, %string )
{
$game::player.insideTrigger = 0;

moveMap.Push();
%string = "";
$isCanceled = 1;
%event = %this.doneEvent;
cancel(%event);
stopSound(talk);

%this.Blurb.safeDelete();
%this.SPText.safeDelete();

    if( !$game::player.FlipX )
    {
    %this.TargetSpeaker.FlipX = 1;
    }
    else
    {
    %this.TargetSpeaker.FlipX = 0;
    }
	GlobalActionMap.unbindObj(keyboard, "C", %this);

%this.speechLine = 0;
echo("Speech line modified! - OnLeave <" @ %this.speechLine @ ">");
%this.readyToTalk = 0;
}

function SpeechDisplayBehavior::textDone(%this)
{
Warn("Speech done!");
%this.isRenderingLine = 0;


    playsound(%this.TalkDoneSound);

$game::player.MaxMoveSpeed = 80;
moveMap.push(); 



if(%this.speechLine < 1)
{
%this.speechLine = 1;
error("Continue, but speech line is now at " @ %this.speechLine @ ". - TextDone");
}


GlobalActionMap.bindObj("keyboard", "C", "nextLine", %this);
echo("Initial Speech line! <" @ %this.speechLine @ ">");

if(%this.APoint == %this.SpeechLine)
{
echo("TextDone: " @ %this.APoint @ ". And the Line # is: " @ %this.SpeechLine);
canvas.pushdialog(BlurbOpsGui);
%this.DeleteBubble();

if(%this.threeOpts)
{
Opt2.Visible = true;
%numPoint = "3.";
}
else
{
Opt2.Visible = false;
%numPoint = "2.";
}

Opt1.setText("1. " @ %this.Opt1Text);
Opt2.setText("2. " @ %this.Opt2Text);
Opt3.setText(%numPoint SPC %this.Opt3Text);

GlobalActionMap.bindObj("keyboard", "1", "Opt1", %this);
GlobalActionMap.bindObj("keyboard", "2", "Opt2", %this);
GlobalActionMap.bindObj("keyboard", "3", "Opt3", %this);

}

}

function SpeechDisplayBehavior::DeleteBubble(%this)
{
    %this.Blurb.safeDelete();
    %this.SpText.safeDelete();
}

function speechDisplayBehavior::nextLine( %this )   
{   
if(!%this.isRenderingLine)
{
%this.speechLine += 1;

echo("Speech line modified! - nextLine <" @ %this.speechLine @ ">");

if(%this.numLines >= %this.speechLine && !%this.numLines < %this.speechLine && %this.numLines != 1 && %this.speechLine != 1)
{

		%this.SpText.text = "";
		%this.blurbText = %this.NextText[%this.speechLine];
		%this.schedule(0, "typewriterText");

}
else
{
    if(%this.speechLine = 1)
    {
	error("First line!");
    GlobalActionMap.unbindObj(keyboard, "C", %this);
    if(%this.APoint != -1)
    {
//    call(%this.DoneFunction);
    }
    }

    if(%this.speechLine > %this.numLines)
    {
    error("Done.");
    }

}
}
}

function SpeechDisplayBehavior::getChoice(%this)
{
//We're going to have to run a different Typewriter text thingy right now because the other one probably wouldn't work...
%this.BlurbSpawn();
%this.WriteAlternate();
}

function SpeechDisplayBehavior::writeAlternate(%this)
{
%this.alternateLine = 1;
%this.typewriterAltText();
}

function SpeechDisplayBehavior::typewriterAltText(%this)
{
GlobalActionMap.unbindObj("keyboard", "C", %this);

$game::player.Controller.Direction = "0 0";
$Game::player.MoveSpeed = "0 0";
$game::player.setLinearVelocityX( 0 );
$game::player.setLinearVelocitY( 0 );
//Store speed
$game::player.maxMoveSpeed = 0;
moveMap.pop();


if(%this.aNumLines >= %this.AlternateLine)
{

        %this.AlternateText = %this.Alternate[%this.Choice @ %this.AlternateLine];

    warn("TypwriterAltText, AlternateText - " @ %this.alternateText);
    %len = strlen(%this.AlternateText);
    for (%i = 1; %i <= %len; %i++)  
    {
        if(!$isCanceled)
        {
        %tempStr = getSubStr(%this.AlternateText, 0, %i);
            
            //if(%this.SpeedUp = 1)
            //{
            //%num2 = %this.timer / 2;
            //%time = %i * %num2;
            //}
            //else
            //{
            %time = %i * %this.timer;
            //}

        %this.schedule(%time, "updateAltText", %tempStr);
        }
    }
%doneTime = %this.timer * strlen(%this.AlternateText);
%this.NewDoneEvent = %this.schedule(%Donetime, "AltTextDone");
}
}

function SpeechDisplayBehavior::updateAltText(%this, %string)  
{
if( isObject ( %this.Blurb ) )
{
    %this.isRenderingLine = 1;
    %bingSound = $bing[getRandom(1,7)];
    %this.SpText.text = %string;
    error(%this.SpText.text);
    playsound(%this.talkSound);
}
}

function SpeechDisplayBehavior::AlttextDone(%this)
{
Warn("Speech done!");
%this.isRenderingLine = 0;

playSound(%this.TalkDoneSound);

$game::player.MaxMoveSpeed = 80;
moveMap.push();



if(%this.AlternateLine < 1)
{
%this.AlternateLine = 1;
error("Continue, but speech line is now at " @ %this.speechLine @ ". - TextDone");
}


GlobalActionMap.bindObj("keyboard", "C", "nextAltLine", %this);
echo("Initial Speech line! <" @ %this.alternateLine @ ">");
}

function speechDisplayBehavior::nextAltLine( %this )   
{   
if(!%this.isRenderingLine)
{
%this.AlternateLine += 1;

warn("Alt speech line modified! - nextLine <" @ %this.AlternateLine @ ">");

if(%this.AnumLines >= %this.AlternateLine && !%this.AnumLines < %this.AlternateLine && %this.AnumLines != 1 && %this.AlternateLine != 1)
{
		%this.SpText.text = "";
        %this.AlternateText = %this.Alternate[%this.Choice @ %this.AlternateLine];
		%this.schedule(0, "typewriterAltText");

}
	else  
	{   
		if(%this.AlternateLine = 1)   
		{   
			warn("First alternate line!");   
        	GlobalActionMap.unbindObj(keyboard, "C", %this);
            call(%this.Donefunction);
        }


        if(%this.AlternateLine > %this.AnumLines)
        {
        warn("Alt done.");
        }

    }
}
}

function SpeechDisplayBehavior::Opt1(%this)
{
echo("Option one, clicked.");
%this.choice = "A";
%this.getChoice();
canvas.popdialog(blurbOpsGui);
GlobalActionMap.unbindObj(keyboard, "1", %this);
GlobalActionMap.unbindObj(keyboard, "2", %this);
GlobalActionMap.unbindObj(keyboard, "3", %this);
}

function SpeechDisplayBehavior::Opt2(%this)
{
if(%this.threeOpts)
{
warn("Option two, clicked.");
%this.choice = "B";
%this.getChoice();
canvas.popdialog(blurbOpsGui);
GlobalActionMap.unbindObj(keyboard, "1", %this);
GlobalActionMap.unbindObj(keyboard, "2", %this);
GlobalActionMap.unbindObj(keyboard, "3", %this);
}
}

function SpeechDisplayBehavior::Opt3(%this)
{
error("Option three, clicked.");
%this.choice = "C";
%this.getChoice();
canvas.popdialog(blurbOpsGui);
GlobalActionMap.unbindObj(keyboard, "1", %this);
GlobalActionMap.unbindObj(keyboard, "2", %this);
GlobalActionMap.unbindObj(keyboard, "3", %this);
}