//-----------------------------------------------------------------------------
// Platformer Starter Kit
// Copyright (C) - Phillip O'Shea
//  
// Player Methods - A player is an Actor with a Player controller. The methods
//                  in this file make the game know what to do with a player.
//                  Adding specific methods to object classes gives more
//                  variety and control to the game.
//-----------------------------------------------------------------------------

/// Mount the camera and update the gui

function newTimer(%time, %callback, %text)
{
// Kill any existing timers...
killTimer();
canvas.pushDialog(TimerGui);
warn("Initiated Timer... ");
$Timing = 1;
$TimerPaused = 0;
StartTiming(%time, %callback, %text);
}

function startTiming(%time, %callback, %text)
{
if($timing)
{
if(!$timerPaused)
{
echo(%time SPC %callback SPC %text @ " Running at a time of " @ $time);
    if(%time > 0)
    {
    playSound(TickTock);
    echo("Time isn't 0!!!");
    %time -= 1;
    TimerText.setText(%text SPC %time);
    %TimeEvent = schedule(1000, 0, "startTiming", %time, %callback, %text);
    }
    else
    {
    error("Time IS 0!!!");
    playsound(error);
    schedule(0, 0, %callback);
    canvas.schedule(0, 0, "popDialog", "timerGui");
    $timing = 0;
    }
    
    if(%time <= 10)
    {
    playSound(bing5);
    }
    
    if(%time <= 3)
    {
    playSound(bing3);
    }
}
else
{
schedule(32, 0, "startTiming", %time, %callback, %text);
}
}
}

function pauseTimer()
{
$timerPaused = 1;
warn("Paused timer.");
}

function unPauseTimer()
{
$timerPaused = 0;
warn("Unpaused timer.");
}

function killTimer()
{
$timing = 0;
canvas.popDialog(TimerGui);
error("Stopped Timer.");
}

function getXP()
{
//Then, we set the text.

SubTotal.setText($pref::points);
LivesFactor.setText($game::player.lives);
LevelFactor.setText($levelNumber);

//Let's get these variables next...

$totalEarnings = $game::player.lives + $levelNumber  * 1000 + $pref::points;
TotalEarnings.setText($TotalEarnings);
$pref::points = $totalEarnings;
}

function PlayerClass::enterMyCustomAnimationState( %this )
{
    // In this function, all you need to do is return the name
    // of the Animation datablock that you would like to transition to
    // and the engine will take care of the rest.
    return CrouchAnimation;
}		   

function PlayerClass::executeMyCustomAnimationState( %this )
{
Echo("SJFKASJHFKJSAHKSADHSKAJDHSA");

    return "NULL";
}
function PlayerClass::onAddToScene( %this, %scenegraph )
{


    Parent::onAddToScene( %this, %scenegraph );
    %this.frostbitten = 0;

    stopSwimming();
    
    if($ReverseLevel)
    {
    mountRevert();
    }

    if($snowLevel)
    {
    mountSnow();
    }

    %this.initAbilities();

    if($game::player.isSwimming)
    {
    alxSourcef($musicHandle2, "AL_GAIN", 1);
    
    }
    else
    {
    alxSourcef($musicHandle2, "AL_GAIN", 0);
    }

    %this.Gravity = "0 140";
    %this.Controller.Direction = "0 0";

    %this.MountCamera();
    
    %this.updateExtraLivesGui();
    %this.updateHealthGui();
    %this.enableUpdateCallback();
    // Initialise Inventory.
    canvas.pushdialog(MouseOverlayGui);

}

function PlayerClass::onUpdate( %this )
{
//Nothing here...
}

function PlayerClass::onReload( %this, %trigger )
{
    // Parent Call.
    Parent::onReload( %this, %trigger );
    
    // Update GUI.
    %this.updateWeaponGui();
}

