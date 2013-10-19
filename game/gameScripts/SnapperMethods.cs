//-----------------------------------------------------------------------------
// Platformer Starter Kit
// Copyright (C) Phillip O'Shea
//  
// Snapper Methods - All of the methods that makes a Snapper a Snapper.
//-----------------------------------------------------------------------------

function SnapperClass::onAddToScene( %this )
{
    Parent::onAddToScene( %this );
    %this.enableUpdateCallback();
%this.maxMoveSpeed = getRandom(25, 35);

    if ( isObject( SnapperHeadTemplate ) )
    {
        %this.SnapperHead = new t2dSceneObject()
        {
            Config     = SnapperHeadTemplate;
            Scenegraph = %this.Scenegraph;

            FlipX = %this.FlipX;
        };

        %this.SnapperHead.mount( %this );
    }
}

function SnapperClass::onUpdate(%this)
{
%this.getAnimationPuppet.rotation = 0;
%this.linearvelocity.y = 0;
}

function SnapperClass::onRemove( %this )
{
    if ( isObject( %this.SnapperHead ) )
    {
        %this.SnapperHead.safeDelete();
    }
}

function SnapperClass::onRespawn( %this, %dAmount, %srcObject )
{
    %this.DisableGravity = false;
}

function SnapperClass::onDeath( %this, %dAmount, %srcObject )
{
    %this.DisableGravity = true;

    if ( isObject( %this.SnapperHead ) )
    {
        %this.SnapperHead.safeDelete();
    }
}

function SnapperClass::onWallCollision( %this, %wall, %normal )
{
    %this.Direction.X = %normal.X;
}    