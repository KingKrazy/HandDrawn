//-----------------------------------------------------------------------------
// Platformer Starter Kit
// Copyright (C) Phillip O'Shea
//  
// Game Methods - This file contains many of the global functions that are
//                used throughout this kit.
//-----------------------------------------------------------------------------

$Game::Cheat::InfiniteAmmo = true;

$Game::Effects::Layer = 2;
$Game::Effects::SizeThreshold = 100;

//-----------------------------------------------------------------------------

/// Sets up the foundations for the kit
function mountRevert()
{

   if(!isObject(%revert))
   {
   %revert = new t2dStaticSprite()
   {
      sceneGraph = scenewindow2d.getScenegraph();
      imageMap = "White_CircleImageMap";
      frame = "0";
      sourceRect = "0 0 0 0";
      layer = 0;
      position = $game::player.position;
      canSaveDynamicFields = "1";
      size = "50 50";
      SrcBlendFactor = "ONE_MINUS_DST_COLOR";
      DstBlendFactor = "ZERO";
         mountID = "891";
   };
   }
  %revert.mount($game::player, "0 0");
}

function mountSnow()
{
   %snow = new t2dParticleEffect() {
      scenegraph = scenewindow2d.getscenegraph();
      effectFile = "~/data/particles/SnowEffect.eff";
      useEffectCollisions = "1";
      //effectTime = "2.08882e-40";
      canSaveDynamicFields = "1";
      Position = $game::player.position;
      size = "190.000 142.000";
      FlipY = "1";
      Layer = "1";
      CollisionMaxIterations = "1";
         mountID = "14";
   };
  %snow.mount($game::player, "0 0");
  %snow.playEffect(true);
  %snow.isPlaying = true;

}

function shakeIntervals(%timemin, %timemax)
{
if($ShakeEnabled)
{
echo("Shake phase!");
%time = getRandom(%timeMin * 1000, %timeMax * 1000);
echo("The time is... " @ %time);
schedule(%time, 0, "shakeCamera");
schedule(%time, 0, "shakeIntervals", %timeMin, %timeMax);
}
}

function shakeCamera()
{
if($shakeEnabled)
{
   %scroller = new t2dScroller() {
      scenegraph = scenewindow2D.getSceneGraph();
      imageMap = "White_patchImageMap";
      sourceRect = "0 0 0 0";
      canSaveDynamicFields = "1";
      Position = blueskylevel1.position;
      size = blueskylevel1.size;
      Layer = 0;
      SrcBlendFactor = "ONE_MINUS_DST_COLOR";
      DstBlendFactor = "ZERO";
         mountID = "40";
   };

%sceneWindow = SceneWindow2D;
dismountCamera();
playSound(explosion);
%va1 = %sceneWindow.getCurrentCameraPosition().X + 2.5;
%va2 = %sceneWindow.getCurrentCameraPosition().Y;

%num1 = %va1 SPC %va2;

%vae1 = %sceneWindow.getCurrentCameraPosition().X - 5;
%vae2 = %sceneWindow.getCurrentCameraPosition().Y;

%num2 = %vae1 SPC %vae2;

%sceneWindow.schedule(0, "setCurrentCameraPosition", %num1);
%sceneWindow.schedule(50, "setCurrentCameraPosition", %num2);
%sceneWindow.schedule(100, "setCurrentCameraPosition", %num1);
%sceneWindow.schedule(150, "setCurrentCameraPosition", %num2);
%sceneWindow.schedule(200, "setCurrentCameraPosition", %num1);
%sceneWindow.schedule(250, "setCurrentCameraPosition", %num2);
%sceneWindow.schedule(300, "setCurrentCameraPosition", %num1);
%scroller.schedule(300, "delete");
%sceneWindow.schedule(300, "setCurrentCameraPosition", $game::player.getPosition());
$game::player.schedule(350, "mountCamera");
}
}

