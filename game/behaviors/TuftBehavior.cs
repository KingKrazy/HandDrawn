if (!isObject(TuftPickupBehavior))
{
    %template = new BehaviorTemplate(TuftBehavior);
   
    %template.friendlyName = "Tuft of Grass Behavior";
    %template.behaviorType = "Enviroment";
    %template.description  = "Makes the tuft of grass blow when the player runs through it.";

}

function TuftBehavior::onAddToScene(%this, %scengraph)
{
%this.Owner.Class = "TuftClass";
%this.Owner.CollisionActiveSend = "1";
%this.Owner.CollisionActiveReceive = "1";
%this.Owner.CollisionCallback = "1";
%this.Owner.Immovable = "1";
%this.Owner.setCollidesWith( "ActorObject" );
%this.CollisionPolyList = "0.500 -1.000 1.000 -1.000 1.000 1.000 0.500 1.000";
}

function TuftClass::onAnimationBegin(%this)
{
%this.Owner.playSound(TuftSound);
}

function TuftBehavior::onCollision( %this, %theirObject )
{
//echo(%this.Owner @ " has been collided with!");

    if(%theirObject.FlipX)
    {
    %this.owner.flipX = 0;
    %this.Owner.playAnimation( %this.Owner.AnimationName );
    }
    else
    {
    %this.owner.flipX = 1;
    %this.Owner.playAnimation( %this.Owner.AnimationName );
    }
}