function MountClass::onAddToScene( %this )
{
%this.isMount = 1;
%this.BlobAmmo = 10;
%this.ActiveWeapon = "BlobLauncherWeapon";
echo(%this.activeWeapon);
%this.schedule(900, "manualUpdate");

    %this.Sub = 1;

    if ( isObject( DrillHeadTemplate ) )
    {
        %this.DrillHead = new t2dSceneObject()
        {
            config     = DrillHeadTemplate;
            scenegraph = %scenegraph; //%this.scenegraph would probably work here as well

            FlipX = %this.FlipX;
        };
        %this.DrillHead.addToScene(%scenegraph);
        %this.DrillHead.mount( %this );
    }
%this.maxMoveSpeed = getRandom(12.5, 17.5);

}

function MountClass::onRemove( %this )
{

}

function MountClass::onRespawn( %this, %dAmount, %srcObject )
{
    %this.DisableGravity = false;
}

function MountClass::onLanded( %this, %platformObject )
{

}

function MountClass::onDeath( %this, %dAmount, %srcObject )
{

if(%this.onGround)
{
%this.linearvelocity.Y = "0";
%this.ConstantForce.Y = "0";
%this.gravity = "0 0";
}

playSound(drilldiesound);

cancel($ComboEvent);
$PointsEarned += 100;


    if ( isObject( %this.DrillHead ) )
    {
        %this.DrillHead.safeDelete();
    }


if($pointsEarned >= 100)
{
%Color = "0 0 1 1";
}

if($pointsEarned >= 500)
{
%Color = "0 1 1 1";
}

if($pointsEarned >= 1000)
{
%Color = "0 1 0 1";
}

if($pointsEarned >= 2000)
{
%Color = "1 1 0 1";
}

if($pointsEarned >= 5000)
{
%Color = "1 0 0 1";
}

if($pointsEarned >= 10000)
{
%Color = "0 0 0 1";
$pointsEarned = 10000;
}

    %TextSprite = new t2dTextObject()
    {
        SceneGraph    = Scenewindow2D.getSceneGraph();
      canSaveDynamicFields = "1";
      Position = %This.Position;
      size = "14.758 4.920";
      text = $PointsEarned;
      font = "OCR A Std";
      wordWrap = "1";
      hideOverflow = "1";
      textAlign = "Left";
      lineHeight = "4.91946";
      aspectRatio = "1.15903";
      lineSpacing = "0";
      characterSpacing = "0";
      autoSize = "0";
      fontSizes = "42";
      BlendColor = %Color;
      bilinearFilter = "1";
      snapToInteger = "0";
      noUnicode = "0";
         hideOverlap = "0";
         mountID = "794";
         snapToIntegerPos = "0";
      _behavior0 = "ScaleBehavior	xWidthMin	0.001	yWidthMin	0.001	xWidthMax	15	yWidthMax	5	DeleteObject	1";
      ConstantForce = "0 -50";

    };

$pref::points += $PointsEarned;

$ComboEvent = schedule(1500, 0, "ResetComboMeter");

%thingy = new t2dAnimatedSprite()
{
        SceneGraph    = Scenewindow2D.getSceneGraph();
        Animation     = "DrillDieAnimation";
        Class         = "CoolStuff";
        Animation      = %this.Animation;
        Layer         = %this.Layer - 1;
        Position      = %this.Position;
        Rotation      = %this.Rotation;
        AutoRotation  = $PencilAutoRotation[getRandom(0,1)];
        Lifetime = 2.0;
        ConstantForce = "0 50";
        Size          = %this.Size;
        _behavior0 = "ScaleBehavior\txWidthMin\t0\tyWidthMin\t0\txWidthMax\t7.5\tyWidthMax\t7.5\tTime\t1\tDelayStart\t0.5";

};


EnemyHealthBar.setValue(0);
%puppet = %this.getAnimationPuppet();
CurrentEnemy.setSceneObject(%nothing);

    %this.DisableGravity = true;


}

function MountClass::onWallCollision( %this, %wall, %normal )
{
    %this.Direction.X = %normal.X;
}

function mountClass::ManualUpdate(%this)
{
if(%this.getAnimationPuppet().getAnimationFrame == 0 && %this.getAnimationState() $= "run")
{
    %this.BlobAmmo += 1;
    %this.OnAttack( 0, true );
    echo("DAI!");
    %this.OnAttack( 0, false );
}
%this.schedule(750, "manualUpdate");
}