function initialisePlatformerKit()
{
    // Object Manager.
    exec ( "./ObjectManager.cs" );
    
    // Register Platformer Kit Types.
    registerObjectType( "SpawnPointObject" );
    registerObjectType( "PlatformObject OneWayPlatform" );
    registerObjectType( "PlatformObject SolidPlatform" );

    registerObjectType( "ActorObject PlayerObject" );
    registerObjectType( "ActorObject EnemyObject" );

    registerObjectType( "ActorTrigger PlayerTrigger" );
    registerObjectType( "ActorTrigger EnemyTrigger" );

    registerObjectType( "Projectile PlayerProjectile" );
    registerObjectType( "Projectile EnemyProjectile" );
    registerObjectType( "ProjectileCollider" );

    // Setup Object Information.
    setPlatformMask( getObjectTypeGroup( "PlatformObject" ) );
    setTriggerMask( getObjectTypeGroup( "ActorTrigger" ) );
    setSpawnPointMask( getObjectTypeGroup( "SpawnPointObject" ) );

    // Sound Manager.
    exec ( "./SoundManager.cs" );
    // Parallax Manager.
    exec ( "./ParallaxMethods.cs" );

    // Action Scripts.
    exec ( "./ActionScripts.cs" );

    // Weapon Scripts.
    exec ( "./Weapons/WeaponData.cs" );
    exec ( "./Weapons/ProjectileMethods.cs" );
    exec ( "./Weapons/FrozenPineConeLauncher.cs" );
    exec ( "./Weapons/PoisenedPineConeLauncher.cs" );
    exec ( "./Weapons/BurningPineConeLauncher.cs" );
    exec ( "./Weapons/PineConeLauncher.cs" );
    exec ( "./Weapons/Multis/MultiPineConeLauncher.cs" );
    exec ( "./Weapons/Multis/MultiFrozenPineConeLauncher.cs" );
    exec ( "./Weapons/Multis/MultiBurningPineConeLauncher.cs" );
    exec ( "./Weapons/Multis/MultiPoisonedPineConeLauncher.cs" );
    exec ( "./Weapons/FireBallLauncher.cs" );
    exec ( "./Weapons/BombLauncher.cs" );
    exec ( "./Weapons/BoneLauncher.cs" );
    exec ( "./Weapons/BulletWeapon.cs" );
    exec ( "./Weapons/RocketLauncher.cs" );
    exec ( "./Weapons/SpreadshotLauncher.cs" );
    exec ( "./Weapons/SpeedshotLauncher.cs" );

    // Base Actor Scripts.
    exec ( "./ActorMethods.cs" );
    // Derived Actor Scripts.
    exec ( "./BoomBotMethods.cs" );
    exec ( "./PlayerMethods.cs" );
    exec ( "./DrillMethods.cs" );
    //exec ( "./BoolMethods.cs" );
}

//-----------------------------------------------------------------------------

function t2dSceneObject::getPlatformInstance( %this )
{
    %platformBehavior = %this.getBehavior( PlatformBehavior );
    if ( isObject( %platformBehavior ) )
    {
        return %platformBehavior;
    }

    return 0;
}

function t2dSceneObject::getSpawnPointInstance( %this )
{
    %spawnPointComponent = %this.getComponentByName( pskSpawnPoint );
    if ( isObject( %spawnPointComponent ) )
    {
        return %spawnPointComponent;
    }

    return 0;
}

//-----------------------------------------------------------------------------

function PlayerClass::Weapon(%this, %weapon, %amount)
{
%fullname = %weapon @ "Ammo";
%this.setActiveWeapon(%weapon @ "LauncherWeapon");

if(%fullname $= "PineConeLauncherWeapon")
{
$game::player.PineConeAmmo += %amount;
}

if(%fullname $= "BurningPineConeLauncherWeapon")
{
%this.BurningPineConeAmmo += %amount;
}

if(%fullname $= "FrozenPineConeLauncherWeapon")
{
%this.FrozenPineConeAmmo += %amount;
}

if(%fullname $= "PoisonedPineConeLauncherWeapon")
{
%this.PoisonedPineConeAmmo += %amount;
}

if(%fullname $= "MultiPineConeLauncherWeapon")
{
%this.MultiPineConeAmmo += %amount;
}

if(%fullname $= "MultiBurningPineConeLauncherWeapon")
{
%this.MultiBurningPineConeAmmo += %amount;
}

if(%fullname $= "MultiFrozenPineConeLauncherWeapon")
{
%this.MultiFrozenPineConeAmmo += %amount;
}

if(%fullname $= "MultiPoisonedPineConeLauncherWeapon")
{
%this.MultiPoisonedPineConeAmmo += %amount;
}

%this.updateWeaponGui();
}

function t2dSceneGraph::onLevelEnded( %this )
{
$ShakeEnabled = 0;
echo("Level over.");
$game::player.temporarySwim = 0;
}

