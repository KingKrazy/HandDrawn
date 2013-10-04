//-----------------------------------------------------------------------------
// Platformer Starter Kit
// Copyright (C) Phillip O'Shea
//  
// Controller - This behavior translate the input from the user into the
//              actions of its owner. All a controller does is provide a brain
//              for the body, telling it which direction to face, when to jump
//              or when to attack.
//-----------------------------------------------------------------------------

if ( !isObject( ControllerBehavior ) )
{
    %template = new BehaviorTemplate( ControllerBehavior );
    
    %template.friendlyName = "Player Controller";
    %template.behaviorType = "Actor";
    %template.description  = "Player Controller";
    
    %template.addBehaviorField( keyLeft,   "Move Left",  KEYBIND, "keyboard a" );
    %template.addBehaviorField( keyRight,  "Move Right", KEYBIND, "keyboard d" );
    %template.addBehaviorField( keyUp,     "Move Up",    KEYBIND, "keyboard w" );
    %template.addBehaviorField( keyDown,   "Move Down",  KEYBIND, "keyboard s" );
    %template.addBehaviorField( keyJump,   "Jump",       KEYBIND, "keyboard space" );
//    %template.addBehaviorField( keyAttack, "Attack",     KEYBIND, "mouse button0" );
    %template.addBehaviorField( keyReload, "Reload",     KEYBIND, "keyboard R" );
}

/// Set up the player's controller
function ControllerBehavior::onAddToScene( %this, %scenegraph )
{
    // Reset
    %this.Owner.Direction = "0 0";
    
    // Set the collision details
    %this.Owner.setObjectType( "PlayerObject" );
    %this.Owner.setCollidesWith( "PlatformObject EnemyObject PlayerTrigger" );
    
    // Make sure we have a move map
    if ( !isObject( moveMap ) )
    {
        return;
    }
    
    // Bind the appropriate keys
    moveMap.bindCmd( getWord( %this.keyLeft, 0 ),   getWord( %this.keyLeft, 1 ),   %this @ ".keyDown( Left );",   %this @ ".keyUp( Left );" );
    moveMap.bindCmd( getWord( %this.keyRight, 0 ),  getWord( %this.keyRight, 1 ),  %this @ ".keyDown( Right );",  %this @ ".keyUp( Right );" );
    moveMap.bindCmd( getWord( %this.keyUp, 0 ),     getWord( %this.keyUp, 1 ),     %this @ ".keyDown( Up );",     %this @ ".keyUp( Up );" );
    moveMap.bindCmd( getWord( %this.keyDown, 0 ),   getWord( %this.keyDown, 1 ),   %this @ ".keyDown( Down );",   %this @ ".keyUp( Down );" );
    moveMap.bindCmd( getWord( %this.keyJump, 0 ),   getWord( %this.keyJump, 1 ),   %this @ ".keyDown( Jump );",   %this @ ".keyUp( Jump );" );
    moveMap.bindCmd( getWord( %this.keyAttack, 0 ), getWord( %this.keyAttack, 1 ), %this @ ".keyDown( Attack );", %this @ ".keyUp( Attack );" );
    moveMap.bindCmd( getWord( %this.keyReload, 0 ), getWord( %this.keyReload, 1 ), %this @ ".keyDown( Reload );", %this @ ".keyUp( Reload );" );
    
    // Make sure the controller works
    moveMap.push();
}

/// Store the Player reference.
function ControllerBehavior::onBehaviorAdd( %this )
{
    // Store the Owner.
    $Game::Player = %this.Owner;
    %this.owner.setUseMouseEvents(true);
}

