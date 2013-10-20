//-----------------------------------------------------------------------------
// Platform Timer
//-----------------------------------------------------------------------------

if ( !isObject( PlatformTimerBehavior ) )
{
    %template = new BehaviorTemplate( PlatformTimerBehavior );

    %template.friendlyName = "Platform Timer";
    %template.behaviorType = "Platform";
    %template.description  = "Platform timer";
    
    %template.addBehaviorField( Number,    "What order this comes along",    STRING, 1 );
    %template.addBehaviorField( Size,    "The size to store.",    STRING, "20.000 5.000" );

}

function PlatformTimerBehavior::onAddToScene( %this, %scenegraph )
{
%this.Owner.Size = "0 0";
%this.Owner.Visible = 0;
%this.schedule(%this.Number * 2000 - 1000, "TimePlatform");
//echo("Platform has been added to the scene.");
//Store Size and Positon...
%this.StoredPosition = %this.Owner.Position;
%this.Owner.Position = Cache.Postion;
}

function PlatformTimerBehavior::TimePlatform( %this )
{
%this.Owner.Visible = 1;
//echo("Visible!");
%this.schedule(2000, "RemovePlatform");
%this.Owner.Size = %This.Size;
%this.Owner.Position = %this.StoredPosition;
}

function PlatformTimerBehavior::RemovePlatform( %this )
{
//echo("Invisible!");
%this.Owner.Visible = 0;
%this.schedule(6000, "TimePlatform");
%this.Owner.Size = "0 0";
%this.Owner.Position = Cache.Position;
}