/// Load any ingame features here
function t2dSceneGraph::onLevelLoaded( %this )
{
   if ( sceneWindow2D.getSceneGraph() != %this )
    {
        return;
    }
	initialiseParallaxLayers();
    // Ensure that the channel volumes are reset
    //alxStopAll();
    %soundChannel = getSoundChannel();
    %soundVolume  = $SoundManager::Sound::Volume;
    %musicChannel = getMusicChannel();
    %musicVolume  = $SoundManager::Music::Volume;

    alxSetChannelVolume( %soundChannel, %soundVolume );
    alxSetChannelVolume( %musicChannel, %musicVolume );

    // Play the musical stuff and execute primary game scripts.
    %scenegraph = sceneWindow2D.getSceneGraph();
    %levelObj = %scenegraph.getSceneObject();
    echo(%levelObj.music);
    playMusic(%levelObj.music);
    canvas.pushDialog(%levelObj.tutorialGui);
    $levelNumber = %levelObj.LevelNumber;
    call(%levelObj.onLevelLoad);
    call(%levelObj.onLevelLoad2);
    call(%levelObj.onLevelLoad3);
    call(%levelObj.onLevelLoad4);
    call(%levelObj.onLevelLoad5);
    call(%levelObj.onLevelLoad6);
    
    CurrentLevel(%levelObj.LevelNumber);
    %Ltype = %levelObj.LevelType;
    
    if(%levelObj.Reverse)
    {
    $ReverseLevel = 1;
    }
    else
    {
    $reverseLevel = 0;
    }

    if(%levelObj.Snowy)
    {
    $SnowLevel = 1;
    }
    else
    {
    $SnowLevel = 0;
    }


    //$game::player.getAnimationPuppet().blendColor = %LType SPC %LType SPC %LType @ " 1";

    LevelTitle.settext("<just:center>" @ %levelObj.LevelName);

    // Delete the old manager
    if ( isObject( SpawnPointManager ) )
    {
        SpawnPointManager.delete();
    }

    // Create the Spawn Point Manager
    %spawnPointManager = new pskSpawnPointManager( SpawnPointManager )
    {
        SceneGraph     = %this;
        UpdateInterval = 200;
    };

    // Initialise layers in the next frame


    canvas.pushDialog(mouseOverlayGui);
    LoadGame(SFNSyntax(), 1, 1, 1, 1);
}

// setViewLimitOn("-300 -165", "300 55");
// setViewLimitOn("-150 -37.5", "150 37.5");
function setViewLimitOn( %minPoint, %maxPoint )
{
    %content      = Canvas.getContent();
    %contentCount = %content.getCount();
    for ( %i = 0; %i < %contentCount; %i++ )
    {
        %contentObj = %content.getObject( %i );
        if ( %contentObj.getClassName() !$= "t2dSceneWindow" )
        {
            continue;
        }
        
        %cameraZoomMod     = 1 / %contentObj.getCurrentCameraZoom();
        %cameraZoomFactorX = %contentObj.getCurrentCameraSize().X * ( %cameraZoomMod - 1 ) / 2.0;
        %cameraZoomFactorY = %contentObj.getCurrentCameraSize().Y * ( %cameraZoomMod - 1 ) / 2.0;
        
        %cameraMinPoint = t2dVectorSub( %minPoint, %cameraZoomFactorX SPC %cameraZoomFactorY );
        %cameraMaxPoint = t2dVectorAdd( %maxPoint, %cameraZoomFactorX SPC %cameraZoomFactorY );
        
        %contentObj.setViewLimitOn( %cameraMinPoint SPC %cameraMaxPoint );
    }
}

//-----------------------------------------------------------------------------

/// Returns the scene time
function getSceneTime()
{
    return sceneWindow2D.getSceneGraph().getSceneTime();
}

//-----------------------------------------------------------------------------

function copyBehaviorFields( %behavior, %dstObject )
{
    %template = %behavior.Template;
    if ( !isObject( %template ) )
    {
        return false;
    }

    %fieldCount = %template.getBehaviorFieldCount();
    for ( %i = 0; %i < %fieldCount; %i++ )
    {
        %fieldName  = getField( %template.getBehaviorField( %i ), 0 );
        %fieldValue = %behavior.getFieldValue( %fieldName );
        
        %dstObject.setFieldValue( %fieldName, %fieldValue );
    }

    return true;
}