/// Mount the camera if required
function PlayerClass::onLevelLoaded( %this )
{


    // If you add the player straight into the scene and not through a spawner,
    // then you need to wait until the level has been loaded to mount the
    // camera.
    %this.mountCamera();
    %this.Controller.Direction = "0 0";
    $timing = 0;
}

/// Called when the player lands on a platform
function PlayerClass::onLanded( %this, %platformObject )
{
    if ( isObject( DragonLandSound ) )
    {
        %this.playSound( DragonLandSound );
    }

        if(!%this.isswimming && %this.linearVelocity.Y >= 200)
        {
        //Store velocity...
        %ammount = $game::player.linearVelocity.Y / 4;
        %this.takeDamage(%ammount, %this, true, true);
        }
}

function PlayerClass::onFall(%this)
{
echo("Falling!");
%this.SmoothRotation();
}

function playerClass::jumpUp(%this)
{
%this.getanimationpuppet().autorotation = 20;
}

function PlayerClass::smoothRotation(%this)
{
%this.autorotation = 0;
if(%this.getAnimationPuppet().rotation > 0)
{
%this.getAnimationPuppet().rotation -= 1;
%this.schedule(3, "smoothRotation");
}
}


function IceBlockEffect::onLanded( %this, %platformObject )
{
%this.rotation = %platformObject.rotation;
}

/// Called when the player is healed
function PlayerClass::onHeal( %this, %hAmount )
{
    %this.updateHealthGui();
}

/// Called when the player/enemy is damaged
function DrillClass::onDamage( %this, %dAmount )
{
%AIHealth = %this.health / 100;

EnemyHealthBar.setValue(%AIHealth);
echo("Hello, my name is " @ %this);
%puppet = %this.getAnimationPuppet();
CurrentEnemy.setSceneObject(%puppet);
}


function SnakeClass::onDamage( %this, %dAmount )
{
%AIHealth = %this.health / 100;

%theirObject.wasHurtByPlayer = 1;


EnemyHealthBar.setValue(%AIHealth);
//echo("Hello, my name is " @ %this);
%puppet = %this.getAnimationPuppet();
CurrentEnemy.setSceneObject(%puppet);
}

function PlayerClass::onDamage( %this, %dAmount )
{
    HudVisible();
    %this.updateHealthGui();
    isHurt();
    popHurtGui();
    }

/// Called when a player dies
function PlayerClass::onDeath( %this, %dAmount, %srcObject )
{
HudVisible();
//Splat!
if(!%this.inAir && %this.onGround && %this.linearVelocity.Y = 0)
{
%this.DisableGravity = true;
%this.immovable = true;
}
else
{
%this.getanimationpuppet().angularvelocity = 500;
%this.setanimationstate("fall");
}

stopSwimming();
ClearRegen();
SZBehavior.onLeave("", "$game::player", 1);
//


$pref::points = $pref::points - 25;

    // Dismount the camera

    getLivesStatus();

    // Bounce the player
    //%this.bounce( %this.JumpForce, 180 );

    // Update the gui
    %this.updateExtraLivesGui();
    %this.updateHealthGui();

    %TextSprite = new t2dTextObject()
    {
        SceneGraph    = Scenewindow2D.getSceneGraph();
      canSaveDynamicFields = "1";
      Position = %This.Position;
      size = "14.758 4.920";
      text = "-75";
      font = "OCR A Std";
      wordWrap = "1";
      hideOverflow = "1";
      textAlign = "Left";
      lineHeight = "4.91946";
      aspectRatio = "1.15903";
      lineSpacing = "0";
      characterSpacing = "0";
      autoSize = "0";
      fontSizes = "42";
      BlendColor = "1 0 0 1";
      bilinearFilter = "1";
      snapToInteger = "0";
      lifetime = "2.0";
      noUnicode = "0";
         hideOverlap = "0";
         mountID = "794";
         snapToIntegerPos = "0";
      _behavior0 = "ScaleBehavior	xWidthMin	0.001	yWidthMin	0.001	xWidthMax	15	yWidthMax	5	Pulse	1";
     ConstantForce = "0 50";
    };

dismountCamera();

}

