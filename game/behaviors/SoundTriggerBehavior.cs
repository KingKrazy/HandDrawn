//-----------------------------------------------------------------------------
// Platformer Starter Kit
// Copyright (C) Phillip O'Shea
//  
// Music Trigger - This trigger will play the specified music when the player
//                 passes through. You can also specify "alternate" music
//                 to be triggered. For example: MusicA is playing and has
//                 an alternate specified as MusicB. When the actor passes
//                 through it will play MusicB. Now that MusicB is playing,
//                 when the actor passes back through, it will play MusicA.
//                 Alternates are specified in the AudioDatablock under the
//                 field name "Alternate".
//-----------------------------------------------------------------------------

if ( !isObject( SoundTriggerBehavior ) )
{
    %template = new BehaviorTemplate( SoundTriggerBehavior );

    %template.friendlyName = "Sound Trigger";
    %template.behaviorType = "Miscellaneous";
    %template.description  = "Play sound.";

    %template.addBehaviorField( Sound,     "Sound to play!",     OBJECT, "Sound!", AudioProfileDatablock );
}

/// Set up the trigger
function SoundTriggerBehavior::onAddToScene( %this, %scenegraph )
{
    // Make sure we're a trigger
}

function SoundTriggerBehavior::onEnter( %this, %theirObject )
{
playSound(%this.sound);
}

function SoundTriggerBehavior::onLeave( %this, %theirObject )
{
stopSound(%this.sound);
}