//-----------------------------------------------------------------------------
// Platformer Starter Kit
// Copyright (C) Phillip O'Shea
//  
// Pepper Pickup - This provides health to Players! (Must be added to a pick-
//                 up object)
//-----------------------------------------------------------------------------
$BingNumber = $bing[$bingNum];

if ( !isObject( PepperPickupBehavior ) )
{
    %template = new BehaviorTemplate( PepperPickupBehavior );

    %template.friendlyName = "Pepper Pick-up";
    %template.behaviorType = "Collectable";
    %template.description  = "This pepper restores health";

    %template.addBehaviorField( HealAmount, "Amount of health restored", INT, 10 );
}

function PepperPickupBehavior::onAddToScene( %this, %scenegraph )
{
    %this.Owner.Size              = "10 10";
    %this.Owner.Layer             = "1";
    %this.Owner.CollisionPolyList = "0.889 -0.879 0.712 -0.437 -0.678 0.904 -0.948 0.643 0.442 -0.702";

    if ( %this.Owner.isMemberOfClass( t2dAnimatedSprite ) )
    {    
        %animation  = %this.Owner.AnimationName;
        %frameCount = getWordCount( %animation.AnimationFrames );

        %this.Owner.setAnimationFrame( getRandom( 0, ( %frameCount - 1 ) ) );
        %this.Owner.Size = "10 10";
    }

$PencilC[1] = "1 0 0 1";
$PencilC[2] = "0 1 0 1";
$PencilC[3] = "0 0 1 1";
$PencilC[4] = "1 1 0 1";
$PencilC[5] = "0.5 0 1 1";
$PencilC[6] = "1 0.5 0 1";

%this.Owner.blendColor = $PencilC[getRandom(1, 6)];
}

$pencilAutoRotation[0] = 800;
$pencilAutoRotation[1] = -800;

function PepperPickupBehavior::confirmPickup( %this, %targetObject, %inventoryItem )
{
$pref::points = $pref::points + 5;

    if ( %targetObject.isMethod( "healDamage" ) )
    {
        %targetObject.healDamage( 10 );
    }

$Bing[1] = "Bing1";
$Bing[2] = "Bing2";
$Bing[3] = "Bing3";
$Bing[4] = "Bing4";
$Bing[5] = "Bing5";
$Bing[6] = "Bing6";
$Bing[7] = "Bing7";

%BingSound[1] = $Bing[getRandom(1,7)];
%BingSound[2] = $Bing[getRandom(1,7)];
%FinBingSound = %bingSound[getRandom(1,2)];

        %targetObject.playSound( %FinBingSound );


    %impactSprite = new t2dStaticSprite()
    {
        SceneGraph    = Scenewindow2D.getSceneGraph();
        Class         = "PencilImpactEffect";
        ImageMap      = "PencilImageMap";
        Layer         = "0";
        Position      = %this.Owner.Position;
        Rotation      = %this.Owner.Rotation;
        AutoRotation  = $PencilAutoRotation[getRandom(0,1)];
        Lifetime = 2.0;
        ConstantForce = "0 50";
        Size          = "10 10";
        BlendColor = %this.Owner.blendColor;
        _behavior0 = "ScaleBehavior\txWidthMin\t0\tyWidthMin\t0\txWidthMax\t7.5\tyWidthMax\t7.5\tTime\t1\tDelayStart\t0.5";
    };

  %aura = new t2dParticleEffect()
  {
      scenegraph = sceneWindow2D.getSceneGraph();
      layer      = "0";
      effectFile = "~/data/particles/YelloEmitter.eff";
      useEffectCollisions = "1";
      class = "PencilImpactParticles";
      effectMode = "kill";
      effectTime = "0.2";
      canSaveDynamicFields = "1";
      Position = %this.Owner.Position;
      size = "30.400 30.293";
      SortPoint = "-0.037 -0.295";
      CollisionMaxIterations = "1";
      BlendColor = %this.Owner.blendColor;
  
  };
    %aura.playEffect(true);
  %aura.isPlaying = true;

    %TextSprite = new t2dTextObject()
    {
        SceneGraph    = Scenewindow2D.getSceneGraph();
      canSaveDynamicFields = "1";
      Position = %TargetObject.Position;
      size = "14.758 4.920";
      layer = %impactSprite.layer;
      text = "+5";
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
      textColor = "0 1 0 1";
      bilinearFilter = "1";
      snapToInteger = "0";
      noUnicode = "0";
         hideOverlap = "0";
         mountID = "794";
         snapToIntegerPos = "0";
      _behavior0 = "ScaleBehavior	xWidthMin	0.001	yWidthMin	0.001	xWidthMax	15	yWidthMax	5	DeleteObject	1";
         ConstantForce = "0 -50";

    };


    return true;
}