/// Called when a player respawns
function PlayerClass::onRespawn( %this )
{


    // Load the checkpoint data

    %this.getanimationpuppet().angularvelocity = 0;
    %this.getanimationpuppet().rotation = 0;

    %this.DisableGravity = false;
    %this.immovable = false;

    loadCheckPoint();

    // Remount the camera
    %this.mountCamera();

    // Update the gui
    %this.updateExtraLivesGui();
    %this.updateHealthGui();
}

function PlayerClass::onGameOver( %this )
{
    // No more lives left!
    gameOver();
}

/// Called when a player collides with an enemy.
function PlayerClass::resolveEnemyCollision( %ourObject, %theirObject, %normal )
{
    // Resolve the collisions differently for different ai types
    switch$ ( %theirObject.ActorType )
    {
        case "Drill" : %ourObject.resolveDrillCollision( %theirObject, %normal ); break;
        case "Sub" : %ourObject.resolveSubCollision( %theirObject, %normal ); break;
        case "Snake" : %ourObject.resolveSnakeCollision( %theirObject, %normal ); break;
        case "Snapper" : %ourObject.resolveScrapperCollision( %theirObject, %normal ); break;
        case "Scrapper" : %ourObject.resolveSnapperCollision( %theirObject, %normal ); break;
        case "Bool" : %ourObject.resolveBoolCollision( %theirObject, %normal );

    }
}

function PlayerClass::resolveSubCollision( %ourObject, %theirObject, %normal )
{
    // Get the contact angle
    %angle = mRadToDeg( mAtan( -%normal.X, %normal.Y ) );
    %angle = mAbs( %angle ) % 360;

    // Check if we've hit the drill properly
    if ( (%angle <= 40 || %angle >= 360 - 40 )
        && %ourObject.LinearVelocity.Y > %theirObject.LinearVelocity.Y
        && %ourObject.Position.Y < %theirObject.Position.Y )
    {
        // Do damage to the drill and bounce the player
        %theirObject.takeDamage( %theirObject.Health, %ourObject, true, true );

        // Stop them from moving
        %theirObject.Direction = "0.0 0.0";
        %theirObject.Gravity   = "0.0 0.0";

        %ourObject.bounce( %ourObject.JumpForce / 2, 180 );
    }
    else
    {
        // Do damage to the player
        %ourObject.takeDamage( 10, %theirObject, true, false );
        if ( %ourObject.isMethod( "onAreaDamage" ) )
        {
            %ourObject.onAreaDamage( %ourObject, %normal );
        }
        %ourobject.frostbite(%theirObject);
    }
}

function PlayerClass::frostbite(%this, %meanie)
{
if(!%this.frostbitten)
{
        %this.FrostEffect = new t2dParticleEffect()
    {
      scenegraph = scenewindow2d.getSceneGraph();
      effectFile = "~/data/particles/FrozenStuffBlue.eff";
      useEffectCollisions = "1";
      effectMode = "KILL";
      effectTime = "4000";
      canSaveDynamicFields = "1";
      rotation = %this.getAnimationPuppet().rotation;
      Position = %this.position;
      size = "5.000 5.000";
      Layer = %theirObject.layer - 1;
      CollisionMaxIterations = "1";
             mountID = "224";
    };

    %link = %this.FrostEffect.mount(%this, "0 0");
    %this.FrostEffect.playEffect(true);
    %this.FrostEffect.isPlaying = true;
    
%this.frostBitten = 1;
%this.schedule(0, "takeDamage", 5, %meanie, true, true);
%this.schedule(1000, "takeDamage", 5, %meanie, true, true);
%this.schedule(2000, "takeDamage", 5, %meanie, true, true);
%this.schedule(3000, "takeDamage", 5, %meanie, true, true);
%this.schedule(4000, "takeDamage", 5, %meanie, true, true);
%this.schedule(4000, "notFrostbitten");
}
}

