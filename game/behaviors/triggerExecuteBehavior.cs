if (!isObject(TriggerExecBehavior))
{
   %template = new BehaviorTemplate(TriggerExecBehavior);
   
   %template.friendlyName = "Trigger Function Execute";
   %template.behaviorType = "Triggers";
   %template.description  = "Executes a method when trigger is entered or left.";
   
   %template.addBehaviorField(entermethod, "The method to call on entering", string, "");
   %template.addBehaviorField(entermethodparm, "parms for method", string, "");
   %template.addBehaviorField(leavemethod, "The method to call on leaving", string, "");
   %template.addBehaviorField(leavemethodparm, "parms for method", string, "");
   %template.addBehaviorField(simpleFunction, "Execute a function… or something.", string, "");

   %template.addBehaviorField( PlayerOnly, "Damage the player, not other actors",       BOOL,  false );

   %template.addBehaviorField(dontif, "methods won't be called if this is true", string, "");

}
function TriggerExecBehavior::onBehaviorAdd(%this)
{
	// set 'em up on the trigger itself for easy access
   %this.owner.entermethod = %this.entermethod;
   %this.owner.leavemethod = %this.leavemethod;
   %this.owner.entermethodparm = %this.entermethodparm;
   %this.owner.leavemethodparm = %this.leavemethodparm;
   %this.owner.simpleFunction = %this.simpleFunction;
   %this.owner.dontif = %this.dontif;
      
}

function t2dTrigger::onEnter(%this, %object)
{

	if(%this.dontif !$= "" && eval("if(" @ %this.dontif @ ") { return 1; }else{ return 0;}"))
		return;
		
	if(%this.entermethod !$= "")
		call(%this.entermethod, %this.owner, %this.entermethodparm);


%FunctionToCall = %this.simpleFunction;
}
function t2dTrigger::onLeave(%this, %object)
{
	echo(%object.getname() @ " has left the trigger.");
	
	if(%this.dontif !$= "" && eval("if(" @ %this.dontif @ ") { return 1; }else{ return 0;}"))
		return;
		
	if(%this.leavemethod !$= "")
		call(%this.leavemethod, %this.owner, %this.leavemethodparm);
}

function TriggerExecBehavior::onAddToScene( %this, %scenegraph )
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

function t2dTrigger::confirmPickup(%this, %object)
{
	
	if(%this.dontif !$= "" && eval("if(" @ %this.dontif @ ") { return 1; }else{ return 0;}"))
		return;
		
	if(%this.entermethod !$= "")
		call(%this.entermethod, %this.owner, %this.entermethodparm);

}

