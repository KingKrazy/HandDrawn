if (!isObject(ShrinkPickupBehavior))
{
    %template = new BehaviorTemplate(ShrinkPickupBehavior);
   
    %template.friendlyName = "Shrink Powerup Behavior";
    %template.behaviorType = "Collectable";
    %template.description  = "Resize player";

    %template.addBehaviorField(sizeX, "The player's new X size.", float, 16.0);
    %template.addBehaviorField(sizeY, "The player's new Y size.", float, 16.0);
    %template.addBehaviorField(shrinkTimeOut, "Time before setting to normal size. -1 is forever.", string, 30.000);

}

function ShrinkPickupBehavior::confirmPickup( %this, %targetObject, %inventoryItem )
{
   %player = $game::player;
   
   if(isObject(%player))
   {
   playSound(shrinkPowerup);
   _newFadeSequence("nothing 0 0 250", "null()");
   _newFadeSequence("nothing 0 0 250", "null()");
  
   //Collect some stuff...
    
   %puppet = $game::player.getAnimationPuppet();
    //%playerNewSizeX = "\"" @ %this.SizeX;
   //echo(%playerNewSizeX);
  // %playerNewSizeY = %this.SizeY @ "\"";
 //   echo(%playerNewSizeY);
   //Run through the visual effects...
   
   %puppet.Size = "8.000 8.000";
   echo(%puppet.Size);
   schedule(%this.shrinkTimeOut, 0, "ClearSize");
   %this.Owner.safeDelete();
   }
}

//Restore player to original size...

function clearSize( %this, %targetObject )
{
   %puppet = $game::player.getAnimationPuppet();
   %puppet.Size = "16.000 16.000";
}