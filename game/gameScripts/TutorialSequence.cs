function TS1()
{
canvas.pushDialog(TutorialGui);
TText.setText($TS1);
}

function TS2()
{
TText.setText($TS2);
}

function TS3()
{
TText.setText($TS3);
}

function TS4()
{
TText.setText($TS4);
}

function TS5()
{
TText.setText($TS5);
}

function TS6()
{
TText.setText($TS6);
}

function TS7()
{
TText.setText($TS7);
}

function TS8()
{
TText.setText($TS8);
}

function WLJf()
{
TText.setText($WLJf);
}

function TS9()
{
TText.setText($TS9);
}

function TS10()
{
TText.setText($TS10);
}

function TS11()
{
TText.setText($TS11);
}

function TS11a()
{
TText.setText($TS11a);
}

function TS12()
{
TText.setText($TS12);
}

function TS13()
{
TText.setText($TS13);
}

function TS14()
{
TText.setText($TS14);
}

function TS15()
{
TText.setText($TS15);
}

function TS16()
{
TText.setText($TS16);
}

function TS17()
{
TText.setText($TS17);
}

function TS18()
{
TText.setText($TS18);
}

function TS19()
{
TText_I.setText($TS19);
schedule(10000, 0, "PopTutorialGui");
}


$TS1 = "Hello! Welcome to HandDrawn. This tutorial will walk you through the basics of the gameplay.";

$TS2 = "Ahead you will see a Monstrosity. They move slowly and you can hear them coming. If they touch you, you will lose a few hearts. Shoot or stomp on them to eliminate, although stomping is more effective. Also, some enemies don't take off damgae in tens. You can see how much of each heart you have.";

$TS3 = "If you are hurt, a Fragmentation will restore some health.";

$TS4 = "Some platforms will move by themselves. They allow you to gain access to higher areas. Others are static, and even more allow you to jump from below them to the surface. With those types of platforms, if you hold the \"down\" button and press space, you will fall through them.";

$TS5 = "You can wall jump! Simply jump against a wall and while holding a keyboard direction key, (such as A or D), press the jump button. Try to walk jump on the indicated areas.";

$TS6 = "You have just collected a checkpoint marker. When you die, you will respawn here. This does not persist across all levels, though.";

$TS7 = "Gliding is a really useful ability. If you jump and hold the space bar, you will pull out your parachute. You can only use the parachute for a few seconds before you fall. To get the most out of it, be strategic with the amount of seconds you wait before usage!";

$TS8 = "This part\'s fun. All you need to do is collect the power up. Then you will able to cover ground much faster!";

$TS9 = "When you step into that blue area, you will be teleported to a different location. Some portals can work two ways but this one will only send you and not receive.";

$TS10 = "Don\'t linger on these platforms ahead! They\'ll fall from under you. Fortunately, you have the right kit. Use the speed power up but don\'t overdo it.";

$TS11 = "There was a person who thought it was a good idea to stand on shrinking platforms. He should be bellow somewhere. Follow his example to join him.";

$TS11a = "You knew I was joking, right?";

$TS12 = "Rotating platforms. They rotate. What did you expect?";

$TS13 = "Rotating and falling and shrinking… oh my!";

$TS14 = "Here\'s a tip: don't try this too fast. Jump on the platforms one by one or wall jump to the top. Jump just as your target has fully shrunken.";

$TS15 = "The power up you just collected will give you super traction in both the air and ground for exactly a minute. Use it to aid your ascent!";

$TS16 = "This is a gravity modification zone. The amount of gravity here will be different. You probably won\'t see much of this in the levels in the near future. This is low-gravity zone. Oh, and by the way: watch out for hurtling platforms.";
$TS17 = "Wait for a platform to take you to another warp point! Try not to fall off when you are riding.";
$TS18 = "You've just completed the tutorial! You now know a few of the basics.";


//Inverted Zone...

$TS19 = "Me again! Welcome to the invert zone, where colors are inverted. I know that the oposite of blue isn't green, but I decided green looked better over a sort of disgusting sepia-borwn shade so I went ahead and made green be the color of this message. I also just thought I\'d tell you not to stick around those Vert monsters for too long after you kill them. JSYK—they explode! Enjoy!";

function popTutorialGui()
{
    canvas.popDialog(tutorialGui);
    canvas.popDialog(tutorial_IGui);
}
