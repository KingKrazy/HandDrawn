//-----------------------------------------------------------------------------
// Platformer Starter Kit
// Copyright (C) Phillip O'Shea
//  
// Area Damage - This behavior can be owned by either a Trigger or a Scene
//               Object. If a player enters the trigger it will take damage,
//               and will continue to do so each interval. If an actor
//               collides with a scene object, then it will take damage upon
//               collision.
//-----------------------------------------------------------------------------

if ( !isObject( CompassBehavior ) )
{
    %template = new BehaviorTemplate( CompassBehavior );

    %template.friendlyName = "Compass Area";
    %template.behaviorType = "Miscellaneous";
    %template.description  = "Attach a compass to the player to point to a waypoint.";

    %template.addBehaviorField( PlayerOnly, "Don't effect the other actors.",       BOOL,  true );
}

/// Set up the object
function CompassBehavior::onAddToScene( %this, %scenegraph )
{
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

/// Attach compass!
function CompassBehavior::onEnter( %this, %theirObject )
{
if(!$CompassAttached)
{
$CompassAttached = 1;

%Compass = new t2dStaticSprite(Compass)
   {
      SceneGraph    = Scenewindow2D.getSceneGraph();
      imageMap = "CompasImageMap";
      frame = "0";
      sourceRect = "0 0 0 0";
      canSaveDynamicFields = "1";
      Position = %theirObject.position;
      size = "50.000 50.000";
         mountID = "332";
      _behavior0 = "FaceObjectBehavior	object	Waypoint	turnSpeed	90";
   };

Compass.mount(%theirObject, 0, 0, 0, 1, 1, 0);
Compass.setMountTrackRotation(false);
}
}

function CompassBehavior::onLeave( %this, %theirObject )
{
$CompassAttached = 0;
Compass.safeDelete();
}