function t2dSceneObject::getComponentByName( %this, %name )
{
    %count = %this.getComponentCount();
    for ( %i = 0; %i < %count; %i++ )
    {
        %comp = %this.getComponent( %i );
        if ( %comp.getClassName() $= %name )
        {
            return %comp;
        }
    }

    return -1;
}

//-----------------------------------------------------------------------------

/// Just a quick function to ensure all cameras get mounted in the same way
function t2dSceneWindow::mountCamera( %this, %mountTarget )
{
    %this.mount( %mountTarget, "0 0", 2.5, true );
}

/// Mounts the scene camera to the object
/// Mounts the scene camera to the object
function t2dSceneObject::mountCamera(%this)
{
    if (sceneWindow2D.getIsCameraMounted())
        dismountCamera();
    
    // Mount the camera to the objects
    sceneWindow2D.mountCamera(%this);
    
    // Mount parallax mounts
    if (isObject(ParallaxLayerMounts))
    {
        for (%i = 0; %i < ParallaxLayerMounts.getCount(); %i++)
        {
            %parallaxMount  = ParallaxLayerMounts.getObject(%i);
            %parallaxWindow = %parallaxMount.SceneWindow;
            
            // Mount the window to the mount
            %parallaxWindow.mountCamera(%parallaxMount);
            // Mount to the target
            %parallaxMount.mount(%this);
        }
    }
}

/// Dismounts the scene camera
function dismountCamera()
{
    if (!sceneWindow2D.getIsCameraMounted())
        return;
    
    // Dismount the camera from the object
    sceneWindow2D.dismount();
    
    // Dismount parallax mounts
    if (isObject(ParallaxLayerMounts))
    {
        for (%i = 0; %i < ParallaxLayerMounts.getCount(); %i++)
        {
            %parallaxMount  = ParallaxLayerMounts.getObject(%i);
            %parallaxWindow = %parallaxMount.SceneWindow;
            
            // Dismount the camera
            %parallaxWindow.dismount();
            // Dismount the mount
            %parallaxMount.dismount();
        }
    }
}

/// Dismounts the scene camera
function dismountCamera()
{
    if ( !sceneWindow2D.getIsCameraMounted() )
    {
        return;
    }

    // Dismount the camera from the object
    sceneWindow2D.dismount();

    // Dismount parallax mounts
    if ( isObject( ParallaxLayerMounts ) )
    {
        for ( %i = 0; %i < ParallaxLayerMounts.getCount(); %i++ )
        {
            %parallaxMount  = ParallaxLayerMounts.getObject( %i );
            %parallaxWindow = %parallaxMount.SceneWindow;

            // Dismount the camera
            %parallaxWindow.dismount();
            
            // Dismount the mount
            %parallaxMount.dismount();
        }
    }
}

//-----------------------------------------------------------------------------

function loadNewLevel( %levelFile, %delay )
{
canvas.popdialog(LevelCompleteGui);
canvas.hidecursor();

    // Opt out early if nothing was passed
    if ( %levelFile $= "" )
    {
        return;
    }

    // Prevents a crash ; )
    if ( %delay $= "" || %delay < 100 ) %delay = 100;

    // If you haven't included a directory then we'll use the default
    if ( !isFile( %levelFile ) )
    {
        %levelFile = "game/data/levels/" @ %levelFile;
    }

    // Add on the extension if needed
    %fileExtn = ".t2d";
    if ( getSubStr( %levelFile, strlen( %levelFile ) - strlen( %fileExtn ), strlen( %fileExtn ) ) !$= %fileExtn )
    {
        %levelFile = %levelFile @ %fileExtn;
    }

    // Load the file if possible
    if ( isFile( %levelFile ) )
    {
        sceneWindow2D.schedule( %delay, "loadLevel", %levelFile );
    }
    else
    {
        warn( "loadNewLevel() - Level not found: " @ %levelFile );
    }
}

//-----------------------------------------------------------------------------

/// Displays the game over sequence
function gameOver()
{
        stopMusic();

_newFadeSequence(" 0 0 2000", "");
schedule(2000, 0, "loadGGGui");
canvas.showcursor();
}

function loadGGGui()
{
canvas.pushdialog(gameOverGui);
}

function gameOverTheora()
{
GameOverVideo.setFile("game/data/video/GameOver.ogv");
playSound(youLose);
schedule(4000, 0, "ArrowInPos");
}

function arrowInPos()
{
GOarrow.setActive(true);
}

