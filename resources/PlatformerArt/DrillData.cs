//-----------------------------------------------------------------------------
// Platformer Starter Kit
// Copyright (C) Phillip O'Shea
//-----------------------------------------------------------------------------

//-----------------------------------------------------------------------------
//
// Audio
//
//-----------------------------------------------------------------------------

datablock AudioProfile( DrillDieSound )
{
    filename    = "./data/audio/drill/drill_dies.wav";
    description = "SoundOnce";
    preload     = true;
};

datablock AudioProfile( VertDieSound )
{
    filename    = "./data/audio/drill/drill_dies.wav";
    description = "SoundOnce";
    preload     = true;
};

datablock AudioProfile( VertIdleSound )
{
    //filename    = "./data/audio/vert/vert_motor_loop.wav";
    description = "SoundLoop";
    preload     = true;
};

datablock AudioProfile( PowAlertSound )
{
    filename    = "./data/audio/vert/PowAlert.wav";
    description = "SoundOnce";
    preload     = true;
};

//datablock AudioProfile( DrillIdleSound )
//{
//Keep the function intact so the console will shut up. 

    //filename    = "./data/audio/drill/drill_motor_loop.wav";
    //description = "SoundLoop";
    //preload     = true;
//};

//-----------------------------------------------------------------------------
//
// Graphics
//
//-----------------------------------------------------------------------------


new t2dImageMapDatablock( DrillFallImageMap )
{
    imageName = "./data/images/Drill/Drill_Fall.png";
    imageMode = "CELL";
    frameCount = "-1";
    filterMode = "SMOOTH";
    filterPad = "1";
    preferPerf = "1";
    cellRowOrder = "1";
    cellOffsetX = "0";
    cellOffsetY = "0";
    cellStrideX = "0";
    cellStrideY = "0";
    cellCountX = "1";
    cellCountY = "1";
    cellWidth = "280";
    cellHeight = "280";
    preload = "1";
    allowUnload = "0";
};

new t2dImageMapDatablock( BoolImageMap )
{
    imageName = "./data/images/Bool/Bool.png";
    imageMode = "CELL";
    frameCount = "-1";
    filterMode = "SMOOTH";
    filterPad = "1";
    preferPerf = "1";
    cellRowOrder = "1";
    cellOffsetX = "0";
    cellOffsetY = "0";
    cellStrideX = "0";
    cellStrideY = "0";
    cellCountX = "1";
    cellCountY = "1";
    cellWidth = "500";
    cellHeight = "500";
    preload = "1";
    allowUnload = "0";
};

new t2dImageMapDatablock( BoolImageMap )
{
    imageName = "./data/images/Bool/Bool.png";
    imageMode = "CELL";
    frameCount = "-1";
    filterMode = "SMOOTH";
    filterPad = "1";
    preferPerf = "1";
    cellRowOrder = "1";
    cellOffsetX = "0";
    cellOffsetY = "0";
    cellStrideX = "0";
    cellStrideY = "0";
    cellCountX = "1";
    cellCountY = "1";
    cellWidth = "500";
    cellHeight = "500";
    preload = "1";
    allowUnload = "0";
};

new t2dAnimationDatablock( BoolFallAnimation )
{
    imageMap = "BoolImageMap";
    animationFrames = "0";
    animationTime = "0.4";
    animationCycle = "1";
    randomStart = "0";
    startFrame = "0";
};

new t2dAnimationDatablock( DrillFallAnimation )
{
    imageMap = "DrillRollImageMap";
    animationFrames = "0 1 2 4 5";
    animationTime = "0.4";
    animationCycle = "1";
    randomStart = "0";
    startFrame = "0";
};

new t2dImageMapDatablock( DrillFall_to_IdleImageMap )
{
    imageName = "./data/images/Drill/Drill_Fall_to_roll.png";
    imageMode = "CELL";
    frameCount = "-1";
    filterMode = "SMOOTH";
    filterPad = "1";
    preferPerf = "1";
    cellRowOrder = "1";
    cellOffsetX = "0";
    cellOffsetY = "0";
    cellStrideX = "0";
    cellStrideY = "0";
    cellCountX = "-1";
    cellCountY = "-1";
    cellWidth = "170";
    cellHeight = "128";
    preload = "1";
    allowUnload = "0";
};

new t2dAnimationDatablock( DrillFall_to_IdleAnimation )
{
    imageMap = "DrillFall_to_IdleImageMap";
    animationFrames = "0 1 2 3";
    animationTime = "0.333333";
    animationCycle = "0";
    randomStart = "0";
    startFrame = "0";
};

new t2dImageMapDatablock( DrillRollImageMap )
{
    imageName = "./data/images/Drill/Drill_roll.png";
    imageMode = "CELL";
    frameCount = "-1";
    filterMode = "SMOOTH";
    filterPad = "1";
    preferPerf = "1";
    cellRowOrder = "1";
    cellOffsetX = "0";
    cellOffsetY = "0";
    cellStrideX = "0";
    cellStrideY = "0";
    cellCountX = "3";
    cellCountY = "3";
    cellWidth = "500";
    cellHeight = "500";
    preload = "1";
    allowUnload = "0";
};

new t2dAnimationDatablock( DrillIdleAnimation ) {
    imageMap = "DrillRollImageMap";
    animationFrames = "0 1 2 4 5";
    animationTime = "0.4";
    animationCycle = "1";
    randomStart = "0";
    startFrame = "0";
};