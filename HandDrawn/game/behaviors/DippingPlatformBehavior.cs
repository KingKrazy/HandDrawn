//---------------------------------------------------------------------------------
//----------------------------------BEGIN------------------------------------------

if ( !isObject( DipBehavior ) )
{
    %template = new BehaviorTemplate( DipBehavior );

    %template.friendlyName = "DipBehavior";
    %template.behaviorType = "Platform";
    %template.description  = "The object dips down on actor landed.";
}


function DipBehavior::onActorEnter( %this, %actor, %object )
{
%this.Owner.setPositionY(%this.PositionY - 1);
}

function DipBehavior::onActorLeft( %this, %actor, %object )
{
%this.Owner.setPosition(%object.PositionX SPC %Object.PositionY + 1 );
}

//---------------------------------END--------------------------------------------