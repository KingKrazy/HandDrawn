//-----------------------------------------------------------------------------
// Platformer Starter Kit
// Copyright (C) Phillip O'Shea
//  
// Platform - Platforms are either solid, or one-way. The engine only
//            recognises collisions with solid platforms, and the kit will
//            attempt to register one-way collisions through script. When a
//            platform is created, it will attempt to find a "surfaceImage".
//            This tells the kit what the surface of the platform looks like,
//            and how an actor should react upon contact.
//-----------------------------------------------------------------------------

if ( !isObject( platformTriggerBehavior ) )
{
    %template = new BehaviorTemplate( platformTriggerBehavior );

    %template.friendlyName = "Platform Trigger";
    %template.behaviorType = "Platform";
    %template.description  = "Platform trigger behavior to make a platformer start moving on landed.";

    %template.addBehaviorField( ForceX, "The force to push it at", FLOAT, 1.0 );
    %template.addBehaviorField( ForceY, "The force to push it at", FLOAT, 1.0 );
}

//-----------------------------------------------------------------------------

function platformTriggerBehavior::onActorEnter( %this, %actor )
{
if(%actor = $game::player && %this.LinearVelocity.X = 0 && %this.LinearVelocity.Y = 0)
{
%this.Owner.LinearVelocity.Y = %this.ForceY;
%this.Owner.LinearVelocity.X = %this.ForceX;
}
}