function PlayerClass::notFrostBitten(%this)
{
%this.frostEffect.safeDelete();
%this.frostbitten = 0;
}

function PlayerClass::resolveBoolCollision( %ourObject, %theirObject, %normal )
{
    // Get the contact angle
    %angle = mRadToDeg( mAtan( -%normal.X, %normal.Y ) );
    %angle = mAbs( %angle ) % 360;

    // Check if we've hit the drill properly
    if ( (%angle <= 40 || %angle >= 360 - 40 )
        && %ourObject.LinearVelocity.Y > %theirObject.LinearVelocity.Y
        && %ourObject.Position.Y < %theirObject.Position.Y )
    {
        // Do damage to the drill and bounce the player
        %theirObject.takeDamage( %theirObject.Health, %ourObject, true, true );

        // Stop them from moving
        %theirObject.Direction = "0.0 0.0";
        %theirObject.Gravity   = "0.0 0.0";

        %ourObject.bounce( %ourObject.JumpForce / 2, 180 );
    }
    else
    {
        // Do damage to the player
        %ourObject.takeDamage( 10, %theirObject, true, false );
        if ( %ourObject.isMethod( "onAreaDamage" ) )
        {
            %ourObject.onAreaDamage( %ourObject, %normal );
        }
    }
}


function KillPlayer()
{
$game::player.takeDamage( 1000, "NaturalCauses", true, false );
}

/// Called upon collision with a drill type enemy
function PlayerClass::resolveDrillCollision( %ourObject, %theirObject, %normal )
{
%AIHealth = %theirObject.health / 100;

EnemyHealthBar.setValue(%AIHealth);

    // Get the contact angle
    %angle = mRadToDeg( mAtan( -%normal.X, %normal.Y ) );
    %angle = mAbs( %angle ) % 360;

    // Check if we've hit the drill properly
    if ( (%angle <= 40 || %angle >= 360 - 40 )
        && %ourObject.LinearVelocity.Y > %theirObject.LinearVelocity.Y
        && %ourObject.Position.Y < %theirObject.Position.Y )
    {
        // Do damage to the drill and bounce the player
        %theirObject.takeDamage( %theirObject.Health, %ourObject, true, true );

        // Stop them from moving
        %theirObject.Direction = "0.0 0.0";
        %theirObject.Gravity   = "0.0 0.0";

        %ourObject.bounce( %ourObject.JumpForce / 2, 180 );
    

    }
    else
    {
        // Do damage to the player
        %ourObject.takeDamage( 35, %theirObject, true, false );
    }
}


function PlayerClass::resolveSnapperCollision( %ourObject, %theirObject, %normal )
{
%AIHealth = %theirObject.health / 100;

EnemyHealthBar.setValue(%AIHealth);

    // Get the contact angle
    %angle = mRadToDeg( mAtan( -%normal.X, %normal.Y ) );
    %angle = mAbs( %angle ) % 360;

    // Check if we've hit the drill properly
    if ( (%angle <= 40 || %angle >= 360 - 40 )
        && %ourObject.LinearVelocity.Y > %theirObject.LinearVelocity.Y
        && %ourObject.Position.Y < %theirObject.Position.Y )
    {
        // Do damage to the drill and bounce the player
        //%theirObject.takeDamage( %theirObject.Health, %ourObject, true, true );

        // Stop them from moving
        //%theirObject.Direction = "0.0 0.0";
        //%theirObject.Gravity   = "0.0 0.0";

        %ourObject.bounce( %ourObject.JumpForce / 2, 180 );
    

    }
    else
    {
        // Do damage to the player
        %ourObject.takeDamage( 35, %theirObject, true, false );
    }
}

