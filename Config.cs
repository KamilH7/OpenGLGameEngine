using System.Drawing;
using System.Numerics;

static class Config
{
    public static readonly string VertexShaderPath = @"/Shaders/VertexShader.shader";
    public static readonly string FragmentShaderPath = @"/Shaders/FragmentShader.shader";

    public static readonly string GameTitle = "BoxNinja";
    public static readonly Vector2 WindowDimensions = new Vector2(1920, 1080);
    public static readonly Color BackgroundColor = Color.FromArgb(255, 158, 24, 125);
}

