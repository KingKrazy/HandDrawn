if (!isObject(WPMBehavior))
{
   %template = new BehaviorTemplate(WPMBehavior);
   
   %template.friendlyName = "Waypoint mover";
   %template.behaviorType = "Triggers";
   %template.description  = "Moves the waypont.";
   
   %template.addBehaviorField(Dest, "The place to move the waypoint", string, "");

}

function WPMBehavior::onEnter(%this, %theirobject)
{
Waypoint.SetPosition(%this.Dest.Position);
}

function WPMBehavior::onAddToScene( %this, %scenegraph )
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