function PlayerClass::resolveScrapperCollision( %ourObject, %theirObject, %normal )
{
%AIHealth = %theirObject.health / 100;

EnemyHealthBar.setValue(%AIHealth);

    // Get the contact angle
    %angle = mRadToDeg( mAtan( -%normal.X, %normal.Y ) );
    %angle = mAbs( %angle ) % 360;

    // Check if we've hit the drill properly
    if ( (%angle <= 40 || %angle >= 360 - 40 )
        && %ourObject.LinearVelocity.Y > %theirObject.LinearVelocity.Y
        && %ourObject.Position.Y < %theirObject.Position.Y )
    {
        // Do damage to the drill and bounce the player
        //%theirObject.takeDamage( %theirObject.Health, %ourObject, true, true );

        // Stop them from moving
        //%theirObject.Direction = "0.0 0.0";
        //%theirObject.Gravity   = "0.0 0.0";

        %ourObject.bounce( %ourObject.JumpForce / 2, 180 );
    

    }
    else
    {
        // Do damage to the player
        %ourObject.takeDamage( 35, %theirObject, true, false );
    }
}



function PlayerClass::resolveSnakeCollision( %ourObject, %theirObject, %normal )
{
%AIHealth = %theirObject.health / 100;

EnemyHealthBar.setValue(%AIHealth);


    // Get the contact angle
    %angle = mRadToDeg( mAtan( -%normal.X, %normal.Y ) );
    %angle = mAbs( %angle ) % 360;

    // Check if we've hit the drill properly
    if ( (%angle <= 40 || %angle >= 360 - 40 )
        && %ourObject.LinearVelocity.Y > %theirObject.LinearVelocity.Y
        && %ourObject.Position.Y < %theirObject.Position.Y )
    {
        // Do damage to the drill and bounce the player
        %theirObject.takeDamage( %theirObject.Health, %ourObject, true, true );

        // Stop them from moving
        %theirObject.Direction = "0.0 0.0";
        %theirObject.Gravity   = "0.0 0.0";

        %ourObject.bounce( %ourObject.JumpForce / 4, 180 );

    }
    else
    {
        // Do damage to the player
        %ourObject.takeDamage( 35, %theirObject, true, false );
        if ( %ourObject.isMethod( "onAreaDamage" ) )
        {
            %ourObject.onAreaDamage( %ourObject, %normal );
        }
    }
}

function PlayerClass::onAreaDamage( %this, %theirObject, %normal )
{
    // Get the contact angle
    %angle = mRadToDeg( mAtan( -%normal.Y, %normal.X ) );
    %angle = mAbs( %angle ) % 360;

    %this.bounce( %this.JumpForce, %angle - 90 );
}

/// Update the health interface
function PlayerClass::updateHealthGui( %this )
{
    //Update the bar
    %HealthBar = %this.Health / 100;

    HealthBar.setValue(%HealthBar);
    
    // Update Peppers.
    %pepperCount = mFloor( %this.Health / 10 );
    for ( %i = 0; %i < 10; %i++ )
    {
        %ghostVisible = !( %i < %pepperCount );

        if ( isObject( "ghostPepper" @ 9 - %i ) )
        {
            eval ( "ghostPepper" @ 9 - %i @ ".Visible = %ghostVisible;" );
        }

        if ( isObject( "pepper" @ 9 - %i ) )
        {
            eval ( "pepper" @ 9 - %i @ ".Visible = !%ghostVisible;" );

        }
    }
    
    // Update Extra Lives.
    %this.updateExtraLivesGui();
}

/// Update the extra life interface
function PlayerClass::updateExtraLivesGui( %this )
{
    // Update Extra Lives.
    if ( isObject( ExtraLivesCounter ) )
    {
        ExtraLivesCounter.Text = %this.Lives;

        if ( %this.Lives < 10 )
        {
            ExtraLivesCounter.Text = 0 @ %this.Lives;
        }
    }
}