/// A key is pressed
function ControllerBehavior::keyDown( %this, %keyDown )
{
    // Left key
    if ( %keyDown $= "Left" )
    {
        %this.Owner.Direction.X = -1;

        if($game::player.isSwimming)
        {
            if(!%this.Owner.onGround)
            {
            $game::player.setAnimationState( "Swim" );
            }
        }

    }
    
    // Right key
    if ( %keyDown $= "Right" )
    {
        %this.Owner.Direction.X =  1;
       
        if(%this.Owner.isSwimming)
        {
            if(!$game::player.onGround)
            {
            $game::player.setAnimationState( "Swim" );
            }
        }
    
    }
    
    // Up key
    if ( %keyDown $= "Up" )
    {
        %this.Owner.Direction.Y = -1;

        if($game::player.isSwimming)
        {
        $game::player.gravity = "0 -25";
        }
    
    }
    
    // Down key
    if ( %keyDown $= "Down" )
    {
        %this.Owner.Direction.Y =  1;
        
        
        if($game::player.canCrouch && !%this.isClimbing)
        {
        $game::player.setAnimationState( "Crouch" );
        }

    if($game::player.isSwimming)
    {
        if(%this.Owner.Direction.X != 0)
        {
        $game::player.setanimationState( "Swim" );
        }



    %this.Owner.gravity = "0 75";

    %bubbleSound = $bubbleSound[getRandom(1,3)];
    playSound(%bubbleSound);

    %State = $game::player.getAnimationState();
    
    if(%this.Owner.getAnimationState $= "swim")
    {
    %posX = 1.5;
    %posY = 0;
    echo("Is swimming so POSX and POSY = " @ %posX SPC %posY @ ". State is: " @ %this.Owner.getAnimationState());
    }
    else
    {
    %posX = 0;
    %posY = -1.5;
    warn("Isn\'t swimming so POSX and POSY = " @ %posX SPC %posY @ ". State is: " @ %this.Owner.getAnimationState());
    }

    %bubbleOffset = %posX SPC %posY;

          %aura = new t2dParticleEffect()
  {
      scenegraph = sceneWindow2D.getSceneGraph();
      layer      = 0;
      effectFile = "~/data/particles/BubblesStuff.eff";
      useEffectCollisions = "1";
      class = "WaterParticles";
      effectMode = "kill";
      effectTime = "0.2";
      canSaveDynamicFields = "1";
      Position = %pos;
      size = "4.000 4.000";
      SortPoint = "-0.037 -0.295";
      CollisionMaxIterations = "1";
  };
    %aura.playEffect(true);
  %aura.isPlaying = true;
  %aura.mount($game::player, %Bubbleoffset);

    
    }


    }
    
    // Jump key
    if ( %keyDown $= "Jump" )
    {
        %this.Owner.Jump = true;
       //$game::player.doSimpleAfterImageEffect(100, 1500, false, true, 0.14, 50, 0);
    }
    
    // Attack key
    if (%keyDown $= "Attack")
    {
        // Note that the attack key is being held
        %this.Owner.Attack = true;
        $game::player.setAnimationState( "Shoot" );

        // Attack!
        %this.Owner.attack();
    }
    
    // Reload key
    if ( %keyDown $= "Reload" )
    {
        // Reload.
        %this.Owner.onReload( 0, true );
    }
}

/// A key is released
function ControllerBehavior::keyUp( %this, %keyUp )
{
    // Left key
    if ( %keyUp $= "Left" && %this.Owner.Direction.X == -1 )
    {
        %this.Owner.Direction.X = 0;
    }
    
    // Right key
    if ( %keyUp $= "Right" && %this.Owner.Direction.X == 1 )
    {
        %this.Owner.Direction.X = 0;
    }
        
    // Up key
    if ( %keyUp $= "Up" )
    {
        %this.Owner.Direction.Y = 0;
    
    if($game::player.isSwimming)
    {
    $game::player.gravity = "0 -10";
    }

    }
    
    // Down key
    if ( %keyUp $= "Down" )
    {
        %this.Owner.Direction.Y = 0;
    
    if($game::player.Crouching && !$game::player.isSwimming && $game::player.canCrouch)
    {
    $game::player.setAnimationState( "Idle" );
    $game::player.CollisionPolyList = "-0.108 0.000 -0.100 -0.350 0.100 -0.350 0.100 0.000 0.000 0.340";

    }

    if($game::player.isSwimming)
    {
    $game::player.gravity = "0 -10";
    }
    
    }
    
    // Jump key
    if ( %keyUp $= "Jump" )
    {
        %this.Owner.Jump = false;
    }
    
    // Attack key
    if ( %keyUp $= "Attack" )
    {
        %this.Owner.onAttack( 0, false );
    }
    
    // Attack key
    if ( %keyUp $= "Attack" )
    {
        %this.Owner.onReload( 0, false );
    }
}

//-----------------------------------------------------------------------------
// Mouse Methods.
//-----------------------------------------------------------------------------

