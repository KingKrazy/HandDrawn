//-----------------------------------------------------------------------------
// Platformer Starter Kit
// Copyright (C) - Phillip O'Shea
//-----------------------------------------------------------------------------

datablock t2dSceneObjectDatablock( PlayerActorBaseTemplate )
{
    SuperClass        = "PlayerClass";
    Layer             = "1";
    
    _Behavior0        = "ControllerBehavior";
};

//-----------------------------------------------------------------------------

datablock t2dSceneObjectDatablock( BoomBotActorTemplate : PlayerActorBaseTemplate )
{
    Class             = "BoomBotClass";
    ActorType         = "BoomBot";
    
    Size              = "200 200";
    MaxMoveSpeed      = "60";
    CollisionPolyList = "-0.300 -0.500 0.300 -0.500 0.400 0.250 0.000 0.770 -0.300 0.400";

    Gravity           = "0 150";
    UpdateDirection   = "0";

    AnimationData     = "BoomBotActorAnimationData";
    _Behavior0        = "ControllerBehavior";
};

datablock SimDataBlock( BoomBotActorAnimationData )
{
    // t2dShape3D properties
    Shape                 = "game/data/shapes/players/BoomBot/BoomBot.dts";
    ShapeRotation         = "0.0 0.0 4.71239";
    ShapeScale            = "0.4 0.4 0.4";

    ShapeRotationRight    = "0.0 0.0 4.71239";
    ShapeRotationLeft     = "0.0 0.0 1.57080";

    IdleAnimation         = "root";
    RunBackwardsAnimation = "back";
};

//-----------------------------------------------------------------------------

datablock t2dSceneObjectDatablock( DragonActorTemplate : PlayerActorBaseTemplate )
{
    Class             = "DragonPlayer";
    Layer             = 1;
    Lives             = "5";
    ActorType         = "Dragon";
    MaxMoveSpeed      = 80;    
    JumpForce         = 100;
    Size              = "22.000 22.000";
    CollisionPolyList = "-0.108 0.000 -0.100 -0.350 0.100 -0.350 0.100 0.000 0.000 0.340";
};

datablock t2dSceneObjectDatablock( CavemanActorTemplate : PlayerActorBaseTemplate )
{
    Class             = "CavemanPlayer";
    ActorType         = "Caveman";
    Lives             = "5";
    Size              = "16.000 16.000";
    CollisionPolyList = "-0.108 0.000 -0.100 -0.350 0.100 -0.350 0.100 0.000 0.000 0.340";
    Layer             = "1";
    _Behavior0        = "ControllerBehavior";
    MaxMoveSpeed      = 80;

    AllowRespawn      = true;
};

//-----------------------------------------------------------------------------

datablock t2dSceneObjectDatablock( SubActorTemplate )
{
    Class             = "SubClass";
    ActorType         = "Sub";
    
    Size              = "26.000 26.000";
    Layer             = "2";
      CollisionPolyList = "-0.751 -0.462 0.373 -0.457 0.422 -0.142 -0.182 0.152 -0.761 -0.172";
    _Behavior0        = "AIControllerBehavior\tAIType\tDrill";
    GroundAccel       = 1000;
    GroundDecel       = 1000;
    
    AllowRespawn      = false;
    DeathTimeOut      = 500;
};

datablock t2dSceneObjectDatablock( SnakeActorTemplate )
{
    Class             = "SnakeClass";
    ActorType         = "Snake";
    
    Size              = "26.000 26.000";
    Layer             = "2";
      CollisionPolyList = "-0.751 -0.462 0.373 -0.457 0.422 -0.142 -0.182 0.152 -0.761 -0.172";
    _Behavior0        = "AIControllerBehavior\tAIType\tDrill";
    SoundData         = "VertSoundData";
    GroundAccel       = 1000;
    GroundDecel       = 1000;
    
    AllowRespawn      = false;
    DeathTimeOut      = 1000;
};

datablock t2dSceneObjectDatablock( BoolActorTemplate )
{
    Class             = "BoolClass";
    ActorType         = "Bool";
    angularVelocity   = "540";
    Size              = "26.000 26.000";
    Layer             = "2";
    //CollisionDetectionMode = "CIRCLE";
      CollisionPolyList = "-0.447 0.329 0.250 0.314 0.324 0.555 0.231 1.000 -0.432 1.000";
    _Behavior0        = "AIControllerBehavior\tAIType\tDrill";
    MaxMoveSpeed      = 16;
    GroundAccel       = 1000;
    GroundDecel       = 1000;
    JumpForce         = 70;
    AllowRespawn      = false;
    DeathTimeOut      = 500;
};

datablock t2dSceneObjectDatablock( DrillActorTemplate )
{
    Class             = "DrillClass";
    Size              = "24.000 24.000";
    Layer             = "2";
      CollisionPolyList = "-0.751 -0.462 0.373 -0.457 0.422 -0.142 -0.182 0.152 -0.761 -0.172";




    ActorType         = "Drill";
    _Behavior0        = "AIControllerBehavior\tAIType\tDrill";
    
    AnimationData     = "DrillAnimationData";
    SoundData         = "DrillSoundData";
    
    GroundAccel       = 1000;
    GroundDecel       = 1000;
    
    AllowRespawn      = false;
    DeathTimeOut      = 500;
    
    InnerRadius       = 20;
    OuterRadius       = 80;
};

datablock t2dSceneObjectDatablock( SnapperActorTemplate )
{
    Class             = "SnapperClass";
    ActorType         = "Snapper";
    
    Size              = "26.000 26.000";
    Layer             = "2";
      CollisionPolyList = "-0.751 -0.462 0.373 -0.457 0.422 -0.142 -0.182 0.152 -0.761 -0.172";
    _Behavior0        = "AIControllerBehavior\tAIType\tDrill";
    SoundData         = "VertSoundData";
    AirAccel       = 1000;
    AirDecel       = 1000;
    
    AllowRespawn      = false;
    DeathTimeOut      = 500;
    Gravity = "0 0";
};

datablock t2dSceneObjectDatablock( ScrapperActorTemplate )
{
    Class             = "ScrapperClass";
    ActorType         = "Scrapper";
    
    Size              = "26.000 26.000";
    Layer             = "2";
      CollisionPolyList = "-0.751 -0.462 0.373 -0.457 0.422 -0.142 -0.182 0.152 -0.761 -0.172";
    _Behavior0        = "AIControllerBehavior\tAIType\tDrill";
    SoundData         = "VertSoundData";
    AirAccel       = 1000;
    AirDecel       = 1000;
    
    AllowRespawn      = false;
    DeathTimeOut      = 500;
    Gravity = "0 0";
};


datablock SimDataBlock( DrillAnimationData )
{
    RunAnimation      = "DrillIdleAnimation";
};

datablock SimDataBlock( DrillSoundData )
{
    RunSound          = "DrillIdleSound";
};

datablock SimDataBlock( VertSoundData )
{
    RunSound          = "VertIdleSound";
};


datablock t2dSceneObjectDatablock( PepperTemplate )
{
    AnimationName     = "yummy_pepperAnimation";
    Size              = "5.000 5.000";
    Layer             = "1";
    CollisionPolyList = "0.889 -0.879 0.712 -0.437 -0.678 0.904 -0.948 0.643 0.442 -0.702";
    _Behavior0        = "PickupBehavior";
    _Behavior1        = "PepperPickupBehavior";
};

//-----------------------------------------------------------------------------

new GuiControlProfile( CrossHairProfile )
{
    Opaque = "0";
    Border = "0";
    Modal  = "0";
};