/// Update the weapon interface
function PlayerClass::updateWeaponGui( %this )
{
    %guiControl[0] = PrimaryAmmoGui;
    %guiControl[1] = SecondaryAmmoGui;
    
    %weapon      = %this.ActiveWeapon;
    %actionCount = %weapon.ActionCount;
    for ( %i = 0; %i < %actionCount; %i++ )
    {
        %ammo = %weapon.Action[%i].Ammunition;
        if ( isObject( %ammo ) && isObject( %guiControl[%i] ) )
        {
            %guiControl[%i].setText( strreplace( trim( %this.getFieldValue( %ammo.getName() ) ), " ", " | " ) );
        }
    }
}

//-----------------------------------------------------------------------------
// Dragon Player Methods
//-----------------------------------------------------------------------------

function DragonPlayer::initInventory( %this )
{
    // Parent Call.
    PlayerClass::initInventory( %this );
    
    // Shoot Fireballs.

}

//-----------------------------------------------------------------------------
// Caveman Player Methods
//-----------------------------------------------------------------------------

function CavemanPlayer::initInventory( %this )
{
    // Parent Call.
    PlayerClass::initInventory( %this );
    
    // Shoot Bones.
    //%this.setActiveWeapon( BoneLauncherWeapon );
}

function popHurtGui()
{
schedule(3000, 0, "StopHurt");
}

function StopHurt()
{
canvas.popdialog(HurtGui);
}

function isHurt()
{
_newFadeSequence(" 300 0 0 ", "nulltime();");
canvas.pushDialog(hurtGui);
}

function nulltime()
{
//This is here to do nothing
}

function getLivesStatus( %this )
{
	if (%this.Lives == 1)
	{
	canvas.pushDialog(OneTryLeftGui);
	schedule(5000, 0, "pop1moretry");
	}
	else
	{
	canvas.popDialog(OneTryLeftGui);
	}
}

function pop1moretry()
{
canvas.popDialog(OneTryLeftGui);
}

function PlayerClass::ClearOnWall(%this)
{
%this.onWall = false;
}

/// Called when a player collides with a wall.  
function PlayerClass::hitWall( %ourObject, %theirObject, %normal )  
{  
    if (%ourObject.onGround)  
    {  
        %ourObject.onWall = false;  
    }  
    else
    {  
        //Only change to FallAgainstWall when we are falling.  
        if (getWord( %ourObject.LinearVelocity, 1) > 0){  
            //Reset jump so we can jump off the wall  
            
            if(!$game::player.isSwimming && %this.canWallLeap)
            {

            if ( %ourObject.onWall != true ){
                %ourObject.jump = false;  
            }  
            %ourObject.onWall = true;  
            //Get direction of platform  
            if ( %theirObject.getPosition.X > %ourObject.getPosition.X)
            {  
                %ourObject.onWallDirection = 1;  
            }  
            else
            {  
                %ourObject.onWallDirection = -1;  
            }  
            %ourObject.setAnimationState( "FallAgainstWall" );  
            }
        }
    }  
}  

function PlayerClass::initAnimationStates( %this )
{
    %temp = %this.ActorType;

     %this.registerAnimationState( "shoot", %temp @ "ShootAnimation" );
     %this.registerAnimationState( "shootRun", %temp @ "ShootRunAnimation" );
     %this.registerAnimationState( "shootJump", %temp @ "ShootJumpAnimation" );
     %this.registerAnimationState( "crouch", %temp @ "CrouchAnimation" );

    // Register Animation States
	%this.registerAnimationState( "fallAgainstWall", %temp @ "FallAgainstWallAnimation", "" );
	%this.registerAnimationState( "swim", %temp @ "SwimAnimation", "" );

}

function PlayerClass::notOnWall(%this)
{
%this.onWall = false;
//echo("Not on wall!");

                if (%this.Direction.X == 1)
                {    
                    %this.bounce( %this.JumpForce, 90 + 45 );    
                }    
                else 
                {    
                    if ( %this.Direction.X == -1 )
                    {    
                        %this.bounce( -%this.JumpForce, 45 );    
                    }    
                }

}

