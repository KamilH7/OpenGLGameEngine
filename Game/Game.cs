using Geometry;
using System;
using static OpenGL.GL;

static class Game
{
    private static VAO triangleVAO;
    private static VAO squareVAO;

    public static void Start()
    {
        TimerController.AddTimer(1, SetRandomColor);
        triangleVAO = GenerateTriangleVAO();
        squareVAO = GenerateSquareVAO();
        SetBackgroundColor();
        SetRandomColor();
    }

    static Shape Square;

    private static VAO GenerateSquareVAO()
    {
        var vertices = new[] {
             new Vertex(new float[]{-0.5f, -0.5f, 0.0f }),
             new Vertex(new float[]{0.5f, -0.5f, 0.0f}),
             new Vertex(new float[]{0.5f,  0.5f, 0.0f}),
             new Vertex(new float[]{-0.5f,  0.5f, 0.0f}),
        };

        Square = new Shape(vertices);
        return new VAO(Square);
    }

    private static VAO GenerateTriangleVAO()
    {
        Shape[] triangles = new Shape[2];

        var vertices = new[] {
        new Vertex(new float[]{-0.5f, -0.5f * (float) Math.Sqrt(3) / 3, 0.0f }), // Lower left corner
		new Vertex(new float[]{0.5f, -0.5f * (float) Math.Sqrt(3) / 3, 0.0f }), // Lower right corner
		new Vertex(new float[]{-1.0f, 0.5f * (float) Math.Sqrt(3) * 2 / 3, 0.0f }) // Upper corner
	    };

        triangles[0] = new Shape(vertices);

        var vertices2 = new[]{
        new Vertex(new float[]{-0.5f, -0.5f, 0.0f }), // Lower left corner
		new Vertex(new float[]{0.5f, -0.5f, 0.0f }), // Lower right corner
		new Vertex(new float[]{1.0f, 0.5f, 0.0f }) // Upper corner
	    };

        triangles[1] = new Shape(vertices2);

        return new VAO(triangles);
    }

    public static void Update()
    {
        triangleVAO.Draw();
        squareVAO.Draw();
        Square.Move((float)(-0.2 * DeltaTime.Time), (float)(0.2 * DeltaTime.Time), 0);

    }

    private static Random rand = new Random();

    private static void SetRandomColor()
    {
        var r = (float)rand.NextDouble();
        var g = (float)rand.NextDouble();
        var b = (float)rand.NextDouble();

        glUniform3f(glGetUniformLocation(MainProgram.Program, "color"), r, g, b);
    }

    static void SetBackgroundColor()
    {
        float r = (float)Config.BackgroundColor.R / 255;
        float g = (float)Config.BackgroundColor.G / 255;
        float b = (float)Config.BackgroundColor.B / 255;
        float a = (float)Config.BackgroundColor.A / 255;

        glClearColor(r, g, b, a);
    }

}

