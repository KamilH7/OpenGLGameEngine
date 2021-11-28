using GLFW;
using System;
using System.Text;
using System.IO;
using static OpenGL.GL;

class MainProgram
{
    private static uint program;
    public static uint Program => program;

    private static Window window;
    public static Window Window => window;

    private static DateTime previousGameTime;

    static void Main(string[] sargs)
    {
        Initialize();
        Game.Start();

        previousGameTime = DateTime.Now;

        while (Running())
        {
            SetDeltaTime();
            UpdateOpenGL();
            TimerController.Update();
            Game.Update();
        }

        Glfw.Terminate();
    }

    private static void UpdateOpenGL()
    {
        Glfw.SwapBuffers(Window);
        Glfw.PollEvents();
        glClear(GL_COLOR_BUFFER_BIT);
    }

    private static void SetDeltaTime()
    {
        TimeSpan difference = DateTime.Now - previousGameTime;
        previousGameTime = previousGameTime + difference;
        DeltaTime.SetDeltaTime(difference.TotalSeconds);
    }

    private static bool Running()
    {
        return !Glfw.WindowShouldClose(Window);
    }

    private static void Initialize()
    {
        SetupHints();
        window = CreateWindow();
        program = CreateProgram();
    }

    private static void SetupHints()
    {
        Glfw.WindowHint(Hint.ClientApi, ClientApi.OpenGL);
        Glfw.WindowHint(Hint.ContextVersionMajor, 3);
        Glfw.WindowHint(Hint.ContextVersionMinor, 3);
        Glfw.WindowHint(Hint.OpenglProfile, Profile.Core);
        Glfw.WindowHint(Hint.Doublebuffer, true);
        Glfw.WindowHint(Hint.Decorated, true);
    }

    private static Window CreateWindow()
    {
        var width = (int)Config.WindowDimensions.X;
        var height = (int)Config.WindowDimensions.Y;
        var window = Glfw.CreateWindow(width, height, Config.GameTitle, Monitor.None, Window.None);
        var screen = Glfw.PrimaryMonitor.WorkArea;
        var x = (screen.Width - width) / 2;
        var y = (screen.Height - height) / 2;

        Glfw.SetWindowPosition(window, x, y);
        Glfw.MakeContextCurrent(window);
        Import(Glfw.GetProcAddress);

        return window;
    }

    private static uint CreateProgram()
    {
        var vertexShader = CreateShader(GL_VERTEX_SHADER, GetVertexShader());
        var fragmentShader = CreateShader(GL_FRAGMENT_SHADER, GetFragmentShader());

        var program = glCreateProgram();

        glAttachShader(program, vertexShader);
        glAttachShader(program, fragmentShader);

        glLinkProgram(program);

        glDeleteShader(vertexShader);
        glDeleteShader(fragmentShader);

        glUseProgram(program);
        return program;
    }

    private static string GetFragmentShader()
    {
        return ReadFile(Config.FragmentShaderPath);
    }

    private static string GetVertexShader()
    {
        return ReadFile(Config.VertexShaderPath);
    }

    private static string ReadFile(string path)
    {
        try
        {  
            return File.ReadAllText(GetFullPath(path));
        }
        catch(FileNotFoundException e)
        {
            Console.WriteLine(e);
            return "";
        }
    }

    private static string GetFullPath(string subPath)
    {
        string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
        path += subPath;
        return path;
    }

    private static uint CreateShader(int type, string source)
    {
        var shader = glCreateShader(type);
        glShaderSource(shader, source);
        glCompileShader(shader);
        return shader;
    }
}