function PlayerClass::executeSwimAnimationState(%this)
{
    if(%this.onGround)
    {
        if(%this.direction.X != 0)
        {
        return "run";
        }

    return "idle";
    }
return NULL;
}

function PlayerClass::executeCrouchAnimationState(%this)
{
$game::player.crouching = 1;

    if(%this.Direction.X != 0)
    {
    return "run";
    $game::player.crouching = 0;
    }

    if(!%this.onGround)
    {

        return "fall";

        if($game::player.isSwimming)
        {
        return "swim";
        }

        if(%this.isGliding)
        {
        return "glide";
        }

    $game::player.crouching = 0;
    }


    if($game::player.crouching)
    {
    %this.CollisionPolyList = "-0.575 0.285 0.614 0.069 1.000 0.604 -0.010 0.619 -0.761 0.476";
    }
    else
    {
    %this.CollisionPolyList = "-0.108 0.000 -0.100 -0.350 0.100 -0.350 0.100 0.000 0.000 0.340";
    }
return NULL;
}

////////////////////////////////////////////////////////////////////////////////
/// SHOOT STATE
////////////////////////////////////////////////////////////////////////////////

function PlayerClass::executeShootAnimationState(%this)
{
    if ( !%this.Alive )
    {
        return "die";
    }
    
    if ( %this.Climbing )
    {
        if ( %this.LinearVelocity.Y < 0 )
        {
            return "climbUp";
        }
        else if ( %this.LinearVelocity.Y > 0 )
        {
            return "climbDown";
        }
        
        return "climbIdle";
    }
    
    if ( !%this.OnGround )
    {
        if ( %this.Attack )
        {
            return "shootJump";
        }
        else
        {
            if ( %this.LinearVelocity.Y > 0 )
            {
                if ( %this.Gliding )
                {
                    return "glide";
                }
                
                return "fall";
            }
        }
    }
    
    %moveSpeed         = %this.Speed.X;
    %inheritedVelocity = %this.InheritedVelocity.X;
    %groundVelocity    = %this.GroundObject.LinearVelocity.X;
    if ( %moveSpeed == 0 && %inheritedVelocity != %groundVelocity )
    {
        return "slide";
    }
    
    if ( %this.Attack )
    {
        if ( %this.OnGround )
        {
            if (%this.Direction.X != 0)
            {
                return "shootRun";
            }
        }
        else
        {
            return "shootJump";
        }
    }
    else
    {
        if (%this.Direction.X != 0)
        {
            return "run";
        }
        
        return "idle";
    }
    
    return NULL;
}

////////////////////////////////////////////////////////////////////////////////
/// SHOOT RUN STATE
////////////////////////////////////////////////////////////////////////////////

function PlayerClass::executeShootRunAnimationState(%this)
{
    if ( !%this.Alive )
    {
        return "die";
    }
    
    if ( %this.Climbing )
    {
        if ( %this.LinearVelocity.Y < 0 )
        {
            return "climbUp";
        }
        else if ( %this.LinearVelocity.Y > 0 )
        {
            return "climbDown";
        }
        
        return "climbIdle";
    }
    
    if ( !%this.OnGround )
    {
        if ( %this.Attack )
        {
            return "shootJump";
        }
        else
        {
            if ( %this.LinearVelocity.Y > 0 )
            {
                if ( %this.Gliding )
                {
                    return "glide";
                }
                
                return "fall";
            }
        }
    }
    
    if ( %this.Attack )
    {
        if ( %this.OnGround )
        {
            if ( %this.Direction.X == 0 )
            {
                return "shoot";
            }
        }
        else
        {
            return "shootJump";
        }
    }
    else
    {
        if ( %this.Direction.X == 0 )
        {
            return "idle";
        }
        else
        {
            return "run";
        }
    }

    return NULL;
}

////////////////////////////////////////////////////////////////////////////////
/// SHOOT JUMP STATE
////////////////////////////////////////////////////////////////////////////////

