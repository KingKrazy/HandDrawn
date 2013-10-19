if (!isObject(WarpPickupBehavior))
{
    %template = new BehaviorTemplate(WarpPickupBehavior);
   
    %template.friendlyName = "Warp Behavior";
    %template.behaviorType = "Physx Object Trigger";
    %template.description  = "Create a trigger object that teleports the player to a new position";

    %template.addBehaviorField(targetX, "The player's new X position.", float, 0.0);
    %template.addBehaviorField(targetY, "The player's new Y position.", float, 0.0);

   %template.addBehaviorField( GoToObject, "Teleport to object?", BOOL, false );

   %template.addBehaviorField(Destination, "If so, give an object to teleport to", object, "", t2dSceneObject);

}

function WarpPickupBehavior::confirmPickup( %this, %targetObject, %inventoryItem )
{
echo(%this.Destination.Position);
   %player = $game::player;

   if(!%this.GoToObject)
   {
        if(isObject(%player))
        {
        _newFadeSequence(" 250 0 0", "");

        playSound(warp);

        %player.Position = %this.targetX SPC %this.targetY;
        %Player.setLinearVelocityX( 0 );
        %Player.setLinearVelocityY( 0 );

        }
   }
   else
   {
        %player.Position = %this.Destination.Position;
        %Player.setLinearVelocityX( 0 );
        %Player.setLinearVelocityY( 0 );
        playSound(warp);
        _newFadeSequence(" 250 0 0", "");
   }
}