$PI                    = 3.141592654;
$Game::CrosshairOffset = 100;
$Game::MinLookAngle    = -$PI * 0.09256;
$Game::MaxLookAngle    =  $PI * 0.14942;

//-----------------------------------------------------------------------------

function updateLookPosition()
{
    // Valid Player?
    if ( !isObject( $Game::Player ) || $Game::Player.getClassName() !$= "pskActor3D" )
    {
        // Quit.
        return;
    }

    // Fetch Cursor Details.
    %canvasPoint  = Canvas.getCursorPos();
    %canvasCenter = t2dVectorScale( Canvas.getExtent(), 0.5 );
    %offset       = t2dVectorSub( %canvasPoint, %canvasCenter );

    // Determine the Direction and Look Angle.
    %flip      = false;
    %lookAngle = mAtan( %offset.y, %offset.x );

    if ( %lookAngle < ( -$PI / 2.0 ) )
    {
        %flip      = true;
        %lookAngle = -( %lookAngle + $PI );
    }
    else if ( %lookAngle > ( $PI / 2.0 ) )
    {
        %flip      = true;
        %lookAngle = -( %lookAngle - $PI );
    }

    // Determine the Look Position;
    %lookPosition = ( %lookAngle - $Game::MinLookAngle ) / ( $Game::MaxLookAngle - $Game::MinLookAngle );

    // Update the Player Information.
    $Game::Player.setLookPosition( %lookPosition );
    $Game::Player.setFlipX( %flip );
    
    // Update the Crosshair Position.
    updateCrosshairPosition();
}

function updateCrosshairPosition()
{
    // Fetch the Crosshair.
    %crosshairObject = CrossHairGui;
    // Valid?
    if ( !isObject( %crosshairObject ) || !%crosshairObject.isVisible() )
    {
        // Quit.
        return;
    }
    
    // Get the Muzzle Point & Vector.
    %muzzlePoint  = sceneWindow2D.getWindowPoint( $Game::Player.getMuzzlePoint() );
    %muzzleVector = $Game::Player.getMuzzleVector();

    // Offset the Muzzle Point.
    %crosshairPoint = t2dVectorAdd( %muzzlePoint, t2dVectorScale( %muzzleVector, $Game::CrosshairOffset ) );
    // Fetch the Half Size.
    %crosshairHalfSize = t2dVectorScale( %crosshairObject.getExtent(), 0.5 );
    // Reposition the Control.
    %crosshairObject.setPosition( mCeil( %crosshairPoint.X - %crosshairHalfSize.X ),
                                  mCeil( %crosshairPoint.Y - %crosshairHalfSize.Y ) );
}

function MouseInputCtrl::onMouseMove( %this, %modifier, %worldPosition, %clicks )
{
    updateLookPosition();
}

function MouseInputCtrl::onMouseDragged( %this, %modifier, %worldPosition, %clicks )
{
    updateLookPosition();
}

function MouseInputCtrl::onRightMouseDragged( %this, %modifier, %worldPosition, %clicks )
{
    updateLookPosition();
}

//-----------------------------------------------------------------------------

function MouseInputCtrl::onMouseDown( %this, %modifier, %worldPosition, %clicks )
{
    // Player?
moveMap.bind(mouse, button0, Attack);  
    if ( isObject( $Game::Player ) )
    {
        // Primary Fire.
        $Game::Player.onAttack( 0, true );

    }
}

function MouseInputCtrl::onMouseUp( %this, %modifier, %worldPosition, %clicks )
{
    // Player?
    if ( isObject( $Game::Player ) )
    {
        // Primary Fire.
        $Game::Player.onAttack( 0, false );
    }
}

//-----------------------------------------------------------------------------

function MouseInputCtrl::onRightMouseDown( %this, %modifier, %worldPosition, %clicks )
{
    // Player?
    if ( isObject( $Game::Player ) )
    {
        // Alternate Fire.
        $Game::Player.onAttack( 1, true );
    }
}

function MouseInputCtrl::onRightMouseUp( %this, %modifier, %worldPosition, %clicks )
{
    // Player?
    if ( isObject( $Game::Player ) )
    {
        // Alternate Fire.
        $Game::Player.onAttack( 1, false );
    }
}