function PlayerClass::executeShootJumpAnimationState(%this)
{
    if ( !%this.Alive )
    {
        return "die";
    }
    
    if ( %this.Climbing )
    {
        if ( %this.LinearVelocity.Y < 0 )
        {
            return "climbUp";
        }
        else if ( %this.LinearVelocity.Y > 0 )
        {
            return "climbDown";
        }
        
        return "climbIdle";
    }
    
    if ( %this.OnGround )
    {
        if ( %this.Attack )
        {
            if ( %this.Direction.X != 0 )
            {
                return "shootRun";
            }
            
            return "shoot";
        }
        else
        {
            if ( %this.Direction.X != 0 )
            {
                return "run";
            }
            
            return "idle";
        }
    }
    else
    {
        if ( !%this.Attack )
        {
            if ( %this.Owner.LinearVelocity.Y < 0 )
            {
                return "jump";
            }
            else
            {
                return "fall";
            }
        }
    }
    
    return NULL;
}

function PlayerClass::executeFallAgainstWallAnimationState(%this)
{    
    if ( %this.onWall == false )
	{
    	return "fall";
    }

    if ( %this.onGround )    
    {    
        %this.onWall = false;    

        if (%this.Direction.X == 0)
        {    
            return "idle";    
        }    
        else 
        {    
            return "run";    
        }    
    }    
    else 
    {    
        if ( %this.onWall == true )
        {    
            //Check if we have jumped since hitting the wall    
            if ( %this.jump )
            {    
                // Bounce the player
                %this.onWall = false;    

                if (%this.Direction.X == 1)
                {    
                    %this.bounce( %this.JumpForce, 90 + 45 );    
                }
                else 
                {    
                    if ( %this.Direction.X == -1 )
                    {    
                        %this.bounce( -%this.JumpForce, 45 );
                    }
                }    

                return "jump";    
            }    
            else 
            {    
                //Check our direction    
                if ( %this.Direction.X == %this.onWallDirection && %this.Direction.X == -%this.onWallDirection )
                {    
                    //We are no longer touching the wall.    
                    %this.onWall = false;    
                    return "fall";    
                }
                else 
                {    
                    //Slow down the player decent.    
                    if ( getWord( %this.LinearVelocity, 1 ) > 50 )
                    {    
                        %this.setLinearVelocityY( mClamp( getWord( %this.LinearVelocity, 1 ), 0, 50 ));
                        //%this.fallEvent = %this.schedule(500, "notOnWall");
                        //echo("Scheduling drop!");
                    }
                }    
            }    
        }    
        else 
        {    
            %this.onWall = false;    

            if ( %this.jump )
            {    
                return "jump";    
            }    
            else 
            {    
                return "glide";    
            }    
        }    
    }    

    return NULL;    
}

function PlayerClass::initAbilities(%this)
{
    if($PlayerHasParachute)
    {
    %this.allowGliding = true;
    }
    else
    {
    %this.allowGliding = false;
    }

    if($PlayerCanCrouch)
    {
    %this.canCrouch = true;
    }
    else
    {
    %this.canCrouch = false;
    }
    

    if($PlayerCanWallLeap)
    {
    %this.canWallLeap = true;
    }
    else
    {
    %this.canWallLeap = false;
    }

    if($PlayerCanSwim)
    {
    %this.canSwim = true;
    }
    else
    {
    %this.CanSwim = false;
    }

}

//Experimental

function ChangeCaveman()
{
$game::player.removeBehavior(SpawnPointBehavior);  
$game::player.addBehavior(SpawnPointBehavior);
}

function echotester()
{
//$echostuff = sceneWindow2D.getSceneGraph();
echo($echostuff);
}

function alpha()
{
$echostuff = "testing123";
}

function Rotatus()
{
%puppet = $game::player.getAnimationPuppet();
%puppet.setRotation( 45 );
}
//More, not experimental