function savebanner()
{

    if ( isObject( saveSprite ) )
    {
SaveSprite.Position = sceneWindow2D.getCurrentCameraPosition();
SaveSprite.Visible  = true;
    }
}
/// Displays the level completed sequence
function levelComplete()
{


        // Dismount the camera
        dismountCamera();
        //scenewindow2D.endLevel();

        // Show the congratulations banner

        if ( isObject( LevelCompleteMusic ) )
        {
            // Stop any playing sounds and mute the sound effects channel
            alxStopAll();
            //alxSetChannelVolume( getSoundChannel(), 0.0 );

            // Play the level complete music
            playMusic( YouWin );
        }
canvas.pushdialog(LevelCompleteGui);
if($playerLevel <= $levelNumber)
{
$playerlevel = $nextLevelNumber;
}
}

//-----------------------------------------------------------------------------

/// %vA = 2d vector; %vB = int/2d vector
function mVectorMultiply( %vA, %vB )
{
    %x = ( %vA.X * %vB.X );
    %y = ( getWordCount( %vB ) > 1 ) ? ( %vA.Y * %vB.Y ) : ( %vA.Y * %vB.X );
    
    return %x SPC %y;
}

/// Ensures x isn't outside of the min and max values
function mClamp( %x, %min, %max )
{
    if ( %x < %min )
        return %min;
    
    if ( %x > %max )
        return %max;
        
    return %x;
}

/// See if two vectors are equal
function mVectorsEqual( %va, %vb )
{
    return ( %va.x == %vb.x && %va.y == %vb.y );
}

/// See if a point is within a line
function mAxisOverlap( %x, %vA, %vB )
{
    if ( %x >= %vA && %x <= %vB )
        return true;
    
    return false;
}

function mMin( %a, %b )
{
    if ( getWordCount( %a ) == 2 && getWordCount( %b ) == 2 )
    {
        if ( t2dVectorLength( %a ) < t2dVectorLength( %b ) )
            return %a;
        
        return %b;
    }
    else
    {
        if ( %a < %b )
            return %a;
        
        return %b;
    }
}

function mMax( %a, %b )
{
    if ( getWordCount( %a ) == 2 && getWordCount( %b ) == 2 )
    {
        if ( t2dVectorLength( %a ) > t2dVectorLength( %b ) )
            return %a;
        
        return %b;
    }
    else
    {
        if ( %a > %b )
            return %a;
        
        return %b;
    }
}

/// Creates a rotation matrix
function mRotationMatrix( %angle )
{
    %angle = mDegToRad( %angle );
    %sin   = mSin( %angle );
    %cos   = mCos( %angle );
    
    return %cos SPC %sin SPC -%sin SPC %cos;
}

/// Multiply a 2x2 matrix with a 2x1 vector
function mMatrixMultiply( %m, %v )
{
    %m11 = getWord( %m, 0 );
    %m12 = getWord( %m, 1 );
    %m21 = getWord( %m, 2 );
    %m22 = getWord( %m, 3 );
    
    %v1  = getWord( %v, 0 );
    %v2  = getWord( %v, 1 );
    
    %x   = %m11 * %v1 + %m12 * %v2;
    %y   = %m21 * %v1 + %m22 * %v2;
    
    return %x SPC %y;
}

//-----------------------------------------------------------------------------

/// Loops through all of the objects in a SimSet and returns them as a string
function SimSet::storeSet( %this )
{
    // Loop through all the objects and store them in a string
    %objectCount = %this.getCount();
    for ( %i = 0; %i < %objectCount; %i++ )
    {
        %listString = %listString SPC %this.getObject( %i );
    }

    // Trim and return
    return trim( %listString );
}

/// Loop through objects in a SimSet and make sure they are on the specified list.
/// It will also attempt to re-add removed items not in the set.
function SimSet::restoreSet( %this, %objectList, %delete, %restore )
{
    if ( %delete  $= "" ) %delete  = true;
    if ( %restore $= "" ) %restore = true;

    // Delete new items
    for ( %i = 0; %i < %this.getCount(); %i++ )
    {
        // Grab the object
        %object = %this.getObject( %i );

        // Check if it is part of the original list
        if ( !isWordInList( %objectList, %object ) )
        {
            // Remove it from the set
            %this.remove( %object );

            // Delete it if requested
            if ( %delete )
            {
                %object.safeDelete();
            }

            // Decrement the counter
            %i--;
        }
    }
    
    // Attempt to restore old items
    if ( %restore )
    {
        for ( %i = 0; %object < getWordCount( %objectList ); %i++ )
        {
            // Grab the object
            %object = getWord( %objectList, %i );

            // Check if it is still part of the set
            if ( !%this.isMember( %object ) )
            {
                // Check if it still exists
                if ( !isObject( %object ) )
                {
                    continue;
                }

                // Re-add it to the list
                %this.add( %object );
            }
        }
    }
}

