using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using ExtremelySimpleLogger;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MLEM.Data;
using MLEM.Data.Content;
using MLEM.Textures;
using MLEM.Ui;
using MLEM.Ui.Elements;
using TinyLife;
using TinyLife.Actions;
using TinyLife.Emotions;
using TinyLife.Mods;
using TinyLife.Objects;
using TinyLife.Utilities;
using TinyLife.World;
using Action = TinyLife.Actions.Action;

namespace ReBodMod;

public class ReBodMod : Mod {

    // the logger that we can use to log info about this mod
    public static Logger Logger { get; private set; }
    public static ExampleOptions Options { get; private set; }
};

// visual data about this mod
public override string Name => "ReBodMod";
    public override string Description => "This is a retexture mod for Tiny Life!";
    public override TextureRegion Icon => this.uiTextures[new Point(0, 0)];
    public override string IssueTrackerUrl => "https://github.com/PrinceAllart/ReBodMod/issues";
    public override string TestedVersionRange => "[0.43.0,0.43.8]";

    public override void Initialize(Logger logger, RawContentManager content, RuntimeTexturePacker texturePacker, ModInfo info) {
    ReBodMod.Logger = logger;

    // loads a texture atlas with the given amount of separate texture regions in the x and y axes
    // we submit it to the texture packer to increase rendering performance. The callback is invoked once packing is completed
    // additionally, we pad all texture regions by 1 pixel, so that rounding errors during rendering don't cause visual artifacts
    TextureHandler.OnLoadGameContent += (ref ContentManager originalContent, ref string name, Type _) => {
        if (name == "Textures/Person/Adult/Body")
        {
            originalContent = content; // the one passed to you in Initialize
            name = "ReBodMod/Person/Adult/Body";
        }
    };
