//-----------------------------------------------------------------------------
// Platformer Starter Kit
// Copyright (C) JackRabbit Productions
//  
//-----------------------------------------------------------------------------

if ( !isObject( GravityBehavior ) )
{
    %template = new BehaviorTemplate( GravityBehavior );
    
    %template.friendlyName = "Gravity Zone";
    %template.behaviorType = "Physx Object Trigger";
    %template.description  = "Change the gravity while in the trigger.";
    %template.addBehaviorField(gravitystart, "The method to call on entering", string, "0 50");
    %template.addBehaviorField(gravityend, "The method to call on leaving", string, "0 20");
    %template.addBehaviorField( PlayerOnly, "Damage the player, not other actors",       BOOL,  false );

}

function GravityBehavior::onEnter(%this, %object, %targetObject)
{
%Object.gravity = %this.gravitystart;
playsound(gravityEnter);
}

function GravityBehavior::onLeave(%this, %object, %targetObject)
{
%Object.gravity = %this.gravityend;
playsound(gravityexit);
}

function GravityBehavior::onAddToScene( %this, %scenegraph )
{
    // Collision system
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