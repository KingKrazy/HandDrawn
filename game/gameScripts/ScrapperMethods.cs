//-----------------------------------------------------------------------------
// Platformer Starter Kit
// Copyright (C) Phillip O'Shea
//  
// Scrapper Methods - All of the methods that makes a Scrapper a Scrapper.
//-----------------------------------------------------------------------------
function ScrapperClass::onAddToScene( %this )
{
    Parent::onAddToScene( %this );
   // %this.getanimationPuppet().ForwardOnly = 1;
   // %this.forwardOnly = 1;
%this.maxMoveSpeed = getRandom(25, 35);
//It's assumed that scrapper is in the water.
%this.inWater = 1;
%this.enableUpdateCallback();
    if ( isObject( ScrapperHeadTemplate ) )
    {
        %this.ScrapperHead = new t2dSceneObject()
        {
            Config     = ScrapperHeadTemplate;
            Scenegraph = %this.Scenegraph;

            FlipX = %this.FlipX;
        };

        %this.ScrapperHead.mount( %this );
    }
}

function ScrapperClass::onUpdate(%this)
{
%this.getAnimationPuppet().setRotation(0);
%this.getAnimationPuppet().flipY = 0;
if(checkDistance($game::player, %this) <= 50 && %this.inWater)
{
echo("DIE, HUMAN!");
%this.FacePlayer();
}
else if(!%this.inWater)
{
%this.takeDamage(1000, %this, true, true);
}
else if(!checkDistance($game::player, %this) <= 50 && %this.Swimming)
{
%this.linearvelocity.y = 0;
}
}

function ScrapperClass::facePlayer(%this)
{
    %this.direction.X = 1;
   %this.vector = t2dVectorSub(%this.position, $game::player.position);
   %targetRotation = mRadToDeg(mAtan(%this.vector.y, %this.vector.x)) + 180 + 0;
    %this.calculateVelocity();
      %this.setRotation(%targetRotation);
      %this.getanimationPuppet().setRotation(%targetRotation);

if(%this.getAnimationPuppet().rotation <= 270 || %this.getAnimationPuppet().rotation >= 90)
{
%this.getAnimationPuppet().flipY = 1;
}

}

function ScrapperClass::calculateVelocity(%this)
{
   %this.linearVelocity.y = -1 * %this.vector.y * 2;
   %this.linearVelocity.x = -1 * %this.vector.x * 2;
}

function ScrapperClass::onRemove( %this )
{
echo("SCRAPPER BE DEAD, YO");

    if ( isObject( %this.ScrapperHead ) )
    {
        %this.ScrapperHead.safeDelete();
    }
}

function ScrapperClass::onRespawn( %this, %dAmount, %srcObject )
{
    %this.DisableGravity = false;
}

function ScrapperClass::onDeath( %this, %dAmount, %srcObject )
{
    %this.DisableGravity = true;

    if ( isObject( %this.ScrapperHead ) )
    {
        %this.ScrapperHead.safeDelete();
    }
}

function ScrapperClass::onWallCollision( %this, %wall, %normal )
{
    %this.Direction.X = %normal.X;
}    