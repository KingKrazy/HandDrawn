//-----------------------------------------------------------------------------
// Platformer Starter Kit
// Copyright (C) JackRabbit Productions
//  
//-----------------------------------------------------------------------------

if ( !isObject( CameraSizeBehavior ) )
{
    %template = new BehaviorTemplate( CameraSizeBehavior );
    
    %template.friendlyName = "Camera Size Behavior";
    %template.behaviorType = "Triggers";
    %template.description  = "Edit camera size.";

    %template.addBehaviorField(XSizeCameraEnter, "Camera X enter.", float, 190.000);
    %template.addBehaviorField(YSizeCameraEnter, "Camera Y enter.", float, 142.000);
    %template.addBehaviorField(XSizeCameraExit, "Camera X exit.", float, 0.0);
    %template.addBehaviorField(YSizeCameraExit, "Camera Y exit.", float, 0.0);

    %scenegraph = %this.getSceneGraph();


}

function CameraSizeBehavior::onEnter( %this, %theirObject )
{
%scenegraph.cameraSize = "\"" @ %this.XSizeCameraEnter SPC %this.YSizeCameraEnter @ "\"";
}

function CameraSizeBehavior::onLeave( %this, %theirObject )
{
%scenegraph.cameraSize = "\"" @ %this.XSizeCameraExit SPC %this.YSizeCameraExit @ "\"";
}