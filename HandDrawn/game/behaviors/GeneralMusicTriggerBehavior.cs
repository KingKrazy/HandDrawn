//-----------------------------------------------------------------------------
//General Music player: Plays music when spawns.
//-----------------------------------------------------------------------------

if ( !isObject( GeneralMusicTriggerBehavior ) )
{
    %template = new BehaviorTemplate( GeneralMusicTriggerBehavior );

    %template.friendlyName = "General Music Trigger";
    %template.behaviorType = "Miscellaneous";
    %template.description  = "Play music on add to scene";

    %template.addBehaviorField( MusicToStart, "The name of the datablock to play",       DEFUALT );
}

/// Set up the trigger
function GeneralMusicTriggerBehavior::onAddToScene( %this, %scenegraph )
{
playMusic(%this.Owner.MusicToStart);
}