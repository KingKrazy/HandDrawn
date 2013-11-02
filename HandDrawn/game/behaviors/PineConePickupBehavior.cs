//-----------------------------------------------------------------------------
// Platformer Starter Kit
// Copyright (C) JackRabbit Productions
//  
//-----------------------------------------------------------------------------

if ( !isObject( PineConePickupBehavior ) )
{
    %template = new BehaviorTemplate( PineConePickupBehavior );
    
    %template.friendlyName = "Pinecone Pick-up";
    %template.behaviorType = "Collectable";
    %template.description  = "Give the actor a few pinecones.";
   %template.addBehaviorField(amount, "How many pinecones to give this player", float, "100");
    %template.addBehaviorField( Type,       "The kind of pine cone",               ENUM,   "PineConeLauncherWeapon", "PineConeLauncherWeapon" TAB "PoisonedPineconeLauncherWeapon" TAB "FrozenPineconeLauncherWeapon" TAB "BurningPineconeLauncherWeapon" TAB "MultiPineconeLauncherWeapon" TAB "MultiFrozenPineconeLauncherWeapon" TAB "MultiBurningPineconeLauncherWeapon" TAB "MultiPoisonedPineconeLauncherWeapon" TAB "BlobLauncherWeapon");

}

function PineConePickupBehavior::confirmPickup( %this, %targetObject, %inventoryItem )
{
$game::player.setActiveWeapon(%this.Type);

if(%this.Type $= "BlobLauncherWeapon")
{
$game::player.BlobAmmo += %this.amount;
}

if(%this.Type $= "PineConeLauncherWeapon")
{
$game::player.PineConeAmmo += %this.amount;
}

if(%this.Type $= "BurningPineConeLauncherWeapon")
{
$game::player.BurningPineConeAmmo += %this.amount;
}

if(%this.Type $= "FrozenPineConeLauncherWeapon")
{
$game::player.FrozenPineConeAmmo += %this.amount;
}

if(%this.Type $= "PoisonedPineConeLauncherWeapon")
{
$game::player.PoisonedPineConeAmmo += %this.amount;
}

if(%this.Type $= "MultiPineConeLauncherWeapon")
{
$game::player.MultiPineConeAmmo += %this.amount;
}

if(%this.Type $= "MultiBurningPineConeLauncherWeapon")
{
$game::player.MultiBurningPineConeAmmo += %this.amount;
}

if(%this.Type $= "MultiFrozenPineConeLauncherWeapon")
{
$game::player.MultiFrozenPineConeAmmo += %this.amount;
}

if(%this.Type $= "MultiPoisonedPineConeLauncherWeapon")
{
$game::player.MultiPoisonedPineConeAmmo += %this.amount;
}


playSound(%this.Type @ "PickupSound");

%thingy = new t2dStaticSprite()
{
        SceneGraph    = Scenewindow2D.getSceneGraph();
        Class         = "PineImpactEffect";
        ImageMap      = %this.Owner.ImageMap;
        Layer         = %this.Owner.Layer - 1;
        Position      = %this.Owner.Position;
        Rotation      = %this.Owner.Rotation;
        AutoRotation  = $PencilAutoRotation[getRandom(0,1)];
        Lifetime = 2.0;
        ConstantForce = "0 50";
        Size          = %this.Owner.Size;
        _behavior0 = "ScaleBehavior\txWidthMin\t0\tyWidthMin\t0\txWidthMax\t7.5\tyWidthMax\t7.5\tTime\t1\tDelayStart\t0.5";

};

%this.Owner.safeDelete();

}