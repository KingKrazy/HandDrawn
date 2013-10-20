//-----------------------------------------------------------------------------
// AttachPath behaviour
// for Torque Game Builder
// by Michael Hartlef
// Version 1.0, January 14, 2008
//-----------------------------------------------------------------------------

if (!isObject(AttachPathBehaviour))
{
   %template = new BehaviorTemplate(AttachPathBehaviour);
   
   %template.friendlyName = "Attach Path";
   %template.behaviorType = "AI";
   %template.description  = "Attach an object to a path";
   
   %template.addBehaviorField(path, "The path", object, "", t2dPath);
   %template.addBehaviorField(speed, "The speed at which the object will move along the path", float, "1.0");
   %template.addBehaviorField(direction, "1 to specify forward movement, -1 to specify reverse movement", integer, "1");
   %template.addBehaviorField(startnode, "The node that the object starts at (0=default)", integer, "0");
   %template.addBehaviorField(endnode, "The node that the object ends at (0=default)", integer, "0");
   %followM = "WRAP" TAB "REVERSE" TAB "RESTART";
   %template.addBehaviorField(followmode, "The action to take upon reaching the end of the path", enum, "WRAP", %followM);
   %template.addBehaviorField(loops, "The number of loops to take around the path (0=unlimited)", integer, "0");
   %template.addBehaviorField(sendtostart, "True to send the object directly to the start node, false to have the object move there", bool, "0");
   %template.addBehaviorField(guy, "The guy to put on the path", object, "", t2dSceneObject);
    %template.addBehaviorField( PlayerOnly, "Damage the player, not other actors",       BOOL,  true );
    %template.addBehaviorField( TrackRotation, "Track the rotation",       BOOL,  false );

}

function AttachPathBehaviour::onAddToScene( %this, %scenegraph )
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

function AttachPathBehaviour::onEnter(%this, %scenegraph)
{
   if (isObject(%this.path))
      %this.path.attachObject(%this.Guy, %this.speed, %this.direction, %this.startnode, %this.endnode, %this.followmode, %this.loops, %this.sendtostart);
%this.Path.setOrient(%this.guy, %this.trackRotation);
}