//-----------------------------------------------------------------------------

// Find the first platform at the given position
function getPlatform( %worldPosition, %step )
{
    if ( %step $= "" ) %step = 50;
    
    %sceneGraph = sceneWindow2D.getSceneGraph();
    for ( %i = 0;
         %pickList = %sceneGraph.pickLine( t2dVectorAdd( %worldPosition, 0 SPC %step * ( %i + 0 ) ), t2dVectorAdd( %worldPosition, 0 SPC %step * ( %i + 1 ) ) );
         %i++ )
    {
        %objectCount = getWordCount( %pickList );
        for ( %j = 0; %j < %objectCount; %j++ )
        {
            %object = getWord( %pickList, %j );
            %platformBehavior = %object.getBehavior( PlatformBehavior );
            if ( %platformBehavior )
            {
                %surfacePoint = %platformBehavior.getSurfacePosition( %worldPosition.X );
                if ( %surfacePoint.Y >= %worldPosition.Y )
                    return %object;
            }
        }
        
        // Quit if we're stretching too far
        if ( %i == 100 )
            break;
    }
}

//-----------------------------------------------------------------------------

function isWordInList( %list, %word )
{
   %wordCount = getWordCount( %list );
   for ( %i = 0; %i < %wordCount; %i++ )
      if ( getWord( %list, %i ) $= %word )
         return true;
   
   return false;
}

function isWordInFieldList( %list, %word )
{
   %fieldCount = getFieldCount( %list );
   for ( %i = 0; %i < %fieldCount; %i++ )
      if ( isWordInList( getField( %list, %i ), %word ) )
         return true;
   
   return false;
}

function removeWordFromList( %list, %word )
{
   %wordCount = getWordCount( %list );
   for ( %i = 0; %i < %wordCount; %i++ )
      if ( getWord( %list, %i ) $= %word )
         return removeWord( %list, %i );
   
   return %list;
}

//-----------------------------------------------------------------------------

/// Bug fix
function t2dSceneObject::onFrameChange( %this, %frame )
{
    // Without this empty function TGB will not call the behavior's "onFrameChange" function
}

function CurrentLevel(%name)
{

if(%name >= $playerLevel)
{
$PlayerLevel = %name;
echo($CurrentLevel);
$onCompleteNumber = $playerlevel;
nextLevelLogic(%name);
return $CurrentLevel;
}
else if(%name <= $playerLevel)
{
nextLevelLogic($playerlevel);
}
$currentLevel = %name;

}

function nextLevelLogic(%name)
{
if($playerLevel <= %name)
{
$nextLevelNumber = $playerLevel + 1;
}
else
{
$nextLevelNumber = %name + 1;
}
}

function t2dSceneObject::setObjAlpha(%this, %number)
{
%blendRed = getWord(%this.blendColor, 0);
%blendGreen = getWord(%this.blendColor, 1);
%blendBlue = getWord(%this.blendColor, 2);

%this.blendColor = %blendRed SPC %blendGreen SPC %blendBlue SPC %number;
}

function t2dSceneObject::getObjAlpha(%this)
{
%blendAlpha = getWord(%this.blendColor, 3);

echo(%blendAlpha);
return %blendAlpha;
}

//function t2dSceneObject::onAddToScene(%this)
//{
//if(isObject($game::player))
//{
//    if($smartStream)
//    {
//    %this.schedule(getRandom(32,1000), "ManualUpdate");
//    }
//}
//}

function t2dSceneObject::ManualUpdate(%this)
{
if($smartStream)
{
    if(checkDistance($game::player.getAnimationPuppet(), %this) >= $streamDist)
    {
        if(%this.visible)
        {
        %this.visible = 0;
        }
    }
    else if(checkDistance($game::player, %this) < $streamDist && !%this.visible)
    {
    %this.visible = 1;
    }
%numeric = $StreamDist / 10 * -1 + 70;
%this.schedule(%numeric, "ManualUpdate");
}
}